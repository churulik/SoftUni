using System;

class EmployeeData
{
    static void Main(string[] args)
    {
        string firstName = "John";
        string lastName = "Malkovich";
        byte age = 44;
        string gender = "m";
        ulong personalID = 8306112507;
        uint uniqueEmployeeNum = 27569999;

        Console.WriteLine("First Name: {0}", firstName);
        Console.WriteLine("Last Name: {0}", lastName);
        Console.WriteLine("Age: {0}", age);
        Console.WriteLine("Gender: {0}", gender);
        Console.WriteLine("Personal ID Number: {0}", personalID);
        Console.WriteLine("Unique employee number: {0}", uniqueEmployeeNum);
    }
}
