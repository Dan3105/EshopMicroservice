using EshopMicroservice.Models;
using EshopMicroservice.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
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
        public IActionResult Post([FromBody] ProductDTO product)
        {
            using (var scope= new TransactionScope())
            {
                var value = new Product
                {
                    Name = product.Name,
                    Description = product.description,
                    Price = product.price,
                    CategoryId = product.CategoryId
                };
                productRepository.CreateProduct(value);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new {id=value.Id }, value);
            }
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProductDTO value)
        {
            if (value != null)
            {
                var foundProduct= productRepository.GetProduct(id);
                if (foundProduct == null)
                {
                    return NotFound();
                }
                foundProduct.Name = value.Name;
                foundProduct.Description = value.description;
                foundProduct.Price = value.price;
                foundProduct.CategoryId = value.CategoryId;

                using (var scope = new TransactionScope())
                {
                    productRepository.UpdateProduct(foundProduct);
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

    public class ProductDTO
    {
        [Required]
        public string Name { set; get; }
        public string description { set; get; }
        [Required]
        public float price { set; get; }
        [Required]
        public int CategoryId { set; get; }
    }
}
