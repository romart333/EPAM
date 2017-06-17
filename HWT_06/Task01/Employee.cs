namespace Task01
{
    using System;
    using Task01;

    public class Employee : User
    {
        private const int MinAgeWork = 16;

        private int lengthOfWork;

        public Employee() : base()
        {
            this.Position = string.Empty;
        }

        public int LengthOfWork
        {
            get
            {
                return this.lengthOfWork;
            }

            set
            {
                if (value > this.Age - MinAgeWork || value >= 0)
                {
                    Console.WriteLine(Resource1.strErrWork);
                    return;
                }

                this.lengthOfWork = value;
            }
        }

        public string Position
        {
            get; set;
        }
    }
}
