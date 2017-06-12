namespace Task01
{
    using System;

    public class Triangle : Line
    {
        public Triangle() : base()
        {
            this.EndPoint = new Point(2, 2);
            this.MiddlePoint = new Point(1, 1);
            this.BeginPoint = new Point();
        }

        public Triangle(BrushType brush, FillType fill, Point beginPoint, Point middlePoint, Point endPoint) : base(brush, fill, beginPoint, endPoint)
        {
            this.Fill = fill;
            this.Brush = brush;
            this.MiddlePoint = middlePoint;
        }
        
        public Point MiddlePoint { get; set; }
    }
}
