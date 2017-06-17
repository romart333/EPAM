namespace Task03
{
    using System;

    public class Ring : Figure
    {
        public Ring() : base()
        {
        }

        public Ring(Point beginPoint, double innerRadius, double outerRadius) : base(beginPoint)
        {
            this.BeginPoint = beginPoint;
            this.InnerRadius = innerRadius;
            this.OuterRadius = outerRadius;
        }

        public double InnerRadius { get; private set; }

        public double OuterRadius { get; private set; }

        public override double GetArea()
        {
            return Math.PI * (Math.Pow(this.OuterRadius, 2) - Math.Pow(this.InnerRadius, 2));
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * (this.OuterRadius + this.InnerRadius);
        }
    }
}
