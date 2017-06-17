namespace Task04
{
    using System;

    public class Chocolate : IBonus
    {
        public int LocationY { get; set; }

        public int LocationX { get; set; }

        public void CharacterUp()
        {
            Map.player.Speed++;
        }
    }
}
