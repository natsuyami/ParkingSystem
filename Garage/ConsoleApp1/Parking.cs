using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Parking
    {

        int Acounter = 0;
        int Dcounter = 0;
        Stack<int> inside = new Stack<int>(); //Stacks for vehicles inside the parking slot
        Stack<int> outside = new Stack<int>(); //Stacks for vehicles outside the parking slot

        public void Operation()
        {
            while (true)
            {

                Console.WriteLine("*********Welcome to the Garage Simulation*******");
                Console.WriteLine("1.Vehicle entry registration");
                Console.WriteLine("2.Vehicle departure registration");
                Console.WriteLine("3.Number of Arrivals and Departures");
                Console.WriteLine("4.Check parking space");
                Console.WriteLine("5.Exit");
                Console.WriteLine("************************************************");
                Console.WriteLine("Enter your choice");

                int Choice = Convert.ToInt32(Console.ReadLine());
                if (Choice == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter the license plate number: ");
                    var Lplate = Convert.ToInt32(Console.ReadLine());
                    if (this.inside.Contains(Lplate) == true)
                    {
                        Console.WriteLine("That car is already in the parking space");
                        Console.WriteLine("Press any key to try again");
                        Console.ReadLine();
                        Console.Clear();


                    }
                    else if (inside.Count() == 10)
                    {
                        Console.WriteLine("The Parking Area is full");
                        Console.WriteLine("Press any key to go back");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        inside.Push(Lplate);
                        Acounter = Acounter + 1;
                        Console.WriteLine("Successfully Parked!");
                        Console.WriteLine("Press any key to go back");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }
                else if (Choice == 2)
                {
                    Console.Clear();
                    foreach (var item in inside)
                        Console.WriteLine(item);
                    Console.WriteLine("Please enter the license plate number: ");
                    int DepPlate = Convert.ToInt32(Console.ReadLine());
                    if (inside.Contains(DepPlate) == true)
                    {
                        int checker = inside.Peek();
                        while (checker != DepPlate)
                        {

                            outside.Push(inside.Pop());
                            Dcounter = Dcounter + 1;
                            checker = inside.Peek();
                        }
                        if (checker == DepPlate)
                        {
                            Dcounter = Dcounter + 1;
                            inside.Pop();
                        }
                        foreach (var item in outside)
                            Acounter = Acounter + 1;
                        foreach (var item in outside)
                            inside.Push(item);

                        outside.Clear();

                        Console.WriteLine("Successfully Departed!");
                        Console.WriteLine("Press any key to go back");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Car license number not found");
                        Console.WriteLine("Press any key to go back");
                        Console.ReadLine();
                        Console.Clear();
                    }


                }
                else if (Choice == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Number of Arrivals:" + Acounter);

                    Console.WriteLine("Number of Departures:" + Dcounter);
                    Console.WriteLine("Press any key to go back");
                    Console.ReadLine();
                    Console.Clear();

                }
                else if (Choice == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Number of cars in the parking lot: {0}", inside.Count);
                    int Space = 10 - inside.Count;
                    Console.WriteLine("Number of free spaces: {0}", Space);
                    Console.WriteLine("License plate list:");
                    foreach (var item in inside)
                        Console.WriteLine(item);

                    Console.WriteLine("Press any key to go back");
                    Console.ReadLine();
                    Console.Clear();

                }
                else if (Choice == 5)
                {
                    Environment.Exit(0);
                }
            }


        }

        public void EnhanceOperation()
        {
            int result = 5;
            Parking.UI();
            this.Choice(out result);
            this.Todo(result);
        }

        public static void UI()
        {
            Console.WriteLine("*********Welcome to the Garage Simulation*******");
            Console.WriteLine("1.Vehicle entry registration");
            Console.WriteLine("2.Vehicle departure registration");
            Console.WriteLine("3.Number of Arrivals and Departures");
            Console.WriteLine("4.Check parking space");
            Console.WriteLine("5.Exit");
            Console.WriteLine("************************************************");
        }

        public void Choice(out int result)
        {
            Console.WriteLine("Enter your choice");
            try
            {
                result = Convert.ToInt32(Console.ReadLine());
                if (result >= 6 || result < 0) {
                    throw new FormatException();
                }
            }
            catch (FormatException)
            {
                result = 0;
                Console.Clear();
                Console.WriteLine("Incorrect Input, choose from 1-5.");
                Parking.UI();
                this.Choice(out result);
            }
        }

        public void Todo(int choice)
        {

            Console.Clear();
            switch(choice)
            {
                case 1:
                    this.ChoiceOne();
                    break;
                case 2:
                    this.ChoiceTwo();
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                
            }
        }

        public void GetPlate(out int result)
        {
            try
            {
                Console.WriteLine("Please enter the license plate number: ");
                result = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Choose only numbers");
                this.GetPlate(out result);
            }
;
        }

        public void ChoiceOne()
        {
            int plateNumber;
            this.GetPlate(out plateNumber);
            if (inside.Contains(plateNumber) == true)
            {
                Console.WriteLine("That car is already in the parking space");
                Console.WriteLine("Press any key to try again");
                Console.ReadLine();
                Console.Clear();


            }
            else if (inside.Count() == 10)
            {
                Console.WriteLine("The Parking Area is full");
                Console.WriteLine("Press any key to go back");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                inside.Push(plateNumber);
                Acounter = Acounter + 1;
                Console.WriteLine("Successfully Parked!");
                Console.WriteLine("Press any key to go back");
                Console.ReadLine();
                Console.Clear();     
            }
            this.EnhanceOperation();
        }

        public void ChoiceTwo()
        {
            int plateNumber = 0;
            foreach (var item in inside)
                Console.WriteLine(item);
            this.GetPlate(out plateNumber);
            if (inside.Contains(plateNumber) == true)
            {
                int checker = inside.Peek();
                while (checker != plateNumber)
                {

                    outside.Push(inside.Pop());
                    Dcounter = Dcounter + 1;
                    checker = inside.Peek();
                }
                if (checker == plateNumber)
                {
                    Dcounter = Dcounter + 1;
                    inside.Pop();
                }
                foreach (var item in outside)
                    Acounter = Acounter + 1;
                foreach (var item in outside)
                    inside.Push(item);

                outside.Clear();

                Console.WriteLine("Successfully Departed!");
                Console.WriteLine("Press any key to go back");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Car license number not found");
                Console.WriteLine("Press any key to go back");
                Console.ReadLine();
                Console.Clear();
            }
            this.EnhanceOperation();
        }

        public void ChoiceThree()
        {

        }
    }

}


    