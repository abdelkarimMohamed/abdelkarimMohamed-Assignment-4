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
            switch (choice)
            {
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
                case 8:
                    RefDemo(); // ref
                    break;
                case 9:
                    OutDemo(sessionNames, sessionDurations); //ref
                    break;
                case 10:
                    ReferenceTypeDemo(sessionDurations);     //ref
                    break;
                case 11:
                    ParamsDemo();     // params Keyword
                    break;
                case 12:
                    ShowSessionDateDetails(sessionNames, sessionDates, sessionDurations);//Part 9 — Session Date Details // case:8
                    break;
                case 13:
                    CompareTwoSessionDates(sessionNames, sessionDates); //Part 10 — Date Difference  // case:11
                    break;
                case 14:
                    DisplayPastAndUpcomingSessions(sessionNames, sessionDates); //Part 11 — Past and Upcoming Sessions // case:9
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
        //RefDemo();


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
    static void DoubleValue(ref int number)
    {
        number = number * 2;
    }
    static void RefDemo()
    {
        int value = 100;

        Console.WriteLine($"Before: {value}");
        DoubleValue(ref value);
        Console.WriteLine($"After: {value}");
    }
    static bool TryGetSessionInfo(string[] names, int[] durations, string sessionName,
                              out int index, out int duration)
    {
        index = Array.IndexOf(names, sessionName);

        if (index >= 0)
        {
            duration = durations[index];
            return true;
        }

        duration = 0;
        return false;
    }
    static void OutDemo(string[] names, int[] durations)
    {
        Console.Write("Enter session: ");
        string input = Console.ReadLine();

        if (TryGetSessionInfo(names, durations, input, out int index, out int duration))
        {
            Console.WriteLine($"Index: {index}");
            Console.WriteLine($"Duration: {duration} minutes");
        }
        else
        {
            Console.WriteLine("Session not found.");
        }
    }
    static void ChangeFirstElement(int[] values)
    {
        values[0] = 999;
    }
    static void ReferenceTypeDemo(int[] durations)
    {
        int[] copy = new int[durations.Length];
        Array.Copy(durations, copy, durations.Length);

        Console.WriteLine("Before calling the function:");
        PrintArray(copy);

        ChangeFirstElement(copy);

        Console.WriteLine("After calling the function:");
        PrintArray(copy);
    }

    static void PrintArray(int[] values)
    {
        foreach (int v in values)
            Console.Write($"{v} ");
        Console.WriteLine();
    }
    static int CalculateTotalDuration(params int[] durations)
    {
        int total = 0;

        for (int i = 0; i < durations.Length; i++)
        {
            total += durations[i];
        }

        return total;
    }
    static void ParamsDemo()
    {
        Console.WriteLine($"Two sessions: {CalculateTotalDuration(120, 180)} minutes");
        Console.WriteLine($"Three sessions: {CalculateTotalDuration(120, 180, 240)} minutes");
        Console.WriteLine($"Five sessions: {CalculateTotalDuration(60, 90, 120, 180, 240)} minutes");
    }
    static DateTime GetSessionEndTime(DateTime startTime, int durationMinutes)
    {
        return startTime.AddMinutes(durationMinutes);
    }
    static void DisplaySessionDateDetails(string[] names, DateTime[] dates, int[] durations, int index)
    {
        DateTime start = dates[index];
        int duration = durations[index];
        DateTime end = GetSessionEndTime(start, duration);

        Console.WriteLine($"Session: {names[index]}");
        Console.WriteLine($"Date: {start.ToString("dd MMMM yyyy")}");
        Console.WriteLine($"Day: {start.DayOfWeek}");
        Console.WriteLine($"Year: {start.Year}");
        Console.WriteLine($"Month: {start.Month}");
        Console.WriteLine($"Day Number: {start.Day}");
        Console.WriteLine($"Start Time: {start.ToString("hh:mm tt")}");
        Console.WriteLine($"Duration: {duration} minutes");
        Console.WriteLine($"End Time: {end.ToString("hh:mm tt")}");
    }
    static void ShowSessionDateDetails(string[] names, DateTime[] dates, int[] durations)
    {
        Console.Write("Enter session name: ");
        string input = Console.ReadLine();

        int index = Array.IndexOf(names, input);

        if (index >= 0)
        {
            DisplaySessionDateDetails(names, dates, durations, index);
        }
        else
        {
            Console.WriteLine("Session not found.");
        }
    }

    static void CompareTwoSessionDates(string[] names, DateTime[] dates)
    {
        Console.Write("First Session: ");
        string firstInput = Console.ReadLine();

        Console.Write("Second Session: ");
        string secondInput = Console.ReadLine();

        int firstIndex = Array.IndexOf(names, firstInput);
        int secondIndex = Array.IndexOf(names, secondInput);

        if (firstIndex < 0 || secondIndex < 0)
        {
            Console.WriteLine("Session not found.");
            return;
        }

        TimeSpan difference = dates[secondIndex] - dates[firstIndex];

        Console.WriteLine("Difference:");
        Console.WriteLine($"{(int)difference.TotalDays} days");
        Console.WriteLine($"{(int)difference.TotalHours} hours");
    }
    static void DisplayPastAndUpcomingSessions(string[] names, DateTime[] dates)
    {
        DateTime now = DateTime.Now;

        for (int i = 0; i < names.Length; i++)
        {
            string status;

            if (dates[i] < now)
            {
                status = "Past";
            }
            else
            {
                status = "Upcoming";
            }

            Console.WriteLine($"{names[i],-22} {status}");
        }
    }

}



