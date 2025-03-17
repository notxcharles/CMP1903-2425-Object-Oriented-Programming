using System;

namespace vehicle_system
{
    // Vehicle is the base class
    public class Vehicle
    {
        private string _brand;
        private int _year;

        public Vehicle(string brand, int year)
        {
            _brand = brand;
            _year = year;
        }

        public string Brand { get { return _brand; } }
        public int Year { get { return _year; } }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"{Brand} built in {Year}");
        }


    }
}
