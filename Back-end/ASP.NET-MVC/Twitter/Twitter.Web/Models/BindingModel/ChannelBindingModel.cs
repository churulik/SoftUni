using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Twitter.Web.Models.BindingModel
{
    public class ChannelBindingModel
    {

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [DisplayName("Full name")]
        public string FullName { get; set; }

        [Required]
        [RegularExpression(@"(\S)+", ErrorMessage = "White space is not allowed.")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Username { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string Description { get; set; }

        [RegularExpression(@"^.*\.jpg$|^.*\.jpeg$|^.*\.png$", ErrorMessage = "Invalide image. Valid image has to end on '.jpg', '.jpeg' or '.png'")]
        public string ImageUrl { get; set; }
    }
}