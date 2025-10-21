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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GymDBContext _dbContext;

        public UnitOfWork(GymDBContext dbContext)
        {
            _dbContext = dbContext;
            
        }
        private readonly Dictionary<Type, object> _repository = new();

        public ISessionRepository sessionRepository => new SessionRepository(_dbContext);

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity, new()
        {
          //   return new GenericRepository<TEntity>(_dbContext);

            var EntityType = typeof(TEntity);
            if (_repository.ContainsKey(EntityType))
            {
                return (IGenericRepository<TEntity>)_repository[EntityType];
            }
            var newRep= new GenericRepository<TEntity>(_dbContext);
            _repository[EntityType] = newRep;

            return newRep;
        }

        public int SaveChange()
        {
            return _dbContext.SaveChanges();
        }
    }
}
