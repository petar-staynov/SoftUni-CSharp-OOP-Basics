using System;
using SoftUniRestaurant.Models.Tables;
using SoftUniRestaurant.Models.Tables.Contracts;

namespace SoftUniRestaurant.Factories
{
    public class TableFactory
    {
        public ITable Create(string type, int tableNumber, int capacity)
        {
            switch (type)
            {
                case "Inside":
                    return new InsideTable(tableNumber, capacity);
                    break;
                case "Outside":
                    return new OutsideTable(tableNumber, capacity);
                    break;
                default:
                    return null;

                //throw new ArgumentException("Invalid table type");
            }
        }
    }
}