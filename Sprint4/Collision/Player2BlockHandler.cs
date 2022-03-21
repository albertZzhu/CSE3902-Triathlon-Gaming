using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4.Collision
{
	class Player2BlockHandler
	{
		public Player2BlockHandler()
		{
			
		}


		public void Handle(Iplayer player, int[] handleList)
		{
			for(int i=0;i<handleList.Length;i++)
			{
				if (handleList[i] == 0)
				{
					player.moveLock(i);
					//*player.Move(i % 2 == 0 ? i + 1 : i - 1);
				}
				else
				{
					player.moveunLock(i);
				}
			}
		}
	}
}