using System.ComponentModel.DataAnnotations;

namespace Twitter.Models
{
    public class Report
    {
        public int Id { get; set; }

        [Required]
        public string ReportProblem { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public int TweetId { get; set; }
    }
}