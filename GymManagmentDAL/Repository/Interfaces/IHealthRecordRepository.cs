﻿using GymManagmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repository.Interfaces
{
    internal interface IHealthRecordRepository
    {
        // get all
        IEnumerable<HealthRecord> GetAll();

        //get by id
        HealthRecord? GetById(int id);

        // add
        int Add(HealthRecord healthRecord);


        // update
        int Update(HealthRecord healthRecord);

        // delete
        int Delete(int id);
    }
}
