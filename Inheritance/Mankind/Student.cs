using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Mankind
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber) : base(firstName, lastName)
        {
            FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get => facultyNumber;
            set
            {
                var pattern = @"^[a-zA-Z0-9]{5,10}$";

                if (!Regex.IsMatch(value, pattern))
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                facultyNumber = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(base.ToString());
            result.AppendLine($"Faculty number: {FacultyNumber}");
            return result.ToString();
        }
    }
}