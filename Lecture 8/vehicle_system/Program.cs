using System;
using System.Collections.Generic;

namespace vehicle_system
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Create vehicle objects, including new Car, new Bike,
            // new Truck, and new Bus
            Truck truck1 = new Truck("bigtruck", 4, 2300);
            Car car1 = new Car("Williams", 2025, 0);
            Bike bike1 = new Bike("Ducati", 2022, true);
            Bus bus1 = new Bus("Stagecoach", 2015, 3);
            // TODO: Store the created vehicle objects
            // in a list to test polymorphism
            List<Vehicle> vehicles = new List<Vehicle>();
            vehicles.Add(truck1);
            vehicles.Add(car1);
            vehicles.Add(bike1);
            vehicles.Add(bus1);

            // TODO: Since a Car and a Truck are both Vehicles,
            // loop through the vehicle collection using foreach
            // and display vehicle information via polymorphism. 
            // What are your observations?
            foreach (Vehicle vehicle in vehicles)
            {
                vehicle.DisplayInfo();
            }

            
        }
    }
}
