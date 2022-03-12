using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3
{
	class QuitCom : ICommand
	{
		void ICommand.ChangePlayer(Player player)
		{

		}
		public void Execute()
		{
			System.Windows.Forms.Application.Exit();
		}
	}
}
