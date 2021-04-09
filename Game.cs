using System;
using System.Collections.Generic;
using System.Text;

namespace MathGame
{
    class Game
    {
        private static Random rand = new Random();
        public static string UserInputStr()
        {
            string output = Console.ReadLine();
            if (String.IsNullOrEmpty(output))
            {
                Console.WriteLine("Incorrect Format, try again:");
                return UserInputStr();
            }
            return output;
        }
        public static int UserInputInt()
        {
            int output = 0;
            try
            {
                output = Int32.Parse(UserInputStr());
            }
            catch
            {
                Console.WriteLine("Incorrect Format, try again:");
                return UserInputInt();
            }
            return output;
        }
        public static double UserInputDouble()
        {
            double output = 0.0;
            try
            {
                output = Double.Parse(UserInputStr());
            }
            catch
            {
                Console.WriteLine("Incorrect Format, try again:");
                return UserInputDouble();
            }
            return output;
        }
        public static void GameUI()
        {
            for ( ; ; ) {
                Console.WriteLine("Welcome to Math Games!");
                Console.WriteLine(" Please select an operation to practice: ");
                Console.WriteLine(" 1. Addition");
                Console.WriteLine(" 2. Subtraction");
                Console.WriteLine(" 3. Multiplication");
                Console.WriteLine(" 4. Division");
                Console.WriteLine(" 5. All of the above");
                Console.WriteLine(" 6. Exit application");
                Console.WriteLine("\nEnter Selection: ");
                string input = UserInputStr();
                while (input != "1" && input != "2" && input != "3" && input != "4" && input != "5" && input != "6")
                {
                    Console.WriteLine("\nEnter Selection: ");
                    input = UserInputStr();
                }
                if (input == "6") return;
                Console.WriteLine("How many problems would you like?");
                int numProb = UserInputInt();
                GameRun(input, numProb);
            }
        }

        public static int AdditionProblem(double x, double y)
        {
            Console.WriteLine($"{x} + {y} = ? :");
            double answer = UserInputDouble();
            if(answer == x + y)
            {
                Console.WriteLine("Correct!");
                return 1;
            }
            Console.WriteLine($"Incorrect, the correct answer is: {x + y}.");
            return 0;
        }
        public static int SubtractionProblem(double x, double y)
        {
            Console.WriteLine($"{x} - {y} = ? :");
            double answer = UserInputDouble();
            if (answer == x - y)
            {
                Console.WriteLine("Correct!");
                return 1;
            }
            Console.WriteLine($"Incorrect, the correct answer is: {x - y}.");
            return 0;
        }
        public static int MultiplicationProblem(double x, double y)
        {
            Console.WriteLine($"{x} x {y} = ? :");
            double answer = UserInputDouble();
            if (answer == x * y)
            {
                Console.WriteLine("Correct!");
                return 1;
            }
            Console.WriteLine($"Incorrect, the correct answer is: {x * y}.");
            return 0;
        }
        public static int DivisionProblem(double x, double y)
        {
            Console.WriteLine($"{x} / {y} = ? :");
            double answer = UserInputDouble();
            if (answer == Math.Round((x / y), 2) || answer == Math.Round((x / y), 1))
            {
                Console.WriteLine("Correct!");
                return 1;
            }
            Console.WriteLine($"Incorrect, the correct answer is: {x / y}.");
            return 0;
        }
        public static void GameRun(string selection, int num)
        {
            double x = 0;
            double y = 0;

            int correct = 0;
            for (int i = 0; i < num; i++)
            {
                x = rand.Next(1, 101);
                y = rand.Next(1, 101);
                switch (selection)
                {
                    case "1":
                        correct += AdditionProblem(x,y);
                        break;
                    case "2":
                        correct += SubtractionProblem(x, y);
                        break;
                    case "3":
                        correct += MultiplicationProblem(x, y);
                        break;
                    case "4":
                        correct += DivisionProblem(x, y);
                        break;
                    case "5":
                        correct += AdditionProblem(x, y);
                        x = rand.Next(1, 101);
                        y = rand.Next(1, 101);
                        i++;
                        correct += SubtractionProblem(x, y);
                        x = rand.Next(1, 101);
                        y = rand.Next(1, 101);
                        i++;
                        correct += MultiplicationProblem(x, y);
                        x = rand.Next(1, 101);
                        y = rand.Next(1, 101);
                        i++;
                        correct += DivisionProblem(x, y);
                        x = rand.Next(1, 101);
                        y = rand.Next(1, 101);
                        break;
                    default:
                        throw new Exception("Invalid selection in game runtime");
                }
            }

            Console.WriteLine($"Game complete. You got {correct} out of {num} questions correct.");
        }
    }
}