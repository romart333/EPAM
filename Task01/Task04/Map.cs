using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    static class Map
    {
        public const int Width = 800;
        public const int Heigth = 600;
        private static Player player;
        private static Wolf wolf;
        private static Bear bear;
        private static Cherry cherry;
        private static Chocolate chocolate;
        private static Stone stone;
        private static Tree tree;

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
