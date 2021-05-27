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

        public void Change(Exercise exercise, string name, string description, MuscleGroup muscle)
        {
            // TODO: предупреждаем об ошибке
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) || muscle == null) return;
            if (exercise == null) return;
            if (db.Exercises.FirstOrDefault(s => s.Name == name) != null) return;

            exercise.Name = name;
            exercise.Description = description;
            exercise.MuscleGroup = muscle;
            db.SaveChanges();
        }

        public void Delete(Exercise exercise)
        {
            if (db.Exercises.Contains(exercise))
            {
                db.Exercises.Remove(exercise);
                db.SaveChanges();
            }
        }
    }
}
