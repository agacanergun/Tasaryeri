using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.Core.Interfaces;
using Tasaryeri.DAL.Contexts;

namespace Tasaryeri.DAL.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : class
    {

        SqlContext db;
        public SqlRepository(SqlContext db)
        {
            this.db = db;
        }

        public int Add(T entity)
        {

            db.Add(entity);
            var x = db.SaveChanges();
            return x;
        }

        public void Delete(T entity)
        {
            db.Remove(entity);
            db.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return db.Set<T>();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Where(exp);
        }

        public T GetBy(Expression<Func<T, bool>> exp)
        {

            return db.Set<T>().FirstOrDefault(exp);

        }

        public void Update(T entity)
        {
            var updatedEntity = db.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
