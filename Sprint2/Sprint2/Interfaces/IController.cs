using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    interface IController
    {
        //if pressed? need getState
        //cannot declare instance variables in an interface. want KeyboardState obj (more generally tho)

        //Called in initialize
        void InitializeController();

        //Updates inputs
        //called in update
        void CompareStates(Player player, ISprite item, ISprite block, ISprite enemy);


    }
}
