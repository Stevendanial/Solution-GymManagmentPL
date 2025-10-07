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
    internal class MemberShipRepository: IMemberShipRepository
    {
        private readonly GymDBContext _dBContext;
        public MemberShipRepository(GymDBContext dBContext)
        {
            _dBContext = dBContext;

        }

        public int Add(MemberShip memberShip)
        {
            _dBContext.MemberShips.Add(memberShip);
            return _dBContext.SaveChanges();

        }

        public int Delete(int id)
        {
            var memberShip = _dBContext.MemberShips.Find(id);
            if (memberShip != null) return 0;
            _dBContext.Remove(memberShip);
            return _dBContext.SaveChanges();

        }

        public IEnumerable<MemberShip> GetAll()=> _dBContext.MemberShips.ToList();


        public MemberShip? GetById(int id)=> _dBContext.MemberShips.Find(id);


        public int Update(MemberShip memberShip)
        {
           
                _dBContext.MemberShips.Update(memberShip);
                    return _dBContext.SaveChanges();
        }
    }
}
