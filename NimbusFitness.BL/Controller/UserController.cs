using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using NimbusFitness.BL.Model;

namespace NimbusFitness.BL
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь.
        /// </summary>
        public List<User> Users { get; }

        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        public User CurrentUser { get; }

        /// <summary>
        /// Является ли пользователь новым.
        /// </summary>
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Создание пользователя.
        /// </summary>
        /// <param name="userName"> Имя. </param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым.", nameof(userName));
            }

            Users = GetUserData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                IsNewUser = true;
            }

            Save();
        }

        /// <summary>
        /// Изменяет данные текущего пользователя.
        /// </summary>
        /// <param name="userName"> Имя. </param>
        /// <param name="gender"> Гендер. </param>
        /// <param name="birthDate"> Дата рождения. </param>
        /// <param name="weight"> Вес. </param>
        /// <param name="height"> Рост. </param>
        public void SetNewUserData(string userName, string gender, DateTime birthDate, double weight = 1, double height = 1)
        {
            // TODO: Проверка

            CurrentUser.Name = userName;
            CurrentUser.Gender = new Gender(gender);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;

            Users.Add(CurrentUser);
            Save();
        }

        /// <summary>
        /// Получить сохранённый список пользователей.
        /// </summary>
        /// <returns> Список пользователей. </returns>
        private List<User> GetUserData()
        {
            var binaryFormatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && binaryFormatter.Deserialize(fs) is List<User> users)
                    return users;
                else
                    return new List<User>();
            }
        }

        /// <summary>
        /// Сохранение пользователя.
        /// </summary>
        public void Save()
        {
            var binaryFormatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                binaryFormatter.Serialize(fs, Users);
            }
        }
    }
}