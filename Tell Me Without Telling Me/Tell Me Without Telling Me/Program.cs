using System;

namespace Tell_Me_Without_Telling_Me
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isPlaying = true;
            int level = 1;
            int health = 3;
            double score = 0;
            int hint = 3;

            Console.WriteLine("TELL ME WITHOUT TELLING ME");
            Console.WriteLine();

            while (isPlaying)
            {
                Console.WriteLine("Do you want to Play?");
                Console.WriteLine("Type [Y] for \"Yes\" and [N] for \"No\"");
                string play = GetUserInput();

                if (play == "y")
                {
                    Console.WriteLine("\n------------------------------------\n");
                    Console.WriteLine("Type in the answers to the riddles\n");

                    //A loop to go through all riddle questions.
                    //Ends when health reaches 0, if all riddles are shown, or both.
                    for (int riddleNumber = 0; (health > 0) && (riddleNumber <= 24); riddleNumber++)
                    {
                        
                        int numDot = riddleNumber + 1;

                        //Checks if five riddles have passed, if yes, level goes up by 1 and restore 3 health.
                        if (((riddleNumber % 5) == 0) && riddleNumber > 0)
                        {
                            level++;
                            health = 3;
                            Console.WriteLine("LEVEL UP!");
                            Console.WriteLine("You've regained all your health.");
                            Console.WriteLine("\n------------------------------------\n");
                        }

                        Console.WriteLine("Level: " + level);
                        Console.WriteLine("Tries left: " + health);
                        Console.WriteLine("Score: " + score);
                        Console.WriteLine("Hints: " + hint);
                        Console.WriteLine("(Press [H] to use a hint)\n");
                        Console.WriteLine("{0}. {1}", numDot, RiddleManager(riddleNumber));
                        string userInput = GetUserInput();

                        //Checks if user presses [H] and wants to use a hint.
                        if (userInput == "h")
                        {
                            if (hint > 0)
                            {
                                hint--;
                                Console.WriteLine();
                                Console.WriteLine(HintManager(riddleNumber));
                                userInput = GetUserInput();
                            }
                            else
                            {
                                Console.WriteLine("\nYou don't have any hints.\n");
                                Console.WriteLine("{0}. {1}", numDot, RiddleManager(riddleNumber));
                                userInput = GetUserInput();
                            }
                        }

                        //Checks if user entered the correct answer or not.
                        if (userInput == AnswerManager(riddleNumber))
                        {
                            score++;
                            Console.WriteLine();
                            Console.WriteLine("Correct!");

                            //User gains a hint every 3 correct answers.
                            if ((score % 3) == 0)
                            {
                                hint++;
                                Console.WriteLine("You gained a hint!");
                            }
                        }
                        else
                        {
                            health--;
                            Console.WriteLine();
                            Console.WriteLine("Incorrect, the answer is: " + AnswerManager(riddleNumber));
                        }

                        Console.WriteLine("\n------------------------------------\n");
                    }

                    Console.WriteLine("Thank you for playing!");
                    Console.WriteLine("Your total score is: " + score);
                    isPlaying = false;
                }
                else if (play == "n")
                {
                    Console.WriteLine("\n------------------------------------\n");
                    Console.WriteLine("Ok. Have a nice day.");
                    isPlaying = false;
                }
                else
                {
                    Console.WriteLine("Invalid character, Please try again.");
                    Console.WriteLine("\n------------------------------------\n");
                }
            }

            Console.WriteLine("\nPress ANY KEY to exit.");
            Console.Read();
        }

        //All 25 riddles are stored in an array here
        static string RiddleManager(int riddleNumber)
        {
            string[] Riddles = new string[]
            {
                ("What is the coldest country in the world?"),
                ("What has a neck but no head?"),
                ("What has one eye but can’t see anything at all?"),
                ("What kind of tree can you carry in your hand?"),
                ("What’s full of holes but can still hold liquid?"),
                ("What two words, when combined, hold the most letters?"),
                ("What bird can lift the most weight?"),
                ("Where is an ocean with no water?"),
                ("What word starts with IS, ends with AND, and has LA in the middle?"),
                ("Before Mount Everest was discovered, what was the tallest mountain on Earth?"),
                ("What will you actually find at the end of every rainbow?"),
                ("I start out tall, but the longer I stand, the shorter I grow. What am I?"),
                ("What has a head, a tail, but does not have a body?"),
                ("What gets sharper the more you use it?"),
                ("What belongs to you but gets used by everyone else more than you?"),
                ("What are two things you can never eat for breakfast?"),
                ("What’s greater than God and more evil than the devil. Rich people want it, poor people have it. And if you eat it, you’ll die?"),
                ("What has a face and two hands, but no arms or legs?"),
                ("What has a thumb and four fingers but isn’t actually alive?"),
                ("What goes up and down, but always remains in the same place?"),
                ("What word is spelled incorrectly in every single dictionary?"),
                ("What starts with \"e\" and ends with \"e\" but only has one letter in it?"),
                ("Some months have 31 days, others have 30 days, but how many have 28 days?"),
                ("I’m so fragile that if you say something, you’ll break me. What am I?"),
                ("What has four eyes but can’t see?")
            };

            return Riddles[riddleNumber];
        }

        //All 25 answers are stored in an array here
        static string AnswerManager(int answerNumber)
        {
            string[] Answers = new string[]
            {
                ("chile"),
                ("bottle"),
                ("needle"),
                ("palm"),
                ("sponge"),
                ("post office"),
                ("crane"),
                ("map"),
                ("island"),
                ("mount everest"),
                ("w"),
                ("candle"),
                ("coin"),
                ("brain"),
                ("name"),
                ("lunch and dinner"),
                ("nothing"),
                ("clock"),
                ("glove"),
                ("stairs"),
                ("incorrectly"),
                ("envelope"),
                ("twelve"),
                ("silence"),
                ("mississippi")
            };

            return Answers[answerNumber];
        }

        //All 25 hints are stored in an array here
        static string HintManager(int hintNumber)
        {
            string[] Hints = new string[]
            {
                ("A country in South America"),
                ("It's not a shirt"),
                ("It's sharp"),
                ("A type of tree, as well as a body part"),
                ("It's usually yellow in colour"),
                ("It's a room, specifically an office"),
                ("It takes the shape of the letter \"T\", with the one side being longer"),
                ("It's made of paper"),
                ("It's surrounded by water"),
                ("It's located between Nepal and Tibet"),
                ("It's not a word"),
                ("An alternative for flashlight"),
                ("Circular in shape"),
                ("The nervous system"),
                ("You have it ever since you were born"),
                ("Inedible"),
                ("Synonymous to the word NIL"),
                ("It tells you the time"),
                ("Used as protection for your hands"),
                ("Usually depicted as a way to heaven"),
                ("The answer is in the question"),
                ("It's not just one letter"),
                ("It's not just February"),
                ("Polar opposite of Noise"),
                ("It's a state in the U.S.")
            };

            return Hints[hintNumber];
        }

        //Gets user input
        static string GetUserInput()
        {
            string input = Console.ReadLine();
            return input.ToLower();
        }
    }
}
