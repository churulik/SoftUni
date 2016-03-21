namespace _04.SoftUniLS.StudetnsTypes.CurrentStudentsTypes
{
    public class Onsite : CurrentStudent
    {
        public int NumberOfVisits { get; set; }


        public Onsite(string firstName, string lastName, int age, string stdNum, double avgGrd, string currentCourse) : 
            base(firstName, lastName, age, stdNum, avgGrd, currentCourse)
        {
        }
    }
}