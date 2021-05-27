namespace BusinessLogic.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public MuscleGroup MuscleGroup { get; set; }
        public virtual Training Training { get; set; }

        public Exercise() { }
        public Exercise(string name, string description, MuscleGroup muscleGroup)
        {
            Name = name;
            Description = description;
            MuscleGroup = muscleGroup;
        }
    }
}
