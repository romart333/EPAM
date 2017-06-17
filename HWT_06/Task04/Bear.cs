namespace Task04
{
    using System;

    public class Bear : IMonster
    {
        private const int SPEED = 1;
        private const int DAMAGE = 2;

        public Bear()
        {
            this.Speed = SPEED;
            this.Damage = DAMAGE;
        }

        public int Damage { get; set; }

        public int Speed { get; set; }

        public int LocationX { get; set; }

        public int LocationY { get; set; }

        private bool Forward { get; set; }

        public void AttackPlayer()
        {
            Map.player.Health -= 2;
        }

        public void Move() // передвижение по прямой
        {
            if (this.LocationX == 0)
            {
                this.Forward = true;
            }

            if (this.LocationX == Map.Width)
            {
                this.Forward = false;
            }

            if (Math.Abs(this.LocationX - Map.player.LocationX) <= 1 && Math.Abs(this.LocationY - Map.player.LocationY) <= 1)
            {
                this.AttackPlayer();
                return;
            }

            this.LocationX = this.Forward ? this.LocationX + 1 : this.LocationX - 1;
            return;
        }
    }
}
