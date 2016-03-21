using System;
using System.ComponentModel.DataAnnotations;
using BookShop.Models.Enum;

namespace BookShop.Services.Models
{
    public class UpdateBookViewModel
    {
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

        public int AuthorId { get; set; }

        public AgeRestriction AgeRestriction { get; set; }
    }
}