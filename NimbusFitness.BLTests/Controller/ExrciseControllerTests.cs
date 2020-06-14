using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NimbusFitness.BL.Model;

namespace NimbusFitness.BL.Controller.Tests
{
    [TestClass()]
    public class ExrciseControllerTests
    {
        [TestMethod()]
        public void AddExerciseTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            var rnd = new Random();
            UserController userController = new UserController(userName);
            ExerciseController exerciseController = new ExerciseController(userController.CurrentUser);
            Activity activity = new Activity(activityName, rnd.Next(10, 30));

            // Act
            exerciseController.AddExercise(activity, DateTime.Now, DateTime.Now.AddHours(1));

            // Assert
            Assert.AreEqual(activity.Name, exerciseController.Activities.Last().Name);
        }
    }
}