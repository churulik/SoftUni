namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course
    {
        private string courseName;
        private string teacherName;

        protected Course(string courseName)
        {
            this.CourseName = courseName;
        }

        protected Course(string courseName, string teacherName)
            : this(courseName)
        {
            this.TeacherName = teacherName;
        }

        protected Course(string courseName, string teacherName, IList<string> students)
            : this(courseName, teacherName)
        {
            this.Students = students;
        }

        public string CourseName
        {
            get { return this.courseName; }
            set
            {
                this.IsNullOrWhiteSpace(value, this.courseName, "The CourseName cannot be empty.");

                this.courseName = value;
            }
        }

        public string TeacherName
        {
            get { return this.teacherName; }

            set
            {
                this.IsNullOrWhiteSpace(value, this.teacherName, "The teacher CourseName cannot be empty.");

                this.teacherName = value;
            }
        }

        public IList<string> Students { get; set; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(" { CourseName = ");
            result.Append(this.CourseName);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            return result.ToString();
        }

        private void IsNullOrWhiteSpace(string value, string parametarName, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(parametarName), message);
            }
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }

            return "{ " + string.Join(", ", this.Students) + " }";
        }
    }
}