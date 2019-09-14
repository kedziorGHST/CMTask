using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CMTask.Models;
using CMTask.Repository;

namespace CMTask.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : ControllerBase
    {
        private readonly IDataRepository<Product> _dataRepository;

        public ProductsController(IDataRepository<Product> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Products
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Product> products = _dataRepository.Get();
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            Product product = _dataRepository.Get(id);

            if (product == null)
            {
                return NotFound("Product record couldn't be found.");
            }

            return Ok(product);
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult GuidPost([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product is null.");
            }

            _dataRepository.Post(product);
            return CreatedAtRoute(
                "Get",
                new {id = product.id}, product.id);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product is null.");
            }

            Product productToUpdate = _dataRepository.Get(id);
            if (productToUpdate == null)
            {
                return NotFound("The Product record couldn't be found.");
            }

            _dataRepository.Put(productToUpdate, product);
            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            Product product = _dataRepository.Get(id);
            if (product == null)
            {
                return NotFound("The Product record couldn't be found.");
            }

            _dataRepository.Delete(product);
            return NoContent();
        }

    }
}