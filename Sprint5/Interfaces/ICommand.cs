using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint5
{
	interface ICommand
	{
		void ChangePlayer(Player player);
		void Execute();
	}
}
