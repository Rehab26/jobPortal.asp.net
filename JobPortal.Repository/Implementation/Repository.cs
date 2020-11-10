using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using JobPortal.Models.Implementation;
using JobPortal.Repository.Contract;
using System.Data.Entity.Design;

namespace JobPortal.Repository.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly System.Data.Entity.DbContext _dbContext;

        public Repository(System.Data.Entity.DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TEntity entity)
        {
            if (typeof(TEntity) == typeof(Entity))
            {
                (entity as Entity).DateCreated = DateTime.Now;
            }

            _dbContext.Set<TEntity>().Add(entity);
            //_dbContext.SaveChanges();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            //entities.ToList().ForEach(e => e.DateCreated = DateTime.Now);
            _dbContext.Set<TEntity>().AddRange(entities);
        }

        public TEntity Get(object id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        //public IEnumerable<TEntity> FindUsingDictionary(Dictionary<string, object> dictionary)
        //{

        //}

        public void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbContext.Set<TEntity>().RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            if (typeof(TEntity) == typeof(Entity))
            {
                (entity as Entity).DateModified = DateTime.Now;
            }
            _dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }

        //public void SaveChanges()
        //{
        //    _dbContext.SaveChanges();
        //}

        public void Attach(TEntity entity)
        {
            _dbContext.Set<TEntity>().Attach(entity);
        }
        public void Include(string entityName)
        {
            _dbContext.Set<TEntity>().Include(entityName);
        }

    }
}
