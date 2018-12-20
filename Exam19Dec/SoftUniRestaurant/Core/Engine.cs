using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SoftUniRestaurant.Core
{
    public class Engine
    {
        private RestaurantController restaurantController;

        private bool isRunning;

        public Engine(RestaurantController restaurantController)
        {
            this.restaurantController = restaurantController;
            this.isRunning = false;
        }

        public void Run()
        {
            this.isRunning = true;

            while (this.isRunning)
            {
                string line = Console.ReadLine();
                string[] commandArgs = line.Split(' ');

                string command = commandArgs[0];

                string output = string.Empty;

                try
                {
                    switch (command)
                    {
                        case "END":
                            Console.WriteLine(restaurantController.GetSummary());
                            isRunning = false;
                            break;

                        case "AddFood":
                            string addFoodType = commandArgs[1];
                            string addFoodName = commandArgs[2];
                            decimal addFoodPrice = decimal.Parse(commandArgs[3]);

                            Console.WriteLine(restaurantController
                                .AddFood(addFoodType, addFoodName, addFoodPrice));
                            break;

                        case "AddDrink":
                            string addDrinkType = commandArgs[1];
                            string addDrinkName = commandArgs[2];
                            int addDrinkServingSize = int.Parse(commandArgs[3]);
                            string addDrinkBrand = commandArgs[4];

                            Console.WriteLine(restaurantController
                                .AddDrink(addDrinkType, addDrinkName, addDrinkServingSize, addDrinkBrand));
                            break;

                        case "AddTable":
                            string addTableType = commandArgs[1];
                            int addtableNum = int.Parse(commandArgs[2]);
                            int addtablecapacity = int.Parse(commandArgs[3]);

                            Console.WriteLine(
                                restaurantController.AddTable(addTableType, addtableNum, addtablecapacity));
                            break;

                        case "ReserveTable":
                            int reserveTableNumOfPeople = int.Parse(commandArgs[1]);

                            Console.WriteLine(restaurantController.ReserveTable(reserveTableNumOfPeople));
                            break;

                        case "OrderFood":
                            int orderFoodTableNum = int.Parse(commandArgs[1]);
                            string foodName = commandArgs[2];

                            Console.WriteLine(restaurantController.OrderFood(orderFoodTableNum, foodName));
                            break;

                        case "OrderDrink":
                            Console.WriteLine(
                                restaurantController.OrderDrink(int.Parse(commandArgs[1]), commandArgs[2],
                                    commandArgs[3]));
                            break;

                        case "LeaveTable":
                            int leaveTableNum = int.Parse(commandArgs[1]);
                            Console.WriteLine(restaurantController.LeaveTable(leaveTableNum));
                            break;

                        case "GetFreeTablesInfo":
                            var result = restaurantController.GetFreeTablesInfo();
                            if (result.Length > 0)
                            {
                                Console.WriteLine(result);
                            }

                            break;

                        case "GetOccupiedTablesInfo":
                            var result2 = restaurantController.GetOccupiedTablesInfo();
                            if (result2.Length > 0)
                            {
                                Console.WriteLine(result2);
                            }

                            break;
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}