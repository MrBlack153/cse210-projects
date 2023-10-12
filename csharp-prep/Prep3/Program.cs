using System;

class JournalEntry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }
}

class Journal
{
    private List<JournalEntry> entries;

    public Journal()
    {
        entries = new List<JournalEntry>();
    }

    public void AddEntry(string prompt, string response)
    {
        JournalEntry entry = new JournalEntry
        {
            Prompt = prompt,
            Response = response,
            Date = DateTime.Now
        };
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (JournalEntry entry in entries)
        {
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (JournalEntry entry in entries)
            {
                writer.WriteLine($"Prompt: {entry.Prompt}");
                writer.WriteLine($"Response: {entry.Response}");
                writer.WriteLine($"Date: {entry.Date}");
                writer.WriteLine();
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string prompt = line.Substring(line.IndexOf(":") + 1).Trim();
                string response = reader.ReadLine().Substring(line.IndexOf(":") + 1).Trim();
                DateTime date = DateTime.Parse(reader.ReadLine().Substring(line.IndexOf(":") + 1).Trim());

                JournalEntry entry = new JournalEntry
                {
                    Prompt = prompt,
                    Response = response,
                    Date = date
                };
                entries.Add(entry);

                reader.ReadLine(); // Read the empty line
            }
        }
    }
}

class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        bool running = true;
        while (running)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Answer the following prompt:");
                    Console.WriteLine();

                    // List of prompts
                    List<string> prompts = new List<string>
                    {
                        "Who was the most interesting person I interacted with today?",
                        "What was the best part of my day?",
                        "How did I see the hand of the Lord in my life today?",
                        "What was the strongest emotion I felt today?",
                        "If I had one thing I could do over today, what would it be?"
                    };

                    // Display a random prompt
                    Random random = new Random();
                    int randomIndex = random.Next(prompts.Count);
                    string prompt = prompts[randomIndex];
                    Console.WriteLine($"Prompt: {prompt}");

                    // Get the response from the user
                    Console.Write("Response: ");
                    string response = Console.ReadLine();

                    // Add the entry to the journal
                    journal.AddEntry(prompt, response);

                    Console.WriteLine();
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("Enter the filename to save the journal to: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    Console.WriteLine("Journal saved successfully.");
                    Console.WriteLine();
                    break;

                case "4":
                    Console.Write("Enter the filename to load the journal from: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    Console.WriteLine("Journal loaded successfully.");
                    Console.WriteLine();
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    Console.WriteLine();
                    break;
            }
        }
    }
}