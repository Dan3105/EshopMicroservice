using EshopMicroservice.Models;
using EshopMicroservice.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EshopMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public IActionResult Get()
        {
            var products = productRepository.GetProducts();
            return new OkObjectResult(products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}", Name="Get")]
        public IActionResult Get(int id)
        {
            var product = productRepository.GetProduct(id);
            return new OkObjectResult(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] Product value)
        {
            using (var scope= new TransactionScope())
            {
                productRepository.CreateProduct(value);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new {id=value.Id }, value);
            }
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product value)
        {
            if (value != null)
            {
                using (var scope = new TransactionScope())
                {
                    productRepository.UpdateProduct(value);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            productRepository.DeleteProduct(id);
            return new OkResult();
        }
    }
}
