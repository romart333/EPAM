namespace Task04
{
    using System;

    public class Chocolate : IBonus
    {
        public const int Length = 6;

        public int LocationY { get; set; }

        public int LocationX { get; set; }

        public void CharacterUp()
        {
            Map.player[0].Speed++;
        }
    }
}
