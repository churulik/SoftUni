using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Twitter.Web.Models.ViewModel
{
    public class ChannelViewModel
    {
        public int ChannelId { get; set; }
        [DisplayName("Full name")]
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}