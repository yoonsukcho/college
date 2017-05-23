using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// PROG2070-17W-Sec4-Programming: Software Quality Assurance
/// Assignment1 - main program
/// 
/// Yoonsuk Cho #7135551
/// Feb 02, 2017
/// </summary>
namespace YChoAssignment01
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isCont = true;
            int input = 0;

            while (isCont)
            {
                Console.Write("Input Square Side Length: ");
                if (Int32.TryParse(Console.ReadLine(), out input))
                {
                    if (input < 1) isCont = true;
                    else isCont = false;
                }
                if (isCont)
                {
                    Console.WriteLine("You have got a wrong input!");
                }
                else
                {
                    Console.WriteLine("Input side length: " + input);
                }
                clearScreen();

            }

            Square square = new Square(input);
            isCont = true;
            while (isCont)
            {
                
                Console.WriteLine("1.Get Square Side Length");
                Console.WriteLine("2.Change Square Side Length");
                Console.WriteLine("3.Get Square Perimeter");
                Console.WriteLine("4.Get Square Area");
                Console.WriteLine("5.Exit");
                Console.WriteLine("");
                Console.Write("Please select number (1-5): ");
                
                if (Int32.TryParse(Console.ReadLine(), out input))
                {
                    if (input < 1 || input > 5) input = 6;
                }
                else input = 6;

                switch (input)
                {
                    case 1:
                        Console.WriteLine("Square Side is {0}", square.GetSide());
                        clearScreen();
                        break;
                    case 2:
                        Console.WriteLine("Input side length: ");
                        int sideLength = 0;
                        if (Int32.TryParse(Console.ReadLine(), out sideLength))
                        {
                            if (sideLength >= 1)
                            {
                                square.ChangeSide(sideLength);
                                Console.WriteLine("Square side is changed to {0}", sideLength);
                                clearScreen();
                                break;
                            }
                        }
                        Console.WriteLine("You have got a wrong input!");
                        clearScreen();
                        break;
                    case 3:
                        Console.WriteLine("Square Perimeter is {0}", square.GetPerimeter());
                        clearScreen();
                        break;
                    case 4:
                        Console.WriteLine("Square Area is {0}", square.GetArea());
                        clearScreen();
                        break;
                    case 5:
                        isCont = false;
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
        /// </summary>
        private static void clearScreen()
        {
            Console.WriteLine("Press any key !");
            Console.ReadKey();
            Console.Clear();
        }


    }
}
