using Api_Crud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_Crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        List<Product> products = new List<Product> {
            new Product { Id = 1,Name = "Smartphones", Description = "Portable devices for communication, internet browsing, and apps."},
            new Product { Id = 2,Name = "Laptops", Description = "Portable computers with a keyboard and screen."},
            new Product { Id = 3,Name = "Tablets", Description = "Touchscreen devices for web browsing and media."},
            new Product { Id = 4,Name = "Cameras", Description = "Devices for capturing photos and videos."},

        };

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        { 
            var product = products.First(product => product.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            if(product == null)
            {
                return BadRequest();
            }

            var NewProduct = new Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
            };
            products.Add(NewProduct);

            return Ok(NewProduct);
        }
        [HttpPut("{id}")]
        public IActionResult Update(Product request, int id)
        {
            var product = products.FirstOrDefault(product => product.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            product.Name = request.Name;
            product.Description = request.Description;
            products.Add(product);
            return Ok(product);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(products => products.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            products.Remove(product);
            return Ok();
        }

    }
}
