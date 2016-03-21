using System.Linq;
using System.Web.Http;
using BookShop.Data;
using BookShop.Models;

namespace BookShop.Services.Controllers
{
    [Authorize]
    public class CategoriesController : ApiController
    {
        private readonly BookShopEntities _context = new BookShopEntities();

        public IHttpActionResult GetCategories()
        {
            var categories = _context.Categories.Select(c => new {c.Id, c.Name});

            return Ok(categories);
        }

        public IHttpActionResult GetCategory(int id)
        {
            var findCategoryId = _context.Categories.Find(id);
            
            if (findCategoryId == null)
            {
                return NotFound();
            }

            var category = _context.Categories
                .Where(c => c.Id == id)
                .Select(c => new { c.Id, c.Name });

            return Ok(category);
        }

        [HttpPut]
        public IHttpActionResult UpdateCategory(int id, string name)
        {
            var findCategoryId = _context.Categories.Find(id);

            if (findCategoryId == null)
            {
                return NotFound();
            }
            var checkForDuplicates = _context.Categories;

            foreach (var duplicate in checkForDuplicates)
            {
                if (duplicate.Name == name)
                {
                    return BadRequest("The category name alredy exists.");
                }
            }
            var category = _context.Categories.First(c => c.Id == id);

            category.Name = name;
            _context.SaveChanges();

            return Ok("The category name was update.");
        }

        public IHttpActionResult DeleteCategory(int id)
        {
            var findCategoryId = _context.Categories.Find(id);

            if (findCategoryId == null)
            {
                return NotFound();
            }

            var category = _context.Categories.First(c => c.Id == id);
            
            _context.Categories.Remove(category);
            _context.SaveChanges();

            return Ok("The category was delete.");
        }

        public IHttpActionResult PostCategory(string name)
        {
            var checkForDuplicates = _context.Categories;

            foreach (var duplicate in checkForDuplicates)
            {
                if (duplicate.Name == name)
                {
                    return BadRequest("The category name alredy exists.");
                }
            }

            var category = new Category
            {
                Name = name
            };

            _context.Categories.Add(category);
            _context.SaveChanges();

            return Ok("The category was add.");
        }
    }
}
