namespace Task01
{
    using System;

    public class Point
    {
        public Point()
        {
        }

        public Point(double x, double y)
        {
            this.CoordX = x;
            this.CoordY = y;
        }

        public double CoordX { get; set; }

        public double CoordY { get; set; }
    }
}
