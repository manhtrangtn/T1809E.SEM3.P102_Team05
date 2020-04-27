using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using T1809E.SEM3.P102_Team05.Models;

namespace T1809E.SEM3.P102_Team05.Services
{
    public interface IProductService : IService<Product>
    {
        IEnumerable<Product> GetListWithSearchAndPaging(string keyword, string sortType, 
            string sortBy, int pageNumber, int pageSize);
    }

}