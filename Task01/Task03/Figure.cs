namespace Task03
{
    using System;

    abstract public class Figure
    {
        public Point BeginPoint { get; set; }

        public Figure()
        {
            Point point = new Point();
        }

        public Figure(Point beginPoint)
        {
            BeginPoint = beginPoint;
        }

        abstract public double GetArea();
        abstract public double GetPerimeter();
    }
}
