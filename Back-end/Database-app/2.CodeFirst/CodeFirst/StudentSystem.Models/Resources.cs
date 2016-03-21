using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
    public class Resources
    {
        public int Id { get; set; }

        [Required]
        public string ResourcesName { get; set; }

        public TypeOfResources TypeOfResources { get; set; }

        [Required]
        public string Url { get; set; }

        public int CourseId { get; set; }

        public virtual Courses Course { get; set; }
    }
}
