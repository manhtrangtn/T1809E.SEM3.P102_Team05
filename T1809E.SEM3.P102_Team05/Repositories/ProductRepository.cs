using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using T1809E.SEM3.P102_Team05.Data;
using T1809E.SEM3.P102_Team05.Models;

namespace T1809E.SEM3.P102_Team05.Repositories
{
    public class ProductRepository : RepositoryBase<Product>
    {
        private AppDatabaseContext db;
        public ProductRepository(AppDatabaseContext db) : base(db)
        {
           this.db = db;
        }


        public IQueryable<Product> QueryOrder (Expression<Func<Product, bool>> filter, string columName)
        {
            IQueryable<Product> _resetSet;

            _resetSet = filter != null ? db.Set<Product>().Where<Product>(filter).AsQueryable() : db.Set<Product>().AsQueryable();
            switch (columName)
            {
                case "Name": _resetSet = _resetSet.OrderBy(x => x.Name).AsQueryable();
                    break;
                case "Price": _resetSet = _resetSet.OrderBy(x => x.Price).AsQueryable();
                    break;
                case "CreateAt": _resetSet = _resetSet.OrderBy(x => x.CreateAt).AsQueryable();
                    break;
            }
            return _resetSet;
        }

    }
}