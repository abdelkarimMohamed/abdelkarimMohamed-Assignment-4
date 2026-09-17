namespace AcademyScheduleAnalyzer;

class Program
{
    static void Main(string[] args)
    {
        string[] sessionNames =
        {
            "C# Basics",
            "Arrays",
            "Functions",
            "Date and Time",
            "Exception Handling"
        };

        DateTime[] sessionDates =
        {
            new DateTime(2026, 9, 10, 18, 0, 0),
            new DateTime(2026, 9, 13, 18, 0, 0),
            new DateTime(2026, 9, 17, 18, 0, 0),
            new DateTime(2026, 9, 20, 18, 0, 0),
            new DateTime(2026, 9, 24, 18, 0, 0)
        };

        int[] sessionDurations =
        {
            180,
            240,
            180,
            240,
            180
        };

        DisplaySessions(sessionNames, sessionDates, sessionDurations);
        SearchSession(sessionNames, sessionDates, sessionDurations);
        SortSessionNames(sessionNames);
        ReverseSessionNames(sessionNames);
        FindSessionIndex(sessionNames);
        CheckSessionExists(sessionNames);
        FindSessionByCondition(sessionNames);
        FindSessionIndexByCondition(sessionNames);
        CopyArrayDemo(sessionNames);
        


    }
    static void DisplaySessions(string[] names, DateTime[] dates, int[] durations)
    {
        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {names[i]}");
            Console.WriteLine($"Date: {dates[i].ToString("dd MMMM yyyy")}");
            Console.WriteLine($"Start Time: {dates[i].ToString("hh:mm tt")}");
            Console.WriteLine($"Duration: {durations[i]} minutes");
            Console.WriteLine();
        }
    }
    static void DisplaySessionDetails(string[] names, DateTime[] dates, int[] durations, int index)
    {
        Console.WriteLine($"Name: {names[index]}");
        Console.WriteLine($"Date: {dates[index].ToString("dd MMMM yyyy")}");
        Console.WriteLine($"Start Time: {dates[index].ToString("hh:mm tt")}");
        Console.WriteLine($"Duration: {durations[index]} minutes");
    }
    static void SearchSession(string[] names, DateTime[] dates, int[] durations)
    {

        Console.Write("Enter session name: ");
        string input = Console.ReadLine();

        int index = Array.IndexOf(names, input);

        if (index >= 0)
        {
            DisplaySessionDetails(names, dates, durations, index);
        }
        else
        {
            Console.WriteLine("Session not found.");
        }

    }
    static void SortSessionNames(string[] names)
    {
        string[] copy = new string[names.Length];
        Array.Copy(names, copy, names.Length);
        Array.Sort(copy);
        Console.WriteLine("Sorted session names:");
        foreach (string name in copy)
        {
            Console.WriteLine($"- {name}");
        }
    }
    static void ReverseSessionNames(string[] names)
    {
        string[] copy = new string[names.Length];
        Array.Copy(names, copy, names.Length);

        Array.Reverse(copy);

        Console.WriteLine("Reversed session names:");
        foreach (string name in copy)
        {
            Console.WriteLine($"- {name}");
        }
    }
    static void FindSessionIndex(string[] names)
    {
        Console.Write("Enter session name: ");
        string input = Console.ReadLine();

        int index = Array.IndexOf(names, input);

        if (index >= 0)
        {
            Console.WriteLine($"Index: {index}");
        }
        else
        {
            Console.WriteLine("Session not found.");
        }

    }
    static void CheckSessionExists(string[] names)
    {
        Console.Write("Enter session name: ");
        string input = Console.ReadLine();

        bool exists = Array.Exists(names, name => name == input);

        if (exists)
            Console.WriteLine("Session exists.");
        else
            Console.WriteLine("Session does not exist.");
    }
    static void FindSessionByCondition(string[] names)
    {
        string found = Array.Find(names, name => name.Length > 10);

        if (found != null)
            Console.WriteLine($"First session with a long name: {found}");
        else
            Console.WriteLine("No session matched the condition.");
    }

    static void FindSessionIndexByCondition(string[] names)
    {
        int index = Array.FindIndex(names, name => name.StartsWith("F"));

        if (index >= 0)
            Console.WriteLine($"Index of first session starting with 'F': {index}");
        else
            Console.WriteLine("No session matched the condition.");
    }

    static void CopyArrayDemo(string[] names)
    {
        string[] copy = new string[names.Length];
        Array.Copy(names, copy, names.Length);

        copy[0] = "CHANGED";

        Console.WriteLine("Original array:");
        foreach (string name in names)
            Console.WriteLine($"- {name}");

        Console.WriteLine();
        Console.WriteLine("Copied array:");
        foreach (string name in copy)
            Console.WriteLine($"- {name}");
    }
}



