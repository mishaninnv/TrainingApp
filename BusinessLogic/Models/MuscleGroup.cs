namespace BusinessLogic.Models
{
    public class MuscleGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public MuscleGroup() { }
        public MuscleGroup(string name)
        {
            Name = name;
        }
    }
}
