namespace Task04
{
    using System;

    public class Wolf : IMonster
    {
        private const int SPEED = 2;
        private const int DAMAGE = 1;
        public const int Length = 3;

        public Wolf()
        {
            this.Speed = SPEED;
            this.Damage = DAMAGE;
        }

        public int Damage { get; set; }

        public int Speed { get; set; }

        public int LocationX { get; set; }

        public int LocationY { get; set; }

        private bool Down { get; set; }

        private bool Forward { get; set; }

        public void AttackPlayer()
        {
            Map.player[0].Health--;
        }

        public void Move()
        {
            if (this.LocationX == 0)
            {
                Forward = true;
            }

            if (this.LocationY == 0)
            {
                this.Down = false;
            }

            if (this.LocationX == Map.Width)
            {
                this.Forward = false;
            }

            if (this.LocationY == Map.Heigth)
            {
                this.Down = true;
            }

            if (Math.Abs(this.LocationX - Map.player[0].LocationX) <= 1 && Math.Abs(this.LocationY - Map.player[0].LocationY) <= 1)
            {
                this.AttackPlayer();
                return;
            }

            this.LocationX = this.Forward ? this.LocationX + 1 : this.LocationX - 1;
            return;
        }
    }
}
