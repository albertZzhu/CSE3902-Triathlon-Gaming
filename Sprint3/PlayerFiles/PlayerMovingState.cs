using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3.PlayerFiles
{
    class PlayerMovingState : IState
    {
        PlayerStateMachine machine;

        public PlayerMovingState(PlayerStateMachine mach)
        {
            machine = mach;
        }

        public void Attack()
        {
            machine.Attack();
        }

        public void Damage()
        {
            throw new NotImplementedException(); //change sprite? //set player as damaged
        }

        public void Move()
        {
            Facing face = machine.GetFacingMachine().GetFacing();
            if (face == Facing.RIGHT) 
            {
                machine.SetLocation(machine.GetLocation() + new Vector2(10, 0));
                machine.GetPlayer().SetSprite(SpriteFactory.GetSprite("right_move"));
            }
            else if (face == Facing.LEFT)
            {
                machine.SetLocation(machine.GetLocation() + new Vector2(-10, 0));
                machine.GetPlayer().SetSprite(SpriteFactory.GetSprite("left_move"));
            }  
            if (face == Facing.UP)
            {
                machine.SetLocation(machine.GetLocation() + new Vector2(0, -10));
                machine.GetPlayer().SetSprite(SpriteFactory.GetSprite("back_move"));
            } 
            if (face == Facing.DOWN)
            {
                machine.SetLocation(machine.GetLocation() + new Vector2(0, 10));
                machine.GetPlayer().SetSprite(SpriteFactory.GetSprite("front_move"));
            }
                
        }
    }
}
