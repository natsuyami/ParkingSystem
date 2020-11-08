using System;
using System.Text.RegularExpressions;

namespace ParkingSystem
{
    class Screen
    {

        private const string mainScreen = "*********Welcome to the Garage Simulation*******\n" +
                                            "1. Vehicle entry registration\n" +
                                            "2. Vehicle departure registration\n" +
                                            "3. Number of Arrivals and Departures\n" +
                                            "4. Check parking space\n" +
                                            "5. Exit\n" +
                                            "************************************************";
        
        private const string Pattern = "\\w{3}-\\d{3}";
        private int choice;
        private string plateNumber;

        public int getChoice()
        {
            return this.choice;
        }

        public string getPlateNumber()
        {
            return this.plateNumber;
        }

        /*
         * <summary>Display the choices for operation in the parking system</summary>
         */
        public void MainScreen()
        {
            Console.WriteLine(mainScreen);
        }

        /*
         * <summary>Input user's choice in the parking system</summary>
         */
        public void Choose()
        {
            Console.WriteLine("Enter your choice:");
            try
            {
                this.choice = Convert.ToInt32(Console.ReadLine());
                if (this.choice >= 6 || this.choice < 0)
                {
                    throw new FormatException();
                }
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("\nIncorrect input, choose only from 1 to 5.\n");
                this.MainScreen();
                this.Choose();
            }
        }

        /*
         * <summary>Input plate number of the vehicle in the parking system</summary>
         */
        public void InputPlateNumber()
        {
            try
            {
                Console.WriteLine("Please enter the license plate number (example: ERT-123): ");
                this.plateNumber = Console.ReadLine();
                Regex rgx = new Regex(Pattern);
                if (!rgx.IsMatch(this.plateNumber))
                {
                    throw new FormatException();
                }
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Plate number should have a pattern of letters followed with '-' and then followed by numbers");
                Console.WriteLine("Example of plate number is: ERT-123");
                this.InputPlateNumber();
            }
        }

        /*
         * <summary>Show meesage in the parking system</summary>
         * <param>message</param> message to be shown in the system
         */
        public void WriteResult(string message)
        {
            Console.WriteLine(message);
            Console.ReadLine();
            Console.Clear();
        }
    }
}
