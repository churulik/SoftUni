using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsShop.Models
{
    public class User
    {
        private ICollection<User> friends;
        private ICollection<Product> products;

        public User()
        {
            this.friends = new HashSet<User>();
            this.products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string LastName { get; set; }

        public int Age { get; set; }

        public virtual ICollection<User> Friends
        {
            get { return this.friends; }
            set { this.friends = value; }
        }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
    }
}
