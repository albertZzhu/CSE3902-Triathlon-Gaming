using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class PrevItemCom : ICommand
    {
        void ICommand.Execute(Player player, Item item, ISprite block, NPC1 enemy)
        {
            int i = item.GetIndex() - 1;
            if (i > 0)
                item.SetIndex(i);
            else
                item.SetIndex(item.GetItemList().Count - 1);
        }
    }
}