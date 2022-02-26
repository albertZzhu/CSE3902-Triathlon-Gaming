using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3
{
	class PrevBlockCom : ICommand
	{
		Block block;
		PrevBlockCom(Block b)
        {
			block = b;
        }
		void ICommand.Execute()
		{
			block.SwitchingBackward();
		}
	}
}
