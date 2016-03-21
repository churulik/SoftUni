using System.ComponentModel.DataAnnotations;

namespace BookShop.Services.Models
{
    public class SearchBookViewModel
    {
        public int Id { get; set; }
      
        public string Title { get; set; }
    }
}