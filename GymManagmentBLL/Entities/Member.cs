using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentBLL.Entities
{
    internal class Member: GymUser
    {
        public string? phone { get; set; }

        #region Relationships
        #region Member-Healthrecord
        public HealthRecord HealthRecord { get; set; } = null!;
        #endregion

        #region Member-MemberSession
        public ICollection<MemberSession> MemberSessions { get; set; } = null!;

        #endregion

        #region Member-plan

        public ICollection<MemberShip> MemberPlan { get; set; } = null!;
        #endregion

        #endregion
    }
}
