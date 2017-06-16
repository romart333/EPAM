namespace Task01
{

    using System;
    public class Square : Line
    {
        public Square() : base()
        {
            EndPoint = new Point(1, 1);
            BeginPoint = new Point();
        }

        public Square(BrushType brush, FillType fill, Point beginPoint, Point endPoint) : base(brush, fill, beginPoint, endPoint)
        {
            this.Fill = fill;
            this.Brush = brush;
            this.BeginPoint = beginPoint;
            this.EndPoint = endPoint;
        }

        public double Width
        {
            get
            {
                return Difference(EndPoint.CoordX, BeginPoint.CoordX);
            }
        }
    }
}
