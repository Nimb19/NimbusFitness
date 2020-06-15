using System;
using System.Collections.Generic;
using System.Linq;

namespace NimbusFitness.BL.Model
{
    /// <summary>
    /// Приём пищи.
    /// </summary>
    [Serializable]
    public class Eating
    {
        public int Id { get; set; }

        /// <summary>
        /// Момент приёма пищи.
        /// </summary>
        public DateTime Moment { get; set; }

        /// <summary>
        /// Словарь съеденных продуктов.
        /// </summary>
        public Dictionary<Food, double> Foods { get; set; }

        public int UserId { get; set; }

        /// <summary>
        /// Пользователь, принимающий пищу.
        /// </summary>
        public virtual User User { get; set; }

        public Eating() { }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        /// <summary>
        /// Метод добавления съеденных продуктов.
        /// </summary>
        /// <param name="food"> Название продукта. </param>
        /// <param name="weight"> Вес. </param>
        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if (product == null)
                Foods.Add(food, weight);
            else
                Foods[product] += weight;
        }
    }
}
