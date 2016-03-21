using System;

namespace _04.StudentClass
{
    class Test
    {
        static void Main()
        {
            var student = new Student("Peter", 22);
            student.PropertyChange += (sender, eventArgs) =>
            {
                Console.WriteLine("Property changed: {0} (from {1} to {2})",
                    eventArgs.PropertyName, eventArgs.OldValue, eventArgs.NewValue);
            };
            student.Name = "Maria";
            student.Age = 19;
        }
    }
}
