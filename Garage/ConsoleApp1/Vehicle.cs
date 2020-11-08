
namespace ParkingSystem
{
    class Vehicle
    {

        private int id; // unique identifier for the system
        private string plateNumber; // vehicle registered plate number
        private string type; // vehicle type e.g. car, vann, truck, shuttle

        public Vehicle(int id, string plateNumber, string type)
        {
            this.id = id;
            this.plateNumber = plateNumber;
            this.type = type;
        }

        public int GetId()
        {
            return this.id;
        }

        public string GetPlateNumber()
        {
            return this.plateNumber;
        }

        public string GetType()
        {
            return this.type;
        }
    }
}
