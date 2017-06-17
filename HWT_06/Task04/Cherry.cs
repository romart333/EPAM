namespace Task04
{
    using System;

    public class Cherry : IBonus 
    {
        public int LocationY { get; set; }
        public int LocationX { get; set; }

        public void CharacterUp()
        {
            Map.player.Health++;
        }
    }
}
