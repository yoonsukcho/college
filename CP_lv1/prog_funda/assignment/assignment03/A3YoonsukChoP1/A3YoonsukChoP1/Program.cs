/*
 * Program name: A3YoonsukChoP1 - Even numbers & Perfect squares Calculator
 * 
 * Purpose: assignment 3-1
 *
 * Revision History:
 * created Sept 2015 by Yoonsuk Cho 
 * 
 * */

using System;

namespace A3YoonsukChoP1
{
    class Program
    {
        static void Main(string[] args)
        {
            int selMenu = 0;
            do
            {
                selMenu = startMenu();

                switch (selMenu)
                {
                    case 1:
                        execEven();
                        break;
                    case 2:
                        execSquare();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("BYE!");
                        break;
                    default:
                        break;
                }

            } while (selMenu !=3);

        }

        private static void execEven()
        {
            int numCnt = 0;
            Console.Write("\n\nHow many even numbers would you like to show?: ");
            string inputStr = Console.ReadLine();
            if (int.TryParse(inputStr, out numCnt))
            {
                if (numCnt <= 0)
                {
                    Console.WriteLine("\nPlease, input the number bigger than zero.\n");
                }
                
                for (int i = 1; i <= numCnt; i++)
                {
                    if (i == 1) Console.WriteLine("");
                    Console.WriteLine(i + ": " + ((i - 1) * 2));
                    if (i == numCnt) Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Please, input a integer number.\n");
            }
            Console.WriteLine("\nIf you want to continue press any key:");
            ConsoleKeyInfo selKey = Console.ReadKey();
            
        }

        private static void execSquare()
        {
            bool keepGoing = true;
            int i = 1;
            while (keepGoing)
            {
                Console.Write("\n\nthe square number of " + i + " is " + Math.Pow(i, 2d));
                Console.Write("\nIf you want to quit press \"q\", or to continue press any key: ");
                ConsoleKeyInfo selKey = Console.ReadKey();
                if (selKey.KeyChar.ToString().Equals("Q", StringComparison.CurrentCultureIgnoreCase))
                {
                    keepGoing = false;
                }
                i++;
            }
            Console.Write("\n\n");
        }


        private static int startMenu()
        {
            Console.Clear();
            int selNum = 0;
            Console.WriteLine("What would you like to calculate?");
            Console.WriteLine("1 - even numbers");
            Console.WriteLine("2 - perfect squares");
            Console.WriteLine("3 - quit");
            Console.Write("Please, select one option [1, 2 or 3]: ");
            ConsoleKeyInfo selKey = Console.ReadKey();
            string selMenu = selKey.KeyChar.ToString();
            if (!int.TryParse(selMenu, out selNum) || (selNum < 1 || selNum > 3))
            {
                Console.WriteLine("\n\nPlease, choose one among [1-3].\n\n");
            }
            return selNum;
        }
    }
}
