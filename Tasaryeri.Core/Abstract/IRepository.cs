using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tasaryeri.Core.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> exp);
        T GetBy(Expression<Func<T, bool>> exp);
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
        int AddRange(IEnumerable<T> entities);
        int DeleteRange(IEnumerable<T> entities);
    }
}