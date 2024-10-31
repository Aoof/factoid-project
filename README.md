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
Displays messages in a styled "bubble" format on the console.
```csharp
private static void ShowBubble(string text, ConsoleColor color = ConsoleColor.DarkGreen)
```

### 12. CommandString Method
Formats command descriptions for display in the guide and input prompt.
```csharp
private static string CommandString(string command, string description)
```

### 13. GetInput Method
Displays the main input prompt, including student names and special commands, and captures the user's input.
```csharp
private static string GetInput(string prompt = "Enter your question: ")
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