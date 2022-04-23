using System;
using System.Collections.Generic;
using System.Text;
using Sprint5;

namespace Sprint5.Collision
{
	class NPC2BlockHandler
	{
		public NPC2BlockHandler()
		{

		}

		public void Handle(INPC enemy, int[] handleList)
		{
			for (int i = 0; i < handleList.Length; i++)
			{
				if (handleList[i] == 0)
				{
					enemy.moveLock((FacingEnum)i);
					//*player.Move(i % 2 == 0 ? i + 1 : i - 1);
				}
				else
				{
					enemy.moveunLock((FacingEnum)i);
				}
			}
		}
	}
}