using GymManagmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repository.Interfaces
{
    internal interface IMemberSessionRepository
    {
        // get all
        IEnumerable<MemberSession> GetAll();
        //get by id
        MemberSession? GetById(int id);
        // add
        int Add(MemberSession memberSession);
        // update
        int Update(MemberSession memberSession);
        // delete
        int Delete(int id);
    }
}
