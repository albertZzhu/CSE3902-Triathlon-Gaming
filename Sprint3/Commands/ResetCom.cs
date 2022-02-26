using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
namespace Sprint3
{
	class ResetCom : ICommand
	{
		Player player;
		Item item;
		Block block;
		NPC1 enemy;

		public ResetCom(Player p, Item i, Block b, NPC1 e)
        {
			player = p;
			item = i;
			block = b;
			enemy = e;
        }
		public void Execute()
		{
			player.Reset();
			item.Reset();
			block.Reset();
			enemy.SetIndx(0);
			enemy.SetLocation(new Vector2(50, 50));
		}
	}
}
