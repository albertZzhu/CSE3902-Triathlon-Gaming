using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class DamageCom : ICommand
    {
        void ICommand.Execute(ISprite player, ISprite item, ISprite block, ISprite enemy)
        {
            player.Update();
        }
    }
}