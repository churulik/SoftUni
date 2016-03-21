using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BookShop.Models.Enum;

namespace BookShop.Models
{
    public class Book
    {
        private ICollection<Category> _categories;

        private ICollection<Purchase> _purchases; 

        public Book()
        {
            this._categories = new HashSet<Category>();
            this._purchases = new HashSet<Purchase>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        public string Title { get; set; }

        [StringLength(1000, ErrorMessage = "The max lenght is 1000 symbols.")]
        public string Description { get; set; }

        public Edition Edition { get; set; }

        public decimal Price { get; set; }
        
        public int Copies { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public AgeRestriction AgeRestriction { get; set; }

        public virtual Author Author { get; set; }

        public virtual ICollection<Category> Categories
        {
            get { return this._categories; }
            set { this._categories = value; }
        }

        public virtual ICollection<Purchase> Purchases
        {
            get { return this._purchases; }
            set { this._purchases = value; }
        }
    }
}
