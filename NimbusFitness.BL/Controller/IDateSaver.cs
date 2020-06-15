using System.Collections.Generic;

namespace NimbusFitness.BL.Controller
{
    public interface IDateSaver
    {
        void Save<T>(List<T> item) where T : class;
        List<T> Load<T>() where T : class;
    }
}
