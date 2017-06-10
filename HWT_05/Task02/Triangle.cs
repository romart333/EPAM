namespace Task02
{
    using System;

    public class Triangle
    {
        private double a, b, c;
        private string strErr = "Сторона должна быть положительной. Установлено значение 1";

        public Triangle()
        {
            this.a = this.b = this.c = 1;
        }

        public double A
        {
            get
            {
                return this.a;
            }

            set
            {
                this.a = this.Validate(value);
            }
        }

        public double B
        {
            get
            {
                return this.b;
            }

            set
            {
                this.b = this.Validate(value);
            }
        }

        public double C
        {
            get
            {
                return this.c;
            }

            set
            {
                this.c = this.Validate(value);
            }
        }

        public double Perimeter
        {
            get { return this.a + this.b + this.c; }
        }

        public double Area
        {
            get
            {
                double halfperim = this.Perimeter / 2;
                return Math.Sqrt(halfperim * (this.a - halfperim) * (this.b - halfperim) * (this.c - halfperim));
            }
        }

        private double Validate(double value)
        {
            if (value <= 0)
            {
                Console.WriteLine(this.strErr);
                return 1;
            }

            return value;
        }
    }
}
