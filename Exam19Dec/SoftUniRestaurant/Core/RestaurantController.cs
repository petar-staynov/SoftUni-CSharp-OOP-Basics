using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftUniRestaurant.Factories;
using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;

namespace SoftUniRestaurant.Core
{
    using System;

    public class RestaurantController
    {
        private FoodFactory FoodFactory = new FoodFactory();
        private DrinkFactory DrinkFactory = new DrinkFactory();
        private TableFactory TableFactory = new TableFactory();

        private List<IFood> menu = new List<IFood>();
        private List<IDrink> drinks = new List<IDrink>();
        private List<ITable> tables = new List<ITable>();

        private decimal income;

        public string AddFood(string type, string name, decimal price)
        {
            IFood food = FoodFactory.Create(type, name, price);

            menu.Add(food);
            return
                $"Added {name} ({type}) with price {price:f2} to the pool";
        }

        public string AddDrink(string type, string name, int servingSize, string brand)
        {
            IDrink drink = DrinkFactory.Create(type, name, servingSize, brand);

            drinks.Add(drink);
            return
                $"Added {name} ({brand}) to the drink pool";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = TableFactory.Create(type, tableNumber, capacity);

            tables.Add(table);

            return
                $"Added table number {tableNumber} in the restaurant";
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.FirstOrDefault(t => !t.IsReserved && t.Capacity >= numberOfPeople);
            if (table == null)
            {
                throw new ArgumentException($"No available table for {numberOfPeople} people");
            }

            table.Reserve(numberOfPeople);

            return
                $"Table {table.TableNumber} has been reserved for {numberOfPeople} people";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                throw new ArgumentException($"Could not find table with {tableNumber}");
            }

            IFood food = menu.FirstOrDefault(f => f.Name == foodName);
            if (food == null)
            {
                throw new ArgumentException($"No {foodName} in the menu");
            }

            table.OrderFood(food);
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                throw new ArgumentException($"Could not find table with {tableNumber}");
            }

            IDrink drink = drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);
            if (drink == null)
            {
                throw new ArgumentException($"There is no {drinkName} {drinkBrand} available");
            }

            table.OrderDrink(drink);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                throw new ArgumentException($"Could not find table with {tableNumber}");
            }

            decimal bill = table.GetBill();
            table.Clear();

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}")
                .AppendLine($"Bill: {bill:f2}");

            income += bill;

            return sb.ToString().TrimEnd();
        }

        public string GetFreeTablesInfo()
        {
            var freeTables = tables.Where(t => !t.IsReserved).ToList();

            StringBuilder sb = new StringBuilder();
            foreach (ITable freeTable in freeTables)
            {
                sb.AppendLine(freeTable.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTablesInfo()
        {
            var occupiedTables = tables.Where(t => t.IsReserved).ToList();

            StringBuilder sb = new StringBuilder();
            foreach (ITable occupiedTable in occupiedTables)
            {
                sb.AppendLine(occupiedTable.GetOccupiedTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetSummary()
        {
            return $"Total income: {this.income:f2}lv";
        }
    }
}