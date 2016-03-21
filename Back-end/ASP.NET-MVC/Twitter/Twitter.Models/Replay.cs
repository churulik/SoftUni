using System.ComponentModel.DataAnnotations;

namespace Twitter.Models
{
    public class Replay
    {
        public int Id { get; set; }

        [Required]
        public string ReplayText { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int TweetId { get; set; }

        [Required]
        public string PostedOn { get; set; }

        [Required]
        public int ChannelId { get; set; }

        public Channel Channel { get; set; }
    }
}