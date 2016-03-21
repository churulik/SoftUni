using System.ComponentModel.DataAnnotations;

namespace News.Models
{
    public class News
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        public string Content { get; set; }

        [Required]
        public string PublishedDate { get; set; }
    }
}
