using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T1809E.SEM3.P102_Team05.Models;
using T1809E.SEM3.P102_Team05.Repositories;

namespace T1809E.SEM3.P102_Team05.Services.Implements
{
    public class ProductService : IProductService
    {
        private ProductRepository ProductRepo;

        public ProductService(ProductRepository repo)
        {
            this.ProductRepo = repo;
        }

        public Product Add(Product entity)
        {
            return ProductRepo.Add(entity);
        }

        public Product Delete(Product entity)
        {
            return ProductRepo.Delete(entity);
        }

        public Product Delete(int id)
        {
            return ProductRepo.Delete(id);
        }

        public void Update(Product entity)
        {
            ProductRepo.Update(entity);
        }

        public IEnumerable<Product> GetAll()
        {
            return ProductRepo.GetAll();
        }

        public async Task<Product> FindById(int id)
        {
            return await ProductRepo.FindById(id);
        }

        public IEnumerable<Product> GetListWithSearchAndPaging(string keyword, string sortType, string sortBy, int pageNumber, int pageSize)
        {
            bool isAscending;
            string columnName;
            IEnumerable<Product> products;
            ValidatePageArgs(keyword, sortType, sortBy, pageNumber, pageSize);

            isAscending = sortType.Equals("asc") ? true : false;

            columnName = sortBy.Equals("name") ? "Name" : sortBy.Equals("price") ? "Price" : "CreateAt";

            if (string.IsNullOrEmpty(keyword))
            {
                products = ProductRepo.GetMultiPaging(ProductRepo
                    .QueryOrder(null, columnName), sortBy, isAscending, pageNumber, pageSize);
            }else
            {
                products = ProductRepo.GetMultiPaging(ProductRepo
                    .QueryOrder(x => x.Name.Contains(keyword), columnName), sortBy, isAscending, pageNumber, pageSize);
            }

            return products;
        }


        private void ValidatePageArgs(string keyword, string sortType, string sortBy, int pageNumber, int pageSize)
        {
            if (!string.IsNullOrEmpty(sortType))
            {
                if(!sortType.Equals("asc") && !sortType.Equals("desc"))
                {
                    throw new ArgumentException("sortType invalid!");

                }
            }

            if (!string.IsNullOrEmpty(sortBy))
            {
                if (!sortBy.Equals("name") && sortBy.Equals("price") && !sortBy.Equals("createdDate"))
                {
                    throw new ArgumentException("sortBy invalid!");
                }
            }

            else if (pageSize <= 0 || pageNumber <= 0)
            {
                throw new ArgumentException("pageSize or pageNumber invalid!");
            }
        }


    }
}