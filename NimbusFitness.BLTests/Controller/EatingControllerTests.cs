using Microsoft.VisualStudio.TestTools.UnitTesting;
using NimbusFitness.BL.Controller;
using NimbusFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NimbusFitness.BL.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        Random rnd = new Random();

        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            UserController controller = new UserController(userName);
            EatingController eatingController = new EatingController(controller.CurrentUser);
            var food = new Food(foodName, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));

            // Act
            eatingController.Add(food, 100);

            // Assert
            Assert.AreEqual(food.Name, eatingController.Eating.Foods.First().Key.Name);
        }
    }
}