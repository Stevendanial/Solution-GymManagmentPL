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
    internal class CategoryRepository : ICategoryRepository
    {

        private readonly GymDBContext _dBContext;
        public CategoryRepository(GymDBContext dBContext)
        {
            _dBContext = dBContext;

        }


        public int Add(Category category)
        {
            _dBContext.Categories.Add(category);
            return _dBContext.SaveChanges();

        }

        public int Delete(int id)
        {
            var category = _dBContext.Categories.Find(id);
            if (category != null) return 0;
            _dBContext.Remove(category);
            return _dBContext.SaveChanges();

        }

        public IEnumerable<Category> GetAll()
        {
            return _dBContext.Categories.ToList();

        }

        public Category? GetById(int id)
        {
            return _dBContext.Categories.Find(id);

        }

        public int Update(Category category)
        {
            _dBContext.Categories.Update(category);
            return _dBContext.SaveChanges();

        }
    }
}
