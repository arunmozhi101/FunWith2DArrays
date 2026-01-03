using System;
using System.Drawing;
using Colorful;
using Console = Colorful.Console;

namespace FunWith2DArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            const int TWO_DIMENSION = 2;
            
            Console.WriteLine("Welcome to Fun With 2D Arrays Program!");
            Console.WriteLine("This program provides an opportunity to play with 2D arrays.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

            int rows2DArray, columns2DArray;

            while (true)
            {
                Console.WriteLine("Enter the dimensions of the two dimensional array to create. For the sake of simplicity lets keep the dimensions in single digit.");
                Console.WriteLine("Please enter it in either of these 2 formats -> rows x columns or rows, columns : ");
                string unparsedDimensions = Console.ReadLine();

                char[] delimiters = { 'x', 'X', ',' };
                string[] parsedDimensions = unparsedDimensions.Split(delimiters, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries | StringSplitOptions.None);

                if (parsedDimensions.Length == TWO_DIMENSION)
                {
                    Console.WriteLine("The dimensions of the two dimensional array is: " + parsedDimensions.Length);
                    Console.WriteLine($"The dimensions are : {parsedDimensions[0]} x {parsedDimensions[1]}");
                    rows2DArray = Convert.ToInt32(parsedDimensions[0]);
                    columns2DArray = Convert.ToInt32(parsedDimensions[1]);
                    break;
                }
                else
                {
                    Console.WriteLine("Error: Incorrect dimensions input. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                //int[,] 2DArray = new int[rows2DArray, columns2DArray];
                //array[0, 0] = 1;
            }
            // End of while loop

            // Create the 2D Array
            string[,] string2DArray = new string[rows2DArray, columns2DArray];

            while (true)
            {
                const int MANUAL = 1;
                const int AUTOMATIC = 2;
                Console.WriteLine("Do you want to fill in the values manually by yourself or get the program to fill it up randomly from a pre-defined list?");
                Console.WriteLine("Choose one of the 2 options:");
                Console.WriteLine("1 - Manual [Can be a single character or a string filled manually by the user one by one.]");
                Console.WriteLine("2 - Automatic [Characters from a pre-configured list filled randomly.]");
                int usersChoiceToFill = Convert.ToInt32(Console.ReadLine());

                if (usersChoiceToFill == MANUAL)
                {
                    for (int i = 0; i < rows2DArray; i++)
                    {
                        for (int j = 0; j < columns2DArray; j++)
                        {
                            Console.Write($"[{i},{j}] = ");
                            string2DArray[i, j] = Console.ReadLine(); //Need to handle exceptions in the future, for now I expect a clean input from the user.
                        }
                    }

                    break;
                }
                else if (usersChoiceToFill == AUTOMATIC)
                {
                    string symbolsList = "!@#$%^&*()_+{}:;\"<>?,./\\[]|-=";

                    for (int i = 0; i < rows2DArray; i++)
                    {
                        for (int j = 0; j < columns2DArray; j++)
                        {
                            Random rng = new Random();
                            int randomNumber = rng.Next(0, symbolsList.Length);

                            string2DArray[i, j] = symbolsList[randomNumber].ToString();
                        }
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("Error: Incorrect option. Please try again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
            }
            //End of While loop
            
            //Print the grid we just created.
            for (int i = 0; i < rows2DArray; i++)
            {
                for (int j = 0; j < columns2DArray; j++)
                {
                    Console.Write($"{string2DArray[i, j]}  ");
                }
                Console.WriteLine();
            }

            // Display options.
            while (true)
            {
                const int INDICES_WITH_BORDER = 1;
                const int CHESS_BOARD_X_O = 2;
                const int NUMBERS_USING_COLORS = 3;
                
                Console.WriteLine("How do you want the grid to be printed?");
                Console.WriteLine("Choose one of the 3 options:");
                Console.WriteLine("1 - Print the indices and a border between the cells.");
                Console.WriteLine("2 - Print like a chess board with alternating values on the grid.");
                Console.WriteLine("3 - Print array with numbers using alternating colors.");
                int usersChoiceToDisplay = Convert.ToInt32(Console.ReadLine());

                if (usersChoiceToDisplay == INDICES_WITH_BORDER)
                {
                    string roofPattern = "";
                    for (int i = 0; i < columns2DArray; i++)
                    {
                        roofPattern += "+---";
                    }

                    roofPattern += "+";

                    for (int i = 0; i < rows2DArray; i++)
                    {
                        Console.WriteLine(roofPattern, Color.Blue);
                        for (int j = 0; j < columns2DArray; j++)
                        {
                            Console.Write($"|{i},{j}", Color.Blue);
                        }

                        Console.Write($"|", Color.Blue);
                        Console.WriteLine();
                    }

                    Console.WriteLine(roofPattern, Color.Blue);
                    break;
                }
                else if (usersChoiceToDisplay == CHESS_BOARD_X_O)
                {
                    int count = 0;
                    char[] xoChars = { 'X', 'O' };

                    for (int i = 0; i < rows2DArray; i++)
                    {
                        for (int j = 0; j < columns2DArray; j++)
                        {
                            Console.Write($"{xoChars[count % 2]}  ", Color.DarkRed);
                            count++;
                        }

                        Console.WriteLine();
                    }

                    break;
                }
                else if (usersChoiceToDisplay == NUMBERS_USING_COLORS)
                {
                    //Print array with numbers using alternating colors
                    int count = 0;
                    string roofPattern = "";
                    ColorAlternatorFactory alternatorFactory = new ColorAlternatorFactory();
                    ColorAlternator alternator = alternatorFactory.GetAlternator(2, Color.Red,
                        Color.Orange, Color.Indigo, Color.LightGreen);

                    for (int i = 0; i < columns2DArray; i++)
                    {
                        roofPattern += "+---";
                    }

                    roofPattern += "+";

                    for (int i = 0; i < rows2DArray; i++)
                    {
                        Console.WriteLine(roofPattern, Color.White);
                        for (int j = 0; j < columns2DArray; j++)
                        {
                            Console.Write("|", Color.White);
                            if (count < 10)
                            {
                                Console.WriteAlternating($" {count} ", alternator);
                                count++;
                            }
                            else
                            {
                                Console.WriteAlternating($" {count}", alternator);
                                count++;
                            }
                        }

                        Console.Write("|", Color.White);
                        Console.WriteLine();
                    }

                    Console.WriteLine(roofPattern, Color.White);
                    break;
                }
                else
                {
                    Console.WriteLine("Error: Incorrect option. Please re-run the program again.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
            }
        }
    }
}