using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
namespace Sprint4
{
	class ResetCom : ICommand
	{
		private Player player;
		private Level1 level;
		public ResetCom(Level1 level)
		{
			this.level = level;
		}

		public void ChangePlayer(Player player)
		{
			this.player = player;
		}
		public void Execute()
		{
			level.resetRoom();
			player.Reset();
			Inventory.Reset();
			/*player.Reset();
			item.Reset();
			block.Reset();
			enemy.SetIndx(0);
			enemy.SetLocation(new Vector2(50, 50));*/
		}
	}
}
