using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3
{
	class Projectile3Com : ICommand
	{
		Player player;

		public Projectile3Com(Player p)
        {
			player = p;
        }
		void ICommand.Execute()
		{
			player.setFireball(2);
		}
	}
}