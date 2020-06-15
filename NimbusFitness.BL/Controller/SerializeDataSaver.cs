using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NimbusFitness.BL.Controller
{
    class SerializeDataSaver : IDataSaver
    {
        public List<T> Load<T>() where T : class
        {
            var binaryFormatter = new BinaryFormatter();
            string filename = typeof(T).Name + ".dat";

            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && binaryFormatter.Deserialize(fs) is List<T> items)
                    return items;
                else
                    return new List<T>();
            }
        }

        public void Save<T>(List<T> item) where T : class
        {
            var binaryFormatter = new BinaryFormatter();
            string filename = typeof(T).Name + ".dat";

            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fs, item);
            }
        }
    }
}
