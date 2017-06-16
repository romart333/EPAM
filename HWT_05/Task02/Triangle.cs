namespace Task02
{
    using System;

    public class Triangle // Треугольник без изменения параметров
    {
        private const double Default1 = 1;
        private const double Default2 = 2;
        private string strErr = "Неверные значения для длин сторон";

        public Triangle()
        {
            this.A = Default1;
            this.B = this.C = Default2;
        }

        public Triangle(double a, double b, double c, out bool ok)
        {
            double sumAB = a + b;
            double sumBC = b + c;
            double sumAC = a + c;
            if (a <= 0 || b <= 0 || c <= 0 || c > sumAB || a > sumBC || b > sumAC)
            {
                Console.WriteLine(strErr);
                ok = false;
                return;
            }

            this.A = a;
            this.B = b;
            this.C = c;
            ok = true;
        }

        public double A
        {
            get; set;
        }

        public double B
        {
            get; private set;
        }

        public double C
        {
            get; private set;
        }

        public double Perimeter
        {
            get { return this.A + this.B + this.C; }
        }

        public double Area
        {
            get
            {
                double halfperim = this.Perimeter / 2;
                return Math.Sqrt(halfperim * (halfperim - this.A) * (halfperim - this.B) * (halfperim - this.C));
            }
        }
    }
}
