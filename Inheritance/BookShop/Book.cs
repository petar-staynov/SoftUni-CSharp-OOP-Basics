using System;
using System.Text;

namespace BookShop
{
    public class Book
    {
        private string title;
        private string author;
        private decimal price;

        public Book(string author, string title, decimal price)
        {
            Author = author;
            Title = title;
            Price = price;
        }

        public string Title
        {
            get => title;
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }

                title = value;
            }
        }

        public string Author
        {
            get => author;
            set
            {
                string[] names = value.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);

                if (names.Length > 1)
                {
                    if (char.IsDigit(names[1][0]))
                    {
                        throw new ArgumentException("Author not valid!");
                    }
                }


                author = value;
            }
        }

        public virtual decimal Price
        {
            get => price;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }

                price = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"Type: {this.GetType().Name}");
            result.AppendLine($"Title: {this.Title}");
            result.AppendLine($"Author: {this.Author}");
            result.AppendLine($"Price: {this.Price:F2}");

            return result.ToString().TrimEnd();
        }
    }
}