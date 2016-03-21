using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Twitter.Models
{
    public class Favorite
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public int TweetId { get; set; }

        public Tweet Tweet { get; set; }
        
    }
}