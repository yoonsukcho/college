using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// PROG2070 – Quality Assurance: Winter 2017
/// Assignment 03
/// Yoonsuk Cho Mar 14, 2017
/// </summary>
namespace ProjectA
{
    /// <summary>
    /// main class of assignment 3
    /// Project A
    /// </summary>
    class Program
    {
        /// <summary>
        /// program start main method
        /// using TimeConversion class
        /// it will convert time unit
        /// this program will not check a time unit and time result
        /// </summary>
        /// <param name="args">parameters of start method</param>

        static void Main(string[] args)
        {
            bool doCont = true;

            while (doCont)
            {
                double inputTime = 0.0d;
                Console.WriteLine("=========================================");
                Console.WriteLine("======   Time Converter ProjectA   ======");
                Console.WriteLine("=========================================");
                Console.WriteLine();
                Console.Write("Enter a time: ");
                string timeStr = Console.ReadLine();
                if (Double.TryParse(timeStr, out inputTime))
                {
                    Console.Write("Enter a time unit (convert from): ");
                    string convertFrom = Console.ReadLine();
                    Console.Write("Enter a time unit (convert to): ");
                    string convertTo = Console.ReadLine();
                    Console.WriteLine();
                    try
                    {
                        double convertedValue = TimeConversion.Convert(inputTime,
                                                                       convertFrom,
                                                                       convertTo);
                        Console.WriteLine("{0}({1}) converts to {2}({3}).",
                                          timeStr,
                                          convertFrom,
                                          convertedValue,
                                          convertTo);
                    }
                    catch (ArgumentException ae)
                    {
                        Console.WriteLine(ae.Message);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                }
                else
                {
                    Console.WriteLine("Invalid number input.");
                }

                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press Enter to continue, or any other key to exit.");

                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    doCont = true;
                    Console.Clear();
                }
                else
                {
                    doCont = false;
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine(" =================");
                    Console.WriteLine("      BYE!!!");
                    Console.WriteLine(" =================");
                    Console.ReadKey();
                }

            }

        }
    }
}
