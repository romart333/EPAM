namespace Task02
{
    using System;
    using Task02;

    public class Round
    {
        private double radius;

        public Round()
        {
        }

        public double Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (value < 0)
                {
                    Console.WriteLine(Recs.errNegValue);
                    return;
                }

                this.radius = value;
            }
        }

        public double Length
        {
            get
            {
                return 2 * this.radius * Math.PI;
            }
        }

        protected double XCenter { get; set; }

        protected double YCenter { get; set; }
    }
}
