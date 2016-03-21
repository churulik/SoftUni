namespace _04.SoftUniLS
{
    public class Student : Person
    {
        public string StudentNumber { get; set; }
        public double AvgGrade { get; set; }

        public Student(string firstName, string lastName, int age, string stdNum, double avgGrd) 
            : base(firstName, lastName, age)
        {
            this.StudentNumber = stdNum;
            this.AvgGrade = avgGrd;
        }
    }
}