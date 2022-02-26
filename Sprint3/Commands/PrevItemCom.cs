using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3
{
    class PrevItemCom : ICommand
    {
        Item item;
        public PrevItemCom(Item i)
        {
            item = i;
        }
        void ICommand.Execute()
        {
            item.SwitchingBackward();
        }
    }
}