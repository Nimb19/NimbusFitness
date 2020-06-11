using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimbusFitness.BL.Model
{
    /// <summary>
    /// Общий класс продуктов.
    /// </summary>
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Название продукта.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Калории на 1 грамм.
        /// </summary>
        public double Calories { get; }

        /// <summary>
        /// Углеводы на 1 грамм.
        /// </summary>
        public double Carbohydrates { get; }

        /// <summary>
        /// Жиры на 1 грамм.
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Белки на 1 грамм.
        /// </summary>
        public double Proteins { get; }

        public Food(string name) : this(name, 1, 1, 1, 1)
        {
            // TODO: Сделать проверку.

            Name = name;
        }

        public Food(string name, double calories, double carbohydrates, double fats, double proteins)
        {
            // TODO: Проверка входящих параметров.

            Name = name;
            Calories = calories / 100;
            Carbohydrates = carbohydrates / 100;
            Fats = fats / 100;
            Proteins = proteins / 100;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
