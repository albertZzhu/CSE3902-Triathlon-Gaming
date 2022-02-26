using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3
{
	class BlockForwardCom : ICommand
	{
		Block block;
		void ICommand.Execute()
		{
			block.SwitchingForward();
		}

		public BlockForwardCom(Block b)
        {
			block = b;
        }
	}
}
