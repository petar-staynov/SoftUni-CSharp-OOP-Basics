using System;

namespace CompanyRoaster
{
    public class Employee
    {
        private string name;
        private decimal salary;
        private string position;
        private string department;
        private string email;
        private int age;

        public Employee(string name, decimal salary, string position, string department)
        {
            Name = name;
            Salary = salary;
            Position = position;
            Deprtament = department;
            Age = -1;
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        public decimal Salary
        {
            get { return this.salary; }
            set { salary = value; }
        }


        public string Position
        {
            get { return position; }
            set { position = value; }
        }


        public string Deprtament
        {
            get => department;
            set => department = value;
        }


        public string Email
        {
            get
            {
                if (this.email == null)
                {
                    return "n/a";
                }

                return email;
            }
            set { email = value; }
        }


        public int Age
        {
            get => this.age;
            set => this.age = value;
        }

        public override string ToString()
        {
            return $"{Name} {Salary:F2} {Email} {Age}";
        }
    }
}