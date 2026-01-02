namespace FunWith2DArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Fun With 2D Arrays Program!");
            Console.WriteLine("This program provides an opportunity to play with 2D arrays.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

            while (true)
            {
                Console.WriteLine("Enter the dimensions of the two dimensional array to create. For the sake of simplicity lets keep the dimensions in single digit.");
                Console.WriteLine("Please enter it in either of these 2 formats -> rows x columns or rows, columns : ");
                string unparsedDimensions = Console.ReadLine();

                char[] delimiters = { 'x', 'X', ',' };
                string[] parsedDimensions = unparsedDimensions.Split(delimiters,StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries | StringSplitOptions.None);

                if (parsedDimensions.Length == 2)
                {
                    Console.WriteLine("The dimensions of the two dimensional array is: " + parsedDimensions.Length);
                    Console.WriteLine($"The dimensions are : {parsedDimensions[0]} x {parsedDimensions[1]}");
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
        }
    }
}