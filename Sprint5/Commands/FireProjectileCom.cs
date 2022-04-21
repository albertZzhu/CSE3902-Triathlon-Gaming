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
			if (this.player.getFireBall() == 2)
            {
				this.player.UnPickupBoomrang();
				this.player.UnLoadBoomrang();
				player.GoAttack();
				player.DistantAttack();
			} 
			else if (this.player.getFireBall() == 0)
            {
				this.player.UnPickupBoomrang();
				this.player.UnLoadBoomrang();
				player.DistantAttack();
			}
			else if(this.player.PickupBoomrang())
			{
				this.player.LoadBoomrang();
			}
		}
    }
}
