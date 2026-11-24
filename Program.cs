using CSToolsFinal;

public class MainClass
{
    public static void Main(string[] args)
    {
        String userInput = "";

        while (true)
        {
            // Main Menu Loop
            while (userInput == "")
            {
                Console.WriteLine("Welcome to Pokemon Type Trainer!\n");
                Console.WriteLine("Select an option:");
                Console.WriteLine("1) Play");
                Console.WriteLine("2) Exit");

                userInput = Console.ReadLine();

                if (userInput != "1" && userInput != "2")
                {
                    userInput = "";
                    Console.Clear();
                    Console.WriteLine("Invalid Option\n");
                }
            }

            if (userInput == "2") // Exit Game
            {
                return;
            }

            userInput = "";

            // Play Game Loop

            Console.Clear();

            int questionNumber = 1;
            int score = 0;
            String correctAnswer = "1";
            
            while (questionNumber <= 10)
            {
                while (userInput == "")
                {
                    Console.Write("Q" + questionNumber + ") ");
                    Console.WriteLine("Which type is strong against the Fire types?");
                    Console.WriteLine("");
                    Console.WriteLine("1) Water");
                    Console.WriteLine("2) Grass");
                    Console.WriteLine("3) Steel");
                    Console.WriteLine("4) Ghost");

                    userInput = Console.ReadLine();

                    if (userInput != "1" && userInput != "2" && userInput != "3" && userInput != "4")
                    {
                        userInput = "";
                        Console.Clear();
                        Console.WriteLine("Select a valid answer\n");
                    }
                }

                if (userInput == correctAnswer)
                {
                    Console.WriteLine("Correct!");
                    score++;
                } else
                {
                    Console.WriteLine("Incorrect");
                }

                Console.ReadKey(true);

                Console.Clear();
                questionNumber++;
                userInput = "";
            }

            Console.WriteLine("End of Quiz!");
            Console.WriteLine("You scored: " + score + " / 10");
            Console.WriteLine("Click to go back to main menu...");

            Console.ReadKey(true);
            Console.Clear();
        }
    }

    public static Question GenerateQuestion()
    {
        String questionText = "";

        return new Question();
    }
}