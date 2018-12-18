using System;
using System.Collections.Generic;
using System.Linq;
using DungeonsAndCodeWizards.Models.Items;

namespace DungeonsAndCodeWizards.Models.Bags
{
    public abstract class Bag
    {
        private const int DefaultCapacity = 100;

        private int capacity;
        private List<Item> items;

        protected Bag(int capacity = DefaultCapacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity
        {
            get { return capacity; }
            set { this.capacity = value; }
        }


        public int Load
        {
            get
            {
                int load = 0;
                foreach (Item item in Items)
                {
                    load += item.Weight;
                }

                return load;
            }
        }


        public IReadOnlyCollection<Item> Items
        {
            get { return items.AsReadOnly(); }
        }

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException("Bag is full!");
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (this.Items.Count <= 0)
            {
                throw new InvalidOperationException("Bag is empty!");
            }

            Item item = this.Items.FirstOrDefault(i => i.GetType().Name == name);
            if (item == null)
            {
                throw new ArgumentException($"No item with name {name} in bag!");
            }

            this.items.Remove(item);
            return item;
        }
    }
}