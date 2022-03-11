using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
namespace Sprint3
{
	class ResetCom : ICommand
	{
		private Player player;
		public ResetCom(Player player)
		{
			this.player = player;
		}
		void ICommand.ChangePlayer(Player player)
		{
			this.player = player;
		}
		public void Execute()
		{
			/*player.Reset();
			item.Reset();
			block.Reset();
			enemy.SetIndx(0);
			enemy.SetLocation(new Vector2(50, 50));*/
		}
	}
}
