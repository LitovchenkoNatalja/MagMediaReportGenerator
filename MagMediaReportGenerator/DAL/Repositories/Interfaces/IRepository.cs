//created as an example
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MagMediaReportGenerator.DAL.Repositories.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T FirstOrDefault(Expression<Func<T, bool>> predicate);
        T SingleOrDefault(Expression<Func<T, bool>> predicate);
        bool Any(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Delete(T entity);
        void Delete(IEnumerable<T> entities);
        void Edit(T entity);
    }
}