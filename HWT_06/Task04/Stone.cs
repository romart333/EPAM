namespace Task04
{
    using System;

    public class Stone : IBarrier
    {
        public const int Length = 3;

        public int Heigth { get;}

        public int Width { get; }

        public int LocationX { get; set; }

        public int LocationY { get; set; }
    }
}
