namespace Task02
{
    using System;

    public class Ring : Round
    {
        private Round innerRound;
        private Round outerRound;

        public Ring() : base()
        {
            this.innerRound = new Round();
            this.outerRound = new Round();
        }

        public new double XCenter { get; set; }

        public new double YCenter { get; set; }

        public double InnerRadius
        {
            get
            {
                return this.innerRound.Radius;
            }

            set
            {
                if (value > this.OuterRadius)
                {
                    Console.WriteLine(Recs.errCmpRadius + Recs.oldValue + $"({this.outerRound.Radius})");
                }

                this.innerRound.Radius = value;
            }
        }

        public double OuterRadius
        {
            get
            {
                return this.outerRound.Radius;
            }

            set
            {
                if (value < this.InnerRadius)
                {
                    Console.WriteLine(Recs.errCmpRadius + Recs.oldValue + $"({this.outerRound.Radius})");
                }

                this.outerRound.Radius = value;
            }
        }

        public double Area
        {
            get
            {
                return Math.PI * (Math.Pow(this.OuterRadius, 2) - Math.Pow(this.InnerRadius, 2));
            }
        }

        public new double Length
        {
            get
            {
                return this.outerRound.Length + this.innerRound.Length;
            }
        }

       new public double Radius { get; private set; } // сокрытие наследуемого свойства
    }
}
