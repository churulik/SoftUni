using System;

class StringsVariable
{
    static void Main()
    {
        string hello = "Hello";
        string world = "World";
        object helloWorld = hello + " " + world;
        Console.WriteLine("I want to say \"{0}\"!", helloWorld);

        string obj = (string)(helloWorld);
        Console.WriteLine("Hey, do you want to say {0}?", obj);
    }
}

