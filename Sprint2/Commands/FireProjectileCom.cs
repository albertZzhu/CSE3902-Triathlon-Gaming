﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class FireProjectileCom : ICommand
    {
        void ICommand.Execute(Player player, Item item, Block block, NPC1 enemy)
        {
            player.DistantAttack();
        }
    }
}