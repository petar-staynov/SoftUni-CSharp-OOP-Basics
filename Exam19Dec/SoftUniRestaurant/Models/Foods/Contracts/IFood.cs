using System.Dynamic;

namespace SoftUniRestaurant.Models.Foods.Contracts
{
    public interface IFood
    {
        string Name { get; }

        int ServingSize { get; }

        decimal Price { get; }

        //TODO maybe remove this
        //string ToString();
    }
}