using System;

namespace vehicle_system
{
    public class Car : Vehicle
    {
        private int _doors;

        public Car(string brand, int year, int doors) : base(brand, year)
        {
            _doors = doors;
        }

        public int Doors { get { return _doors; } }

        public override void DisplayInfo()
        {
            Console.WriteLine($"{Brand} built in {Year} with {Doors} doors");
        }
    }
}
