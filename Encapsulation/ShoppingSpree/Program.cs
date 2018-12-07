using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            string line1 = Console.ReadLine();
            string line2 = Console.ReadLine();

            string[] peopleArgs = line1.Split(new string[] {";"}, StringSplitOptions.RemoveEmptyEntries);

            List<Person> peopleObjs = new List<Person>();
            foreach (string person in peopleArgs)
            {
                string[] personArgs = person.Split(new string[] {"="}, StringSplitOptions.RemoveEmptyEntries);
                string personName = personArgs[0];
                decimal personMoney = decimal.Parse(personArgs[1]);

                try
                {
                    Person personObj = new Person(personName, personMoney);
                    peopleObjs.Add(personObj);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            string[] productsArgs = line2.Split(new string[] {";"}, StringSplitOptions.RemoveEmptyEntries);

            List<Product> productsObjs = new List<Product>();
            foreach (string product in productsArgs)
            {
                string[] productArgs = product.Split(new string[] {"="}, StringSplitOptions.RemoveEmptyEntries);
                string productName = productArgs[0];
                decimal productCost = decimal.Parse(productArgs[1]);

                try
                {
                    Product productObj = new Product(productName, productCost);
                    productsObjs.Add(productObj);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                string[] commandArgs = command.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                string personName = commandArgs[0];
                string productName = commandArgs[1];

                Person person = peopleObjs.FirstOrDefault(p => p.Name == personName);
                if (person != null)
                {
                    Product product = productsObjs.FirstOrDefault(p => p.Name == productName);
                    if (product != null)
                    {
                        person.AddProduct(product);
                    }
                }
            }

            foreach (Person person in peopleObjs)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}