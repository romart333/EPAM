namespace Task01
{
    using System;

    public enum FillType
    {
        Solid,
        Gradient,
        Texture
    }

    public enum BrushType
    {
        Solid,
        Dodge,
        Healing,
        Dotted
    }

    

    public class Figure
    {
        private const int BrushCount = 4;
        private const int FillCount = 3;
        private BrushType brush;
        private FillType fill;

        public Figure()
        {
            Brush = BrushType.Solid;
            Fill = FillType.Solid;
        }

        public Figure(BrushType brush, FillType fill)
        {
            this.Brush = brush;
            this.Fill = fill;
        }

        protected BrushType Brush
        {
            get
            {
                return this.brush;
            }

                        set
            {
                if (value < 0 || (int)value >= BrushCount)
                {
                    Console.WriteLine("Некорректный выбор кисти.");
                    return;
                }

                this.brush = value;
            }
        }

        protected FillType Fill
        {
            get
            {
                return this.fill;
            }

            set
            {
                if (value < 0 || (int)value >= FillCount)
                {
                    Console.WriteLine("Некоррректный выбор заливки.");
                    return;
                }

                this.fill = value;
            }
        }

        protected double Difference(double end, double begin)
        {
            return Math.Abs(end - begin);
        }
    }
}
