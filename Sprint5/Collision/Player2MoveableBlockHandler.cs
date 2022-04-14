using System;
using System.Collections.Generic;
using System.Text;
using Sprint5.State_Machines;


namespace Sprint5.Collision
{
	class Player2MoveableBlockHandler
	{
		public Player2MoveableBlockHandler()
		{
		}

		public void Handle(Player player, MoveableBlock block)
		{
			block.Move((FacingEnum)player.GetState().FacingState());
		}
	}
}
