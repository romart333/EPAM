namespace Task04
{
    using System;

    public class Stone : IBarrier
    {
        public int Size { get; set; } // 3x3

        public int LocationX { get; set; }

        public int LocationY { get; set; }
    }
}
