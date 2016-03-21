using System.Linq;
using System.Web.Http;
using BookShop.Data;
using BookShop.Models;

namespace BookShop.Services.Controllers
{
    [Authorize]
    [RoutePrefix("api/Authors")]
    public class AuthorsController : ApiController
    {
        private readonly BookShopEntities _context = new BookShopEntities();
       
        
        public IHttpActionResult GetBook(int id)
        {
            var getBookId = _context.Books.Find(id);

            if (getBookId == null)
            {
                return NotFound();
            }

            var book = _context.Books
                .Where(b => b.Id == id)
                .Select(b => new
                {
                    BookId = b.Id,
                    BookTitle = b.Title
                });
           
            return Ok(book);
        }

        public string PostAuthor(string firstName, string lastName)
        {
            var author = new Author()
            {
                FirstName = firstName,
                LastName = lastName
            };
            _context.Authors.Add(author);
            _context.SaveChanges();

            return string.Format("Successfully add new author with name: {0} {1}", author.FirstName, author.LastName);
        }

        public string PostAuthor(string lastName)
        {
            var author = new Author(){
               
                LastName = lastName
            };
            _context.Authors.Add(author);
            _context.SaveChanges();

            return string.Format("Successfully add new author with last name: {0}", author.LastName);
        }

        [Route("{id}/books")]
        public IHttpActionResult GetBookByAuthorId(int id)
        {
            var getAuthorId = _context.Books.First(b => b.Author.Id == id);

            if (getAuthorId == null)
            {
                return NotFound();
            }

            var book = _context.Books
                .Where(b => b.Author.Id == id)
                .Select(b => new
                {
                    b.Title,
                    b.Description,
                    b.Edition,
                    b.Price,
                    b.Copies,
                    b.ReleaseDate,
                    b.AgeRestriction,
                    AuthorId = b.Author.Id,
                    AuthorName = b.Author.FirstName + " " + b.Author.LastName,
                    Categroy = b.Categories.Select(c => c.Name)
                });

            return Ok(book);
        }
    }
}
