namespace DefiningClasses
{
    public class Person
    {
        private string name { get; set; }
        private int age { get; set; }

        public Person()
        {
            Name = "No name";
            Age = 1;
        }

        public Person(int age) : this()
        {
            Age = age;
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }


        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public int Age
        {
            get => this.age;
            set => this.age = value;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.Age}";
        }
    }
}