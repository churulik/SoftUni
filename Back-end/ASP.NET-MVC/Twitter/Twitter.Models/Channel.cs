using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Twitter.Models
{
    public class Channel
    {
        private ICollection<Tweet> tweets;

        public Channel()
        {
            this.tweets = new HashSet<Tweet>();
        } 


        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string FullName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Username { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(250)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public virtual ICollection<Tweet> Tweets
        {
            get { return this.tweets; }
            set { this.tweets = value; }
        }
    }
}