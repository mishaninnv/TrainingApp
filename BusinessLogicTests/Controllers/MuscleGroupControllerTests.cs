using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace BusinessLogic.Controllers.Tests
{
    [TestClass()]
    public class MuscleGroupControllerTests
    {
        MuscleGroupController muscleGroupController = new MuscleGroupController();
        BLContext db;

        public MuscleGroupControllerTests()
        {
            db = muscleGroupController.db;
        }

        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var name = Guid.NewGuid().ToString(); 
            if (db.MuscleGroups.FirstOrDefault(s => s.Name == name) != null) return;

            // Act
            muscleGroupController.Add(name);
            
            // Assert
            Assert.AreEqual(name, db.MuscleGroups.FirstOrDefault(s => s.Name == name).Name);
        }

        [TestMethod()]
        public void ChangeTest()
        {
            // Arrange
            var firstName = Guid.NewGuid().ToString(); 
            var changedName = Guid.NewGuid().ToString();

            // Act
            muscleGroupController.Add(firstName);
            muscleGroupController.Change(firstName, changedName);

            // Assert
            Assert.AreEqual(changedName, db.MuscleGroups.FirstOrDefault(s => s.Name == changedName).Name);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Arrange
            var name = Guid.NewGuid().ToString(); 

            // Act
            muscleGroupController.Add(name);
            muscleGroupController.Delete(name);

            // Assert
            Assert.IsTrue(db.MuscleGroups.FirstOrDefault(s => s.Name == name) == null);
        }
    }
}