namespace Task03
{
    using System;

    public class Circle : Figure
    {
        public Circle() : base()
        {
        }

        public Circle(Point beginPoint, double radius) : base(beginPoint)
        {
            this.BeginPoint = beginPoint;
            this.Radius = radius;
        }

        public double Radius { get; protected set; }

        public override double GetArea()
        {
            return default(double);
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * this.Radius;
        }
    }
}
