namespace Task04
{
    using System;

    public class Player : ICreature
    {
        private const int SPEED = 2;
        private const int HEALTH = 5;

        public Player()
        {
            this.Speed = SPEED;
            this.Health = HEALTH;
        }

        public int Speed { get; set; }

        public int LocationX { get; set; }

        public int LocationY { get; set; }

        public int Health { get; set; }
       
        public void Move()
        {
        }

        public void Move(char ch)
        {
            switch (ch)
            {
                case 'a':
                    {
                        if (this.LocationX != 0)
                        {
                            this.LocationX--;
                        }

                        break;
                    }

                case 'd':
                    {
                        if (Map.Width != this.LocationX)
                        {
                            this.LocationX++;
                        }

                        break;
                    }

                case 'w':
                    {
                        if (Map.Heigth != this.LocationY)
                        {
                            this.LocationY++;
                        }

                        break;
                    }

                case 's':
                    {
                        if (this.LocationY != 0)
                        {
                            this.LocationY--;
                        }

                        break;
                    }
            }

            if (Map.cherry.LocationY == this.LocationY && this.LocationX == Map.cherry.LocationX)
            {
                Map.cherry.CharacterUp();
            }

            if (Map.chocolate.LocationY == this.LocationY && Map.chocolate.LocationX == this.LocationX)
            {
                Map.chocolate.CharacterUp();
            }
        }
    }
}