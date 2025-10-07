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
    internal class HealthRecordRepository : IHealthRecordRepository
    {

        private readonly GymDBContext _dBContext;
        public HealthRecordRepository(GymDBContext dBContext)
        {
            _dBContext = dBContext;

        }

        public int Add(HealthRecord healthRecord)
        {
            _dBContext.HealthRecords.Add(healthRecord);
            return _dBContext.SaveChanges();

        }

        public int Delete(int id)
        {
            var healthRecord = _dBContext.HealthRecords.Find(id);
            if (healthRecord == null) return 0;
            _dBContext.Remove(healthRecord);
            return _dBContext.SaveChanges();

        }

        public IEnumerable<HealthRecord> GetAll()=> _dBContext.HealthRecords.ToList();


        public HealthRecord? GetById(int id)=> _dBContext.HealthRecords.Find(id);


        public int Update(HealthRecord healthRecord)
        {
            _dBContext.HealthRecords.Update(healthRecord);
            return _dBContext.SaveChanges();

        }
    }
}
