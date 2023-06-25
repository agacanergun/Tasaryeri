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
            try
            {
                db.Add(entity);
                var response = db.SaveChanges();
                return response;
            }
            catch (Exception)
            {

                throw;
            }        }

        public int Delete(T entity)
        {
            try
            {
                db.Remove(entity);
                var response = db.SaveChanges();
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                return db.Set<T>();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> exp)
        {
            try
            {
                return db.Set<T>().Where(exp);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public T GetBy(Expression<Func<T, bool>> exp)
        {

            try
            {
                return db.Set<T>().FirstOrDefault(exp);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int Update(T entity)
        {
            try
            {
                var updatedEntity = db.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                var response = db.SaveChanges();
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int AddRange(IEnumerable<T> entities)
        {
            try
            {
                db.AddRange(entities);
                var response = db.SaveChanges();
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int DeleteRange(IEnumerable<T> entities)
        {
            try
            {
                db.RemoveRange(entities);
                var response = db.SaveChanges();
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
