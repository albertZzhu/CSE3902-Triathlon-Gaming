using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4
{
    
    class FireProjectileCom : ICommand
    {
        private Player player;
		public FireProjectileCom(Player player)
		{
			this.player = player;
		}

        void ICommand.ChangePlayer(Player player)
        {
            this.player = player;
        }
        void ICommand.Execute()
        {
            player.DistantAttack();
        }
    }
}
