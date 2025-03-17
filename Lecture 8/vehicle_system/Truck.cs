using System;

namespace vehicle_system
{
    public class Truck : Vehicle
    {
        private float _loadCapacity;

        Truck(string brand, int year, float loadCapacity) : base(brand, year)
        {
            _loadCapacity = loadCapacity;
        }

        public float LoadCapacity { get { return _loadCapacity; } }

        public override void DisplayInfo()
        {
            Console.WriteLine($"{Brand} built in {Year}, with {LoadCapacity}kg");
        }
    }
}
