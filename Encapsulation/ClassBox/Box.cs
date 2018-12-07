using System;

namespace ClassBox
{
    class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        private double Length
        {
            get { return length; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine($"Length cannot be zero or negative. ");
                    return;
                }
                length = value;
            }
        }


        private double Width
        {
            get { return width; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine($"Width cannot be zero or negative. ");
                    return;
                }
                width = value;
            }
        }

        private double Height
        {
            get { return height; }
            set
            {
                if(value <= 0)
                {
                    Console.WriteLine($"Height cannot be zero or negative. ");
                    return;
                }
                height = value;
            }
        }

        public double GetSurfaceArea()
        {
            return 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;
        }

        public double GetLateralSurfaceArea()
        {
            return 2 * Length * Height + 2 * Width * Height;
        }

        public double GetSVolume()
        {
            return Length * Width * Height;
        }
    }
}