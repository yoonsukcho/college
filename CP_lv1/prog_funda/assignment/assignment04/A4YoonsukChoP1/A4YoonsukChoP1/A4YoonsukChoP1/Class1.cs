/*
 * Program name: A4YoonsukChoP1 - Dog Information Data class
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
    class DogInformation
    {
        private string name;
        private string breed;
        private string colour;
        private bool isMale;

        public DogInformation()
        {
            this.name = "";
            this.breed = "";
            this.colour = "";
            this.isMale = true;
        }

        public DogInformation(string name, string breed, string colour, bool isMale)
        {
            this.name = name;
            this.breed = breed;
            this.colour = colour;
            this.isMale = isMale;
        }

        public void DisplayDogInformation()
        {
            Console.WriteLine();
            Console.WriteLine("Dog name: {0}", this.name);
            Console.WriteLine("Dog breed: {0}", this.breed);
            Console.WriteLine("Dog colour: {0}", this.colour);
            Console.WriteLine("Dog isMale: {0}", (this.isMale)? "Male":"Female");
        }

        public void EditDogInformation(string name, string breed, string colour, bool isMale)
        {
            this.name = name;
            this.breed = breed;
            this.colour = colour;
            this.isMale = isMale;

        }


    }
}
