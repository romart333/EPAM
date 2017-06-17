namespace Task04
{
    using System;

    public static class Map
    {
        public const int Width = 800;
        public const int Heigth = 600;

        internal static Player player { get; set; }
           
        internal static Wolf wolf { get; set; }

        internal static Bear bear { get; set; }

        internal static Cherry cherry { get; set; }

        internal static Chocolate chocolate { get; set; }

        internal static Stone stone { get; set; }

        internal static Tree tree { get; set; }

        public static void InitialMap()
        {
            player = new Player();
            wolf = new Wolf();
            bear = new Bear();
            cherry = new Cherry();
            chocolate = new Chocolate();
            stone = new Stone();
            tree = new Tree();
        }

        public static void Start()
        {
            // запуск игры..
        }
    }
}