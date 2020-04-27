using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using T1809E.SEM3.P102_Team05.Commons;
using T1809E.SEM3.P102_Team05.Data;
using T1809E.SEM3.P102_Team05.Models;
using T1809E.SEM3.P102_Team05.Models.ModelRequires;
using T1809E.SEM3.P102_Team05.Repositories;
using T1809E.SEM3.P102_Team05.Services;
using T1809E.SEM3.P102_Team05.Services.Implements;

namespace T1809E.SEM3.P102_Team05.Controllers
{
    [EnableCors(origins: Constant.ClientLocal, headers: "*", methods: "*")]
    public class ProductsController : ApiController
    {
        private AppDatabaseContext db;
        private IProductService productService;
        public ProductsController()
        {
            this.db = new AppDatabaseContext();
            var productRepo = new ProductRepository(db);
            this.productService = new ProductService(productRepo);
        }

        // GET: api/Products
        public IQueryable<Product> GetProducts(RequireModelGetAll requireModel)
        {
            if(requireModel == null)
            {
                return productService.GetAll() as IQueryable<Product>;
            }

            return productService.GetListWithSearchAndPaging(requireModel.keyword,
                requireModel.sortType, requireModel.sortBy, requireModel.pageNumber, requireModel.pageSize) as IQueryable<Product>;
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> GetProduct(int id)
        {
            Product product = await productService.FindById(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public async Task<IHttpActionResult> PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            productService.Update(product);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            productService.Add(product);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public async Task<IHttpActionResult> DeleteProduct(int id)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            productService.Delete(id);
            await db.SaveChangesAsync();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.Id == id) > 0;
        }
    }
}