using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Entities
{
    public class MemberSession : BaseEntity
    {
        public int MemberID { get; set; }
        public Member Member { get; set; } = null!;

        public int SessionID { get; set; }
        public Session Session { get; set; } = null!;

        //BookingDay == createAt of BaseEntity
        public bool IsAttended { get; set; }

    }
}

