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
    internal class PlanRepository : IPlanRepository
    {

        private readonly GymDBContext _dBContext;
        public PlanRepository(GymDBContext dBContext)
        {
            _dBContext = dBContext;

        }



        public int Add(Plan plan)
        {
            _dBContext.Plans.Add(plan);
            return _dBContext.SaveChanges();
        }

        public int Delete(int id)
        {
            var plan = _dBContext.Plans.Find(id);
            if (plan != null) return 0;
            _dBContext.Remove(plan);
            return _dBContext.SaveChanges();

        }

        public IEnumerable<Plan> GetAll()=> _dBContext.Plans.ToList();

        public Plan? GetById(int id)=> _dBContext.Plans.Find(id);


        public int Update(Plan plan)
        {
              _dBContext.Plans.Update(plan);
                return _dBContext.SaveChanges();

        }
    }
}
