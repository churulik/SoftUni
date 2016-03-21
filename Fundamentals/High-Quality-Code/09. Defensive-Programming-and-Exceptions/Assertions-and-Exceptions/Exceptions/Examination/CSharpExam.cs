namespace Exceptions.Examination
{
    using System;

    public class CSharpExam : Exam
    {
        private int score;

        public CSharpExam(int score)
        {
            this.Score = score;
        }

        public int Score
        {
            get { return this.score; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(this.score), $"{value} => The score cannot be negative.");
                }

                this.score = value;
            }
        }

        public override ExamResult Check()
        {
            if (this.Score < 0 || this.Score > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(this.Score), "The score value has to be between 0 and 100.");
            }

            return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
        }
    }
}
