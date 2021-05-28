using BusinessLogic.Models;
using System.Linq;

namespace BusinessLogic.Controllers
{
    public class ExerciseController
    {
        public BLContext db { get; } = BLContext.DB;

        public void Add(string name, string description, MuscleGroup muscle)
        {
            // TODO: предупреждаем об ошибке
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) || muscle == null) return;
            if (db.Exercises.FirstOrDefault(s => s.Name == name) != null) return;

            db.Exercises.Add(new Exercise(name, description, muscle));
            db.SaveChanges();
        }

        public void Change(Exercise exercise, string newName, string newDescription, MuscleGroup newMuscle)
        {
            // TODO: предупреждаем об ошибке
            if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newDescription) || newMuscle == null) return;
            if (exercise == null) return;
            if (db.Exercises.FirstOrDefault(s => s.Name == newName) != null) return;

            exercise.Name = newName;
            exercise.Description = newDescription;
            exercise.MuscleGroup = newMuscle;
            db.SaveChanges();
        }

        public void Delete(Exercise exercise)
        {
            if (db.Exercises.FirstOrDefault(s => s.Name == exercise.Name) != null)
            {
                db.Exercises.Remove(exercise);
                db.SaveChanges();
            }
        }
    }
}
