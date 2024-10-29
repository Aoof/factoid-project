using System;

class UserInput
{
    public static void Main(string[] args)
    {
        while (true)
        {
            string input = GetInput();

            if (input == "exit" || input == "" || input == "q" || input == "quit")
            {
                ShowBubble("Terminating Program...", ConsoleColor.DarkRed);
                break;
            }
            else if (input == "history")
            {
                ShowHistory();
            }
            else if (input == "guide")
            {
                ShowGuide();
            }
            else
            {
                ShowBubble($"You entered: {input}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
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
        if (boxWidth > consoleWidth)
        {
            boxWidth = consoleWidth - 2;
        }
    }

    private static void ShowBubble(string text, ConsoleColor color = ConsoleColor.DarkGreen)
    {
        int consoleWidth = Console.WindowWidth;
        int maxBoxWidth = consoleWidth - 2;
        int desiredWidth = Math.Min(text.Length + 6, maxBoxWidth);
        ValidateBoxSize(ref desiredWidth);
        int leftPadding = (consoleWidth - desiredWidth) / 2;

        Console.ForegroundColor = color;
        Console.WriteLine(new string(' ', leftPadding) + "╔" + new string('═', desiredWidth - 2) + "╗");

        int maxTextWidth = desiredWidth - 6;
        string[] lines = text.Split('\n');
        foreach (string textLine in lines)
        {
            for (int i = 0; i < textLine.Length; i += maxTextWidth)
            {
                string line = textLine.Substring(i, Math.Min(maxTextWidth, textLine.Length - i));
                Console.WriteLine(new string(' ', leftPadding) + "║" + new string(' ', 2) + line.PadRight(maxTextWidth) + new string(' ', 2) + "║");
            }
        }

        Console.WriteLine(new string(' ', leftPadding) + "╚" + new string('═', desiredWidth - 2) + "╝");

        Console.ResetColor();
    }

    private static string commandString(string command, string description)
    {
        return $"- {command.PadRight(10)} -- {description}";
    }

    private static string GetInput(string prompt = "Enter your question: ")
    {
        Console.Clear();

        string title = "Factoid Project";
        string studentSection = "Student Names:";
        string commandsSection = "Special Commands:";
        string[] students = { "Abdulrahman Mousa" };
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
