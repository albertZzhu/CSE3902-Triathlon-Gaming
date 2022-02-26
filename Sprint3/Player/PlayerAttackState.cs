using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3.Player
{
    class PlayerAttackState : IState
    {
        PlayerStateMechine machine;
        Facing facing;
        Player player;
        public PlayerAttackState(PlayerStateMechine mach)
        {
            machine = mach;
            facing = machine.FacingState();
            player = machine.GetPlayer();
            
        }
        public void Attack()
        {
            if (facing.Equals(Facing.RIGHT))
            {
                player.SetSprite(SpriteFactory.GetSprite("right_throw"));
            }
            else if (facing.Equals(Facing.LEFT))
            {
                player.SetSprite(SpriteFactory.GetSprite("left_throw"));
            }
            else if (facing.Equals(Facing.UP))
            {
                player.SetSprite(SpriteFactory.GetSprite("up_throw"));
            }
            else if (facing.Equals(Facing.DOWN))
            {
                player.SetSprite(SpriteFactory.GetSprite("down_throw"));
            }
            int animationLength = player.getSprite().GetFrames().size(); //time????
            //1 time animation then change state
        }

        public void Damage()
        {
            throw new NotImplementedException();
        }

        public void Move()
        {
            throw new NotImplementedException();
        }
    }
}
