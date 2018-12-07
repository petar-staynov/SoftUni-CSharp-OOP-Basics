using System;

namespace SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumption;
        private double traveledDistance;

        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumption = fuelConsumption;
            TraveledDistance = 0;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }


        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }


        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }


        public double TraveledDistance
        {
            get { return traveledDistance; }
            set { traveledDistance = value; }
        }

        public void Drive(double distance)
        {
            double fuelNeeded = distance * FuelConsumption;
            if (fuelNeeded > FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
                return;
            }

            FuelAmount -= fuelNeeded;
            TraveledDistance += distance;
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:F2} {TraveledDistance}";
        }
    }
}