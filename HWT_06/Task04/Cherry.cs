namespace Task04
{
    using System;

    public class Cherry : IBonus 
    {
        public const int Length = 4;

        public int LocationY { get; set; }

        public int LocationX { get; set; }

        public void CharacterUp()
        {
            Map.player[0].Health++;
        }
    }
}
