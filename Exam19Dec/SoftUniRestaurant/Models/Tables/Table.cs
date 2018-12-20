using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using SoftUniRestaurant.Models.Drinks;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;

namespace SoftUniRestaurant.Models.Tables
{
    public abstract class Table : ITable
    {
        private ICollection<IFood> foodOrders;
        private ICollection<IDrink> drinkOrders;

        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;
        private bool isReserved;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;

            FoodOrders = new List<IFood>();
            DrinkOrders = new List<IDrink>();
        }

        public decimal Price
        {
            get => NumberOfPeople * PricePerPerson;
        }

        public int TableNumber
        {
            get => tableNumber;
            private set => tableNumber = value;
        }

        public int Capacity
        {
            get => capacity;
            private set
            {
                //TODO maybe <
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }

                capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => numberOfPeople;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }

                numberOfPeople = value;
            }
        }

        public decimal PricePerPerson
        {
            get => pricePerPerson;
            private set => pricePerPerson = value;
        }

        public bool IsReserved
        {
            get => isReserved;

            private set => isReserved = value;
        }

        public ICollection<IFood> FoodOrders
        {
            get => foodOrders;
            private set => foodOrders = value;
        }

        public ICollection<IDrink> DrinkOrders
        {
            get => drinkOrders;
            private set => drinkOrders = value;
        }


        public void Reserve(int numberOfPeople)
        {
            NumberOfPeople = numberOfPeople;
            IsReserved = true;
        }

        public void OrderFood(IFood food)
        {
            this.FoodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            this.DrinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            decimal finalPrice = 0;
            foreach (IFood food in FoodOrders)
            {
                finalPrice += food.Price;
            }

            foreach (IDrink drink in DrinkOrders)
            {
                finalPrice += drink.Price;
            }

            finalPrice += Price;

            return finalPrice;
        }

        public void Clear()
        {
            FoodOrders.Clear();
            DrinkOrders.Clear();
            IsReserved = false;
            numberOfPeople = 0;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {TableNumber}")
                .AppendLine($"Type: {this.GetType().Name}");


            return sb.ToString().TrimEnd();
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.ToString())
                .AppendLine($"Capacity: {Capacity}")
                .AppendLine($"Price per Person: {PricePerPerson:f2}");

            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.ToString())
                .AppendLine($"Number of people: {NumberOfPeople}");
            if (FoodOrders.Count <= 0)
            {
                sb.AppendLine($"Food orders: None");
            }
            else
            {
                sb.AppendLine($"Food orders: {FoodOrders.Count}");
                foreach (IFood food in FoodOrders)
                {
                    sb.AppendLine(food.ToString());
                }
            }

            if (DrinkOrders.Count <= 0)
            {
                sb.AppendLine($"Drink orders: None");
            }
            else
            {
                sb.AppendLine($"Drink orders: {DrinkOrders.Count}");
                foreach (IDrink drink in DrinkOrders)
                {
                    sb.AppendLine(drink.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}