using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your firts name?");
        string first = Console.ReadLine ();
        
        Console.Write("What is your second name?");
        string second = Console.ReadLine ();

        Console.WriteLine ($"Your Name is:{second}, {first} {second}");


    }
}