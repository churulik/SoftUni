using System.Collections.Generic;

namespace BookShop.Models
{
    public class Category
    {
        private ICollection<Book> _books;

        public Category()
        {
            this._books = new HashSet<Book>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Book> Books
        {
            get { return this._books; }
            set { this._books = value; }
        }
    }
}