using GymManagmentDAL.Data.Context;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repository.Classes
{
    public class SessionRepository : GenericRepository<Session>, ISessionRepository
    {
        private readonly GymDBContext _dBContext;
        public SessionRepository(GymDBContext dBContext):base(dBContext)
        {
            _dBContext = dBContext;
        }
        public IEnumerable<Session> GetAlltSessionsWithAllTrainerAndCatogry()
        {
            return _dBContext.sessions.Include(X=>X.Trainer)
                                      .Include(X=>X.Category)
                                      .ToList();

        }

        public int GetCountOfBookedSlots(int sessionId)
        {
            return _dBContext.MemberSessions
                             .Count(X => X.SessionID == sessionId);
        }

        public Session? GetSessionByIdWithAllTrainerAndCatogry(int sessionId)
        {
            return _dBContext.sessions.Include(X => X.Trainer)
                                       .Include(X => X.Category)
                                       .FirstOrDefault(X => X.Id == sessionId);
        }
    }
}
