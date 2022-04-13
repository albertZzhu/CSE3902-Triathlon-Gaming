using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint5
{
    
    class FireProjectileCom : ICommand
    {
        private Player player;
		public FireProjectileCom(Player player)
		{
			this.player = player;
		}

        public void ChangePlayer(Player player)
		{
			this.player = player;
		}
		public void Execute()
		{
			player.DistantAttack();
		}
    }
}
