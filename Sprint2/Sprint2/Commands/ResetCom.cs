using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class ResetCom : ICommand
    {
        public void Execute(ISprite player, ISprite item, ISprite block, ISprite enemy)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
