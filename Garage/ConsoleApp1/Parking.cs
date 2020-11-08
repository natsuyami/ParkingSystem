using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingSystem
{
    class Parking
    {
        private int totalArrivals = 0; // total counts of vehicles who sign for registration
        private int totalDeparted = 0; // total counts of departed vehicles
        Stack<Vehicle> parked = new Stack<Vehicle>(); //Stacks for vehicles inside the parking slot
        Stack<Vehicle> departed = new Stack<Vehicle>(); //Stacks for vehicles departed

        private const string DEFAULT_MESSAGE = "Press enter to try again";
        private const string MESSAGE_ONE = "That car is already in the parking space\n" + DEFAULT_MESSAGE;
        private const string MESSAGE_TWO = "The Parking Area is full\n" + DEFAULT_MESSAGE;
        private const string MESSAGE_THREE = "Successfully Parked!\n" + DEFAULT_MESSAGE;
        private const string MESSAGE_FOUR = "Successfully Departed!\n" + DEFAULT_MESSAGE;
        private const string MESSAGE_FIVE = "Car license number not found\n" + DEFAULT_MESSAGE;

        private Screen screen = new Screen();

        public void RegisterVehicle()
        {
            screen.InputPlateNumber();

            var matches = parked.Where(p => p.GetPlateNumber() == screen.getPlateNumber());

            if (matches.Any())
            {
                screen.WriteResult(MESSAGE_ONE);
            }
            else if (parked.Count == 10)
            {
                screen.WriteResult(MESSAGE_TWO);
            }
            else
            {
                totalArrivals++;
                Vehicle vehicle = new Vehicle(totalArrivals, screen.getPlateNumber(), "unknown");
                parked.Push(vehicle);
                screen.WriteResult(MESSAGE_THREE);
            }
        }

        public void DepartVehicle()
        {
            this.ListVehicles();

            screen.InputPlateNumber();

            var matches = parked.Where(p => p.GetPlateNumber() == screen.getPlateNumber());

            if (matches.Any())
            {

                while (matches.Any()) 
                {
                    parked.Pop();
                    totalDeparted++;
                    matches = parked.Where(p => p.GetPlateNumber() == screen.getPlateNumber());
                }

                Vehicle vehicle = new Vehicle(totalDeparted, screen.getPlateNumber(), "unknown");
                departed.Push(vehicle);

                screen.WriteResult(MESSAGE_FOUR);
            }
            else
            {
                screen.WriteResult(MESSAGE_FIVE);
            }
        }

        public void TotalCounts()
        {
            screen.WriteResult("Number of Arrivals:" + totalArrivals + "\nNumber of Departures:" + totalDeparted);
        }

        public void TotalParkingSpace()
        {
            Console.WriteLine("Number of cars in the parking lot: {0}", parked.Count);
            int Space = 10 - parked.Count;
            Console.WriteLine("Number of free spaces: {0}", Space);
            this.ListVehicles();
            screen.WriteResult(DEFAULT_MESSAGE);
        }

        public void ListVehicles()
        {
            Console.WriteLine("List of Parked Plate Numbers:");
            foreach (Vehicle vehicle in parked)
            {
                Console.WriteLine("ID: " + vehicle.GetId() + ", Plate Number: " + vehicle.GetPlateNumber() + ", Type: " + vehicle.GetType());
            }
        }
    }

}
