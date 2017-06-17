namespace Task03
{
    using System;

    public class Rectangle : Line
    {
        public Rectangle() : base()
        {
            this.BeginPoint = new Point();
            this.EndPoint = new Point();
        }

        public Rectangle(Point beginPoint, Point endPoint) : base(beginPoint, endPoint)
        {
            this.BeginPoint = beginPoint;
            this.EndPoint = endPoint;
        }

        public double Heigth
        {
            get
            {
                return this.GetLength(this.EndPoint.CoordX, this.BeginPoint.CoordX);
            }
        }

        public double Width
        {
            get
            {
                return this.GetLength(this.EndPoint.CoordY, this.BeginPoint.CoordY);
            }
        }

        public double GetLength(double end, double begin)
        {
            return Math.Abs(end - begin);
        }

        public override double GetArea()
        {
            return this.Width * this.Heigth;
        }

        public override double GetPerimeter()
        {
            return (this.Width * 2) + (this.Heigth * 2);
        }

        private new void GetLength() // сокрытие метода от пользователя
        {
        }
    }
}
