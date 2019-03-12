using PhotographyAutomation.DateLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;

namespace PhotographyAutomation.DateLayer.Services
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        private readonly PhotographyAutomationDBEntities _db;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(PhotographyAutomationDBEntities db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>();
        }


        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> where = null)
        {
            try
            {
                IQueryable<TEntity> query = _dbSet;
                if (where != null)
                {
                    query = query.Where(where);
                }

                return query.ToList();
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.Data);
                Debug.WriteLine(exception.InnerException);
                Debug.WriteLine(exception.Source);
                Debug.WriteLine(exception.StackTrace);
                return null;
            }
        }

        public virtual TEntity GetById(object id)
        {
            try
            {
                return _dbSet.Find(id);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.Data);
                Debug.WriteLine(exception.InnerException);
                Debug.WriteLine(exception.Source);
                Debug.WriteLine(exception.StackTrace);
                return null;
            }
        }

        public virtual void Insert(TEntity entity)
        {
            try
            {
                _dbSet.Add(entity);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.Data);
                Debug.WriteLine(exception.InnerException);
                Debug.WriteLine(exception.Source);
                Debug.WriteLine(exception.StackTrace);
            }
        }

        public virtual void Update(TEntity entity)
        {
            try
            {
                //Method 1  ->  using System.Data.Entity.Migrations;
                _db.Set<TEntity>().AddOrUpdate(entity);


                //Method 2
                //if (_db.Entry(entity).State == EntityState.Detached || _db.Entry(entity).State == EntityState.Modified)
                //{
                //    _db.Set<TEntity>().Attach(entity); //attach
                //    _db.Entry(entity).State = EntityState.Modified; //do it here
                //}
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.Data);
                Debug.WriteLine(exception.InnerException);
                Debug.WriteLine(exception.Source);
                Debug.WriteLine(exception.StackTrace);
            }
        }

        public virtual void Delete(TEntity entity)
        {
            try
            {
                if (_db.Entry(entity).State == EntityState.Detached || _db.Entry(entity).State == EntityState.Modified)
                {
                    _dbSet.Attach(entity);
                }

                _dbSet.Remove(entity);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.Data);
                Debug.WriteLine(exception.InnerException);
                Debug.WriteLine(exception.Source);
                Debug.WriteLine(exception.StackTrace);
            }
        }

        public virtual void Delete(object id)
        {
            try
            {
                var entity = GetById(id);
                Delete(entity);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.Data);
                Debug.WriteLine(exception.InnerException);
                Debug.WriteLine(exception.Source);
                Debug.WriteLine(exception.StackTrace);
            }
        }
    }
}
