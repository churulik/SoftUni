using System.ComponentModel.DataAnnotations;

namespace Twitter.Web.Models.BindingModel
{
    public class ReportBindingModel
    {
        [Required(ErrorMessage = "Please select one of the reports.")]
        public string ReportProblem { get; set; }

        public int TweetId { get; set; }
    }
}