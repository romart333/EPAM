using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    interface Monster : Creature
    {
        int Damage { get; set; }
        void AttackPlayer();
    }
}
