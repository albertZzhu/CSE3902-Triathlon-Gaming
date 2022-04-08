using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4.Collision
{
	class Player2ItemHandler : ICollisionHandler<Iplayer, Iitem>
	{
		public Player2ItemHandler()
		{
		}

		public void Handle(Iplayer player, Iitem item, Side.side side)
		{
			string type = item.GetItemTexture();
			if (!item.isDisappear())
			{
				item.goDisappear();
                Inventory.AddItem(item);
				SoundManager.Instance.PlaySound("GetItem");
                if (type.Equals("triforce"))
                {
					Win.SetWinCondition(true);
                }
			}
		}
	}
}
