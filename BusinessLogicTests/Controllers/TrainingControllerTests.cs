using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogic.Models;

namespace BusinessLogic.Controllers.Tests
{
    [TestClass()]
    public class TrainingControllerTests
    {
        TrainingController trainingController = new TrainingController();
        BLContext db;
        Random random = new Random();

        public TrainingControllerTests()
        {
            db = trainingController.db;
        }

        public string GetRandomString() => Guid.NewGuid().ToString();
        public Training GetTraining(int counter)
        {
            var name = GetRandomString();
            var description = GetRandomString();
            var exercises = new List<Exercise>();

            for (var i = 0; i < counter; i++)
            {
                exercises.Add(new Exercise(GetRandomString(), GetRandomString(), new MuscleGroup(GetRandomString())));
            }

            return new Training(name, description, exercises);
        }

        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var counter = random.Next(3, 10);
            var training = GetTraining(counter);            

            // Act
            trainingController.Add(training.Name, training.Description, training.Exercises as List<Exercise>);
            var currTraining = db.Trainings.FirstOrDefault(s => s.Name == training.Name);

            // Assert
            Assert.AreEqual(counter, currTraining.Exercises.Count);
            Assert.AreEqual(training.Name, currTraining.Name);
        }

        [TestMethod()]
        public void ChangeTest()
        {
            // Arrange
            var currTraining = db.Trainings.First();
            var counter = random.Next(3, 10);
            var training = GetTraining(counter);

            // Act
            trainingController.Change(currTraining, training.Name, training.Description, training.Exercises as List<Exercise>);

            // Assert
            Assert.AreEqual(counter, currTraining.Exercises.Count);
            Assert.AreEqual(training.Name, currTraining.Name);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Arrange
            var counter = random.Next(3, 7);
            var currTraining = GetTraining(counter);
            var name = currTraining.Name;

            // Act
            trainingController.Add(currTraining.Name, currTraining.Description, currTraining.Exercises as List<Exercise>);
            trainingController.Delete(db.Trainings.FirstOrDefault(s => s.Name == name));

            // Assert
            Assert.IsTrue(db.Trainings.FirstOrDefault(s => s.Name == name) == null);
        }
    }
}