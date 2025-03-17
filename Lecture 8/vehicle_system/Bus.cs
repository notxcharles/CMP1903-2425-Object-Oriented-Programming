using System;

namespace vehicle_system
{
    public class Bus : Vehicle
    {
        private int passengerCapacity;

        Bus(string brand, int year, int doors) : base(brand, year)
        {
            passengerCapacity = doors;
        }

        public int Doors { get { return passengerCapacity; } }

        public override void DisplayInfo()
        {
            Console.WriteLine($"{Brand} built in {Year} with {passengerCapacity} passenger capacity");
        }
    }
}
