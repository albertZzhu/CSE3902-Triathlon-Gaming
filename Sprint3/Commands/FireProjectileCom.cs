using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3
{
    class FireProjectileCom : ICommand
    {
        Player player;

        public FireProjectileCom(Player p)
        {
            player = p;
        }
        void ICommand.Execute()
        {
            player.DistantAttack();
        }
    }
}
