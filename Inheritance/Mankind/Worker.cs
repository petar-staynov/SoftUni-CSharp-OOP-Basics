using System;
using System.Text;

namespace Mankind
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private decimal workHoursPerDay;

        public Worker(string firstName, string lastName, decimal salary, decimal hours) : base(firstName, lastName)
        {
            WeekSalary = salary;
            WorkHoursPerDay = hours;
        }

        public decimal WeekSalary
        {
            get => weekSalary;
            set
            {
                if (value <= 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }

                weekSalary = value;
            }
        }

        public decimal WorkHoursPerDay
        {
            get => workHoursPerDay;
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }

                workHoursPerDay = value;
            }
        }

        public decimal GetSalaryHour()
        {
            decimal result = WeekSalary / (5 * WorkHoursPerDay);
            return result;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(base.ToString());
            result.AppendLine($"Week Salary: {WeekSalary:F2}");
            result.AppendLine($"Hours per day: {WorkHoursPerDay:F2}");
            result.AppendLine($"Salary per hour: {GetSalaryHour():F2}");

            return result.ToString();
        }
    }
}