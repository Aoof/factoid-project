# FactoidProject

## Installation

1. **Clone the repository:**
   ```sh
   git clone https://github.com/Aoof/FactoidProject.git
   cd FactoidProject
   ```

2. **Build the project:**
   ```sh
   dotnet build
   ```

3. **Run the project:**
   ```sh
   dotnet run
   ```

## Overview

FactoidProject is a console application designed to analyze and answer questions based on the data provided by the user. The application processes the input data, identifies the type of question, and attempts to find the best possible answer from the data.

## Main Components

### 1. Main Method
The entry point of the application. It sets up the console, prompts the user for data, and enters a loop to process user questions until the user decides to exit.
```csharp
public static void Main(string[] args)
```

### 2. ProcessQuestion Method
Analyzes the user's question, determines the type of question, retrieves relevant data, and calculates the similarity between the question and the data to find the best possible answer.
```csharp
private static void ProcessQuestion(string input)
```

### 3. GetAnswers Method
Determines the type of answer to extract based on the question type (e.g., person, place, date, number) and retrieves the relevant answers from the given sentence.
```csharp
private static string[] GetAnswers(string sentence, QuestionTypes questionType)
```

### 4. RetrieveData Method
Processes the input data by splitting it into sentences and cleaning up unnecessary characters.
```csharp
private static string[] RetrieveData(string input)
```

### 5. RemoveStopWords Method
Removes common stop words from a given string to improve the accuracy of the similarity calculation.
```csharp
private static string RemoveStopWords(string str)
```

### 6. GetPeople, GetPlaces, GetDates, GetNumbers Methods
Each method extracts specific types of information (people, places, dates, numbers) from a given sentence.
```csharp
private static string[] GetPeople(string sentence)
private static string[] GetPlaces(string sentence)
private static string[] GetDates(string sentence)
private static string[] GetNumbers(string sentence)
```

### 7. GetSimilarity Method
Calculates the similarity between the user's question and a given sentence from the data.
```csharp
private static double GetSimilarity(string input, string sentence)
```

### 8. GetQuestionType Method
Identifies the type of question based on specific keywords (e.g., who, where, when, how many, how much).
```csharp
private static QuestionTypes GetQuestionType(string input)
```

### 9. ShowData Method
Displays the current data and allows the user to enter new data.
```csharp
private static void ShowData()
```

### 10. ShowGuide Method
Displays a guide explaining how to use the application and the special commands available.
```csharp
private static void ShowGuide()
```

### 11. ShowBubble Method
Since this method is using a lot of new code that we did not cover in the course I will provide extreme details on how it works. But TLDR, it displays messages in a styled "bubble" format on the console.
[Detailed Explanation of `ShowBubble` Method](#detailed-explanation-of-getinput-and-showbubble-methods)
```csharp
private static void ShowBubble(string text, ConsoleColor color = ConsoleColor.DarkGreen)
```

### 12. CommandString Method
Formats command descriptions for display in the guide and input prompt.
```csharp
private static string CommandString(string command, string description)
```

### 13. GetInput Method
Since this method is using a lot of new code that we did not cover in the course I will provide extreme details on how it works. But TLDR, it displays the main input prompt to the user, including the title, student names, special commands, and captures the user's input. [Detailed Explanation of `GetInput` Method](#detailed-explanation-of-getinput-and-showbubble-methods)
```csharp
private static string GetInput(string prompt = "Enter your question: ")
```

## Detailed Explanation of `GetInput` and `ShowBubble` Methods

### `GetInput` Method

The `GetInput` method is responsible for displaying the main input prompt to the user, including the title, student names, special commands, and capturing the user's input.

#### Code
[View `GetInput` method in `FactoidProject.cs`](FactoidProject.cs#L361)

#### Explanation

1. **Clear Console:**
   ```csharp
   Console.Clear();
   ```

2. **Define Sections and Commands:**
   - Title: "Factoid Project"
   - Student Section: "Student Names:"
   - Commands Section: "Special Commands:"
   - Special Commands: `exit`, `guide`, `data`
   ```csharp
   string title = "Factoid Project";
   string studentSection = "Student Names:";
   string commandsSection = "Special Commands:";
   string[] specialCommands = {
      CommandString("exit", "exit the program"),
      CommandString("guide", "show the guide of the program"),
      CommandString("data", "show the data you have entered")
   };
   ```

3. **Set Console Color:**
   ```csharp
   Console.ForegroundColor = ConsoleColor.Cyan;
   ```

4. **Calculate Box Width:**
   ```csharp
   int consoleWidth = Console.WindowWidth;
   int writingAreaWidth = 60;
   int boxWidth = Math.Max(title.Length, prompt.Length + writingAreaWidth) + 6;
   ValidateBoxSize(ref boxWidth);
   ```

5. **Calculate Padding:**
   ```csharp
   int leftPadding = (consoleWidth - boxWidth) / 2;
   int titlePadding = (boxWidth - 2 - title.Length) / 2;
   ```

6. **Draw Box:**
   - Top Border
   - Title
   - Sections (Student Names, Special Commands)
   - Prompt
   ```csharp
   Console.WriteLine(new string(' ', leftPadding) + "╔" + new string('═', boxWidth - 2) + "╗");
   Console.WriteLine(new string(' ', leftPadding) + "║" + new string(' ', titlePadding) + title + new string(' ', boxWidth - 2 - titlePadding - title.Length) + "║");
   Console.WriteLine(new string(' ', leftPadding) + "╠" + new string('═', boxWidth - 2) + "╣");

   Console.WriteLine(new string(' ', leftPadding) + $"║ {studentSection.PadRight(boxWidth - 4)} ║");
   for (int i = 0; i < students.Length; i++) Console.WriteLine(new string(' ', leftPadding) + $"║ - {students[i].PadRight(boxWidth - 6)} ║");
   Console.WriteLine(new string(' ', leftPadding) + "╠" + new string('═', boxWidth - 2) + "╣");

   Console.WriteLine(new string(' ', leftPadding) + $"║ {commandsSection.PadRight(boxWidth - 4)} ║");
   for (int i = 0; i < specialCommands.Length; i++) Console.WriteLine(new string(' ', leftPadding) + $"║ {specialCommands[i].PadRight(boxWidth - 4)} ║");
   Console.WriteLine(new string(' ', leftPadding) + "╠" + new string('═', boxWidth - 2) + "╣");

   Console.WriteLine(new string(' ', leftPadding) + $"║ {prompt.PadRight(boxWidth - 4)} ║");

   Console.WriteLine(new string(' ', leftPadding) + "╚" + new string('═', boxWidth - 2) + "╝");
   ```

7. **Reset Console Color:**
   ```csharp
   Console.ResetColor();
   ```

8. **Set Cursor Position and Read Input:**
   ```csharp
   Console.SetCursorPosition(leftPadding + 2 + prompt.Length, Console.CursorTop - 2);
   string? input = Console.ReadLine();
   ```

9. **Return Input:**
   ```csharp
   if (input == null) return "";
   return input;
   ```

### `ShowBubble` Method

The `ShowBubble` method is responsible for displaying messages in a styled "bubble" format on the console.

#### Code
[View `ShowBubble` method in `FactoidProject.cs`](FactoidProject.cs#L317)

#### Explanation

1. **Store Message in Bubbles Array:**
   ```csharp
   for (int i = 0; i < bubbles.Length; i++)
   {
      if (bubbles[i] == null)
      {
         bubbles[i] = text;
         bubblesCount++;
         break;
      }
   }
   ```

2. **Calculate Box Dimensions:**
   ```csharp
   int consoleWidth = Console.WindowWidth;
   int maxBoxWidth = consoleWidth / 2 + 20;
   int desiredWidth = Math.Min(text.Length + 6, maxBoxWidth);
   ValidateBoxSize(ref desiredWidth);
   int leftPadding = (consoleWidth - desiredWidth) / 2;
   ```

3. **Set Console Color:**
   ```csharp
   Console.ForegroundColor = color;
   ```

4. **Draw Top Border:**
   ```csharp
   Console.SetCursorPosition(leftPadding, (bubblesCount - 1) * 5);
   Console.WriteLine("╔" + new string('═', desiredWidth - 2) + "╗");
   ```

5. **Draw Text Lines:**
   ```csharp
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
   ```

6. **Draw Bottom Border:**
   ```csharp
   Console.SetCursorPosition(leftPadding, Console.CursorTop);
   Console.WriteLine("╚" + new string('═', desiredWidth - 2) + "╝");
   ```

7. **Reset Cursor Position and Color:**
   ```csharp
   Console.SetCursorPosition(0, Console.CursorTop + 1);
   Console.ResetColor();
   ```


## Special Commands

- `exit` - Exit the program
- `guide` - Show the guide of the program
- `data` - Show the data you have entered

## Example Usage

1. **Run the application:**
   ```sh
   dotnet run
   ```

2. **Enter the data you would like to analyze:**
   ```
   Please enter the data you would like to analyze: 
   ```

3. **Ask a question:**
   ```
   Enter your question: Who is the CEO of the company?
   ```

4. **View the answer and continue:**
   ```
   Press any key to continue...
   ```

5. **Use special commands as needed:**
   ```
   Enter your question: guide
   ```

Enjoy using FactoidProject to analyze and answer questions based on your data!