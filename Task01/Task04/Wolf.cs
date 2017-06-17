using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    class Wolf : Monster
    {
        public int Damage { get; set; }
        public int Speed { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public void AttackPlayer()
        {
        }

        public void Move() // передвижение зигзагом
        {
        }
    }
}
