using System;

class PrintCompanyInfo
{
    static void Main()
    {
        Console.Write("Company name: ");
        string companyName = Console.ReadLine();
        Console.Write("Company address: ");
        string compnanyAddress = Console.ReadLine();
        Console.Write("Phone number: ");
        string phoneNum = Console.ReadLine();
        Console.Write("Fax number: ");
        string faxNum = Console.ReadLine();
        Console.Write("Web site: ");
        string web = Console.ReadLine();
        Console.Write("Manager first name: ");
        string firstName = Console.ReadLine();
        Console.Write("Manager last name: ");
        string lastName = Console.ReadLine();
        Console.Write("Manager age: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Manager phone number: ");
        string phoneManager = Console.ReadLine();
        Console.WriteLine(companyName);
        Console.WriteLine("Address: {0}", compnanyAddress);
        Console.WriteLine("Tel.: {0}", phoneNum);
        Console.WriteLine("Fax: {0}", faxNum);
        Console.WriteLine("Web site: {0}", web);
        Console.WriteLine("Manager: " + firstName + "  " + lastName + " (age: {0}, tel.: {1})", age, phoneManager);
    }
}
