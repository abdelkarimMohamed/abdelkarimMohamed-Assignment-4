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

        //DisplaySessions(sessionNames, sessionDates, sessionDurations);
        //SearchSession(sessionNames, sessionDates, sessionDurations);
        //SortSessionNames(sessionNames);
        //ReverseSessionNames(sessionNames);
        //FindSessionIndex(sessionNames);
        //CheckSessionExists(sessionNames);
        //FindSessionByCondition(sessionNames);
        //FindSessionIndexByCondition(sessionNames);
        //CopyArrayDemo(sessionNames);
        //DisplayDurationStatistics(sessionDurations);
        //DisplaySortedDurations(sessionDurations);

        bool running = true;

        while (running) 
        { 
            ShowMenu();
            int choice = ReadMenuChoice();
            switch (choice) {
                case 1:
                    DisplaySessions(sessionNames, sessionDates, sessionDurations);
                    break;
                case 2:
                    SearchSession(sessionNames, sessionDates, sessionDurations);
                    break;
                case 3:
                    SortSessionNames(sessionNames);
                    break;
                case 4:
                    ReverseSessionNames(sessionNames);
                    break;
                case 5:
                    FindSessionIndex(sessionNames);
                    break;
                case 6:
                    CheckSessionExists(sessionNames);
                    break;
                case 7:
                    DisplayDurationStatistics(sessionDurations);
                    DisplaySortedDurations(sessionDurations);
                    break;
                case 0:
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
            Console.WriteLine();
        }


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
    static int GetTotalDuration(int[] durations)
    {
        int total = 0;

        for (int i = 0; i < durations.Length; i++)
        {
            total += durations[i];
        }

        return total;
    }
    static double GetAverageDuration(int[] durations)
    {
        int total = GetTotalDuration(durations);
        return (double)total / durations.Length;
    }
    static int GetShortestDuration(int[] durations)
    {
        int shortest = durations[0];

        foreach (var item in durations)
        {
            if (item < shortest)
            {
                shortest = item;
            }
        }

        return shortest;
    }
    static int GetLongestDuration(int[] durations)
    {
        int longest = durations[0];

        for (int i = 1; i < durations.Length; i++)
        {
            if (durations[i] > longest)
            {
                longest = durations[i];
            }
        }

        return longest;
    }

    static void DisplayDurationStatistics(int[] durations)
    {
        Console.WriteLine($"Total Duration: {GetTotalDuration(durations)} minutes");
        Console.WriteLine($"Average Duration: {GetAverageDuration(durations)} minutes");
        Console.WriteLine($"Shortest Duration: {GetShortestDuration(durations)} minutes");
        Console.WriteLine($"Longest Duration: {GetLongestDuration(durations)} minutes");
    }

    static void DisplaySortedDurations(int[] durations)
    {
        int[] copy = new int[durations.Length];
        Array.Copy(durations, copy, durations.Length);

        Array.Sort(copy);

        Console.WriteLine("Durations sorted (smallest to largest):");
        foreach (int d in copy)
        {
            Console.Write($"{d} ");
        }
        Console.WriteLine();
    }
    static void ShowMenu()
    {
        Console.WriteLine("===================================");
        Console.WriteLine("       Academy Schedule Analyzer   ");
        Console.WriteLine("===================================");
        Console.WriteLine("1. Display all sessions");
        Console.WriteLine("2. Search for a session");
        Console.WriteLine("3. Sort session names");
        Console.WriteLine("4. Reverse session names");
        Console.WriteLine("5. Find session index");
        Console.WriteLine("6. Check if session exists");
        Console.WriteLine("7. Show duration statistics");
        Console.WriteLine("8. Show session date details");
        Console.WriteLine("9. Show past and upcoming sessions");
        Console.WriteLine("10. Find next session");
        Console.WriteLine("11. Compare two session dates");
        Console.WriteLine("12. Read and validate a custom date");
        Console.WriteLine("13. Select session by index");
        Console.WriteLine("14. Validate session duration");
        Console.WriteLine("15. Generate report using string");
        Console.WriteLine("16. Generate report using StringBuilder");
        Console.WriteLine("0. Exit");
        Console.Write("Choose an option: ");
    }
    static int ReadMenuChoice()
    {
        while (true)
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out int choice))
                return choice;

            Console.Write("Invalid input. Please enter a number: ");
        }
    }

}



