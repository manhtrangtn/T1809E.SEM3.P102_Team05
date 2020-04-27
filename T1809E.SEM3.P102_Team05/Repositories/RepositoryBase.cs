using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using T1809E.SEM3.P102_Team05.Data;

namespace T1809E.SEM3.P102_Team05.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private AppDatabaseContext db;
        private IDbSet<T> dbSet;

        public RepositoryBase(AppDatabaseContext dbContext){
            this.db = dbContext;
            dbSet = db.Set<T>();
        }

        public T Add(T entity)
        {
            return dbSet.Add(entity);
        }

        public T Delete(T entity)
        {
            return dbSet.Remove(entity);
        }

        public T Delete(int id)
        {
            var entity = dbSet.Find(id);
            return dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>().AsQueryable();
        }

        public IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().Where<T>(predicate).AsQueryable<T>();
        }

        public async Task<T> FindById(int id)
        {
            return await db.Set<T>().FindAsync(id);

        }


        public IEnumerable<T> GetMultiPaging(IQueryable<T> queryOrder , string columnName, bool? isAscending, int index, int size)
        {
            int skipCount = index * size;
            IQueryable<T> _resetSet;
            _resetSet = queryOrder;

            if(!string.IsNullOrEmpty(columnName) && isAscending != null)
            {
                switch(isAscending)
                {
                    case true: _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
                        break;
                    case false: _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
                        break;
                }
            }else
            {
                _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            }

            return _resetSet.AsQueryable();
        }
     
    }
}