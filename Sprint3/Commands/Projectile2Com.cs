using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3
{
	class Projectile2Com : ICommand
	{ //should combine these commands? or is this better?
		Player player;
		public Projectile2Com(Player p)
        {
			player = p;
        }
		void ICommand.Execute()
		{
			player.setFireball(1);
		}
	}
}