using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04
{
    interface Creature : Subject
    {
        int Speed { get; set; }
        void Move();
        
    }
}
