using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class PrevBlockCom : ICommand
    {
        void ICommand.Execute(Player player, Item item, ISprite block, ISprite enemy)
        {
            block.Update();
        }
    }
}
