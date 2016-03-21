using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Twitter.Models
{
    public class Follow
    {

        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public string FollowerUsername { get; set; }

        [Required]
        public string FollowerFullName { get; set; }

        [Required]
        public int ChannelId { get; set; }

        public virtual Channel Channel{get; set;}
        
    }
}