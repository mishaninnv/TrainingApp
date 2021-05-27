using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Controllers
{
    public class MuscleGroupController
    {
        public BLContext db { get; } = BLContext.DB;

        public void Add(string name)
        {
            // TODO: добавить предупреждение о наличии такой группы либо о пустой строке (либо сделать пустую строку в форме)
            if (string.IsNullOrEmpty(name)) return;
            if (db.MuscleGroups.FirstOrDefault(s => s.Name == name) != null) return;

            db.MuscleGroups.Add(new MuscleGroup(name));
            db.SaveChanges();
        }

        public void Change(string currentName, string changedName)
        {
            // TODO: добавить предупреждение
            if (string.IsNullOrEmpty(changedName)) return;

            var currentMuscleGroup = db.MuscleGroups.FirstOrDefault(s => s.Name == currentName);
            var changedMuscleGroup = db.MuscleGroups.FirstOrDefault(s => s.Name == changedName);

            if (currentMuscleGroup != null && changedMuscleGroup == null)
            {
                currentMuscleGroup.Name = changedName;
                db.SaveChanges();
            }
        }

        public void Delete(string name)
        {
            var currentMuscleGroup = db.MuscleGroups.FirstOrDefault(s => s.Name == name);
            if (currentMuscleGroup != null)
            {
                db.MuscleGroups.Remove(currentMuscleGroup);
                db.SaveChanges();
            }
        }
    }
}