using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace T1809E.SEM3.P102_Team05.Services
{
    public interface IService<T> where T : class
    {
        Task<T> FindById(int id);
        T Add(T entity);

        void Update(T entity);

        T Delete(T entity);

        T Delete(int id);

        IEnumerable<T> GetAll();
    }
}