using System;

namespace Methods
{
    public static class StudentMethods
    {
        public static bool IsOlderThan(Student firstStudent, Student secondStudent)
        {
            DateTime firstDate =
                DateTime.Parse(firstStudent.OtherInfo.Substring(firstStudent.OtherInfo.Length - 10));
            DateTime secondDate =
                DateTime.Parse(secondStudent.OtherInfo.Substring(secondStudent.OtherInfo.Length - 10));

            return firstDate > secondDate;
        }
    }
}