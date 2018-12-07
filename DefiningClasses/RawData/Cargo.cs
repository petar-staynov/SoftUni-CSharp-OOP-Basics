namespace RawData
{
    public class Cargo
    {
        //1000 fragile

        private int cargoWeight;
        private CargoType cargoType;

        public Cargo(int cargoWeight, CargoType cargoType)
        {
            CargoWeigth = cargoWeight;
            CargoType = cargoType;
        }

        public int CargoWeigth
        {
            get { return cargoWeight; }
            set { cargoWeight = value; }
        }


        public CargoType CargoType
        {
            get { return cargoType; }
            set { cargoType = value; }
        }
    }

}