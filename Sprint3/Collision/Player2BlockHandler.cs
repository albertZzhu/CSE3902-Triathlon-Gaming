using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3.Collision
{
	class Player2BlockHandler : ICollisionHandler<Iplayer, IBlock>
	{
		public Player2BlockHandler()
		{

		}


		public void Handle(Iplayer player, IBlock block, Side.side side)
		{
			if (side == Side.side.left)
			{
				player.moveLock(1);
				//player.Move(0);
			}else if (side == Side.side.right)
			{
				player.moveLock(0);
				//player.Move(1);
			}
			else if (side == Side.side.up)
			{
				player.moveLock(2);
				//player.Move(3);
			}
			else if (side == Side.side.down)
			{
				player.moveLock(3);
				//player.Move(2);
			}
		}

		public void unHandle(Iplayer player, IBlock block, Side.side side)
		{
			if (side == Side.side.left)
			{
				player.moveunLock(1);
			}
			else if (side == Side.side.right)
			{
				player.moveunLock(0);
			}
			else if (side == Side.side.up)
			{
				player.moveunLock(2);
			}
			else if (side == Side.side.down)
			{
				player.moveunLock(3);
			}
		}
	}
}