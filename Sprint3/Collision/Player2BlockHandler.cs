using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3.Collision
{
	class Player2BlockHandler : ICollisionHandler<Iplayer, IBlock>
	{
		
		public void Handle(Iplayer player, IBlock block, Side side)
		{
			player.GoStand();
		}
	}
}
