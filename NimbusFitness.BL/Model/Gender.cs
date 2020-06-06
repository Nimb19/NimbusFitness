using System;

namespace NimbusFitness.BL.Model
{
    /// <summary>
    /// Пол. 
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Создать новый пол.
        /// </summary>
        /// <param name="name"> Название пола. </param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Пол не может быть пустым или null.", nameof(name));

            Name = name;
        }
    }
}
