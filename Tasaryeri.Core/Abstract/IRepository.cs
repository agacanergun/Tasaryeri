﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tasaryeri.Core.Interfaces
{
    public interface IRepository<T>
    {
        public IQueryable<T> GetAll();
        public IQueryable<T> GetAll(Expression<Func<T, bool>> exp);
        public T GetBy(Expression<Func<T, bool>> exp);
        public int Add(T entity);
        public int Update(T entity);
        public int Delete(T entity);
        public int AddRange(IEnumerable<T> entities);
    }
}
