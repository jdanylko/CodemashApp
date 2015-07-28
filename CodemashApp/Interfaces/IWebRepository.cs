using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CodemashApp.Interfaces
{
    public interface IWebRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        T GetById(string id);
        IEnumerable<T> GetRecords(string data);
        void Dispose();
    }
}