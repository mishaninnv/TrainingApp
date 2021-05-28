using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Models;
using System.Linq;

namespace BusinessLogic.Controllers.Tests
{
    [TestClass()]
    public class ExerciseControllerTests
    {
        ExerciseController exerciseController = new ExerciseController();
        BLContext db;

        public ExerciseControllerTests()
        {
            db = exerciseController.db;
        }

        public string GetRandomString() => Guid.NewGuid().ToString();

        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var name = GetRandomString();
            var description = GetRandomString();
            var muscle = new MuscleGroup(GetRandomString());

            // Act
            exerciseController.Add(name, description, muscle);

            // Assert
            Assert.AreEqual(name, db.Exercises.FirstOrDefault(s => s.Name == name).Name);
        }

        [TestMethod()]
        public void ChangeTest()
        {
            // Arrange
            var name = Guid.NewGuid().ToString();
            var description = Guid.NewGuid().ToString();
            var muscle = new MuscleGroup(Guid.NewGuid().ToString());
            var exercise = db.Exercises.First();

            // Act
            exerciseController.Change(exercise, name, description, muscle);

            // Assert
            Assert.AreEqual(exercise.Name, name);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Arrange
            var name = GetRandomString();
            var description = GetRandomString();
            var muscle = new MuscleGroup(GetRandomString());

            // Act
            exerciseController.Add(name, description, muscle);
            exerciseController.Delete(db.Exercises.FirstOrDefault(s => s.Name == name));

            // Assert
            Assert.IsTrue(db.Exercises.FirstOrDefault(s => s.Name == name) == null);
        }
    }
}