using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopAzure.Models;

namespace ShopAzure.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly Context _context;

        public ProductController(Context context)
        {
            _context = context;
            context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return _context.Products.ToList();
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<Product>> GetProductsById(string id)
        {
            return _context.Products.First(x => x.Id == id);
        }

        [HttpGet("/category/{categoryId}")]
        public async Task<ActionResult<List<Product>>> GetProductsByCategory(string id)
        {
            return _context.Products.Where(x => x.CategoryId == id).ToList();
        }

        [HttpPost]
        public async Task<ActionResult> PostProducts(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> PutProducts(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProducts(string id)
        {
            _context.Products.Remove(_context.Products.First(x => x.Id == id));
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
