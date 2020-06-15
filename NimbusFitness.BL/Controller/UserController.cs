using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using NimbusFitness.BL.Controller;
using NimbusFitness.BL.Model;

namespace NimbusFitness.BL
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController : ControllerBase
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

            CurrentUser = Users.FirstOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                IsNewUser = true;
            }
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
            return Load<User>();
        }

        /// <summary>
        /// Сохранение пользователя.
        /// </summary>
        public void Save()
        {
            base.Save(Users);
        }
    }
}