using System;
using System.Linq;
using System.Text;

namespace Mankind
{
    public class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                if (!char.IsUpper(value.First()))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: firstName");
                }
                if (value.Length <= 3)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                if (!char.IsUpper(value.First()))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: lastName");
                }
                if (value.Length <= 2)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
                }

                lastName = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"First Name: {FirstName}");
            result.AppendLine($"Last Name: {LastName}");
            return result.ToString();
        }
    }
}