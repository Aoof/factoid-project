class FactoidProject
{
    private static string[] students = {
        "Rahman",
        "Sofia",
        "Akshay",
        "Abtin",
    };

    private static string[] bubbles = new string[10];
    private static int bubblesCount = 0;

    private enum QuestionType
    {
        UNKNOWN,
        PERSON,
        PLACE,
        DATE,
        NUMBER
    }

    public static void Main(string[] args)
    {
        Console.Title = "Factoid Project";

        ShowBubble("Welcome to the Factoid Project! Loading Project...", ConsoleColor.Blue);
        // System.Threading.Thread.Sleep(2000); // looks like the program is doing something

        while (true)
        {
            string input = GetInput();

            if (input == "exit" || input == "" || input == "q" || input == "quit")
            {
                ShowBubble("Terminating Program...", ConsoleColor.DarkRed);
                break;
            }
            else if (input == "history") { ShowHistory(); }
            else if (input == "guide") { ShowGuide(); }
            else 
            { 
                QuestionAnalysis(input);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            bubbles = new string[10];
            bubblesCount = 0;
        }
    }

    private static void QuestionAnalysis(string input)
    {
        QuestionType questionType = GetQuestionType(input);
        string response = GetResponse(questionType, input);
        ShowBubble(response, ConsoleColor.DarkGreen);
    }

    private static QuestionType GetQuestionType(string input)
    {
        string inputLower = input.ToLower();
        string[,] keywords = {
            { "who", "person" },
            { "where", "place" },
            { "when", "date" },
            { "how many", "number" }
        };

        for (int i = 0; i < keywords.GetLength(0); i++)
        {
            if (inputLower.Contains(keywords[i, 0]) || inputLower.Contains(keywords[i, 1]))
            {
                switch (keywords[i, 1])
                {
                    case "person":
                        return QuestionType.PERSON;
                    case "place":
                        return QuestionType.PLACE;
                    case "date":
                        return QuestionType.DATE;
                    case "number":
                        return QuestionType.NUMBER;
                }
            }
        }
        return QuestionType.UNKNOWN;
    }

    private static string GetResponse(QuestionType questionType, string input)
    {
        switch (questionType)
        {
            case QuestionType.PERSON:
                return "This is a person question.";
            case QuestionType.PLACE:
                return "This is a place question.";
            case QuestionType.DATE:
                return "This is a date / time question.";
            case QuestionType.NUMBER:
                return "This is a number question.";
            default:
                return "This is an unknown question.";
        }
    }

    private static void ShowHistory()
    {
        Console.Clear();
        ShowBubble("History Information", ConsoleColor.Blue);
        ShowBubble("This is placeholder text for the history section.", ConsoleColor.DarkGray);
        ShowBubble("Additional history information would be shown here.", ConsoleColor.DarkGray);
        ShowBubble("Instructions: Follow the prompts", ConsoleColor.DarkGray);
    }

    private static void ShowGuide()
    {
        Console.Clear();
        ShowBubble("Program Guide", ConsoleColor.Blue);
        ShowBubble("This is placeholder text for the guide section.", ConsoleColor.DarkGray);
        ShowBubble("Additional guide information would be shown here.", ConsoleColor.DarkGray);
        ShowBubble("Instructions: Follow the prompts", ConsoleColor.DarkGray);
    }

    private static void ValidateBoxSize(ref int boxWidth)
    {
        int consoleWidth = Console.WindowWidth;
        if (boxWidth > consoleWidth) { boxWidth = consoleWidth - 2; }
    }

    private static void ShowBubble(string text, ConsoleColor color = ConsoleColor.DarkGreen)
    {
        for (int i = 0; i < bubbles.Length; i++)
        {
            if (bubbles[i] == null)
            {
                bubbles[i] = text;
                bubblesCount++;
                break;
            }
        }

        int consoleWidth = Console.WindowWidth;
        int maxBoxWidth = consoleWidth - 2;
        int desiredWidth = Math.Min(text.Length + 6, maxBoxWidth);
        ValidateBoxSize(ref desiredWidth);
        int leftPadding = (consoleWidth - desiredWidth) / 2;

        Console.ForegroundColor = color;
        Console.SetCursorPosition(leftPadding, bubblesCount * 4);
        Console.WriteLine("╔" + new string('═', desiredWidth - 2) + "╗");

        int maxTextWidth = desiredWidth - 6;
        string[] lines = text.Split('\n');
        foreach (string textLine in lines)
        {
            for (int i = 0; i < textLine.Length; i += maxTextWidth)
            {
                string line = textLine.Substring(i, Math.Min(maxTextWidth, textLine.Length - i));
                Console.SetCursorPosition(leftPadding, Console.CursorTop);
                Console.WriteLine("║" + new string(' ', 2) + line.PadRight(maxTextWidth) + new string(' ', 2) + "║");
            }
        }

        Console.SetCursorPosition(leftPadding, Console.CursorTop);
        Console.WriteLine("╚" + new string('═', desiredWidth - 2) + "╝");

        for (int i = 0; i < 10; i++) Console.WriteLine();

        Console.ResetColor();
    }

    private static string commandString(string command, string description)
    {
        return $"- {command.PadRight(10)} -- {description}";
    }

    private static string GetInput(string prompt = "Enter your question: ")
    {
        // Cool User Interface  
        Console.Clear();

        string title = "Factoid Project";
        string studentSection = "Student Names:";
        string commandsSection = "Special Commands:";
        string[] specialCommands = {
            commandString("exit", "exit the program"),
            commandString("history", "show the history of your questions and answers"),
            commandString("guide", "show the guide of the program"),
        };

        Console.ForegroundColor = ConsoleColor.Cyan;

        int consoleWidth = Console.WindowWidth;
        int writingAreaWidth = 60;
        int boxWidth = Math.Max(title.Length, prompt.Length + writingAreaWidth) + 6;

        ValidateBoxSize(ref boxWidth);

        int leftPadding = (consoleWidth - boxWidth) / 2;

        int titlePadding = (boxWidth - 2 - title.Length) / 2;

        Console.WriteLine(new string(' ', leftPadding) + "╔" + new string('═', boxWidth - 2) + "╗");
        Console.WriteLine(new string(' ', leftPadding) + "║" + new string(' ', titlePadding) + title + new string(' ', boxWidth - 2 - titlePadding - title.Length) + "║");
        Console.WriteLine(new string(' ', leftPadding) + "╠" + new string('═', boxWidth - 2) + "╣");

        Console.WriteLine(new string(' ', leftPadding) + $"║ {studentSection.PadRight(boxWidth - 4)} ║");
        foreach (string student in students) Console.WriteLine(new string(' ', leftPadding) + $"║ - {student.PadRight(boxWidth - 6)} ║");
        Console.WriteLine(new string(' ', leftPadding) + "╠" + new string('═', boxWidth - 2) + "╣");

        Console.WriteLine(new string(' ', leftPadding) + $"║ {commandsSection.PadRight(boxWidth - 4)} ║");
        foreach (string command in specialCommands) Console.WriteLine(new string(' ', leftPadding) + $"║ {command.PadRight(boxWidth - 4)} ║");
        Console.WriteLine(new string(' ', leftPadding) + "╠" + new string('═', boxWidth - 2) + "╣");

        Console.WriteLine(new string(' ', leftPadding) + $"║ {prompt.PadRight(boxWidth - 4)} ║");

        Console.WriteLine(new string(' ', leftPadding) + "╚" + new string('═', boxWidth - 2) + "╝");

        Console.ResetColor();

        Console.SetCursorPosition(leftPadding + 2 + prompt.Length, Console.CursorTop - 2);
        string? input = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine();

        if (input == null) return "";
        return input;
    }
}
