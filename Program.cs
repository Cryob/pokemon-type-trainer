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
            Console.WriteLine("Game Loop!");
            Console.ReadLine();
            
        }
    }
}