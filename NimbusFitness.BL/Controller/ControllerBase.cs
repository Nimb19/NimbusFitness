using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NimbusFitness.BL.Controller
{
    public abstract class ControllerBase
    {
        protected void Save(string filename, object item)
        {
            var binaryFormatter = new BinaryFormatter();

            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fs, item);
            }
        }

        protected T Load<T>(string filename)
        {
            var binaryFormatter = new BinaryFormatter();

            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && binaryFormatter.Deserialize(fs) is T items)
                    return items;
                else
                    return default(T);
            }
        }
    }
}
