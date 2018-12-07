using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private readonly List<Person> people = new List<Person>();

        public void AddMember(Person member)
        {
            this.people.Add(member);
        }

        public List<Person> People()
        {
            return this.people;
        }

        public Person GetOldestMember()
        {
            Person oldestPerson = people.OrderByDescending(p => p.Age).First();
            return oldestPerson;
        }
    }
}
