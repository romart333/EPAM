namespace Task01
{
    using System;

    public class Round
    {
        private double radius;

        public Round()
        {
            this.radius = 1;
        }

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
                    this.radius = 1;
                    Console.WriteLine("Радиус должен быть положительным значением. Установлено значение 1");
                }
                else
                {
                    this.radius = value;
                }

                this.Area = this.GetArea();
                this.Length = this.GetLength();
            }
        }

        public double XCenter { get; set; }

        public double YCenter { get; set; }

        public double Length { get; private set; }

        public double Area { get; private set; }

        private double GetArea()
        {
            return Math.PI * Math.Pow(this.radius, 2);
        }

        private double GetLength()
        {
            return 2 * this.radius * Math.PI;
        }
    }
}
