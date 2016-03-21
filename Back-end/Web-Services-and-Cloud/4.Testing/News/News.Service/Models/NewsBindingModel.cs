using System.ComponentModel.DataAnnotations;

namespace News.Service.Models
{
    public class NewsBindingModel
    {
        public string Title { get; set; }
       
        public string Content { get; set; }

        public string PublishedDate { get; set; }
    }
}