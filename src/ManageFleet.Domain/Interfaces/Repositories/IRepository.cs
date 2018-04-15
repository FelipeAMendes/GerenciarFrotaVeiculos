using ManageFleet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ManageFleet.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        TEntity Insert(TEntity obj);

        TEntity Update(TEntity obj);

        void Remove(int id);

        IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate);

        int SaveChanges();
    }
}