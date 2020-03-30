using MMEdit.Configuration;
using MMEdit.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace MMEdit
{
    internal class Host : ApplicationContext, IHost, IDisposable
    {
        #region Fields
        public readonly bool _SingletonMode;
        #endregion

        #region Constructor
        public Host() : base()
        {
            _SingletonMode = true;
            Plugins = new List<IPlugin>();
            Widgets = new List<IWidget>();
            Settings = new List<ICustomSettings>();
            ImportPlugins = new List<IImportPlugin>();
            ExportPlugins = new List<IExportPlugin>();
            StartPlugins = new List<IStartPlugin>();

            try
            {
                Histories = Util.Deserialize<List<History>>(History.HistoryCachePath);
            }
            catch (Exception)
            {
                Histories = new List<History>();
            }

            try
            {
                ImportConfig = Util.XmlDeserialize<ImportConfig>(ImportConfig.ImageConfigPath);
            }
            catch (Exception)
            {
                ImportConfig = new ImportConfig();
            }

            ThreadExit += (s, e) =>
            {
                Properties.Settings.Default.Save();
                Util.Serialize(History.HistoryCachePath, Histories);
            };
            //RegisterSettings(new PreferencesSettings(this));
            LoadPlugins();
            MainForm = new MainForm(this);
#if DEBUG
            foreach (var item in Plugins)
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Version: {item.Version}");
                Console.WriteLine($"Guid: {item.Guid}");
                Console.WriteLine($"Description: {item.Description}");
                Console.WriteLine($"DataPath:{GetPluginDataPath(item)}");
            }
#endif
        }

        public Host(string[] args) : this()
        {
            if (args != null && args.Length >= 1 && File.Exists(args[0]))
            {
                OpenEdit(args[0]);
            }
        }
        #endregion

        #region Properties
        public List<IPlugin> Plugins { get; }
        public List<IWidget> Widgets { get; }
        public List<ICustomSettings> Settings { get; }
        public List<History> Histories { get; }
        public List<IImportPlugin> ImportPlugins { get; }
        public List<IExportPlugin> ExportPlugins { get; }
        public List<IStartPlugin> StartPlugins { get; }
        public ImportConfig ImportConfig { get; }

        IReadOnlyList<IPlugin> IHost.Plugins => Plugins.AsReadOnly();
        IReadOnlyList<IImportPlugin> IHost.ImportPlugins => ImportPlugins.AsReadOnly();
        IReadOnlyList<IExportPlugin> IHost.ExportPlugins => ExportPlugins.AsReadOnly();
        IReadOnlyList<IStartPlugin> IHost.StartPlugins => StartPlugins.AsReadOnly();
        IReadOnlyList<IWidget> IHost.Widgets => Widgets.AsReadOnly();
        IReadOnlyList<ICustomSettings> IHost.Settings => Settings.AsReadOnly();
        IList<History> IHost.Histories => Histories;
        #endregion

        #region Events
        public event EventHandler<PluginEventArgs> PluginLoaded;
        protected virtual void OnPluginLoaded(PluginEventArgs e)
        {
            PluginLoaded?.Invoke(this, e);
        }
        #endregion

        #region Methods
        public IPlugin GetPlugin(Guid guid)
        {
            return Plugins.Find(plugin => plugin.Guid == guid);
        }

        public IPlugin GetPlugin(string guid)
        {
            return GetPlugin(new Guid(guid));
        }

        public T GetPlugin<T>(Guid guid) where T : IPlugin
        {
            return (T)Plugins.Find(plugin => plugin.Guid == guid);
        }

        public T GetPlugin<T>(string guid) where T : IPlugin
        {
            return GetPlugin<T>(new Guid(guid));
        }

        public string GetPluginDataPath(IPlugin plugin)
        {
            return Path.Combine(Application.UserAppDataPath, $@"Data\{plugin.GetType().FullName}");
        }

        public void LoadPlugin(string path)
        {
            Assembly assembly = Assembly.LoadFrom(path);
            try
            {
                foreach (Type type in assembly.GetTypes())
                {
                    if (type.IsPublic && type.IsClass && !type.IsAbstract && type.GetInterface(typeof(IPlugin).FullName) != null)
                    {

                        IPlugin plugin;
                        try
                        {
                            plugin = (IPlugin)assembly.CreateInstance(type.FullName);
                        }
                        catch (Exception e)
                        {
                            throw new PluginLoadException(string.Format(Properties.Resources.Msg_PluginInstantiationException, type.FullName), e);
                        }

                        if (GetPlugin(plugin.Guid) != null)
                        {
                            plugin.Dispose();
                            throw new PluginLoadException(string.Format(Properties.Resources.Msg_PluginRegistrationException_DuplicateGuid, type.FullName, plugin.Guid));
                        }

                        Plugins.Add(plugin);

                        if (plugin is IImportPlugin importPlugin)
                        {
                            ImportPlugins.Add(importPlugin);
                        }
                        if (plugin is IExportPlugin exportPlugin)
                        {
                            ExportPlugins.Add(exportPlugin);
                        }
                        if (plugin is IStartPlugin startPlugin)
                        {
                            StartPlugins.Add(startPlugin);
                        }
                        if (plugin is IHostConncet hc)
                        {
                            try
                            {
                                hc.Initialize(this);
                            }
                            catch (Exception e)
                            {
                                throw new PluginLoadException(string.Format(Properties.Resources.Msg_PluginHostConnectionException, type.FullName), e);
                            }
                        }

                        OnPluginLoaded(new PluginEventArgs(plugin));
                    }
                }
            }
            catch (PluginLoadException pluginloadException)
            {
                string message = pluginloadException.Message + (string.IsNullOrEmpty(pluginloadException.InnerException?.Message) ? "" : Environment.NewLine + Environment.NewLine) + pluginloadException.InnerException?.Message;
                MessageBox.Show(message, getAssemblyTitle(assembly), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ReflectionTypeLoadException reflectionTypeLoadException)
            {
                string message = reflectionTypeLoadException.Message + Environment.NewLine + Environment.NewLine + "LoaderExceptions:" + Environment.NewLine;

                foreach (Exception loaderException in reflectionTypeLoadException.LoaderExceptions)
                {
                    message += loaderException.Message + Environment.NewLine;
                }
                MessageBox.Show(message, getAssemblyTitle(assembly), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (TargetInvocationException targetInvocationException)
            {
                MessageBox.Show(targetInvocationException.InnerException.Message, getAssemblyTitle(assembly), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception e)
            {
                string message = e.Message + (string.IsNullOrEmpty(e.StackTrace) ? "" : Environment.NewLine + Environment.NewLine) + e.StackTrace;
                MessageBox.Show(message, Properties.Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string getAssemblyTitle(Assembly _assembly)
            {
                object[] attributes = _assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return Path.GetFileNameWithoutExtension(_assembly.CodeBase);
            }
        }

        protected void LoadPlugins()
        {
            string pluginPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Plugins");

            if (Directory.Exists(pluginPath))
            {
                string[] files = Directory.GetFiles(pluginPath, "*.dll", SearchOption.TopDirectoryOnly);

                foreach (string file in files)
                {
                    LoadPlugin(file);
                }
            }
        }


        public IWidgetControl CreateWidget(ObjectFX obj)
        {
            return CreateWidget(obj.WidgetID, obj);
        }

        public T CreateWidget<T>(ObjectFX obj) where T : Control
        {
            return CreateWidget<T>(obj.WidgetID, obj);
        }

        public IWidgetControl CreateWidget(string widgetID, ObjectFX obj)
        {
            return Widgets.Find(w => w.WidgetID == widgetID)?.CreateWidget(obj);
        }

        public T CreateWidget<T>(string widgetID, ObjectFX obj) where T : Control
        {
            return Widgets.Find(w => w.WidgetID == widgetID)?.CreateWidget(obj) as T;
        }

        public void RegisterWidget(IWidget widget)
        {
            int index = Widgets.FindIndex(w => w.WidgetID == widget.WidgetID);

            if (index != -1)
                Widgets[index] = widget;
            else
                Widgets.Add(widget);
        }

        public void RegisterWidgets(IWidget[] widgets)
        {
            foreach (IWidget widget in widgets)
            {
                RegisterWidget(widget);
            }
        }

        public void RegisterWidget(string widgetID, Func<ObjectFX, IWidgetControl> createFunc)
        {
            RegisterWidget(new WidgetClass(widgetID, createFunc));
        }

        public void RegisterSettings(ICustomSettings settings)
        {
            Settings.Add(settings);
        }

        public void InsertHistory(History history, int index = 0)
        {
            Histories.Remove(Histories.Find(h => h.FullName == history.FullName));
            Histories.Insert(index, history);

            if (Histories.Count > Properties.Settings.Default.HistoryMaxCount)
            {
                Histories.RemoveAt(Histories.Count - 1);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
            foreach (IPlugin plugin in Plugins)
            {
                plugin.Dispose();
            }
            base.Dispose(disposing);
        }

        public void OpenEdit(string fileName, bool applyRules = true)
        {
            if (applyRules)
            {
                ExtensionRule rule = ImportConfig.ExtensionRules.Find(r => r.Extension == Path.GetExtension(fileName));
                if (rule != null && GetPlugin(rule.ImporterGuid) is IImportPlugin importer)
                {
                    OpenEdit(importer, fileName);
                    return;
                }
            }

            List<IImportPlugin> importerList = ImportPlugins.FindAll(p => p.IsImportable(fileName));
            if (importerList.Count > 0)
            {
                if (importerList.Count == 1)
                {
                    OpenEdit(importerList[0], fileName);
                }
                else if (importerList.Count > 1)
                {
                    SelectPluginDialog selectPluginDialog = new SelectPluginDialog
                    {
                        Text = string.Format(Properties.Resources.ImportFile, Path.GetFileName(fileName)),
                        PluginList = importerList.ConvertAll<IPlugin>(p => p),
                    };

                    if (selectPluginDialog.ShowDialog() == DialogResult.OK)
                    {
                        OpenEdit((IImportPlugin)selectPluginDialog.SelectedPlugin, fileName);
                    }
                }
            }
            else
            {
                MessageBox.Show(string.Format(Properties.Resources.Msg_ImporterNotFound, fileName), Properties.Resources.Open, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void OpenEdit(History history)
        {
            if (history == null)
                throw new ArgumentNullException(nameof(history));

            IImportPlugin importer = GetPlugin(history.ImporterGuid) as IImportPlugin;
            if (importer == null)
            {
                if (MessageBox.Show(string.Format(Properties.Resources.Msg_ImporterNotFoundQuestion, history.FullName),
                    Properties.Resources.Open, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    OpenEdit(history.FullName, false);
                }
                return;
            }
            OpenEdit(importer, history.FullName);
        }

        public void OpenEdit(IImportPlugin importer, string fileName)
        {
            if (!File.Exists(fileName))
            {
                MessageBox.Show(string.Format(Properties.Resources.Msg_FileDoesNotExist, fileName), Properties.Resources.Open, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                ObjectEdit edit = new ObjectEdit(importer, fileName);
                if (_SingletonMode)
                    ((MainForm)MainForm).ActivateEdit(edit);
                InsertHistory(new History(edit.FileName, edit.Importer.Guid, edit.Importer.Image?.GetThumbnail(16, 16), DateTime.Now));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, Properties.Resources.Open, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion
    }
}
