using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
	class MoveRightCom : ICommand
    {
        void ICommand.Execute(Player player, Item item, ISprite block, ISprite enemy)
        {
            player.Move(0);
        }
    }
}
