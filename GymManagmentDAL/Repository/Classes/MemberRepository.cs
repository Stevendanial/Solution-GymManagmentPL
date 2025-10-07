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
    internal class MemberRepository : IMemberRepository
    {
        // public GymDBContext dBContext { get; set; }= new GymDBContext();
        //private readonly GymDBContext _dBContext =new GymDBContext();

        private readonly GymDBContext _dBContext;
        public MemberRepository(GymDBContext dBContext)
        {
            _dBContext = dBContext;

        }
        public int Add(Member member)
        {
            _dBContext.Members.Add(member);
            return _dBContext.SaveChanges();
        }

        public int Delete(int id)
        {
            var member = _dBContext.Members.Find(id);
            if (member != null) return 0;
            _dBContext.Remove(member);
            return _dBContext.SaveChanges();
            
        }

        public IEnumerable<Member> GetAll()=> _dBContext.Members.ToList();


        public Member? GetById(int id)=> _dBContext.Members.Find(id);


        public int Update(Member member)
        {
           _dBContext.Members.Update(member);
            return _dBContext.SaveChanges();
        }
    }
}
