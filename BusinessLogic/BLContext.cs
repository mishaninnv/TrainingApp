using BusinessLogic.Models;
using System.Data.Entity;

namespace BusinessLogic
{
    public class BLContext : DbContext
    {
        public static BLContext DB { get; } = new BLContext();

        public BLContext() : base("TrainingApp") {}

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<MuscleGroup> MuscleGroups { get; set; }
    }
}
