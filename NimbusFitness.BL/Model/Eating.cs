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
        /// <summary>
        /// Момент приёма пищи.
        /// </summary>
        public DateTime Moment { get; }

        /// <summary>
        /// Словарь съеденных продуктов.
        /// </summary>
        public Dictionary<Food, double> Foods { get; }

        /// <summary>
        /// Пользователь, принимающий пищу.
        /// </summary>
        public User User { get; }

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
