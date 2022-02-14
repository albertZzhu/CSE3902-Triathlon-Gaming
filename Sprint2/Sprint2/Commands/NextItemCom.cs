using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class NextItemCom : ICommand
    {
        private static int i = 0;
        void ICommand.Execute(Player player, Item item, ISprite block, ISprite enemy)
        {
            i++;
            if (i == item.index)
            {
                i = 0;
            }
            item.SetIndex(i);
            item.SetI(0);
        }
    }
}