using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NimbusFitness.BL.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            // Arrange
            string userName = Guid.NewGuid().ToString();
            var gender = "м";
            var birthDate = DateTime.Now.AddYears(-19);
            var weight = 90;
            var heigth = 185;
            UserController userController = new UserController(userName);

            // Act
            userController.SetNewUserData(userName, gender, birthDate, weight, heigth);
            var controller2 = new UserController(userName);

            // Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
            Assert.AreEqual(birthDate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(heigth, controller2.CurrentUser.Height);
        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arrange
            string userName = Guid.NewGuid().ToString();

            // Act
            UserController userController = new UserController(userName);

            // Assert
            Assert.AreEqual(userName, userController.CurrentUser.Name);
        }
    }
}