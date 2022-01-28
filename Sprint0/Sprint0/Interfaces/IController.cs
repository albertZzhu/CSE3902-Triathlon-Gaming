using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    interface IController
    {
        //if pressed? need getState
        //cannot declare instance variables in an interface. want KeyboardState obj (more generally tho)

        //Called in initialize
        void InitializeController();

        //Updates inputs
        //called in update
        void CompareStates(NMNASprite _nmna, MNASprite _mna, NMASprite _nma, MASprite _ma);


    }
}
