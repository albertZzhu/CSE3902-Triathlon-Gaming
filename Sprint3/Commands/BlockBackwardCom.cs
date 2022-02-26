using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3
{
	class BlockBackwardCom : ICommand
	{
		Block block;
		void ICommand.Execute()
		{
			block.SwitchingBackward();
		}

		public BlockBackwardCom(Block b)
        {
			block = b;
        }
	}
}
