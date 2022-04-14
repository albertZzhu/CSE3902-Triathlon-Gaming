using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint5.Collision
{
	class MoveableBlock2BlockHandler
	{
		public MoveableBlock2BlockHandler()
		{
		}


		public void Handle(MoveableBlock block, int[] handleList)
		{
			for (int i = 0; i < handleList.Length; i++)
			{
				if (handleList[i] == 0)
				{
					block.moveLock((Facing)i);
					//*player.Move(i % 2 == 0 ? i + 1 : i - 1);
				}
				else
				{
					block.moveunLock((Facing)i);
				}
			}
		}
	}
}
