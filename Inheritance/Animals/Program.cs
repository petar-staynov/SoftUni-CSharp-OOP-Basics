using System;
using System.Collections.Generic;

namespace Animals
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            while (true)
            {
                string animalType = Console.ReadLine();
                if (animalType == "Beast!")
                {
                    break;
                }

                try
                {
                    var animalArgs = Console.ReadLine()
                        .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);

                    string animalName = animalArgs[0];
                    int animalAge = int.Parse(animalArgs[1]);
                    string animalGender = animalArgs[2];

                    Animal animal = new Animal(animalName, animalAge, animalGender);
                    if (animalType == "Dog")
                    {
                        animal = new Dog(animalName, animalAge, animalGender);
                        animals.Add(animal);
                    }
                    else if (animalType == "Cat")
                    {
                        animal = new Cat(animalName, animalAge, animalGender);
                        animals.Add(animal);
                    }
                    else if (animalType == "Frog")
                    {
                        animal = new Frog(animalName, animalAge, animalGender);
                        animals.Add(animal);
                    }
                    else if (animalType == "Kitten")
                    {
                        animal = new Kitten(animalName, animalAge);
                        animals.Add(animal);
                    }
                    else if (animalType == "Tomcat")
                    {
                        animal = new Tomcat(animalName, animalAge);
                        animals.Add(animal);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid input!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}