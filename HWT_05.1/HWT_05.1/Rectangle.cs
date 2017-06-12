namespace Task01
{
    using System;

    public class Rectangle : Square
    {
        public Rectangle() : base()
        {
            this.BeginPoint = new Point();
            this.EndPoint = new Point(1, 1);
        }

        public Rectangle(BrushType brush, FillType fill, Point beginPoint, Point endPoint) : base(brush, fill, beginPoint, endPoint)
        {
            this.Fill = fill;
            this.Brush = brush;
            this.BeginPoint = beginPoint;
            this.EndPoint = endPoint;
        }

        public double Heigth
        {
            get
            { 
                return this.Difference(EndPoint.CoordY, BeginPoint.CoordY);
            }
        }
    }
}
