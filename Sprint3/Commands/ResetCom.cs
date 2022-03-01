using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint3.PlayerFiles;
namespace Sprint3
{
	class ResetCom : ICommand
	{
		public void Execute(Player player, Item item, Block block, NPC1 enemy)
		{
			player.Reset();
			item.Reset();
			block.Reset();
			enemy.SetIndx(0);
			enemy.SetLocation(new Vector2(50, 50));
		}
	}
}
