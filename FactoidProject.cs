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

    private enum QuestionTypes
    {
        UNKNOWN,
        PERSON,
        PLACE,
        DATE,
        NUMBER
    }

    private static string data = "";

    public static void Main(string[] args)
    {
        Console.Title = "Factoid Project";

        Console.Clear();

        ShowBubble("Welcome to the Factoid Project! Loading Project...", ConsoleColor.Blue);
        Console.WriteLine("Please enter the data you would like to analyze: ");
        string? enteredData = Console.ReadLine(); 
        if (enteredData != null && enteredData != "") data = enteredData;
        else { data = "This is placeholder data for the project."; }
        // System.Threading.Thread.Sleep(2000); // looks like the program is doing something

        while (true)
        {
            string input = GetInput();

            if (input == "exit" || input == "" || input == "q" || input == "quit")
            {
                ShowBubble("Terminating Program...", ConsoleColor.DarkRed);
                break;
            }
            else if (input == "guide") { ShowGuide(); }
            else if (input == "data") { ShowData(); }
            else { ProcessQuestion(input); }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            bubbles = new string[10];
            bubblesCount = 0;
        }
    }

    private static void ProcessQuestion(string input)
    {
        QuestionTypes questionType = GetQuestionType(input);
        string[] sentences = RetrieveData(input);

        double maxSimilarity = 0;
        string bestSentence = "";

        double sumOfSimilarities = 0;

        for (int i = 0; i < sentences.Length; i++)
        {
            string sentence = RemoveStopWords(sentences[i]);
            double similarity = GetSimilarity(input, sentence);

            sumOfSimilarities += similarity;

            string[] answers = GetAnswers(sentence, questionType);

            if (similarity > maxSimilarity && answers.Length > 0 && answers[0] != "I'm not sure.")
            {
                maxSimilarity = similarity;
                bestSentence = sentence; 
            }
        }

        double lexicalMatch = Math.Round((maxSimilarity / sumOfSimilarities) * 100, 2);

        string[] bestAnswers = GetAnswers(bestSentence, questionType);
        string bestAnswer = string.Join(" ", bestAnswers); 

        if (bestAnswers.Length == 0 || bestAnswers[0] == "I'm not sure.") bestAnswer = $"I'm not sure but the closest match is: {bestSentence}";
        if (bestSentence == "") bestAnswer = "I'm not sure.";

        ShowBubble("Question: " + input, ConsoleColor.Blue);
        ShowBubble("Answer: " + bestAnswer, ConsoleColor.DarkGreen);
        ShowBubble($"Highest Match: {lexicalMatch}%", ConsoleColor.DarkYellow);
    }

    private static string[] GetAnswers(string sentence = "", QuestionTypes questionType = QuestionTypes.UNKNOWN)
    {
        string[] words = sentence.Split(' ');
        for (int i = 0; i < words.Length; i++) { words[i] = words[i].Trim(); }

        sentence = string.Join(" ", words);

        string[] answers = questionType switch 
        {
            QuestionTypes.PERSON => GetPeople(sentence),
            QuestionTypes.PLACE => GetPlaces(sentence),
            QuestionTypes.DATE => GetDates(sentence),
            QuestionTypes.NUMBER => GetNumbers(sentence),
            _ => new string[] { "I'm not sure." }
        };

        return answers;
    }

    // DATA RETRIEVAL MODULE
    private static string[] RetrieveData(string input)
    {
        data = data.Replace("\n", " ");
        data = data.Replace("Inc.", "Inc");
        string[] sentences = data.Split(new char[] { '.', '?', '!' });
        for (int i = 0; i < sentences.Length; i++) { sentences[i] = sentences[i].Trim().Replace(",", ""); }
        return sentences;
    }

    private static string RemoveStopWords(string str)
    {
        string[] stopwords = { "the", "and", "a", "to", "of", "in", "i", "is", "that", "it", "on", "you", "this" }; 
        string[] words = str.Split(' ');
        string result = "";

        for (int i = 0; i < words.Length; i++)
        {
            for (int j = 0; j < stopwords.Length; j++)
            {
                if (words[i].ToLower() == stopwords[j]) { words[i] = ""; }
            }
            result += words[i] + " ";
        }

        return result;
    }

    private static string[] GetPeople(string sentence)
    {
        string[] words = sentence.Split(' ');
        string[] people = new string[words.Length];
        int peopleCount = 0;

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length > 0 && char.IsUpper(words[i][0])) 
            { 
                people[peopleCount] = words[i]; 
                peopleCount++; 
            }
        }

        string[] result = new string[peopleCount];
        for (int i = 0; i < peopleCount; i++) { result[i] = people[i]; }

        return result;
    }

    private static string[] GetPlaces(string sentence)
    {
        string[] words = sentence.Split(' ');
        string[] places = new string[words.Length];
        int placesCount = 0;

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].ToUpper() == words[i].ToLower()) { continue; }
            if (words[i] == words[i].ToUpper()) { places[placesCount] = words[i]; placesCount++; }
        }

        string[] result = new string[placesCount];
        for (int i = 0; i < placesCount; i++) { result[i] = places[i]; }

        return result;
    }

    private static string[] GetDates(string sentence)
    {
        string[] words = sentence.Split(' ');
        string[] dates = new string[words.Length];
        int datesCount = 0;

        for (int i = 0; i < words.Length; i++)
        {
            if ((words[i].Contains("/") || words[i].Contains("-")) && 
                int.TryParse(words[i].Split(' ')[0], out int _) ||
                (words[i].Length == 4 && int.TryParse(words[i], out int year) && year > 1000 && year < 3000))
            {
                dates[datesCount] = words[i];
                datesCount++;
            }
        }

        string[] result = new string[datesCount];
        for (int i = 0; i < datesCount; i++) { result[i] = dates[i]; }

        return result;
    }

    private static string[] GetNumbers(string sentence)
    {
        string[] words = sentence.Split(' ');
        string[] numbers = new string[words.Length];
        int numbersCount = 0;

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Contains("$") || words[i].Contains("%") || Double.TryParse(words[i], out double number))
            {
                numbers[numbersCount] = words[i];
                numbersCount++;
            }
        }

        string[] result = new string[numbersCount];
        for (int i = 0; i < numbersCount; i++) { result[i] = numbers[i]; }

        return result;
    }

    private static double GetSimilarity(string input, string sentence)
    {
        string[] inputWords = input.Split(' ');
        string[] sentenceWords = sentence.Split(' ');

        double similarity = 0;

        for (int i = 0; i < inputWords.Length; i++)
        {
            for (int j = 0; j < sentenceWords.Length; j++)
            {
                if (inputWords[i].ToLower() == sentenceWords[j].ToLower()) similarity++;
            }
        }

        int minimumLength = Math.Min(inputWords.Length, sentenceWords.Length);
        similarity /= minimumLength;

        return similarity;
    }

    // QUESTION ANALYSIS MODULE
    private static QuestionTypes GetQuestionType(string input)
    {
        string inputLower = input.ToLower();
        string[,] keywords = {
            { "who", "person" },
            { "where", "place" },
            { "when", "date" },
            { "how many", "number" },
            { "how much", "number" }
        };

        for (int i = 0; i < keywords.GetLength(0); i++)
        {
            if (inputLower.Contains(keywords[i, 0]) || inputLower.Contains(keywords[i, 1]))
            {
                switch (keywords[i, 1])
                {
                    case "person":
                        return QuestionTypes.PERSON;
                    case "place":
                        return QuestionTypes.PLACE;
                    case "date":
                        return QuestionTypes.DATE;
                    case "number":
                        return QuestionTypes.NUMBER;
                }
            }
        }
        return QuestionTypes.UNKNOWN;
    }

    // MENUS AND UI MODULE
    private static void ShowData()
    {
        Console.Clear();

        ShowBubble("Data Information", ConsoleColor.Blue);
        ShowBubble(data, ConsoleColor.DarkMagenta);

        Console.WriteLine("Enter the data you would like to analyze or leave blank to use the current data: ");
        string? enteredData = Console.ReadLine();

        if (enteredData != null && enteredData != "" && enteredData != "q") data = enteredData;

    }

    private static void ShowGuide()
    {
        Console.Clear();
        ShowBubble("Program Guide", ConsoleColor.Blue);
        ShowBubble("This program is designed to answer questions based on the data you provide.", ConsoleColor.DarkMagenta);
        ShowBubble("You can enter a question and the program will analyze the data to find the best answer.", ConsoleColor.DarkMagenta);
        ShowBubble("You can also enter the data you would like to analyze or leave it blank to use the current data.", ConsoleColor.DarkMagenta);
        ShowBubble("Special Commands:", ConsoleColor.DarkYellow);
        ShowBubble(
            CommandString("exit", "exit the program") + "\n" +
            CommandString("guide", "show the guide of the program") + "\n" +
            CommandString("data", "show the data you have entered"),
            ConsoleColor.DarkYellow
        );
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
        int maxBoxWidth = consoleWidth / 2 + 20;
        int desiredWidth = Math.Min(text.Length + 6, maxBoxWidth);
        if (desiredWidth > consoleWidth) { desiredWidth = consoleWidth - 2; }

        int leftPadding = (consoleWidth - desiredWidth) / 2;

        Console.ForegroundColor = color;
        Console.SetCursorPosition(leftPadding, (bubblesCount - 1) * 5);
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

        Console.SetCursorPosition(0, Console.CursorTop + 1);

        Console.ResetColor();
    }

    private static string CommandString(string command, string description) { return $"- {command.PadRight(10)} -- {description}"; }

    private static string GetInput(string prompt = "Enter your question: ")
    {
        Console.Clear();

        string title = "Factoid Project";
        string studentSection = "Student Names:";
        string commandsSection = "Special Commands:";
        string[] specialCommands = {
            CommandString("exit", "exit the program"),
            CommandString("guide", "show the guide of the program"),
            CommandString("data", "show the data you have entered")
        };

        Console.ForegroundColor = ConsoleColor.Cyan;

        int consoleWidth = Console.WindowWidth;
        int writingAreaWidth = 60;
        int desiredWidth = Math.Max(title.Length, prompt.Length + writingAreaWidth) + 6;
        if (desiredWidth > consoleWidth) { desiredWidth = consoleWidth - 2; }

        int leftPadding = (consoleWidth - desiredWidth) / 2;

        int titlePadding = (desiredWidth - 2 - title.Length) / 2;

        Console.WriteLine(new string(' ', leftPadding) + "╔" + new string('═', desiredWidth - 2) + "╗");
        Console.WriteLine(new string(' ', leftPadding) + "║" + new string(' ', titlePadding) + title + new string(' ', desiredWidth - 2 - titlePadding - title.Length) + "║");
        Console.WriteLine(new string(' ', leftPadding) + "╠" + new string('═', desiredWidth - 2) + "╣");

        Console.WriteLine(new string(' ', leftPadding) + $"║ {studentSection.PadRight(desiredWidth - 4)} ║");
        for (int i = 0; i < students.Length; i++) Console.WriteLine(new string(' ', leftPadding) + $"║ - {students[i].PadRight(desiredWidth - 6)} ║");
        Console.WriteLine(new string(' ', leftPadding) + "╠" + new string('═', desiredWidth - 2) + "╣");

        Console.WriteLine(new string(' ', leftPadding) + $"║ {commandsSection.PadRight(desiredWidth - 4)} ║");
        for (int i = 0; i < specialCommands.Length; i++) Console.WriteLine(new string(' ', leftPadding) + $"║ {specialCommands[i].PadRight(desiredWidth - 4)} ║");
        Console.WriteLine(new string(' ', leftPadding) + "╠" + new string('═', desiredWidth - 2) + "╣");

        Console.WriteLine(new string(' ', leftPadding) + $"║ {prompt.PadRight(desiredWidth - 4)} ║");

        Console.WriteLine(new string(' ', leftPadding) + "╚" + new string('═', desiredWidth - 2) + "╝");

        Console.ResetColor();

        Console.SetCursorPosition(leftPadding + 2 + prompt.Length, Console.CursorTop - 2);
        string? input = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine();

        if (input == null) return "";
        return input;
    }
}
