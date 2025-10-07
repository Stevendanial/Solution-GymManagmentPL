using GymManagmentDAL.Data.Context;
using GymManagmentDAL.Entities;
using GymManagmentDAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repository.Classes
{
    internal class MemberSessionRepository : IMemberSessionRepository
    {

        private readonly GymDBContext _dBContext;
        public MemberSessionRepository(GymDBContext dBContext)
        {
            _dBContext = dBContext;

        }



        public int Add(MemberSession memberSession)
        {
            _dBContext.MemberSessions.Add(memberSession);
            return _dBContext.SaveChanges();

        }

        public int Delete(int id)
        {
            var memberSession = _dBContext.MemberSessions.Find(id);
            if (memberSession != null) return 0;
            _dBContext.Remove(memberSession);
            return _dBContext.SaveChanges();

        }

        public IEnumerable<MemberSession> GetAll()=> _dBContext.MemberSessions.ToList();


        public MemberSession? GetById(int id)=> _dBContext.MemberSessions.Find(id);


        public int Update(MemberSession memberSession)
        {
            _dBContext.MemberSessions.Update(memberSession);
            return _dBContext.SaveChanges();

        }
    }
}
