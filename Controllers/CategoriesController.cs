using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopAzure.Models;

namespace ShopAzure.Controllers
{
    [Route("categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly Context _context;

        public CategoriesController(Context context)
        {
            _context = context;
            context.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            return _context.Categories.ToList();
        }

        [HttpGet("{categoryId}")]
        public async Task<ActionResult<Category>> GetCategoryById(string id)
        {
            return _context.Categories.First(x => x.Id == id);
        }

        [HttpPost]
        public async Task<ActionResult> PostCategories(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutCategory(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategories(string id)
        {
            _context.Categories.Remove(_context.Categories.First(x => x.Id == id));
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
