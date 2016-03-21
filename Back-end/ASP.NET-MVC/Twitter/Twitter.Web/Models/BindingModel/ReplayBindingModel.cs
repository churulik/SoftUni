using System.ComponentModel.DataAnnotations;

namespace Twitter.Web.Models.BindingModel
{
    public class ReplayBindingModel
    {
       
        [MinLength(1, ErrorMessage = "Invalid text")]
        public string ReplayText { get; set; }

        public int TweetId { get; set; }
    }
}