using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3.Collision
{
	class Player2ItemHandler : ICollisionHandler<Iplayer, Iitem>
	{
		public Player2ItemHandler()
		{

		}

		public void Handle(Iplayer player, Iitem item, Side.side side)
		{
			if (!item.isDisappear())
			{
				item.goDisappear();
			}
		}
	}
}
