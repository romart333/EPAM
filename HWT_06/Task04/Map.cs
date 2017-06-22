namespace Task04
{
    using System;

    public static class Map
    {
        public const int Width = 800;
        public const int Heigth = 600;

        internal static Player[] player;

        internal static Wolf[] wolf;

        internal static Bear[] bear;

        internal static Cherry[] cherry;

        internal static Chocolate[] chocolate;

        internal static Stone[] stone;

        internal static Tree[] tree;
    
        public static void Start()
        {
            InitialMap();
        }

        private static void InitialObjects<T>(ref T[] arr) where T : class, new()
        {
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = new T();
            }
        }

        private static void InitialMap()
        {
            InitialObjects(ref player);
            InitialObjects(ref wolf);
            InitialObjects(ref bear);
            InitialObjects(ref cherry);
            InitialObjects(ref chocolate);
            InitialObjects(ref stone);
            InitialObjects(ref tree);
        }
    }
}