using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.Entities
{
    internal class Session: BaseEntity
    {
        public string Description { get; set; } = null!;

        public int capacity { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


        #region RelationShips
        #region Session-Catogory

        public int CategoryID { get; set; }
        public Category Category { get; set; }=null!;



        #endregion

        #region Session-Trainer

        public int trainerID { get; set; }
        public Trainer Trainer { get; set; } = null!;
        #endregion

        #region Session-MemberSession

        public ICollection<MemberSession> SessionsMember { get; set; } = null!;
        #endregion
        #endregion
    }
}
