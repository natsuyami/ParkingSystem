using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{



    class Program
    {
  

        static void Main(string[] args)
            
        {
            int Acounter = 0;
            int Dcounter = 0;
            Stack<int> inside = new Stack<int>(); //Stacks for vehicles inside the parking slot
            Stack<int> outside = new Stack<int>(); //Stacks for vehicles outside the parking slot
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
                    if (inside.Contains(Lplate) == true)
                    {
                        Console.WriteLine("That car is already in the parking space");
                        Console.WriteLine("Press any key to try again");
                        Console.ReadLine();
                        Console.Clear();
                       
                        
                    }
                    else if(inside.Count() == 10 )
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
                    Console.WriteLine("Number of Arrivals:"+ Acounter);
                   
                    Console.WriteLine("Number of Departures:"+ Dcounter);
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
                else if(Choice == 5)
                {
                    Environment.Exit(0);
                }
                
               
                   
                
            }
        }
    }
}
