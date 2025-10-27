using GymManagmentBLL.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.Entities
{
    internal class Trainer : GymUser
    {
        public Specialties specialties { get; set; }

        public ICollection<Session> trinerSession { get; set; } = null!;
    }
}
