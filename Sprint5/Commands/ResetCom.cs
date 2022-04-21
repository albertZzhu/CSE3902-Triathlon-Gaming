using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
namespace Sprint5
{
	class ResetCom : ICommand
	{
		private Player player;
		private Level level;
		public ResetCom(Level level)
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
			Inventory.Reset();
			SoundManager.Instance.ThemeMusic();
			/*player.Reset();
			item.Reset();
			block.Reset();
			enemy.SetIndx(0);
			enemy.SetLocation(new Vector2(50, 50));*/
		}
	}
}
