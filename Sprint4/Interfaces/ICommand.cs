using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4
{
	interface ICommand
	{
		void ChangePlayer(Player player);
		void Execute();
	}
}
