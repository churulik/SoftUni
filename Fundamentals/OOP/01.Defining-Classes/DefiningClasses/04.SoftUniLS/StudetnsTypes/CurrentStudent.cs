namespace _04.SoftUniLS.StudetnsTypes
{
    public class CurrentStudent : Student
    {
        public string CurrentCourse { get; set; }

        public CurrentStudent(string firstName, string lastName, int age, 
            string stdNum, double avgGrd, string currentCourse) : base(firstName, lastName, age, stdNum, avgGrd)
        {
            this.CurrentCourse = currentCourse;
        }
    }
}