using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MMEdit
{
    static class Util
    {
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
        #endregion
    }
}
