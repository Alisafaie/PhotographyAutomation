using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PhotographyAutomation.DateLayer.Models;

namespace PhotographyAutomation.DateLayer.Services
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private PhotographyAutomationDBEntities _db;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(PhotographyAutomationDBEntities db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }


        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (where!=null)
            {
                query = query.Where(where);
            }

            return query.ToList();
        }

        public virtual TEntity GetById(object id)
        {
            try
            {
                return _dbSet.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public virtual void Insert(TEntity entity)
        {
            try
            {
                _dbSet.Add(entity);
            }
            catch
            {
                // ignored
            }
        }

        public virtual void Update(TEntity entity)
        {
            try
            {
                _db.Entry(entity).State = EntityState.Modified;
            }
            catch
            {
                // ignored
            }
        }

        public virtual void Delete(TEntity entity)
        {
            try
            {
                if (_db.Entry(entity).State == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }

                _dbSet.Remove(entity);
            }
            catch
            {
                // ignored
            }
        }

        public virtual void Delete(object id)
        {
            try
            {
                var entity = GetById(id);
                Delete(entity);
            }
            catch
            {
                // ignored
            }
        }
    }
}
