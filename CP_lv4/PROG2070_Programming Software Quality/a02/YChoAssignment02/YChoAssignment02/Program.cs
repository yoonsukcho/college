using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// PROG2070 – Quality Assurance: Winter 2017
/// Assignment 02
/// Yoonsuk Cho Feb 14, 2017
/// </summary>
namespace YChoAssignment02
{
    /// <summary>
    /// main class of assignment 2
    /// </summary>
    class Program
    {
        /// <summary>
        /// program start main method
        /// using TriangleSolver.Analyze
        /// it will show the type of triangle with input sides
        /// </summary>
        /// <param name="args">parameters of start method</param>
        static void Main(string[] args)
        {

            bool isCont = true;
            int input = 0;
            int[] sides = { -1, -1, -1 };

            while (isCont)
            {
                Console.WriteLine("1.Enter triangle dimensions");
                Console.WriteLine("2.Exit");
                Console.WriteLine();
                Console.Write("Please select number (1-2): ");
                if (Int32.TryParse(Console.ReadLine(), out input))
                {
                    if (input < 1 || input > 2) input = 3;
                }
                else input = 3;

                switch (input)
                {
                    // when selected '1.Enter triangle dimensions' in the menu
                    case 1:
                        Console.WriteLine("");
                        bool isContIn = true;
                        int sideOrder = 0;
                        while (isContIn)
                        {
                            Console.Write("Enter the side{0}: ", (sideOrder + 1));

                            input = sides[sideOrder];
                            if (Int32.TryParse(Console.ReadLine(), out input))
                            {
                                // case of less than 1
                                if (input < 1)
                                {
                                    Console.WriteLine("Input must be greater than 0.");
                                    Console.WriteLine();
                                    input = -1;
                                }
                            }
                            else
                            {
                                // case of non integer
                                Console.WriteLine("Input must be an integer.");
                                Console.WriteLine();
                            }
                            // integer and greater than 0
                            if (input > 0)
                            {
                                sides[sideOrder] = input;
                                sideOrder++;
                                Console.WriteLine();
                            }
                            // all 3 inputs are integer and greater than 0
                            if (sideOrder > 2)
                            {
                                isContIn = false;
                                string message = TriangleSolver.Analyze(sides);
                                Console.WriteLine(message);
                                Console.WriteLine();
                                clearScreen();
                            }

                        }
                        break;
                    case 2:
                        // when selected '2.Exit' in the menu
                        isCont = false;
                        Console.WriteLine("Bye !");
                        clearScreen();
                        break;
                    default:
                        Console.WriteLine("You have got a wrong input!");
                        clearScreen();
                        break;

                }

            }

        }

        /// <summary>
        /// show message and clear message
        /// if press any key, program goes on.
        /// </summary>
        private static void clearScreen()
        {
            Console.WriteLine("Press any key !");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
