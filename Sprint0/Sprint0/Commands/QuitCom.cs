using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class QuitCom : ICommand
    {
        public void Execute(NMNASprite _nmna, MNASprite _mna, NMASprite _nma, MASprite _ma)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
