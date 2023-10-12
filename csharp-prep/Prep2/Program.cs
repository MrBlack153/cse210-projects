using System;
using System.ComponentModel.Design;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("what is your grade porcentage?");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);  

        string letter = "";
        
        if (percent >= 90) 
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "c";
        }
        Console.WriteLine($"Youre grade is: {letter}") ;

        if (percent >= 70)
        {
            Console.WriteLine("You passed!");
        }
        else
        {
            Console.WriteLine("Better luck next time!");
        }


    }
}