using System;

namespace vehicle_system
{
    public class Bus : Vehicle
    {
        private int _passengerCapacity;

        Bus(string brand, int year, int doors) : base(brand, year)
        {
            _passengerCapacity = doors;
        }

        public int Doors { 
            get { return _passengerCapacity; }
            set
            {
                if (value > 0)
                {
                    _passengerCapacity = value;
                }
            }
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"{Brand} built in {Year} with {_passengerCapacity} passenger capacity");
        }
    }
}
