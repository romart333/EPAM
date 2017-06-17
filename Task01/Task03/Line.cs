namespace Task03
{
    using System;

    public class Line : Figure
    {
        public Line() : base()
        {
            this.EndPoint = new Point();
            this.BeginPoint = new Point();
        }

        public Line(Point beginPoint, Point endPoint) : base(beginPoint)
        {
            this.EndPoint = endPoint;
        }

        public Point EndPoint { get; set; }

        public double GetLength()
        {
            double sqrX = Math.Pow(this.EndPoint.CoordX - this.BeginPoint.CoordX, 2);
            double sqrY = Math.Pow(this.EndPoint.CoordY - this.BeginPoint.CoordY, 2);

            return Math.Sqrt(sqrX + sqrY);
        }

        public override double GetArea()
        {
            return this.GetLength();
        }

        public override double GetPerimeter()
        {
            return this.GetLength();
        }
    }
}