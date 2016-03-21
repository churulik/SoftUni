using System.ComponentModel.DataAnnotations;

namespace Twitter.Models
{
    public class Notification
    {
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string User { get; set; }

        [Required]
        public int ChannelId { get; set; }

        public virtual Channel Channel { get; set; }

        public bool Read { get; set; }
    }
}