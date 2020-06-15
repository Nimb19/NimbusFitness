using System;

namespace NimbusFitness.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        public int Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; set; }

        public int GenderId { get; set; }

        /// <summary>
        /// Гендер.
        /// </summary>
        public virtual Gender Gender { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age
        {
            get
            {
                DateTime nowDate = DateTime.Today;
                int age = nowDate.Year - BirthDate.Year;
                if (BirthDate > nowDate.AddYears(-age)) age--;
                return age;
            }
        }

        public User() { }

        /// <summary>
        /// Создание пользователя.
        /// </summary>
        /// <param name="name"> Имя. </param>
        /// <param name="gender"> Гендер. </param>
        /// <param name="birthDay"> Дата рождения. </param>
        /// <param name="weight"> Вес. </param>
        /// <param name="height"> Рост. </param>
        public User(string name, string gender, DateTime birthDate, double weight, double height)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым или null.", nameof(name));
            }
            if (string.IsNullOrWhiteSpace(gender))
            {
                throw new ArgumentNullException("Гендер не может быть пустым или null.", nameof(gender));
            }
            if (birthDate > DateTime.Now || birthDate < DateTime.Parse("00.00.1900 00:00:00"))
            {
                throw new ArgumentNullException("Дата рождения не может быть меньше 1900 года, или больше сегодняшней даты.", nameof(birthDate));
            }
            if (weight < 0)
            {
                throw new ArgumentNullException("Вес не может быть меньше нуля.", nameof(weight));
            }
            if (height < 0)
            {
                throw new ArgumentNullException("Рост не может быть меньше нуля.", nameof(height));
            }

            Name = name;
            Gender = new Gender(gender);
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым или null.", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
