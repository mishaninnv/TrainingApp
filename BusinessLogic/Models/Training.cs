using System.Collections.Generic;

namespace BusinessLogic.Models
{
    public class Training
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }

        public Training() { }
        public Training(string name, string description, List<Exercise> exercises)
        {
            Name = name;
            Description = description;
            Exercises = exercises;
        }
    }
}
