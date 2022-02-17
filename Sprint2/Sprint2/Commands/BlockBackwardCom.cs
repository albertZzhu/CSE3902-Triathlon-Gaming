using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
	class BlockBackwardCom : ICommand
	{
		void ICommand.Execute(Player player, ISprite item, Block block, NPC1 enemy)
		{
			block.SwitchingBackward();
		}
	}
}
