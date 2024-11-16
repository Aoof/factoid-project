public class TestMe
{
    static string[] DATA = {
        "The history of programming languages spans from documentation of early mechanical computers to modern tools for software development. Early programming languages were highly specialized, relying on mathematical notation and similarly obscure syntax. Throughout the 20th century, research in compiler theory led to the creation of high-level programming languages, which use a more accessible syntax to communicate instructions. The first high-level programming language was created by Konrad Zuse in 1943. The first high-level language to have an associated compiler was created by Corrado Böhm in 1951. Konrad Zuse was born on 1910/06/22, in GERMANY, and was a notable civil engineer, pioneering computer scientist, inventor, and businessman.",
        "Apple Inc. was founded by Steve Jobs and Steve Wozniak in CUPERTINO, CALIFORNIA, on 1976-04-01. The company initially raised $1,000 to develop their first product. In 2023, Apple reported a 15% revenue increase, reaching a total of $387.53 billion."
    };

    public static void Main(string[] args)
    {
        string user = args.Length > 0 ? args[0] : string.Empty;
        if (string.IsNullOrEmpty(user))
        {
            Console.Write("Please enter your name as an argument. ");
            ConsoleColor curr = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Usage: dotnet run <name>");
            Console.ForegroundColor = curr;
            return;
        }

        switch (user.ToLower())
        {
            case "abtin":
                TestAbtin();
                break;
            case "akshay":
                TestAkshay();
                break;
            case "sofia":
                TestSofia();
                break;
            default:
                for (int i = 0; i < DATA.Length; i++)
                {
                    Console.WriteLine("Data " + (i + 1) + ": " + DATA[i]);
                    Console.WriteLine("Sentences:");
                    string[] sentences = Split(DATA[i], new char[] { '.', '?', '!' });
                    for (int j = 0; j < sentences.Length; j++)
                    {
                        Console.WriteLine("Sentence " + (j + 1) + ": " + sentences[j]);
                        Console.WriteLine("People: " + Join(GetPeople(sentences[j]), ", "));
                        Console.WriteLine("Places: " + Join(GetPlaces(sentences[j]), ", "));
                        Console.WriteLine("Dates: " + Join(GetDates(sentences[j]), ", "));
                        Console.WriteLine("Numbers: " + Join(GetNumbers(sentences[j]), ", "));
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("User not found.");
                break;
        }
    }

    public static void TestAbtin()
    {
        Abtin abtin = new Abtin();

        ConsoleColor curr = Console.ForegroundColor;

        foreach (string _data in DATA)
        {
            string[] sentences = Split(_data, new char[] { '.', '?', '!' });

            int correctPeople = 0;
            int peopleCount = 0;

            int correctPlaces = 0;
            int placesCount = 0;

            int correctRetrieveData = 0;
            int retrieveDataCount = 0;

            for (int i = 0; i < sentences.Length; i++)
            {
                string[] people = abtin.GetPeople(sentences[i]);
                string[] places = abtin.GetPlaces(sentences[i]);

                string[] _people = GetPeople(sentences[i]);
                string[] _places = GetPlaces(sentences[i]);

                bool peopleMatch = people.Length == _people.Length;

                for (int j = 0; j < people.Length; j++)
                {
                    peopleCount++;
                    if (people[j] != _people[j])
                    {
                        peopleMatch = false;
                        break;
                    }
                    correctPeople++;
                }

                Console.Write("TEST CASE " + (i + 1) + " - GetPeople:");
                if (peopleMatch)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Passed");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Failed");
                }

                Console.ForegroundColor = curr;

                bool placesMatch = places.Length == _places.Length;

                for (int j = 0; j < places.Length; j++)
                {
                    placesCount++;
                    if (places[j] != _places[j])
                    {
                        placesMatch = false;
                        break;
                    }
                    correctPlaces++;
                }

                Console.Write("TEST CASE " + (i + 1) + " - GetPlaces:");
                if (placesMatch)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Passed");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Failed");
                }

                Console.ForegroundColor = curr;

                string[] retrievedData = abtin.RetrieveData(_data);
                string[] _retrievedData = RetrieveData(_data);

                bool retrieveDataMatch = retrievedData.Length == _retrievedData.Length;

                for (int j = 0; j < retrievedData.Length; j++)
                {
                    retrieveDataCount++;
                    if (retrievedData[j] != _retrievedData[j])
                    {
                        retrieveDataMatch = false;
                        break;
                    }
                    correctRetrieveData++;
                }

                Console.Write("TEST CASE " + (i + 1) + " - RetrieveData:");
                if (retrieveDataMatch)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Passed");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Failed");
                }

                Console.ForegroundColor = curr;
            }
        }
    }

    public static void TestAkshay()
    {
        Akshay akshay = new Akshay();

        ConsoleColor curr = Console.ForegroundColor;

        foreach (string _data in DATA)
        {
            string[] sentences = Split(_data, new char[] { '.', '?', '!' });

            for (int i = 0; i < sentences.Length; i++)
            {
                string[] dates = akshay.GetDates(sentences[i]);
                string[] _dates = GetDates(sentences[i]);

                bool datesMatch = dates.Length == _dates.Length;

                for (int j = 0; j < dates.Length; j++)
                {
                    if (dates[j] != _dates[j])
                    {
                        datesMatch = false;
                        break;
                    }
                }

                Console.Write("TEST CASE " + (i + 1) + " - GetDates:");
                if (datesMatch)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Passed");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Failed");
                }

                Console.ForegroundColor = curr;

                string[] numbers = akshay.GetNumbers(sentences[i]);
                string[] _numbers = GetNumbers(sentences[i]);

                bool numbersMatch = numbers.Length == _numbers.Length;

                for (int j = 0; j < numbers.Length; j++)
                {
                    if (numbers[j] != _numbers[j])
                    {
                        numbersMatch = false;
                        break;
                    }
                }

                Console.Write("TEST CASE " + (i + 1) + " - GetNumbers:");
                if (numbersMatch)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Passed");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Failed");
                }

                Console.ForegroundColor = curr;

                string cleanedData = akshay.RemoveStopWords(sentences[i]);
                string _cleanedData = RemoveStopWords(sentences[i]);

                bool cleanedDataMatch = cleanedData == _cleanedData;

                Console.Write("TEST CASE " + (i + 1) + " - RemoveStopWords:");
                if (cleanedDataMatch)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Passed");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Failed");
                }

                Console.ForegroundColor = curr;
            }
        }
    } 

    public static void TestSofia()
    {
        Sofia sofia = new Sofia();

        ConsoleColor curr = Console.ForegroundColor;

        foreach (string _data in DATA)
        {
            string[] sentences = Split(_data, new char[] { '.', '?', '!' });

            for (int i = 0; i < sentences.Length; i++)
            {
                double similarity = sofia.GetSimilarity("programming languages", sentences[i]);
                double _similarity = GetSimilarity("programming languages", sentences[i]);

                Console.Write("TEST CASE " + (i + 1) + " - GetSimilarity:");
                if (similarity == _similarity)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Passed");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Failed");
                }

                Console.ForegroundColor = curr;

                string questionType = sofia.GetQuestionType("Who created the first high-level programming language?");
                string _questionType = GetQuestionType("Who created the first high-level programming language?");

                Console.Write("TEST CASE " + (i + 1) + " - GetQuestionType:");
                if (questionType == _questionType)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Passed");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Failed");
                }

                Console.ForegroundColor = curr;

                string[] answers = sofia.GetAnswers(sentences[i], questionType);
                string[] _answers = GetAnswers(sentences[i], questionType);

                bool answersMatch = answers.Length == _answers.Length;

                for (int j = 0; j < answers.Length; j++)
                {
                    if (answers[j] != _answers[j])
                    {
                        answersMatch = false;
                        break;
                    }
                }

                Console.Write("TEST CASE " + (i + 1) + " - GetAnswers:");
                if (answersMatch)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Passed");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Failed");
                }

                Console.ForegroundColor = curr;
            }
        }
    }

    // Factoid Project
    public static string[] Split(string str, object separator)
    {
        int size = 0;
        if (separator is char) size = 1;
        else if (separator is string) size = ((string)separator).Length;
        else if (separator is char[]) size = ((char[])separator).Length;
        else return new string[] { "" };

        char[] separators = new char[size];
        int resultSize = 0;

        for (int i = 0; i < size; i++)
        {
            if (separator is char) separators[i] = (char)separator;
            else if (separator is string) separators[i] = ((string)separator)[i];
            else if (separator is char[]) separators[i] = ((char[])separator)[i];
        }

        for (int i = 0; i < str.Length; i++)
        {
            for (int j = 0; j < size; j++)
            {
                if (str[i] == separators[j])
                {
                    resultSize++;
                    break;
                }
            }
        }

        string[] result = new string[resultSize + 1];

        int index = 0;
        string current = "";

        for (int i = 0; i < str.Length; i++)
        {
            bool found = false;
            for (int j = 0; j < size; j++)
            {
                if (str[i] == separators[j])
                {
                    found = true;
                    break;
                }
            }

            if (found)
            {
                result[index] = current;
                index++;
                current = "";
            }
            else
            {
                current += str[i];
            }
        }

        result[index] = current;

        return result;
    }

    public static string ToLower(string str)
    {
        string result = "";
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] >= 'A' && str[i] <= 'Z') result += (char)(str[i] + 32);
            else result += str[i];
        }
        return result;
    }

    public static string ToUpper(string str)
    {
        string result = "";
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] >= 'a' && str[i] <= 'z') result += (char)(str[i] - 32);
            else result += str[i];
        }
        return result;
    }

    public static string Replace(string str, object _old, object _new)
    {
        string old = "";
        string newStr = "";

        if (_old is char) old = ((char)_old).ToString();
        else if (_old is string) old = (string)_old;

        if (_new is char) newStr = ((char)_new).ToString();
        else if (_new is string) newStr = (string)_new;

        string result = "";
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == old[0])
            {
                bool match = true;
                for (int j = 1; j < old.Length; j++)
                {
                    if (i + j >= str.Length || str[i + j] != old[j])
                    {
                        match = false;
                        break;
                    }
                }

                if (match)
                {
                    result += newStr;
                    i += old.Length - 1;
                }
                else
                {
                    result += str[i];
                }
            }
            else
            {
                result += str[i];
            }
        }

        return result;
    }

    public static string Repeat(string str, int count)
    {
        string result = "";
        for (int i = 0; i < count; i++) result += str;
        return result;
    }

    public static string Join(string[] arr, string separator)
    {
        string result = "";
        for (int i = 0; i < arr.Length; i++)
        {
            result += arr[i];
            if (i < arr.Length - 1) result += separator;
        }
        return result;
    }

    public static string Trim(string str)
    {
        string result = "";
        int start = 0;
        int end = str.Length - 1;

        while (start < str.Length && (str[start] == ' ' || str[start] == '\t' || str[start] == '\n' || str[start] == '\r')) start++;
        while (end >= 0 && (str[end] == ' ' || str[end] == '\t' || str[end] == '\n' || str[end] == '\r')) end--;

        for (int i = start; i <= end; i++) result += str[i];

        return result;
    }

    public static string Contains(string str, string substr)
    {
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == substr[0])
            {
                bool match = true;
                for (int j = 1; j < substr.Length; j++)
                {
                    if (i + j >= str.Length || str[i + j] != substr[j])
                    {
                        match = false;
                        break;
                    }
                }

                if (match) return substr;
            }
        }

        return "";
    }

    // List of students
    public static string[] students = {
        "Rahman",
        "Sofia",
        "Akshay",
        "Abtin",
    };

    // Array to store bubbles for UI
    public static string[] bubbles = new string[10];
    public static int bubblesCount = 0;

    // Data to be analyzed
    public static string data = "";
    // Get answers based on the question type
    public static string[] GetAnswers(string sentence = "", string questionType = "UNKNOWN")
    {
        string[] words = Split(sentence, ' ');
        for (int i = 0; i < words.Length; i++) { words[i] = Trim(words[i]); }

        sentence = Join(words, " ");

        string[] answers = questionType switch
        {
            "PERSON" => GetPeople(sentence),
            "PLACE" => GetPlaces(sentence),
            "DATE" => GetDates(sentence),
            "NUMBER" => GetNumbers(sentence),
            _ => new string[] { "I'm not sure." }
        };

        return answers;
    }

    // DATA RETRIEVAL MODULE

    // Retrieve data and split into sentences
    public static string[] RetrieveData(string data)
    {
        data = Replace(data, '\n', ' ');
        data = Replace(data, "Inc.", "Inc");
        string[] sentences = Split(data, new char[] { '.', '?', '!' });
        for (int i = 0; i < sentences.Length; i++) { sentences[i] = Trim(Replace(sentences[i], ',', ' ')); }
        return sentences;
    }

    // Remove common stop words from a string to improve accuracy
    public static string RemoveStopWords(string str)
    {
        string[] stopwords = { "the", "and", "a", "to", "of", "in", "i", "is", "that", "it", "on", "you", "this" };
        string[] words = Split(str, ' ');
        string result = "";

        for (int i = 0; i < words.Length; i++)
        {
            for (int j = 0; j < stopwords.Length; j++)
            {
                if (ToLower(words[i]) == stopwords[j]) { words[i] = ""; }
            }
            result += words[i] + " ";
        }

        return result;
    }

    // Extract people names from a sentence
    public static string[] GetPeople(string sentence)
    {
        string[] words = Split(sentence, ' ');
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

    // Extract place names from a sentence
    public static string[] GetPlaces(string sentence)
    {
        string[] words = Split(sentence, ' ');
        string[] places = new string[words.Length];
        int placesCount = 0;

        for (int i = 0; i < words.Length; i++)
        {
            if (ToUpper(words[i]) == ToLower(words[i])) { continue; }
            if (words[i] == ToUpper(words[i])) { places[placesCount] = words[i]; placesCount++; }
        }

        string[] result = new string[placesCount];
        for (int i = 0; i < placesCount; i++) { result[i] = places[i]; }

        return result;
    }

    // Extract dates from a sentence
    public static string[] GetDates(string sentence)
    {
        string[] words = Split(sentence, ' ');
        string[] dates = new string[words.Length];
        int datesCount = 0;

        for (int i = 0; i < words.Length; i++)
        {
            string word = Replace(words[i], '/', '-');
            word = Replace(word, ' ', '-');
            string[] parts = Split(word, '-');

            if ((Contains(words[i], "/") != "" || Contains(words[i], "-") != "") &&
                int.TryParse(parts[0], out int _) ||
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

    // Extract numbers from a sentence
    public static string[] GetNumbers(string sentence)
    {
        string[] words = Split(sentence, ' ');
        string[] numbers = new string[words.Length];
        int numbersCount = 0;

        for (int i = 0; i < words.Length; i++)
        {
            if (Contains(words[i], "$") != "" || Contains(words[i], "%") != "" || Double.TryParse(words[i], out double number))
            {
                numbers[numbersCount] = words[i];
                numbersCount++;
            }
        }

        string[] result = new string[numbersCount];
        for (int i = 0; i < numbersCount; i++) { result[i] = numbers[i]; }

        return result;
    }

    // Calculate similarity between input and sentence
    public static double GetSimilarity(string input, string sentence)
    {
        string[] inputWords = Split(input, ' ');
        string[] sentenceWords = Split(sentence, ' ');

        double similarity = 0;

        for (int i = 0; i < inputWords.Length; i++)
        {
            for (int j = 0; j < sentenceWords.Length; j++)
            {
                if (ToLower(inputWords[i]) == ToLower(sentenceWords[j])) similarity++;
            }
        }

        int minimumLength = Math.Min(inputWords.Length, sentenceWords.Length);
        similarity /= minimumLength;

        return similarity;
    }

    // QUESTION ANALYSIS MODULE

    // Determine the type of question based on keywords
    public static string GetQuestionType(string input)
    {
        string inputLower = ToLower(input);
        string[,] keywords = {
            { "who", "person" },
            { "where", "place" },
            { "when", "date" },
            { "how many", "number" },
            { "how much", "number" }
        };

        for (int i = 0; i < keywords.GetLength(0); i++)
        {
            if (Contains(inputLower, keywords[i, 0]) != "")
            { return ToUpper(keywords[i, 1]); }
        }
        return "UNKNOWN";
    }
}
