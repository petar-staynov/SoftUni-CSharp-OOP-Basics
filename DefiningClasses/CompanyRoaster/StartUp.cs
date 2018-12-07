using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyRoaster
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>();
            for (int i = 0; i < n; i++)
            {
                string[] inputArgs =
                    Console.ReadLine()
                        .Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                string name = inputArgs[0];
                decimal salary = decimal.Parse(inputArgs[1]);
                string position = inputArgs[2];
                string department = inputArgs[3];

                Employee employee = new Employee(name, salary, position, department);

                if (inputArgs.Length >= 5)
                {
                    for (int argIndex = 4; argIndex < inputArgs.Length; argIndex++)
                    {
                        if (inputArgs[argIndex].Contains("@"))
                        {
                            string email = inputArgs[argIndex];
                            employee.Email = email;
                        }
                        else
                        {
                            int age = int.Parse(inputArgs[argIndex]);
                            employee.Age = age;
                        }
                    }
                }

                employees.Add(employee);
            }

            var bestDepartament = employees
                .GroupBy(e => e.Deprtament)
                .OrderByDescending(d => d.Average(e => e.Salary))
                .Select(d => new
                {
                    Name = d.Key,
                    Employees = d.OrderByDescending(e => e.Salary).ToArray()
                })
                .FirstOrDefault();

            if (bestDepartament != null)
            {
                Console.WriteLine($"Highest Average Salary: {bestDepartament.Name}");
                foreach (Employee employee in bestDepartament.Employees)
                {
                    Console.WriteLine(employee.ToString());
                }
            }
        }
    }
}