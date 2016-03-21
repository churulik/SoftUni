using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
    public class Students
    {
        private ICollection<Courses> courses;

        public Students()
        {
            this.courses = new HashSet<Courses>();
        }

        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday { get; set; }

        public virtual ICollection<Courses> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }
    }
}
