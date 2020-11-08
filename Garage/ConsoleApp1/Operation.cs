
namespace ParkingSystem
{
    class Operation
    {

        private static Parking parking = new Parking();
        private static Screen screen = new Screen();

        public static void start()
        {

            screen.MainScreen();
            screen.Choose();
            switch (screen.getChoice())
            {
                case 1:
                    parking.RegisterVehicle();
                    break;
                case 2:
                    parking.DepartVehicle();
                    break;
                case 3:
                    parking.TotalCounts();
                    break;
                case 4:
                    parking.TotalParkingSpace();
                    break;
                case 5:
                    System.Environment.Exit(1);
                    break;

            }
            start();
        }
    }
}
