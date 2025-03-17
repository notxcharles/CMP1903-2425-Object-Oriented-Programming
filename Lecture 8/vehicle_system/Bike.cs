using System;

namespace vehicle_system
{
    public class Bike : Vehicle
    {
        private bool _hasGear;

        Bike(string brand, int year, bool hasGear) : base(brand, year)
        {
            _hasGear = hasGear;
        }

        public bool HasGear { get { return _hasGear; } }

        public override void DisplayInfo()
        {
            Console.WriteLine($"{Brand} built in {Year}. Has Gears? {HasGear}");
        }

    }
}
