using System;
using SoftUniRestaurant.Models.Drinks;
using SoftUniRestaurant.Models.Drinks.Contracts;

namespace SoftUniRestaurant.Factories
{
    public class DrinkFactory
    {
        public IDrink Create(string type, string name, int servingSize, string brand)
        {
            switch (type)
            {
                case "Alcohol":
                    return new Alcohol(name, servingSize, brand);
                    break;
                case "FuzzyDrink":
                    return new FuzzyDrink(name, servingSize, brand);
                    break;
                case "Juice":
                    return new Juice(name, servingSize, brand);
                    break;
                case "Water":
                    return new Water(name, servingSize, brand);
                default:
                    return null;
                //throw new ArgumentException("Invalid drink type");
            }
        }
    }
}