using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3
{
	class Projectile2Com : ICommand
	{
		void ICommand.Execute(Player player, Item item, Block block, NPC1 enemy)
		{
			player.setFireball(1);
		}
	}
}