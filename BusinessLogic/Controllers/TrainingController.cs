using BusinessLogic.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Controllers
{
    public class TrainingController
    {
        public BLContext db { get; } = BLContext.DB;

        public void Add(string name, string description, List<Exercise> exercises)
        {
            // TODO: предупреждение об ошибке
            if (db.Trainings.FirstOrDefault(s => s.Name == name) != null) return;
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) || exercises == null) return;

            db.Trainings.Add(new Training(name, description, exercises));
            db.SaveChanges();
        }

        public void Change(Training training, string newName, string newDescription, List<Exercise> newExercises)
        {
            // TODO: предупреждение об ошибке
            if (db.Trainings.FirstOrDefault(s => s.Name == newName) != null) return;
            if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newDescription) || newExercises == null) return;
            if (training == null) return;

            training.Name = newName;
            training.Description = newDescription;
            training.Exercises.Clear();
            training.Exercises = newExercises;
            db.SaveChanges();
        }

        public void Delete(Training training)
        {
            if (db.Trainings.FirstOrDefault(s => s.Name == training.Name) != null)
            {
                db.Trainings.Remove(training);
                db.SaveChanges();
            }
        }
    }
}
