namespace Task04
{
    using System;

    public class Tree : IBarrier
    {
        public const int Length = 7;

        public int Heigth { get; }

        public int Width { get; }

        public int LocationX { get; set; }

        public int LocationY { get; set; }
    }
}
