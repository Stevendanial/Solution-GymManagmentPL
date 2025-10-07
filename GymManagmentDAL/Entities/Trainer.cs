using GymManagmentDAL.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace GymManagmentDAL.Entities
{
    public class Trainer : GymUser
    {
        public Specialties specialties { get; set; }

        public ICollection<Session> trinerSession { get; set; } = null!;
    }
}
