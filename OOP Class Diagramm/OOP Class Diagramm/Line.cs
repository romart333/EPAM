namespace Task01
{
    using System;

    public class Line : Figure
    {
        public Line() : base()
        {
            this.EndPoint = new Point(1, 1);
            this.BeginPoint = new Point();
        }

        public Line(BrushType brush, FillType fill, Point beginPoint, Point endPoint) : base(brush, fill)
        {
            this.Fill = fill;
            this.Brush = brush;
            this.BeginPoint = beginPoint;
            this.EndPoint = endPoint;
        }

        public Point BeginPoint { get; set; }

        public Point EndPoint { get; set; }

        public double Length
        {
            get
            {
                return this.Distance(this.EndPoint, this.BeginPoint);
            }
        }

        public double Distance(Point end, Point begin)
        {
            return Math.Sqrt(Math.Pow(end.CoordX - begin.CoordX, 2) + Math.Pow(end.CoordY - begin.CoordY, 2));
        }
    }
}
