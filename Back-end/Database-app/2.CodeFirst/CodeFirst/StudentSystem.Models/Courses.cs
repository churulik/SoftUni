using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
    public class Courses
    {
        private ICollection<Students> students;

        public Courses()
        {
            this.students = new HashSet<Students>();
        }

        public int Id { get; set; }

        [Required]
        public string CourseName { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        

        public virtual ICollection<Students> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }
    }
}
