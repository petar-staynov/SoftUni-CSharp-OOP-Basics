using System;

namespace ClassBox
{
    class Program
    {
        static void Main(string[] args)
        {
            double l = double.Parse(Console.ReadLine());
            double w = double.Parse(Console.ReadLine());
            double h = double.Parse(Console.ReadLine());
            Box box = new Box(l, w, h);

            if (l <= 0 || w <= 0 || h <= 0)
            {
                return;
            }

            Console.WriteLine(
                $"Surface Area - {box.GetSurfaceArea():F2}"
                + Environment.NewLine
                + $"Lateral Surface Area - {box.GetLateralSurfaceArea():F2}"
                + Environment.NewLine
                + $"Volume - {box.GetSVolume():F2}"
            );
        }
    }
}