using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class PrevItemCom : ICommand
    {
        void ICommand.Execute(Player player, Item item, ISprite block, ISprite enemy)
        {
            item.SetIndex(item.itemNum-1);
            item.SetI(0);
        }
    }
}