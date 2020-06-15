using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace NimbusFitness.BL.Controller
{
    public abstract class ControllerBase
    {
        private readonly IDateSaver dateSaver = new SerializeDataSaver();

        protected void Save<T>(List<T> item) where T : class
        {
            dateSaver.Save(item);
        }

        protected List<T> Load<T>() where T : class
        {
            return dateSaver.Load<T>();
        }
    }
}
