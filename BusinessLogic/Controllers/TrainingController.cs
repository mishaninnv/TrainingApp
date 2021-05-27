using BusinessLogic.Models;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Controllers
{
    public class TrainingController
    {
        public BLContext db { get; } = BLContext.DB;
    }
}
