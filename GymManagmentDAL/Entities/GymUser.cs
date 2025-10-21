using GymManagmentDAL.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Entities
{
    public abstract class GymUser : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateOnly DateofBirth { get; set; }
        public Gender Gender { get; set; }

        public Address Address { get; set; } = null!;
    }
}
