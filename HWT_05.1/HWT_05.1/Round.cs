namespace Task01
{
    using System;

    public class Round : Figure
    {
        private double radius;

        public Round() : base()
        {
            this.Radius = 1;
            this.CenterPoint = new Point(0, 0);
        }

        public Round(BrushType brush, FillType fill, Point centerPoint) : base(brush, fill)
        {
            this.Fill = fill;
            this.Brush = brush;
            this.CenterPoint = centerPoint;
        }

        public Point CenterPoint { get; set; }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value <= 0)
                {
                    this.radius = value;
                    this.radius = 1;
                    Console.WriteLine("Радиус должен быть положительным значением");
                }

                this.radius = value;
            }
        }
    }
}
