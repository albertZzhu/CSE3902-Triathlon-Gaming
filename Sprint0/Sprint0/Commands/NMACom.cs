using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Commands
{
    class NMACom : ICommand
    {
        void ICommand.Execute(NMNASprite _nmna, MNASprite _mna, NMASprite _nma, MASprite _ma)
        {
            _mna.SetVisible(false);
            _ma.SetVisible(false);
            _nmna.SetVisible(false);
            _nma.SetVisible(true);
        }
    }
}
