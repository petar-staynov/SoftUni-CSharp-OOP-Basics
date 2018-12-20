using System;
using SoftUniRestaurant.Models.Foods;
using SoftUniRestaurant.Models.Foods.Contracts;

namespace SoftUniRestaurant.Factories
{
    public class FoodFactory
    {
        public IFood Create(string type, string name, decimal price)
        {
            switch (type)
            {
                case "Dessert":
                    return new Dessert(name, price);
                    break;
                case "MainCourse":
                    return new MainCourse(name, price);
                    break;
                case "Salad":
                    return new Salad(name, price);
                    break;
                case "Soup":
                    return new Soup(name,price);
                default:
                    return null;
                    //throw new ArgumentException("Invalid food type");
            }
        }
    }
}