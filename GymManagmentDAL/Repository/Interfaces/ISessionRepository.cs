using GymManagmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repository.Interfaces
{
    internal interface ISessionRepository
    {
        // get all
        IEnumerable<Session> GetAll();
        //get by id
        Session? GetById(int id);
        // add
        int Add(Session session);
        // update
        int Update(Session session);
        // delete
        int Delete(int id);
    }
}
