using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                var commandArgs =
                    Console.ReadLine()
                        .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                string carName = commandArgs[0];
                double fuelAmount = double.Parse(commandArgs[1]);
                double fuelConsumption = double.Parse(commandArgs[2]);
                Car car = new Car(carName, fuelAmount, fuelConsumption);
                cars.Add(car);
            }

            while (true)
            {
                var commandArgs =
                    Console.ReadLine()
                        .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                if (commandArgs[0] == "End")
                {
                    break;
                }

                string carModel = commandArgs[1];
                double distance = double.Parse(commandArgs[2]);

                Car carToDrive = cars.FirstOrDefault(c => c.Model == carModel);
                carToDrive.Drive(distance);
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}