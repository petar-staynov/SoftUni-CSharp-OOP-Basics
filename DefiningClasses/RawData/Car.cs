using System;

namespace RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        public Car(string model, Engine engine, Cargo cargo)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tires = new Tire[0];
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }


        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }


        public Cargo Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }


        public Tire[] Tires
        {
            get { return tires; }
            set { tires = value; }
        }

        public void AddTire(Tire tire)
        {
            Array.Resize(ref this.tires, this.tires.Length + 1);
            this.tires[this.tires.GetUpperBound(0)] = tire;
        }

        public override string ToString()
        {
            return $"{Model}";
        }
    }
}