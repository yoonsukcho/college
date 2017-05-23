/*
 * Program name: A2YoonsukChoP2 - Volume of 3D Objects App 
 * 
 * Purpose: assignment 2-2
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

namespace A2YoonsukChoP2
{
    class Program
    {
        static readonly double pi = 3.14159d;

        static void Main(string[] args)
        {
            double vol = 0.00d;
            double[] inpuValueArray;
            
            string selStr = "";
            bool continuous = true;
            while (continuous) 
            {
                selStr = selectVolType();
                if (selStr.Equals("1"))
                {
                    Console.WriteLine("You chose a sphere.");
                    inpuValueArray = getInputArrays(1);
                    vol = getVol(inpuValueArray[0]);
                    Console.WriteLine("The volume of the sphere is: " + vol);

                } 
                else if (selStr.Equals("2"))
                {
                    Console.WriteLine("You chose a cynlinder.");
                    inpuValueArray = getInputArrays(2);
                    vol = getVol(inpuValueArray[0], inpuValueArray[1]);
                    Console.WriteLine("The volume of the cynlinder is: " + vol);

                }
                else if (selStr.Equals("3"))
                {
                    Console.WriteLine("You chose a rectangular prism.");
                    inpuValueArray = getInputArrays(3);
                    vol = getVol(inpuValueArray[0], inpuValueArray[1], inpuValueArray[2]);
                    Console.WriteLine("The volume of the rectangular prism is: " + vol);

                }
                else
                {
                    Console.WriteLine("You chose wrong value.");
                }
                continuous = askAgain();

            }

        }

        private static bool askAgain()
        {
            Console.WriteLine("\nPress \"c\" key for continue or any other key for quit: ");
            string doContinuous = Console.ReadLine();
            if ("C".Equals(doContinuous) || "c".Equals(doContinuous))
            {
                Console.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }

        private static string selectVolType()
        {
            Console.WriteLine("What would you like to calculate the volume of?");
            Console.WriteLine("Please select one option [1, 2 or 3]");
            Console.WriteLine("1 - Volume of a sphere");
            Console.WriteLine("2 - Volume of a cynlinder");
            Console.WriteLine("3 - Volume of a rectangular prism");
            return Console.ReadLine();
        }

        private static double getVol(double rad)
        {
            double vol = 4d / 3d * pi * Math.Pow(rad, 3d);
            return vol;
        }
        private static double getVol(double rad, double hgt)
        {
            double vol = pi * Math.Pow(rad, 2d) * hgt;
            return vol;
        }
        private static double getVol(double len, double wid, double hgt)
        {
            double vol = len * wid * hgt;
            return vol;
        }
        private static double[] getInputArrays(int sel) {
            double[] inpuValueArray = new double[3]{0.00d, 0.00d, 0.00d};

            if (sel == 1)
            {
                inpuValueArray[0] = askValue("radius");
            }
            else if (sel == 2)
            {
                inpuValueArray[0] = askValue("radius");
                inpuValueArray[1] = askValue("height");
            }
            else
            {
                inpuValueArray[0] = askValue("length");
                inpuValueArray[1] = askValue("width");
                inpuValueArray[2] = askValue("height");
            }
            
            return inpuValueArray;

        }

        private static double askValue(string askVal)
        {
            double retVal = 0.00d;
            while (retVal <= 0)
            {
                Console.Write("Please enter a " + askVal + ": ");
                if (!canParse(Console.ReadLine(), out retVal))
                {
                    Console.WriteLine("Only number which is bigger than 0 is allowed.");
                }
            }
            return retVal;
        }

        private static bool canParse(string str, out double retValue)
        {
            bool success = true;
            retValue = 0d;
            try
            {
                retValue = double.Parse(str);
            }
            catch (Exception ex)
            {
                success = false;
            }
            return success;
        }

    }
}
