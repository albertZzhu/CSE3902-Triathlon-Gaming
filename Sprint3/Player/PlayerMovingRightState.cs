using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3.Player
{
    class PlayerMovingRightState : IState
    {
        public void Attack()
        {
            throw new NotImplementedException(); //stop moving and go to attack state?
        }

        public void Damage()
        {
            throw new NotImplementedException(); //change sprite? //set player as damaged
        }

        public void Move()
        {
            throw new NotImplementedException(); //key hold
        }
    }
}
