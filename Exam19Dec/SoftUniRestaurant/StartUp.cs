using SoftUniRestaurant.Core;

namespace SoftUniRestaurant
{
    public class StartUp
    {
        public static void Main()
        {
            Engine engine = new Engine(new RestaurantController());
            engine.Run();
        }
    }
}
