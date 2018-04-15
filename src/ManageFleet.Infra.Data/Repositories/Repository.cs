using ManageFleet.Domain.Entities;
using ManageFleet.Domain.Interfaces.Repositories;
using ManageFleet.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ManageFleet.Infra.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected ManageFleetContext _context;
        protected DbSet<TEntity> _dbSet;

        protected Repository(ManageFleetContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public virtual TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }
        
        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual TEntity Insert(TEntity obj)
        {
            var objReturn = _dbSet.Add(obj);
            return objReturn.Entity;
        }
        
        public virtual TEntity Update(TEntity obj)
        {
            var entry = _context.Entry(obj);

            if (entry.State is EntityState.Detached)
            {
                _dbSet.Attach(obj);
                entry.State = EntityState.Modified;
            }

            return obj;
        }
        
        public virtual void Remove(int id)
        {
            var obj = GetById(id);
            _dbSet.Remove(obj);
        }
        
        public virtual IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public virtual int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}