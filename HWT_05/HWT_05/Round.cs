namespace Task01
{
    using System;

    public class Round
    {
        private const double radiusDefault = 1;//значение по умолчанию в константы
        private double radius;

        public Round()
        {
            radius = radiusDefault;
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
                    this.radius = radiusDefault;//todo pn видишь? ты его уже не один раз используешь
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
