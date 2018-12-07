using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] dataArgs = Console.ReadLine()
                    .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string carModel = dataArgs[0];
                int engineSpeed = int.Parse(dataArgs[1]);
                int enginePower = int.Parse(dataArgs[2]);
                int cargoWeight = int.Parse(dataArgs[3]);
                CargoType cargoType = (CargoType) Enum.Parse(typeof(CargoType), dataArgs[4]);

                Engine carEngine = new Engine(engineSpeed, enginePower);
                Cargo carCargo = new Cargo(cargoWeight, cargoType);

                Car car = new Car(carModel, carEngine, carCargo);

                for (int tireArg = 5; tireArg < dataArgs.Length; tireArg += 2)
                {
                    double tirePressure = double.Parse(dataArgs[tireArg]);
                    int tireAge = int.Parse(dataArgs[tireArg + 1]);
                    Tire tire = new Tire(tirePressure, tireAge);
                    car.AddTire(tire);
                }

                cars.Add(car);
            }

            string searchedCargoTypeString = Console.ReadLine();
            CargoType searchedCargoType = (CargoType) Enum.Parse(typeof(CargoType), searchedCargoTypeString);

            if (searchedCargoType == CargoType.fragile)
            {
                var result = cars
                    .Where(
                        c => c.Cargo.CargoType == searchedCargoType
                             && c.Tires.Any(t => t.TirePressure < 1)
                    )
                    .ToList();
                foreach (Car car in result)
                {
                    Console.WriteLine(car.ToString());
                }
            }
            else if (searchedCargoType == CargoType.flamable)
            {
                var result = cars
                    .Where(
                        c => c.Cargo.CargoType == searchedCargoType
                             && c.Engine.EnginePower > 250
                    )
                    .ToList();

                foreach (Car car in result)
                {
                    Console.WriteLine(car.ToString());
                }
            }
        }
    }
}