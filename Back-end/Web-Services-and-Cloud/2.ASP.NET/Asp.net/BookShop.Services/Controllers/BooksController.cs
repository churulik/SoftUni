using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData;
using BookShop.Data;
using BookShop.Models;
using BookShop.Models.Enum;
using BookShop.Services.Models;
using Microsoft.AspNet.Identity;

namespace BookShop.Services.Controllers
{
    [Authorize]
    [RoutePrefix("api/Books")]
    public class BooksController : ApiController
    {
        private readonly BookShopEntities _context = new BookShopEntities();

        //Task 1

        public IHttpActionResult GetBook(int id)
        {
            var book = _context.Books
                .Where(b => b.Id == id)
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

        //Using linq
        [HttpGet]
        public IHttpActionResult SearchBook(string search)
        {
            var book = _context.Books
                .Where(b => b.Title.Contains(search))
                .OrderBy(b => b.Title)
                .Take(10)
                .Select(b => new
                {
                    b.Id,
                    b.Title
                });

            return Ok(book);
        }

        //Using Odata
        [HttpGet]
        [EnableQuery]
        public IQueryable<SearchBookViewModel> SearchBook()
        {
            return _context.Books.Select(b => new SearchBookViewModel()
            {
                Id = b.Id,
                Title = b.Title
            });

            //localhost:57863/api/Books?$filter=contains(Title, 'c')&$top=10&$orderby=Title
        }


        [HttpPut]
        public IHttpActionResult UpdateBook(int id, [FromUri]UpdateBookViewModel model)
        {

            var getBookId = _context.Books.Find(id);
            var getAuthorId = _context.Authors.Find(model.AuthorId);

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (getBookId == null)
            {
                return BadRequest("There is no such a book id.");
            }

            if (model.Price < 0)
            {
                return BadRequest("The price cannot be negative.");
            }

            if (model.Copies < 0)
            {
                return BadRequest("The copies cannot be negative.");
            }

            if (!Enum.IsDefined(typeof(Edition), model.Edition))
            {
                return BadRequest("There is no such an edition.");
            }

            if (!Enum.IsDefined(typeof(AgeRestriction), model.AgeRestriction))
            {
                return BadRequest("There is no such an age restriction.");
            }
    

            if (getAuthorId == null)
            {
                return BadRequest("There is no such an author id.");
            }

            var updateBook = _context.Books.First(b => b.Id == id);

            updateBook.Title = model.Title;
            updateBook.Description = model.Description;
            updateBook.Price = model.Price;
            updateBook.Copies = model.Copies;
            updateBook.Edition = model.Edition;
            updateBook.AgeRestriction = model.AgeRestriction;
            updateBook.ReleaseDate = model.ReleaseDate;
            updateBook.Author.Id = model.AuthorId;

            _context.SaveChanges();

            return Ok("The book is update it.");
        }

        public IHttpActionResult DeleteBook(int id)
        {
            var findId = _context.Books.Find(id);

            if (findId == null)
            {
                return BadRequest("The id was not found.");
            }

            var book = _context.Books.First(b => b.Id == id);

            _context.Books.Remove(book);
            _context.SaveChanges();

            return Ok(string.Format("The book was delete."));
        }

        public IHttpActionResult PostBook([FromUri]PostBookBindigModel book)
        {


            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (book.Price < 0)
            {
                return BadRequest("The price cannot be negative.");
            }

            if (book.Copies < 0)
            {
                return BadRequest("The copies cannot be negative.");
            }

            if (!Enum.IsDefined(typeof(Edition), book.Edition))
            {
                return BadRequest("There is no such an edition.");
            }

            if (!Enum.IsDefined(typeof(AgeRestriction), book.AgeRestriction))
            {
                return BadRequest("There is no such an age restriction.");
            }

            var getAuthorId = _context.Authors.Find(book.AuthorId);

            if (getAuthorId == null)
            {
                return BadRequest("There is no such an author id.");
            }

            var newBook = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                Price = book.Price,
                Edition = book.Edition,
                AgeRestriction = book.AgeRestriction,
                ReleaseDate = book.ReleaseDate,
                Categories = new HashSet<Category>() { new Category() { Name = book.CategoryName } }
            };

            _context.Books.Add(newBook);
            _context.SaveChanges();

            return Ok("The book was add.");
        }

        //Task 2

        [Route("buy/{id}")]
        [HttpPut]
        public IHttpActionResult BuyBook(int id)
        {
            //Get the current login user
            var currentUserId = User.Identity.GetUserId();
            var currentUser = _context.Users.FirstOrDefault(x => x.Id == currentUserId);

            var book = _context.Books.First(b => b.Id == id);

            if (book.Copies == 0)
            {
                return BadRequest("There is no more copies.");
            }

            book.Copies = book.Copies - 1;

            var purchase = new Purchase()
            {
                ApplicationUser = currentUser,
                Book = book,
                DateOfPurchase = DateTime.Now,
                IsRecalled = false,
            };

            _context.Purchases.Add(purchase);

            _context.SaveChanges();
            
            return Ok("The book has been purchased.");
        }

        [Route("recall/{id}")]
        [HttpPut]
        public IHttpActionResult RecallBook(int id)
        {
            var pruchasedBook = _context.Purchases.First(p => p.Id == id);

            var days = (DateTime.Now - pruchasedBook.DateOfPurchase).TotalDays;
            if (days < 30)
            {
                var book = _context.Books.First(b => b.Id == pruchasedBook.Id);

                book.Copies = book.Copies + 1;
                pruchasedBook.IsRecalled = true;
                _context.SaveChanges();

                return Ok("The book has been recalled.");
            }

            return Ok("The book has not been recalled.");
        }
        [Route("{username}/purchases")]
        public IHttpActionResult GetDataAboutPurchases(string username)
        {
            var purchase = _context.Purchases.Where(p => p.ApplicationUser.UserName == username)
                .Select(p => new
                {
                    User = p.ApplicationUser.UserName,
                    BookTitle = p.Book.Title,
                    BookPrice = p.Book.Price,
                    p.DateOfPurchase,
                    p.IsRecalled
                });
            return Ok(purchase);
        }
    }
}
