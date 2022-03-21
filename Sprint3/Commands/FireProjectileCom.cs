using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3
{
    class FireProjectileCom : ICommand
    {
        void ICommand.Execute(Player player)
        {
            player.DistantAttack();
        }
    }
}
