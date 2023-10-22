using System;

class Program
{
    static void Main(string[] args)
    {
        string scriptureReference = "John 3:16";
        string scriptureText = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";

        Console.WriteLine("Press Enter to reveal hidden words. Type 'quit' to exit.");
        Console.WriteLine();

        while (true)
        {
            Console.ReadLine();

            Console.Clear();
            Console.WriteLine($"{scriptureReference}: {scriptureText}");
            Console.WriteLine();

            Console.WriteLine("Press Enter to reveal hidden words. Type 'quit' to exit.");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scriptureText = HideRandomWords(scriptureText);
        }
    }

    static string HideRandomWords(string scriptureText)
    {
        string[] words = scriptureText.Split(' ');
        Random random = new Random();

        foreach (string word in words)
        {
            if (!string.IsNullOrWhiteSpace(word) && !word.StartsWith("[HIDDEN]"))
            {
                int randomIndex = random.Next(words.Length);
                words[randomIndex] = "[HIDDEN]";
            }
        }

        return string.Join(" ", words);
    }
}