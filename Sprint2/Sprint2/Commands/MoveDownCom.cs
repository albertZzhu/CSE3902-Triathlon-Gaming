﻿namespace Sprint2
{
	class MoveDownCom : ICommand
	{
		void ICommand.Execute(Player player, Item item, ISprite block, NPC1 enemy)
		{
			player.Move(3);
		}
	}
}
