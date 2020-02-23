using MMEdit.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace MMEdit
{
    internal class Host : IHost, IDisposable
    {
        #region Fields
        private List<IPlugin> PluginList = new List<IPlugin>();
        private List<IWidget> WidgetList = new List<IWidget>();
        #endregion

        #region Constructor
        public Host(IMainForm mainForm)
        {
            MainForm = mainForm;
            ImportPlugins = new List<IImportPlugin>();
            ExportPlugins = new List<IExportPlugin>();

            try
            {
                Histories = Util.Deserialize<List<HistoryItem>>(HistoryItem.HistoryCachePath);
            }
            catch (Exception)
            {
                Histories = new List<HistoryItem>();
            }
        }
        #endregion

        #region Properties
        public IList<IPlugin> Plugins => PluginList;

        public IList<IWidget> Widgets => WidgetList;

        public List<IImportPlugin> ImportPlugins { get; }

        public List<IExportPlugin> ExportPlugins { get; }

        public IMainForm MainForm { get; }

        public List<HistoryItem> Histories { get; }
        #endregion

        #region Events
        public event EventHandler<PluginEventArgs> PluginLoaded;
        protected virtual void OnPluginLoaded(PluginEventArgs e)
        {
            PluginLoaded?.Invoke(this, e);
        }

        public event EventHandler<PluginEventArgs> PluginUnLoading;
        protected virtual void OnPluginUnLoading(PluginEventArgs e)
        {
            PluginUnLoading?.Invoke(this, e);
        }

        public event EventHandler<FileStatusEventArgs> FileStatusChanged;
        public virtual void OnFileStatusChanged(FileStatusEventArgs e)
        {
            FileStatusChanged?.Invoke(this, e);
        }
        #endregion

        #region Methods
        public IPlugin GetPlugin(Guid guid)
        {
            return PluginList.Find(plugin => plugin.Guid == guid);
        }

        public IPlugin GetPlugin(string guid)
        {
            return GetPlugin(new Guid(guid));
        }

        public T GetPlugin<T>(Guid guid) where T : IPlugin
        {
            return (T)PluginList.Find(plugin => plugin.Guid == guid);
        }

        public T GetPlugin<T>(string guid) where T : IPlugin
        {
            return GetPlugin<T>(new Guid(guid));
        }

        public IPlugin GetPlugin(int index)
        {
            return PluginList[index];
        }

        public string GetPluginDataPath(IPlugin plugin)
        {
            return Path.Combine(Application.UserAppDataPath, $@"Data\{plugin.GetType().FullName}");
        }

        public void LoadPlugin(string path)
        {
            Assembly assembly = Assembly.LoadFrom(path);

            foreach (Type type in assembly.GetTypes())
            {
                if (type.IsPublic && type.IsClass && !type.IsAbstract && type.GetInterface(typeof(IPlugin).FullName) != null)
                {
                    try
                    {
                        IPlugin plugin;
                        try
                        {
                            plugin = (IPlugin)assembly.CreateInstance(type.FullName);
                        }
                        catch (Exception e)
                        {
                            throw new PluginLoadException(string.Format(Resources.Msg_PluginInstantiationException, type.FullName), e);
                        }

                        if (GetPlugin(plugin.Guid) != null)
                        {
                            plugin.Dispose();
                            throw new PluginLoadException(string.Format(Resources.Msg_PluginRegistrationException_DuplicateGuid, type.FullName, plugin.Guid));
                        }

                        PluginList.Add(plugin);

                        if (plugin is IImportPlugin)
                        {
                            ImportPlugins.Add(plugin as IImportPlugin);
                        }
                        if (plugin is IExportPlugin)
                        {
                            ExportPlugins.Add(plugin as IExportPlugin);
                        }
                        if (plugin is IWidgetProvider provider)
                        {
                            foreach (var widget in provider.GetWidgets())
                            {
                                RegisterWidget(widget);
                            }
                        }
                        if (plugin is IHostConncet hc)
                        {
                            try
                            {
                                hc.Host = this;
                            }
                            catch (Exception e)
                            {
                                throw new PluginLoadException(string.Format(Resources.Msg_PluginHostConnectionException, type.FullName), e);
                            }
                        }

                        OnPluginLoaded(new PluginEventArgs(plugin));
                    }
                    catch (PluginLoadException pluginloadException)
                    {
                        string message = pluginloadException.InnerException?.Message;

                        if (pluginloadException.InnerException is ReflectionTypeLoadException reflectionTypeLoadException)
                        {
                            message = null;
                            foreach (Exception loaderException in reflectionTypeLoadException.LoaderExceptions)
                            {
                                message += loaderException.Message + Environment.NewLine;
                            }
                        }
                        else if (pluginloadException.InnerException is TargetInvocationException targetInvocationException)
                        {
                            message = targetInvocationException.InnerException.Message;
                        }

                        MessageBox.Show($"{pluginloadException.Message}{(!string.IsNullOrEmpty(message) ? Environment.NewLine + Environment.NewLine : "")}{message}", Resources.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    catch (Exception e) when (!(e is PluginLoadException))
                    {
                        MessageBox.Show($"{e.Message}\r\n\r\n{e.StackTrace}", Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public void LoadPlugins()
        {
            string pluginPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Plugins");

            if (Directory.Exists(pluginPath))
            {
                string[] files = Directory.GetFiles(pluginPath, "*.dll", SearchOption.TopDirectoryOnly);

                foreach (string file in files)
                {
                    LoadPlugin(file);
                }
            }
        }

        public IWidgetControl CreateWidget(string widgetID, ObjectFX obj)
        {
            return WidgetList.Find(w => w.WidgetID == widgetID)?.CreateWidget(obj);
        }

        public T CreateWidget<T>(string widgetID, ObjectFX obj) where T : Control
        {
            return WidgetList.Find(w => w.WidgetID == widgetID)?.CreateWidget(obj) as T;
        }

        public void RegisterWidget(IWidget widget)
        {
            int index = WidgetList.FindIndex(w => w.WidgetID == widget.WidgetID);

            if (index != -1)
                WidgetList[index] = widget;
            else
                Widgets.Add(widget);
        }

        public void RegisterWidget(string widgetID, Func<ObjectFX, IWidgetControl> createFunc)
        {
            RegisterWidget(new WidgetClass(widgetID, createFunc));
        }

        public bool UnLoadPlugin(IPlugin plugin)
        {
            OnPluginUnLoading(new PluginEventArgs(plugin));

            ImportPlugins.Remove(ImportPlugins.Find(p => p.Guid == plugin.Guid));
            ExportPlugins.Remove(ExportPlugins.Find(p => p.Guid == plugin.Guid));

            if (plugin is IWidgetProvider provider)
            {
                foreach (var widget in provider.GetWidgets())
                {
                    UnregisterWidget(widget.WidgetID);
                }
            }

            if (PluginList.Remove(plugin))
            {
                plugin.Dispose();
                return true;
            }
            return false;
        }

        public bool UnregisterWidget(string widgetID)
        {
            IWidget widget = WidgetList.Find(w => w.WidgetID == widgetID);
            return WidgetList.Remove(widget);
        }

        /// <summary>
        /// 将 <see cref="HistoryItem"/> 插入到历史项目列表的指定索引处。
        /// </summary>
        /// <param name="item"></param>
        /// <param name="index"></param>
        public void InsertHistoryItem(HistoryItem item, int index = 0)
        {
            Histories.Remove(Histories.Find(h => h.Filename == item.Filename));
            Histories.Insert(index, item);

            if (Histories.Count > Settings.Default.HistoryItemMaxCount)
            {
                Histories.RemoveAt(Histories.Count - 1);
            }
        }

        public void SerializeHistories()
        {
            Util.Serialize(HistoryItem.HistoryCachePath, Histories);
        }

        public void Dispose()
        {
            List<IPlugin> pluginList = new List<IPlugin>(PluginList);

            foreach (IPlugin plugin in pluginList)
            {
                UnLoadPlugin(plugin);
            }
        }
        #endregion
    }
}
