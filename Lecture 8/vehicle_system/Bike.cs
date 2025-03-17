using System;

namespace vehicle_system
{
    // TODO: Implement inheritance by
    // making Bike a subclass of Vehicle.
    public class Bike : Vehicle
    {
        /// TODO: Declare data members specific to the Bike class, 
        /// following the encapsulation guidelines provided.


        // TODO: Implement Bike constructor that calls the
        // base class constructor.


        // TODO: Override the DisplayInfo() method from the
        // base class to display both Bike-specific attributes
        // and base class attributes.
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
