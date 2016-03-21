using StudentSystem.Models;

namespace _02.ReformYourOwnCode.StudeSystemReformatted.Models
{
    public class Resource
    {
        public int Id { get; set; }

        [Required]
        public string ResourcesName { get; set; }

        public TypeOfResources TypeOfResources { get; set; }

        [Required]
        public string Url { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
