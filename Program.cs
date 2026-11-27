using CSToolsFinal;
using System.Net.Http.Headers;

public class MainClass
{

    public static Dictionary<String, PokeType> allTypes = new Dictionary<String, PokeType>();

    public static void Main(string[] args)
    {
        SetUpTypes();

        String userInput = "";

        int highscore = -1;

        try
        {
            String stringHighscore = File.ReadAllText("highscore.txt");
            highscore = int.Parse(stringHighscore);
        } catch (FileNotFoundException e)
        {
            
        }

        while (true)
        {
            // Main Menu Loop
            while (userInput == "")
            {
                Console.WriteLine("Welcome to Pokemon Type Trainer!\n");
                Console.WriteLine("Select an option:");
                Console.WriteLine("1) Play");
                Console.WriteLine("2) Exit");
                Console.WriteLine();

                if (highscore != -1)
                {
                    Console.WriteLine("Highscore: " + highscore);
                    Console.WriteLine();
                }

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
                WriteHighscoreToFile(highscore);
                Console.WriteLine("Highscore saved to file!");
                Console.WriteLine("Thanks for playing!");
                return;
            }

            userInput = "";

            // Play Game Loop

            Console.Clear();

            int questionNumber = 1;
            int score = 0;
            //String correctAnswer = "1";
            
            while (questionNumber <= 10)
            {
                Question question = GenerateQuestion();

                while (userInput == "")
                {
                    Console.Write("Q" + questionNumber + ") ");
                    Console.WriteLine(question.GetText());
                    Console.WriteLine("");
                    Console.WriteLine("1) " + question.GetChoice1());
                    Console.WriteLine("2) " + question.GetChoice2());
                    Console.WriteLine("3) " + question.GetChoice3());
                    Console.WriteLine("4) " + question.GetChoice4());

                    userInput = Console.ReadLine();

                    if (userInput != "1" && userInput != "2" && userInput != "3" && userInput != "4")
                    {
                        userInput = "";
                        Console.Clear();
                        Console.WriteLine("Select a valid answer\n");
                    }
                }

                if (userInput == question.GetAnswer())
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
            
            if (score > highscore) { highscore = score; }

            Console.ReadKey(true);
            Console.Clear();
        }
    }

    public static Question GenerateQuestion()
    {
        Random rand = new Random();

        int questionType = rand.Next(1, 5);

        int randTypeNumber = rand.Next(0, 18);

        PokeType randomType = allTypes.ElementAt(randTypeNumber).Value;

        String questionText = "";

        String answer1 = "";
        String answer2 = "";
        String answer3 = "";
        String answer4 = "";

        int randAnswerChoice = 1;

        if (questionType == 1)  // Attack Strengths
        {
            questionText = "What type is the " + randomType.GetName() + " type strong against?";
            PokeType answerType = randomType.GetRandAtkStrength();

            randAnswerChoice = rand.Next(1, 5);

            if (randAnswerChoice == 1)
            {
                answer1 = answerType.GetName();

                do
                {
                    answer2 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer2 == answer1 || randomType.GetAtkStrengthsNames().Contains(answer2));

                do
                {
                    answer3 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer3 == answer2 || answer3 == answer1 || randomType.GetAtkStrengthsNames().Contains(answer3));

                do
                {
                    answer4 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer4 == answer3 || answer4 == answer2 || answer4 == answer1 || randomType.GetAtkStrengthsNames().Contains(answer4));
            }
            else if (randAnswerChoice == 2)
            {
                answer2 = answerType.GetName();

                do
                {
                    answer1 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer2 == answer1 || randomType.GetAtkStrengthsNames().Contains(answer1));

                do
                {
                    answer3 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer3 == answer2 || answer3 == answer1 || randomType.GetAtkStrengthsNames().Contains(answer3));

                do
                {
                    answer4 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer4 == answer3 || answer4 == answer2 || answer4 == answer1 || randomType.GetAtkStrengthsNames().Contains(answer4));
            }
            else if (randAnswerChoice == 3)
            {
                answer3 = answerType.GetName();

                do
                {
                    answer1 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer3 == answer1 || randomType.GetAtkStrengthsNames().Contains(answer1));

                do
                {
                    answer2 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer3 == answer2 || answer2 == answer1 || randomType.GetAtkStrengthsNames().Contains(answer2));

                do
                {
                    answer4 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer4 == answer3 || answer4 == answer2 || answer4 == answer1 || randomType.GetAtkStrengthsNames().Contains(answer4));
            }
            else
            {
                answer4 = answerType.GetName();

                do
                {
                    answer1 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer4 == answer1 || randomType.GetAtkStrengthsNames().Contains(answer1));

                do
                {
                    answer2 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer4 == answer2 || answer2 == answer1 || randomType.GetAtkStrengthsNames().Contains(answer2));

                do
                {
                    answer3 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer4 == answer3 || answer3 == answer2 || answer3 == answer1 || randomType.GetAtkStrengthsNames().Contains(answer3));
            }
        }
        else if (questionType == 2)  // Attack Weaknesses
        {
            questionText = "What type resists the " + randomType.GetName() + " type?";
            PokeType answerType = randomType.GetRandAtkWeakness();

            randAnswerChoice = rand.Next(1, 5);

            if (randAnswerChoice == 1)
            {
                answer1 = answerType.GetName();

                do
                {
                    answer2 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer2 == answer1 || randomType.GetAtkWeaknessesNames().Contains(answer2));

                do
                {
                    answer3 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer3 == answer2 || answer3 == answer1 || randomType.GetAtkWeaknessesNames().Contains(answer3));

                do
                {
                    answer4 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer4 == answer3 || answer4 == answer2 || answer4 == answer1 || randomType.GetAtkWeaknessesNames().Contains(answer4));
            }
            else if (randAnswerChoice == 2)
            {
                answer2 = answerType.GetName();

                do
                {
                    answer1 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer2 == answer1 || randomType.GetAtkWeaknessesNames().Contains(answer1));

                do
                {
                    answer3 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer3 == answer2 || answer3 == answer1 || randomType.GetAtkWeaknessesNames().Contains(answer3));

                do
                {
                    answer4 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer4 == answer3 || answer4 == answer2 || answer4 == answer1 || randomType.GetAtkWeaknessesNames().Contains(answer4));
            }
            else if (randAnswerChoice == 3)
            {
                answer3 = answerType.GetName();

                do
                {
                    answer1 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer3 == answer1 || randomType.GetAtkWeaknessesNames().Contains(answer1));

                do
                {
                    answer2 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer3 == answer2 || answer2 == answer1 || randomType.GetAtkWeaknessesNames().Contains(answer2));

                do
                {
                    answer4 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer4 == answer3 || answer4 == answer2 || answer4 == answer1 || randomType.GetAtkWeaknessesNames().Contains(answer4));
            }
            else
            {
                answer4 = answerType.GetName();

                do
                {
                    answer1 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer4 == answer1 || randomType.GetAtkWeaknessesNames().Contains(answer1));

                do
                {
                    answer2 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer4 == answer2 || answer2 == answer1 || randomType.GetAtkWeaknessesNames().Contains(answer2));

                do
                {
                    answer3 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer4 == answer3 || answer3 == answer2 || answer3 == answer1 || randomType.GetAtkWeaknessesNames().Contains(answer3));
            }
        }
        else if (questionType == 3)  // Defense Strengths
        {
            questionText = "What type does the " + randomType.GetName() + " type resist?";
            PokeType answerType = randomType.GetRandDefStrength();

            randAnswerChoice = rand.Next(1, 5);

            if (randAnswerChoice == 1)
            {
                answer1 = answerType.GetName();

                do
                {
                    answer2 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer2 == answer1 || randomType.GetDefStrengthsNames().Contains(answer2));

                do
                {
                    answer3 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer3 == answer2 || answer3 == answer1 || randomType.GetDefStrengthsNames().Contains(answer3));

                do
                {
                    answer4 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer4 == answer3 || answer4 == answer2 || answer4 == answer1 || randomType.GetDefStrengthsNames().Contains(answer4));
            }
            else if (randAnswerChoice == 2)
            {
                answer2 = answerType.GetName();

                do
                {
                    answer1 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer2 == answer1 || randomType.GetDefStrengthsNames().Contains(answer1));

                do
                {
                    answer3 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer3 == answer2 || answer3 == answer1 || randomType.GetDefStrengthsNames().Contains(answer3));

                do
                {
                    answer4 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer4 == answer3 || answer4 == answer2 || answer4 == answer1 || randomType.GetDefStrengthsNames().Contains(answer4));
            }
            else if (randAnswerChoice == 3)
            {
                answer3 = answerType.GetName();

                do
                {
                    answer1 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer3 == answer1 || randomType.GetDefStrengthsNames().Contains(answer1));

                do
                {
                    answer2 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer3 == answer2 || answer2 == answer1 || randomType.GetDefStrengthsNames().Contains(answer2));

                do
                {
                    answer4 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer4 == answer3 || answer4 == answer2 || answer4 == answer1 || randomType.GetDefStrengthsNames().Contains(answer4));
            }
            else
            {
                answer4 = answerType.GetName();

                do
                {
                    answer1 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer4 == answer1 || randomType.GetDefStrengthsNames().Contains(answer1));

                do
                {
                    answer2 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer4 == answer2 || answer2 == answer1 || randomType.GetDefStrengthsNames().Contains(answer2));

                do
                {
                    answer3 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer4 == answer3 || answer3 == answer2 || answer3 == answer1 || randomType.GetDefStrengthsNames().Contains(answer3));
            }
        }
        else if (questionType == 4)  // Defense Weaknesses
        {
            questionText = "What type is strong against the " + randomType.GetName() + " type?";
            PokeType answerType = randomType.GetRandDefWeakness();

            randAnswerChoice = rand.Next(1, 5);

            if (randAnswerChoice == 1)
            {
                answer1 = answerType.GetName();

                do
                {
                    answer2 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer2 == answer1 || randomType.GetDefWeaknessesNames().Contains(answer2));

                do
                {
                    answer3 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer3 == answer2 || answer3 == answer1 || randomType.GetDefWeaknessesNames().Contains(answer3));

                do
                {
                    answer4 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer4 == answer3 || answer4 == answer2 || answer4 == answer1 || randomType.GetDefWeaknessesNames().Contains(answer4));
            }
            else if (randAnswerChoice == 2)
            {
                answer2 = answerType.GetName();

                do
                {
                    answer1 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer2 == answer1 || randomType.GetDefWeaknessesNames().Contains(answer1));

                do
                {
                    answer3 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer3 == answer2 || answer3 == answer1 || randomType.GetDefWeaknessesNames().Contains(answer3));

                do
                {
                    answer4 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer4 == answer3 || answer4 == answer2 || answer4 == answer1 || randomType.GetDefWeaknessesNames().Contains(answer4));
            }
            else if (randAnswerChoice == 3)
            {
                answer3 = answerType.GetName();

                do
                {
                    answer1 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer3 == answer1 || randomType.GetDefWeaknessesNames().Contains(answer1));

                do
                {
                    answer2 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer3 == answer2 || answer2 == answer1 || randomType.GetDefWeaknessesNames().Contains(answer2));

                do
                {
                    answer4 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer4 == answer3 || answer4 == answer2 || answer4 == answer1 || randomType.GetDefWeaknessesNames().Contains(answer4));
            }
            else
            {
                answer4 = answerType.GetName();

                do
                {
                    answer1 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer4 == answer1 || randomType.GetDefWeaknessesNames().Contains(answer1));

                do
                {
                    answer2 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer4 == answer2 || answer2 == answer1 || randomType.GetDefWeaknessesNames().Contains(answer2));

                do
                {
                    answer3 = allTypes.ElementAt(rand.Next(0, 18)).Value.GetName();
                } while (answer4 == answer3 || answer3 == answer2 || answer3 == answer1 || randomType.GetDefWeaknessesNames().Contains(answer3));
            }
        }

        return new Question(questionText, randAnswerChoice.ToString(), answer1, answer2, answer3, answer4);
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


        // Ground
        type = null;
        atkStrengths = new PokeType[5];
        atkWeaknesses = new PokeType[2];
        defStrengths = new PokeType[2];
        defWeaknesses = new PokeType[3];

        allTypes.TryGetValue("Poison", out atkStrengths[0]);
        allTypes.TryGetValue("Rock", out atkStrengths[1]);
        allTypes.TryGetValue("Fire", out atkStrengths[2]);
        allTypes.TryGetValue("Electric", out atkStrengths[3]);
        allTypes.TryGetValue("Steel", out atkStrengths[4]);

        allTypes.TryGetValue("Bug", out atkWeaknesses[0]);
        allTypes.TryGetValue("Grass", out atkWeaknesses[1]);

        allTypes.TryGetValue("Poison", out defStrengths[0]);
        allTypes.TryGetValue("Rock", out defStrengths[1]);

        allTypes.TryGetValue("Water", out defWeaknesses[0]);
        allTypes.TryGetValue("Grass", out defWeaknesses[1]);
        allTypes.TryGetValue("Ice", out defWeaknesses[2]);

        allTypes.TryGetValue("Ground", out type);
        type.SetAtkStrengths(atkStrengths);
        type.SetAtkWeaknesses(atkWeaknesses);
        type.SetDefStrengths(defStrengths);
        type.SetDefWeaknesses(defWeaknesses);


        // Rock
        type = null;
        atkStrengths = new PokeType[4];
        atkWeaknesses = new PokeType[3];
        defStrengths = new PokeType[4];
        defWeaknesses = new PokeType[5];

        allTypes.TryGetValue("Flying", out atkStrengths[0]);
        allTypes.TryGetValue("Bug", out atkStrengths[1]);
        allTypes.TryGetValue("Fire", out atkStrengths[2]);
        allTypes.TryGetValue("Ice", out atkStrengths[3]);

        allTypes.TryGetValue("Fighting", out atkWeaknesses[0]);
        allTypes.TryGetValue("Ground", out atkWeaknesses[1]);
        allTypes.TryGetValue("Steel", out atkWeaknesses[2]);

        allTypes.TryGetValue("Normal", out defStrengths[0]);
        allTypes.TryGetValue("Flying", out defStrengths[1]);
        allTypes.TryGetValue("Poison", out defStrengths[2]);
        allTypes.TryGetValue("Fire", out defStrengths[3]);

        allTypes.TryGetValue("Fighting", out defWeaknesses[0]);
        allTypes.TryGetValue("Ground", out defWeaknesses[1]);
        allTypes.TryGetValue("Water", out defWeaknesses[2]);
        allTypes.TryGetValue("Grass", out defWeaknesses[3]);
        allTypes.TryGetValue("Steel", out defWeaknesses[4]);

        allTypes.TryGetValue("Rock", out type);
        type.SetAtkStrengths(atkStrengths);
        type.SetAtkWeaknesses(atkWeaknesses);
        type.SetDefStrengths(defStrengths);
        type.SetDefWeaknesses(defWeaknesses);


        // Bug
        type = null;
        atkStrengths = new PokeType[3];
        atkWeaknesses = new PokeType[7];
        defStrengths = new PokeType[3];
        defWeaknesses = new PokeType[3];

        allTypes.TryGetValue("Grass", out atkStrengths[0]);
        allTypes.TryGetValue("Psychic", out atkStrengths[1]);
        allTypes.TryGetValue("Dark", out atkStrengths[2]);

        allTypes.TryGetValue("Fighting", out atkWeaknesses[0]);
        allTypes.TryGetValue("Flying", out atkWeaknesses[1]);
        allTypes.TryGetValue("Poison", out atkWeaknesses[2]);
        allTypes.TryGetValue("Ghost", out atkWeaknesses[3]);
        allTypes.TryGetValue("Steel", out atkWeaknesses[4]);
        allTypes.TryGetValue("Fire", out atkWeaknesses[5]);
        allTypes.TryGetValue("Fairy", out atkWeaknesses[6]);

        allTypes.TryGetValue("Fighting", out defStrengths[0]);
        allTypes.TryGetValue("Ground", out defStrengths[1]);
        allTypes.TryGetValue("Grass", out defStrengths[2]);

        allTypes.TryGetValue("Flying", out defWeaknesses[0]);
        allTypes.TryGetValue("Rock", out defWeaknesses[1]);
        allTypes.TryGetValue("Fire", out defWeaknesses[2]);

        allTypes.TryGetValue("Bug", out type);
        type.SetAtkStrengths(atkStrengths);
        type.SetAtkWeaknesses(atkWeaknesses);
        type.SetDefStrengths(defStrengths);
        type.SetDefWeaknesses(defWeaknesses);


        // Ghost
        type = null;
        atkStrengths = new PokeType[2];
        atkWeaknesses = new PokeType[1];
        defStrengths = new PokeType[2];
        defWeaknesses = new PokeType[2];

        allTypes.TryGetValue("Ghost", out atkStrengths[0]);
        allTypes.TryGetValue("Psychic", out atkStrengths[1]);

        allTypes.TryGetValue("Dark", out atkWeaknesses[0]);

        allTypes.TryGetValue("Poison", out defStrengths[0]);
        allTypes.TryGetValue("Bug", out defStrengths[1]);

        allTypes.TryGetValue("Ghost", out defWeaknesses[0]);
        allTypes.TryGetValue("Dark", out defWeaknesses[1]);

        allTypes.TryGetValue("Ghost", out type);
        type.SetAtkStrengths(atkStrengths);
        type.SetAtkWeaknesses(atkWeaknesses);
        type.SetDefStrengths(defStrengths);
        type.SetDefWeaknesses(defWeaknesses);


        // Steel
        type = null;
        atkStrengths = new PokeType[3];
        atkWeaknesses = new PokeType[4];
        defStrengths = new PokeType[10];
        defWeaknesses = new PokeType[3];

        allTypes.TryGetValue("Rock", out atkStrengths[0]);
        allTypes.TryGetValue("Ice", out atkStrengths[1]);
        allTypes.TryGetValue("Fairy", out atkStrengths[2]);

        allTypes.TryGetValue("Steel", out atkWeaknesses[0]);
        allTypes.TryGetValue("Fire", out atkWeaknesses[1]);
        allTypes.TryGetValue("Water", out atkWeaknesses[2]);
        allTypes.TryGetValue("Electric", out atkWeaknesses[3]);

        allTypes.TryGetValue("Normal", out defStrengths[0]);
        allTypes.TryGetValue("Flying", out defStrengths[1]);
        allTypes.TryGetValue("Rock", out defStrengths[2]);
        allTypes.TryGetValue("Bug", out defStrengths[3]);
        allTypes.TryGetValue("Steel", out defStrengths[4]);
        allTypes.TryGetValue("Grass", out defStrengths[5]);
        allTypes.TryGetValue("Psychic", out defStrengths[6]);
        allTypes.TryGetValue("Ice", out defStrengths[7]);
        allTypes.TryGetValue("Dragon", out defStrengths[8]);
        allTypes.TryGetValue("Fairy", out defStrengths[9]);

        allTypes.TryGetValue("Fighting", out defWeaknesses[0]);
        allTypes.TryGetValue("Ground", out defWeaknesses[1]);
        allTypes.TryGetValue("Fire", out defWeaknesses[2]);

        allTypes.TryGetValue("Steel", out type);
        type.SetAtkStrengths(atkStrengths);
        type.SetAtkWeaknesses(atkWeaknesses);
        type.SetDefStrengths(defStrengths);
        type.SetDefWeaknesses(defWeaknesses);


        // Electric
        type = null;
        atkStrengths = new PokeType[2];
        atkWeaknesses = new PokeType[3];
        defStrengths = new PokeType[3];
        defWeaknesses = new PokeType[1];

        allTypes.TryGetValue("Flying", out atkStrengths[0]);
        allTypes.TryGetValue("Water", out atkStrengths[1]);

        allTypes.TryGetValue("Grass", out atkWeaknesses[0]);
        allTypes.TryGetValue("Electric", out atkWeaknesses[1]);
        allTypes.TryGetValue("Dragon", out atkWeaknesses[2]);

        allTypes.TryGetValue("Flying", out defStrengths[0]);
        allTypes.TryGetValue("Electric", out defStrengths[1]);
        allTypes.TryGetValue("Steel", out defStrengths[2]);

        allTypes.TryGetValue("Ground", out defWeaknesses[0]);

        allTypes.TryGetValue("Electric", out type);
        type.SetAtkStrengths(atkStrengths);
        type.SetAtkWeaknesses(atkWeaknesses);
        type.SetDefStrengths(defStrengths);
        type.SetDefWeaknesses(defWeaknesses);


        // Psychic
        type = null;
        atkStrengths = new PokeType[2];
        atkWeaknesses = new PokeType[2];
        defStrengths = new PokeType[2];
        defWeaknesses = new PokeType[3];

        allTypes.TryGetValue("Fighting", out atkStrengths[0]);
        allTypes.TryGetValue("Poison", out atkStrengths[1]);

        allTypes.TryGetValue("Psychic", out atkWeaknesses[0]);
        allTypes.TryGetValue("Steel", out atkWeaknesses[1]);

        allTypes.TryGetValue("Fighting", out defStrengths[0]);
        allTypes.TryGetValue("Psychic", out defStrengths[1]);

        allTypes.TryGetValue("Bug", out defWeaknesses[0]);
        allTypes.TryGetValue("Ghost", out defWeaknesses[1]);
        allTypes.TryGetValue("Dark", out defWeaknesses[2]);

        allTypes.TryGetValue("Psychic", out type);
        type.SetAtkStrengths(atkStrengths);
        type.SetAtkWeaknesses(atkWeaknesses);
        type.SetDefStrengths(defStrengths);
        type.SetDefWeaknesses(defWeaknesses);


        // Ice
        type = null;
        atkStrengths = new PokeType[4];
        atkWeaknesses = new PokeType[4];
        defStrengths = new PokeType[1];
        defWeaknesses = new PokeType[4];

        allTypes.TryGetValue("Flying", out atkStrengths[0]);
        allTypes.TryGetValue("Ground", out atkStrengths[1]);
        allTypes.TryGetValue("Grass", out atkStrengths[2]);
        allTypes.TryGetValue("Dragon", out atkStrengths[3]);

        allTypes.TryGetValue("Water", out atkWeaknesses[0]);
        allTypes.TryGetValue("Ice", out atkWeaknesses[1]);
        allTypes.TryGetValue("Steel", out atkWeaknesses[2]);
        allTypes.TryGetValue("Fire", out atkWeaknesses[3]);

        allTypes.TryGetValue("Ice", out defStrengths[0]);

        allTypes.TryGetValue("Fighting", out defWeaknesses[0]);
        allTypes.TryGetValue("Rock", out defWeaknesses[1]);
        allTypes.TryGetValue("Fire", out defWeaknesses[2]);
        allTypes.TryGetValue("Steel", out defWeaknesses[3]);

        allTypes.TryGetValue("Ice", out type);
        type.SetAtkStrengths(atkStrengths);
        type.SetAtkWeaknesses(atkWeaknesses);
        type.SetDefStrengths(defStrengths);
        type.SetDefWeaknesses(defWeaknesses);


        // Dragon
        type = null;
        atkStrengths = new PokeType[1];
        atkWeaknesses = new PokeType[1];
        defStrengths = new PokeType[4];
        defWeaknesses = new PokeType[3];

        allTypes.TryGetValue("Dragon", out atkStrengths[0]);

        allTypes.TryGetValue("Steel", out atkWeaknesses[0]);

        allTypes.TryGetValue("Fire", out defStrengths[0]);
        allTypes.TryGetValue("Water", out defStrengths[1]);
        allTypes.TryGetValue("Grass", out defStrengths[2]);
        allTypes.TryGetValue("Electric", out defStrengths[3]);

        allTypes.TryGetValue("Ice", out defWeaknesses[0]);
        allTypes.TryGetValue("Dragon", out defWeaknesses[1]);
        allTypes.TryGetValue("Fairy", out defWeaknesses[2]);

        allTypes.TryGetValue("Dragon", out type);
        type.SetAtkStrengths(atkStrengths);
        type.SetAtkWeaknesses(atkWeaknesses);
        type.SetDefStrengths(defStrengths);
        type.SetDefWeaknesses(defWeaknesses);


        // Dark
        type = null;
        atkStrengths = new PokeType[2];
        atkWeaknesses = new PokeType[3];
        defStrengths = new PokeType[2];
        defWeaknesses = new PokeType[3];

        allTypes.TryGetValue("Ghost", out atkStrengths[0]);
        allTypes.TryGetValue("Psychic", out atkStrengths[1]);

        allTypes.TryGetValue("Fighting", out atkWeaknesses[0]);
        allTypes.TryGetValue("Dark", out atkWeaknesses[1]);
        allTypes.TryGetValue("Fairy", out atkWeaknesses[2]);

        allTypes.TryGetValue("Ghost", out defStrengths[0]);
        allTypes.TryGetValue("Dark", out defStrengths[1]);

        allTypes.TryGetValue("Fighting", out defWeaknesses[0]);
        allTypes.TryGetValue("Bug", out defWeaknesses[1]);
        allTypes.TryGetValue("Fairy", out defWeaknesses[1]);

        allTypes.TryGetValue("Dark", out type);
        type.SetAtkStrengths(atkStrengths);
        type.SetAtkWeaknesses(atkWeaknesses);
        type.SetDefStrengths(defStrengths);
        type.SetDefWeaknesses(defWeaknesses);


        // Fairy
        type = null;
        atkStrengths = new PokeType[3];
        atkWeaknesses = new PokeType[3];
        defStrengths = new PokeType[3];
        defWeaknesses = new PokeType[2];

        allTypes.TryGetValue("Fighting", out atkStrengths[0]);
        allTypes.TryGetValue("Dragon", out atkStrengths[1]);
        allTypes.TryGetValue("Dark", out atkStrengths[2]);

        allTypes.TryGetValue("Poison", out atkWeaknesses[0]);
        allTypes.TryGetValue("Steel", out atkWeaknesses[1]);
        allTypes.TryGetValue("Fire", out atkWeaknesses[2]);

        allTypes.TryGetValue("Fighting", out defStrengths[0]);
        allTypes.TryGetValue("Bug", out defStrengths[1]);
        allTypes.TryGetValue("Dark", out defStrengths[2]);

        allTypes.TryGetValue("Poison", out defWeaknesses[0]);
        allTypes.TryGetValue("Steel", out defWeaknesses[1]);

        allTypes.TryGetValue("Fairy", out type);
        type.SetAtkStrengths(atkStrengths);
        type.SetAtkWeaknesses(atkWeaknesses);
        type.SetDefStrengths(defStrengths);
        type.SetDefWeaknesses(defWeaknesses);
    }

    public static void WriteHighscoreToFile(int highscore)
    {
        String path = "highscore.txt";
        File.WriteAllText(path, highscore.ToString());
    }
}