namespace Task03
{
    using System;

    public class Disc : Circle
    {
        public Disc() : base()
        {
        }

        public Disc(Point beginPoint, double radius) : base(beginPoint, radius)
        {
            this.BeginPoint = beginPoint;
            this.Radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * Math.Pow(this.Radius, 2);
        }

        public override double GetPerimeter()
        {
            return base.GetPerimeter();
        }
    }   
}
