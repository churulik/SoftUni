using System.ComponentModel.DataAnnotations;

namespace Twitter.Models
{
    public class Tweet
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(140)]
        public string Content { get; set; }

        [Required]
        public string CreatedOn { get; set; }

        public string CreatedByUserId { get; set; }

        public virtual User CreatedByUser { get; set; }

        public string RetweetBy { get; set; }

        public int Favorites { get; set; }

        public int Replays { get; set; }

        [Required]
        public int ChannelId { get; set; }

        public virtual Channel Channel { get; set; }

    }
}