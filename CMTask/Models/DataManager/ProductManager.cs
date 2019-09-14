using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMTask.Repository;

namespace CMTask.Models.DataManager
{
    public class ProductManager : IDataRepository<Product>
    {
        private readonly ProductContext _productContext;

        public ProductManager(ProductContext context)
        {
            _productContext = context;
        }

        public IEnumerable<Product> Get()
        {
            return _productContext.Products.ToList();
        }

        public Product Get(Guid id)
        {
            return _productContext.Products
                .FirstOrDefault(e => e.id == id);
        }

        public void Post(Product entity)
        {
            _productContext.Products.Add(entity);
            _productContext.SaveChanges();
        }

        public void Put(Product product, Product entity)
        {
            product.name = entity.name;
            product.price = entity.price;

            _productContext.SaveChanges();
        }

        public void Delete(Product product)
        {
            _productContext.Products.Remove(product);
            _productContext.SaveChanges();
        }
    }
}
