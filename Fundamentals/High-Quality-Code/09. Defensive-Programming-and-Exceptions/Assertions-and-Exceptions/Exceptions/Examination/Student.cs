namespace Exceptions.Examination
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        private string firstName;
        private string lastName;

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Student(string firstName, string lastName, IList<Exam> exams) : this (firstName, lastName)
        {
            this.Exams = exams;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                IsNullOrWhiteSpace(value, this.firstName, "Invalide first name!");

                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            set
            {
                IsNullOrWhiteSpace(value, this.lastName, "Invalid last name!");

                this.lastName = value;
            }
        }

        public IList<Exam> Exams { get; set; }

        public IList<ExamResult> CheckExams()
        {
            if (this.Exams == null)
            {
                throw new ArgumentNullException(nameof(this.Exams), "The exam list cannot be empty. Enter at least one exam.");
            }

            if (this.Exams.Count == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(this.Exams), "The student has no exams!");
            }

            IList<ExamResult> results = new List<ExamResult>();
            for (int i = 0; i < this.Exams.Count; i++)
            {
                results.Add(this.Exams[i].Check());
            }

            return results;
        }

        public double CalcAverageExamResultInPercents()
        {
            if (this.Exams == null){
                
                throw new ArgumentNullException(nameof(this.Exams), "Cannot calculate average - the exam list is empty. Enter at least one exam.");
            }

            if (this.Exams.Count == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(this.Exams), "The student has no exams!");
            }

            double[] examScore = new double[this.Exams.Count];
            IList<ExamResult> examResults = CheckExams();
            for (int i = 0; i < examResults.Count; i++)
            {
                examScore[i] = 
                    ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                    (examResults[i].MaxGrade - examResults[i].MinGrade);
            }

            return examScore.Average();
        }

        private void IsNullOrWhiteSpace(string value, string parametarName, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(parametarName), message);
            }
        }
    }
}
