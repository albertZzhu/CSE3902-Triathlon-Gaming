using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3
{
    class PrevItemCom : ICommand
    {
        void ICommand.Execute(Player player, Item item, Block block, NPC1 enemy)
        {
            item.SwitchingBackward();
        }
    }
}