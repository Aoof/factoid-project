public class Sofia
{
    public static void Main() {}
    // Sample data to test your program
    const string DATA = "The history of programming languages spans from documentation of early mechanical computers to modern tools for software development. Early programming languages were highly specialized, relying on mathematical notation and similarly obscure syntax. Throughout the 20th century, research in compiler theory led to the creation of high-level programming languages, which use a more accessible syntax to communicate instructions. The first high-level programming language was created by Konrad Zuse in 1943. The first high-level language to have an associated compiler was created by Corrado Böhm in 1951. Konrad Zuse was born on 1910/06/22, in GERMANY, and was a notable civil engineer, pioneering computer scientist, inventor, and businessman.";

    // Implement the following functions

    // 1. GetSimilarity
    // This function should calculate the similarity between the input string and the sentence string.
    // The similarity is calculated based on the number of matching words between the two strings.
    public double GetSimilarity(string input, string sentence)
    {
        // Implement your solution here using the `input` and `sentence` variables above
        return 0.0; // You will need to change this line to return the actual result
    }

    // 2. GetQuestionType
    // This function should determine the type of question based on the input string.
    // The question type is determined based on specific keywords in the input string.
    public string GetQuestionType(string input)
    {
        // Implement your solution here using the `input` variable above
        return ""; // You will need to change this line to return the actual result
    }

    // 3. GetAnswers
    // This function should return an array of answers based on the input sentence and question type.
    // The functions that will return the answers are GetPeople, GetPlaces, GetDates, GetNumbers.
    // Using your GetQuestionType function, determine the question type and call the appropriate function to get the answers.
    public string[] GetAnswers(string sentence, string questionType)
    {
        // Implement your solution here using the `question` and `DATA` variables above
        return new string[] { }; // You will need to change this line to return the actual result
    }
}
