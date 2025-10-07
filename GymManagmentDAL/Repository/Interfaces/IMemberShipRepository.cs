using GymManagmentDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Repository.Interfaces
{
    internal interface IMemberShipRepository
    {
        // get all
        IEnumerable<MemberShip> GetAll();

        //get by id
        MemberShip? GetById(int id);

        // add
        int Add(MemberShip memberShip);


        // update
        int Update(MemberShip memberShip);

        // delete
        int Delete(int id);


    }
}
