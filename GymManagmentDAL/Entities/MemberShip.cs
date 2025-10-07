using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Entities
{
    public class MemberShip : BaseEntity
    {
        public int MemberID { get; set; }
        public Member Member { get; set; } = null!;

        public int planID { get; set; }
        public Plan plan { get; set; } = null!;

        public DateTime EndDate { get; set; }

        //read only prop
        public string Status
        {
            get
            {
                if (EndDate >= DateTime.Now)
                    return "Expired";

                else
                    return "Active";

            }
        }
    }
}
