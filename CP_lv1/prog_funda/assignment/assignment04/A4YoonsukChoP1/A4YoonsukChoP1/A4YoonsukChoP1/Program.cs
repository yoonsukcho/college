/*
 * Program name: A4YoonsukChoP1 - Dog Information management app
 * 
 * Purpose: assignment 4
 *
 * Revision History:
 * created Sept 2015 by Yoonsuk Cho 
 * 
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4YoonsukChoP1
{
    class Program
    {

        private static DogInformation dogInformation;
        private static int sleepTime = 1000;

        static void Main(string[] args)
        {
            string selMenu = "";
            bool keepGoing = true;

            while (keepGoing)
            {
                selMenu = StartMenu();

                switch (selMenu)
                {
                    case "A":
                    case "a":
                        if (DisplayDogInform()) isContinue();
                        break;
                    case "B":
                    case "b":
                        AddDogInform();
                        break;
                    case "C":
                    case "c":
                        EditDogInform();
                        break;
                    case "D":
                    case "d":
                        ExitApp();
                        keepGoing = false;
                        break;
                    default:
                        Console.WriteLine("\n\nPlease, select one among [A, B, C or D]");
                        System.Threading.Thread.Sleep(sleepTime);
                        break;
                }

            }

        }

        private static string StartMenu()
        {

            string selMenu = "";
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("Dog Information management app");
            Console.WriteLine("===================================\n");
            Console.WriteLine("A: Display the dog information");
            Console.WriteLine("B: Add a new dog information");
            Console.WriteLine("C: Edit an exiting dog information");
            Console.WriteLine("D: Quit");
            Console.Write("\nPlease, select one option [A, B, C or D]: ");
            selMenu = Console.ReadKey().KeyChar.ToString();

            return selMenu;

        }

        private static bool CheckNullDogInstance() 
        {
            if (dogInformation == null)
            {
                Console.WriteLine("\n\nNo dog record exists");
                isContinue();
                return false;
            }
            return true;
        }

        private static bool DisplayDogInform()
        {
            if (!CheckNullDogInstance()) return false;
            Console.Clear();
            Console.WriteLine("Display a current dog information.");
            Console.WriteLine("----------------------------");
            dogInformation.DisplayDogInformation();
            return true;
        }

        private static void AddDogInform()
        {
            if (dogInformation != null)
            {
                Console.WriteLine("\n\nDog record already exists");
                isContinue();
                return;
            }

            Console.Clear();
            Console.WriteLine("Add a new dog information.");
            Console.WriteLine("----------------------------"); 
            string name = checkNullData("name");
            string breed = checkNullData("breed");
            string colour = checkNullData("colour");
            bool isMale = checkBoolData();

            dogInformation = new DogInformation(name, breed, colour, isMale);

            Console.WriteLine("\nNew dog record add success!");
            isContinue();
        
        }

        private static void EditDogInform()
        {
            if (!DisplayDogInform()) return;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Edit an exist dog information.");
            Console.WriteLine("----------------------------");
            string name = checkNullData("new name");
            string breed = checkNullData("new breed");
            string colour = checkNullData("new colour");
            bool isMale = checkBoolData();

            dogInformation.EditDogInformation(name, breed, colour, isMale);

            Console.WriteLine("\nDog record edit success!");
            isContinue();
        }

        private static void ExitApp()
        {
            Console.Clear();
            Console.WriteLine("BYE!");
            System.Threading.Thread.Sleep(sleepTime);
        }

        private static bool isContinue()
        {
            Console.WriteLine("\n\nIf you want to continue, press any key!!");
            string pressKey = Console.ReadKey().Key.ToString();
            if (pressKey != null) return true;
            return false;
        }

        private static string checkNullData(string fieldName)
        {
            bool keepGoing = true;
            string inputData = "";
            do 
            {
                Console.Write("Please, input dog {0}: ", fieldName);
                inputData = Console.ReadLine();
                if (inputData == "")
                {
                    Console.WriteLine("\nAn empty value cannot be allowed.\n");
                }
                else
                {
                    keepGoing = false;
                }

            }
            while (keepGoing);
            return inputData;
        }

        private static bool checkBoolData()
        {
            bool keepGoing = false;
            bool isMale = true;

            do
            {
                keepGoing = false;
                Console.Write("Please, input dog gender - male [m] or female[f]: ");
                string tempGender = Console.ReadLine();
                if (tempGender.Equals("m", StringComparison.CurrentCultureIgnoreCase))
                {
                    isMale = true;
                }
                else if (tempGender.Equals("f", StringComparison.CurrentCultureIgnoreCase))
                {
                    isMale = false;
                }
                else
                {
                    Console.WriteLine("\nPlease, input [m] for male or [f] for female.");
                    keepGoing = true;
                }
            }
            while (keepGoing);
            return isMale;
        }
    }
}
