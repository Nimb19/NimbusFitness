using System;
using System.Collections.Generic;
using System.Linq;
using NimbusFitness.BL.Model;

namespace NimbusFitness.BL.Controller
{
    public class DatabaseDataSaver : IDateSaver
    {
        public List<T> Load<T>() where T : class
        {
            using (var context = new FitnessContext())
            {
                var res = context.Set<T>().Where(t => true).ToList() ?? new List<T>();
                return res;
            }
        }

        public void Save<T>(List<T> item) where T : class
        {
            using (var db = new FitnessContext())
            {
                db.Set<T>().AddRange(item);
                db.SaveChanges();
            }
        }
    }
}
