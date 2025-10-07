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
    internal class TrainerRepository : ITrainerRepository
    {

        private readonly GymDBContext _dBContext;
        public TrainerRepository(GymDBContext dBContext)
        {
            _dBContext = dBContext;

        }

        public int Add(Trainer trainer)
        {
            _dBContext.trainers.Add(trainer);
            return _dBContext.SaveChanges();
        }

        public int Delete(int id)
        {
            var trainer = _dBContext.trainers.Find(id);
            if (trainer != null) return 0;
            _dBContext.Remove(trainer);
            return _dBContext.SaveChanges();
        }

        public IEnumerable<Trainer> GetAll() => _dBContext.trainers.ToList();


        public Trainer? GetById(int id) => _dBContext.trainers.Find(id);


        public int Update(Trainer trainer)
        {
            _dBContext.trainers.Update(trainer);
            return _dBContext.SaveChanges();
        }
    }
}
