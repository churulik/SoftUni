using System.ComponentModel.DataAnnotations;

namespace NewsDd.Models
{
    public class News
    {
        public int Id { get; set; }
        
        [ConcurrencyCheck]
        public string Text { get; set; }
    }
}
