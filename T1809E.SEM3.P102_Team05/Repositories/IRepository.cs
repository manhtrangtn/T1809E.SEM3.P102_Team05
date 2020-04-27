using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace T1809E.SEM3.P102_Team05.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> FindById(int id);

        T Add(T entity);

        void Update(T entity);

        T Delete(T entity);

        T Delete(int id);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate);

        IEnumerable<T> GetMultiPaging(IQueryable<T> queryOrder, string columnName, bool? isAscending, int index, int size);
    }
}