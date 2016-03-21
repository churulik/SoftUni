namespace _04.SoftUniLS.StudetnsTypes.CurrentStudentsTypes
{
    public class Online : CurrentStudent
    {
        public Online(string firstName, string lastName, int age, string stdNum, double avgGrd, string currentCourse) : 
            base(firstName, lastName, age, stdNum, avgGrd, currentCourse)
        {
        }
    }
}