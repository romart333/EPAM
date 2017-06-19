namespace Task04
{
    using System;

    public class Stone : IBarrier
    {
        public int Size { get; set; } // 3x3//todo pn а если захочется прямоугольный камень?

        public int LocationX { get; set; }

        public int LocationY { get; set; }
    }
}
