using System;

namespace Twitter.Web.Models.BindingModel
{
    public class RetweetBindigModel
    {
        public int Id { get; set; }

        public int ChannelId { get; set; }

        public string CreatedOn { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public int TweetId { get; set; }
    }
}