namespace Exceptions.Examination
{
    using System;

    public class ExamResult
    {
        private int grade;
        private int minGrade;
        private int maxGrade;
        private string comments;

        public ExamResult(int grade, int minGrade, int maxGrade, string comments)
        {
            this.Grade = grade;
            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
            this.Comments = comments;
        }

        public int Grade
        {
            get { return this.grade; }
            private set
            {
                IsNotNegative(value, this.grade, "Grade cannot be negative");

                this.grade = value;
            }
        }

        public int MinGrade
        {
            get { return this.minGrade; }
            private set
            {
                IsNotNegative(value, this.minGrade, "Min grade cannot be negative.");

                this.minGrade = value;
            }
        }

        public int MaxGrade
        {
            get { return this.maxGrade; }
            private set
            {
                if (value <= minGrade)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.maxGrade), "Max grade should be grater than min grade.");
                }

                this.maxGrade = value;
            }
        }

        public string Comments
        {
            get { return this.comments; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(this.comments), "The comments cannot be empty.");
                }

                this.comments = value;
            }
        }

        private void IsNotNegative(int value, int paramaterName, string message)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(paramaterName), message);
            }
        }
    }
}
