﻿namespace Sprint2
{
	class PrevBlockCom : ICommand
	{
		void ICommand.Execute(Player player, ISprite item, Block block, NPC1 enemy)
		{
			block.SwitchingBackward();
		}
	}
}
