using CSToolsFinal;
using System.Net.Http.Headers;

public class MainClass
{

    public static Dictionary<String, PokeType> allTypes = new Dictionary<String, PokeType>();

    public static void Main(string[] args)
    {
        SetUpTypes();

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

    public static void SetUpTypes()
    {
        allTypes.TryAdd("Fire", new PokeType("Fire"));
        allTypes.TryAdd("Water", new PokeType("Water"));
        allTypes.TryAdd("Grass", new PokeType("Grass"));
        allTypes.TryAdd("Normal", new PokeType("Normal"));
        allTypes.TryAdd("Fighting", new PokeType("Fighting"));
        allTypes.TryAdd("Flying", new PokeType("Flying"));
        allTypes.TryAdd("Poison", new PokeType("Poison"));
        allTypes.TryAdd("Ground", new PokeType("Ground"));
        allTypes.TryAdd("Rock", new PokeType("Rock"));
        allTypes.TryAdd("Bug", new PokeType("Bug"));
        allTypes.TryAdd("Ghost", new PokeType("Ghost"));
        allTypes.TryAdd("Steel", new PokeType("Steel"));
        allTypes.TryAdd("Electric", new PokeType("Electric"));
        allTypes.TryAdd("Psychic", new PokeType("Psychic"));
        allTypes.TryAdd("Ice", new PokeType("Ice"));
        allTypes.TryAdd("Dragon", new PokeType("Dragon"));
        allTypes.TryAdd("Dark", new PokeType("Dark"));
        allTypes.TryAdd("Fairy", new PokeType("Fairy"));

        // Hard code Strengths/Weaknesses (It had to be done somewhere...)

        // Fire
        PokeType type = null;
        PokeType[] atkStrengths = new PokeType[4];
        PokeType[] atkWeaknesses = new PokeType[4];
        PokeType[] defStrengths = new PokeType[6];
        PokeType[] defWeaknesses = new PokeType[3];

        allTypes.TryGetValue("Bug", out atkStrengths[0]);
        allTypes.TryGetValue("Grass", out atkStrengths[1]);
        allTypes.TryGetValue("Ice", out atkStrengths[2]);
        allTypes.TryGetValue("Steel", out atkStrengths[3]);

        allTypes.TryGetValue("Rock", out atkWeaknesses[0]);
        allTypes.TryGetValue("Fire", out atkWeaknesses[1]);
        allTypes.TryGetValue("Water", out atkWeaknesses[2]);
        allTypes.TryGetValue("Dragon", out atkWeaknesses[3]);

        allTypes.TryGetValue("Bug", out defStrengths[0]);
        allTypes.TryGetValue("Fire", out defStrengths[1]);
        allTypes.TryGetValue("Grass", out defStrengths[2]);
        allTypes.TryGetValue("Steel", out defStrengths[3]);
        allTypes.TryGetValue("Ice", out defStrengths[4]);
        allTypes.TryGetValue("Fairy", out defStrengths[5]);

        allTypes.TryGetValue("Ground", out defWeaknesses[0]);
        allTypes.TryGetValue("Rock", out defWeaknesses[1]);
        allTypes.TryGetValue("Water", out defWeaknesses[2]);

        allTypes.TryGetValue("Fire", out type);
        type.SetAtkStrengths(atkStrengths);
        type.SetAtkWeaknesses(atkWeaknesses);
        type.SetDefStrengths(defStrengths);
        type.SetDefWeaknesses(defWeaknesses);


        // Water
        type = null;
        atkStrengths = new PokeType[3];
        atkWeaknesses = new PokeType[3];
        defStrengths = new PokeType[4];
        defWeaknesses = new PokeType[2];

        allTypes.TryGetValue("Ground", out atkStrengths[0]);
        allTypes.TryGetValue("Rock", out atkStrengths[1]);
        allTypes.TryGetValue("Fire", out atkStrengths[2]);

        allTypes.TryGetValue("Water", out atkWeaknesses[0]);
        allTypes.TryGetValue("Grass", out atkWeaknesses[1]);
        allTypes.TryGetValue("Dragon", out atkWeaknesses[2]);

        allTypes.TryGetValue("Fire", out defStrengths[0]);
        allTypes.TryGetValue("Water", out defStrengths[1]);
        allTypes.TryGetValue("Ice", out defStrengths[2]);
        allTypes.TryGetValue("Steel", out defStrengths[3]);

        allTypes.TryGetValue("Grass", out defWeaknesses[0]);
        allTypes.TryGetValue("Electric", out defWeaknesses[1]);

        allTypes.TryGetValue("Water", out type);
        type.SetAtkStrengths(atkStrengths);
        type.SetAtkWeaknesses(atkWeaknesses);
        type.SetDefStrengths(defStrengths);
        type.SetDefWeaknesses(defWeaknesses);


        // Grass
        type = null;
        atkStrengths = new PokeType[3];
        atkWeaknesses = new PokeType[7];
        defStrengths = new PokeType[4];
        defWeaknesses = new PokeType[5];

        allTypes.TryGetValue("Ground", out atkStrengths[0]);
        allTypes.TryGetValue("Rock", out atkStrengths[1]);
        allTypes.TryGetValue("Water", out atkStrengths[2]);

        allTypes.TryGetValue("Flying", out atkWeaknesses[0]);
        allTypes.TryGetValue("Poison", out atkWeaknesses[1]);
        allTypes.TryGetValue("Bug", out atkWeaknesses[2]);
        allTypes.TryGetValue("Fire", out atkWeaknesses[3]);
        allTypes.TryGetValue("Grass", out atkWeaknesses[4]);
        allTypes.TryGetValue("Dragon", out atkWeaknesses[5]);
        allTypes.TryGetValue("Steel", out atkWeaknesses[6]);

        allTypes.TryGetValue("Ground", out defStrengths[0]);
        allTypes.TryGetValue("Water", out defStrengths[1]);
        allTypes.TryGetValue("Grass", out defStrengths[2]);
        allTypes.TryGetValue("Electric", out defStrengths[3]);

        allTypes.TryGetValue("Flying", out defWeaknesses[0]);
        allTypes.TryGetValue("Poison", out defWeaknesses[1]);
        allTypes.TryGetValue("Bug", out defWeaknesses[2]);
        allTypes.TryGetValue("Fire", out defWeaknesses[3]);
        allTypes.TryGetValue("Ice", out defWeaknesses[4]);

        allTypes.TryGetValue("Grass", out type);
        type.SetAtkStrengths(atkStrengths);
        type.SetAtkWeaknesses(atkWeaknesses);
        type.SetDefStrengths(defStrengths);
        type.SetDefWeaknesses(defWeaknesses);


        // Normal
        type = null;
        atkStrengths = new PokeType[1];
        atkWeaknesses = new PokeType[2];
        defStrengths = new PokeType[1];
        defWeaknesses = new PokeType[1];

        atkStrengths[0] = new PokeType("None");

        allTypes.TryGetValue("Rock", out atkWeaknesses[0]);
        allTypes.TryGetValue("Steel", out atkWeaknesses[1]);

        defStrengths[0] = new PokeType("None");

        allTypes.TryGetValue("Fighting", out defWeaknesses[0]);

        allTypes.TryGetValue("Normal", out type);
        type.SetAtkStrengths(atkStrengths);
        type.SetAtkWeaknesses(atkWeaknesses);
        type.SetDefStrengths(defStrengths);
        type.SetDefWeaknesses(defWeaknesses);


        // Fighting
        type = null;
        atkStrengths = new PokeType[5];
        atkWeaknesses = new PokeType[5];
        defStrengths = new PokeType[3];
        defWeaknesses = new PokeType[3];

        allTypes.TryGetValue("Normal", out atkStrengths[0]);
        allTypes.TryGetValue("Rock", out atkStrengths[1]);
        allTypes.TryGetValue("Ice", out atkStrengths[2]);
        allTypes.TryGetValue("Steel", out atkStrengths[3]);
        allTypes.TryGetValue("Dark", out atkStrengths[4]);

        allTypes.TryGetValue("Flying", out atkWeaknesses[0]);
        allTypes.TryGetValue("Poison", out atkWeaknesses[1]);
        allTypes.TryGetValue("Bug", out atkWeaknesses[2]);
        allTypes.TryGetValue("Psychic", out atkWeaknesses[3]);
        allTypes.TryGetValue("Fairy", out atkWeaknesses[4]);

        allTypes.TryGetValue("Rock", out defStrengths[0]);
        allTypes.TryGetValue("Bug", out defStrengths[1]);
        allTypes.TryGetValue("Dark", out defStrengths[2]);

        allTypes.TryGetValue("Flying", out defWeaknesses[0]);
        allTypes.TryGetValue("Psychic", out defWeaknesses[1]);
        allTypes.TryGetValue("Fairy", out defWeaknesses[2]);

        allTypes.TryGetValue("Fighting", out type);
        type.SetAtkStrengths(atkStrengths);
        type.SetAtkWeaknesses(atkWeaknesses);
        type.SetDefStrengths(defStrengths);
        type.SetDefWeaknesses(defWeaknesses);


        // Flying
        type = null;
        atkStrengths = new PokeType[3];
        atkWeaknesses = new PokeType[3];
        defStrengths = new PokeType[3];
        defWeaknesses = new PokeType[3];

        allTypes.TryGetValue("Fighting", out atkStrengths[0]);
        allTypes.TryGetValue("Bug", out atkStrengths[1]);
        allTypes.TryGetValue("Grass", out atkStrengths[2]);

        allTypes.TryGetValue("Rock", out atkWeaknesses[0]);
        allTypes.TryGetValue("Electric", out atkWeaknesses[1]);
        allTypes.TryGetValue("Steel", out atkWeaknesses[2]);

        allTypes.TryGetValue("Fighting", out defStrengths[0]);
        allTypes.TryGetValue("Bug", out defStrengths[1]);
        allTypes.TryGetValue("Grass", out defStrengths[2]);

        allTypes.TryGetValue("Rock", out defWeaknesses[0]);
        allTypes.TryGetValue("Electric", out defWeaknesses[1]);
        allTypes.TryGetValue("Ice", out defWeaknesses[2]);

        allTypes.TryGetValue("Flying", out type);
        type.SetAtkStrengths(atkStrengths);
        type.SetAtkWeaknesses(atkWeaknesses);
        type.SetDefStrengths(defStrengths);
        type.SetDefWeaknesses(defWeaknesses);


        // Poison
        type = null;
        atkStrengths = new PokeType[2];
        atkWeaknesses = new PokeType[4];
        defStrengths = new PokeType[5];
        defWeaknesses = new PokeType[2];

        allTypes.TryGetValue("Grass", out atkStrengths[0]);
        allTypes.TryGetValue("Fairy", out atkStrengths[1]);

        allTypes.TryGetValue("Poison", out atkWeaknesses[0]);
        allTypes.TryGetValue("Ground", out atkWeaknesses[1]);
        allTypes.TryGetValue("Rock", out atkWeaknesses[2]);
        allTypes.TryGetValue("Ghost", out atkWeaknesses[3]);

        allTypes.TryGetValue("Fighting", out defStrengths[0]);
        allTypes.TryGetValue("Poison", out defStrengths[1]);
        allTypes.TryGetValue("Grass", out defStrengths[2]);
        allTypes.TryGetValue("Bug", out defStrengths[3]);
        allTypes.TryGetValue("Fairy", out defStrengths[4]);

        allTypes.TryGetValue("Ground", out defWeaknesses[0]);
        allTypes.TryGetValue("Psychic", out defWeaknesses[1]);

        allTypes.TryGetValue("Poison", out type);
        type.SetAtkStrengths(atkStrengths);
        type.SetAtkWeaknesses(atkWeaknesses);
        type.SetDefStrengths(defStrengths);
        type.SetDefWeaknesses(defWeaknesses);


        // Poison
        type = null;
        atkStrengths = new PokeType[2];
        atkWeaknesses = new PokeType[4];
        defStrengths = new PokeType[5];
        defWeaknesses = new PokeType[2];

        allTypes.TryGetValue("Poison", out atkStrengths[0]);
        allTypes.TryGetValue("Fairy", out atkStrengths[1]);

        allTypes.TryGetValue("Poison", out atkWeaknesses[0]);
        allTypes.TryGetValue("Ground", out atkWeaknesses[1]);
        allTypes.TryGetValue("Rock", out atkWeaknesses[2]);
        allTypes.TryGetValue("Ghost", out atkWeaknesses[3]);

        allTypes.TryGetValue("Fighting", out defStrengths[0]);
        allTypes.TryGetValue("Poison", out defStrengths[1]);
        allTypes.TryGetValue("Grass", out defStrengths[2]);
        allTypes.TryGetValue("Bug", out defStrengths[3]);
        allTypes.TryGetValue("Fairy", out defStrengths[4]);

        allTypes.TryGetValue("Ground", out defWeaknesses[0]);
        allTypes.TryGetValue("Psychic", out defWeaknesses[1]);

        allTypes.TryGetValue("Poison", out type);
        type.SetAtkStrengths(atkStrengths);
        type.SetAtkWeaknesses(atkWeaknesses);
        type.SetDefStrengths(defStrengths);
        type.SetDefWeaknesses(defWeaknesses);
    }
}