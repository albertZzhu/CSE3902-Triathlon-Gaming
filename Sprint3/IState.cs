using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3
{
    interface IState
    {
        public void Attack();

        public void Damage();

        public void Move(); //??? should I include direction here? i dont think so


    }
}
