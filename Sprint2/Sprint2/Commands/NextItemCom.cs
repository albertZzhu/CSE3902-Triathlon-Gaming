using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class NextItemCom : ICommand
    {
        void ICommand.Execute(Player player, ISprite item, ISprite block, ISprite enemy)
        {
            item.Update();
        }
    }
}