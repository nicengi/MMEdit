using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MMEdit
{
    static class Util
    {
        #region Properties
        public static string AssemblyTitle
        {
            get
            {
                return GetAssemblyTitle(Assembly.GetExecutingAssembly());
            }
        }

        public static string AssemblyVersion
        {
            get
            {
                return GetAssemblyVersion(Assembly.GetExecutingAssembly());
            }
        }

        public static string AssemblyDescription
        {
            get
            {
                return GetAssemblyDescription(Assembly.GetExecutingAssembly());
            }
        }

        public static string AssemblyProduct
        {
            get
            {
                return GetAssemblyProduct(Assembly.GetExecutingAssembly());
            }
        }

        public static string AssemblyCopyright
        {
            get
            {
                return GetAssemblyCopyright(Assembly.GetExecutingAssembly());
            }
        }

        public static string AssemblyCompany
        {
            get
            {
                return GetAssemblyCompany(Assembly.GetExecutingAssembly());
            }
        }
        #endregion

        #region Methods
        public static void Serialize(string path, object obj)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, obj);
            }
        }

        public static T Deserialize<T>(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                return (T)formatter.Deserialize(stream);
            }
        }

        public static void XmlSerialize<T>(string path, T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using (StreamWriter stream = new StreamWriter(new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None)))
            {
                serializer.Serialize(stream, obj, namespaces);
            }
        }

        public static T XmlDeserialize<T>(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                return (T)serializer.Deserialize(stream);
            }
        }

        public static string GetAssemblyTitle(Assembly assembly)
        {
            object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            if (attributes.Length > 0)
            {
                AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                if (titleAttribute.Title != "")
                {
                    return titleAttribute.Title;
                }
            }
            return System.IO.Path.GetFileNameWithoutExtension(assembly.CodeBase);
        }

        public static string GetAssemblyVersion(Assembly assembly)
        {
            return assembly.GetName().Version.ToString();
        }

        public static string GetAssemblyDescription(Assembly assembly)
        {
            object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }
            return ((AssemblyDescriptionAttribute)attributes[0]).Description;
        }

        public static string GetAssemblyProduct(Assembly assembly)
        {
            object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }
            return ((AssemblyProductAttribute)attributes[0]).Product;
        }

        public static string GetAssemblyCopyright(Assembly assembly)
        {
            object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }
            return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
        }

        public static string GetAssemblyCompany(Assembly assembly)
        {
            object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
            if (attributes.Length == 0)
            {
                return "";
            }
            return ((AssemblyCompanyAttribute)attributes[0]).Company;
        }
        #endregion

        #region ExtensionMethods
        /// <summary>
        /// 获取指定大小的缩略图 <see cref="Image"/>。
        /// </summary>
        /// <param name="original"></param>
        /// <param name="thumbWidth"></param>
        /// <param name="thumbHeight"></param>
        /// <returns></returns>
        public static Image GetThumbnail(this Image original, int thumbWidth, int thumbHeight)
        {
            Image image = new Bitmap(original, thumbWidth, thumbHeight);

            using (Graphics g = Graphics.FromImage(image))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                g.Clear(Color.Transparent);
                g.DrawImage(original, 0, 0, thumbWidth, thumbHeight);

                return image;
            }
        }

        /// <summary>
        /// 将指定的文件名筛选器字符串合并到 <see cref="FileDialog"/>。
        /// </summary>
        /// <param name="dialog"></param>
        /// <param name="filter"></param>
        public static void CombineFilter(this FileDialog dialog, string filter)
        {

            dialog.Filter = func(dialog.Filter) + filter;

            string func(string str)
            {
                if (!string.IsNullOrEmpty(str) && dialog.Filter[str.Length - 1] != '|')
                    return str += "|";
                else
                    return str;
            }
        }
        #endregion
    }
}
