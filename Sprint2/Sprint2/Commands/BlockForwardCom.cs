﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
	class BlockForwardCom : ICommand
	{
		void ICommand.Execute(Player player, Item item, Block block, NPC1 enemy)
		{
			block.SwitchingForward();
		}
	}
}