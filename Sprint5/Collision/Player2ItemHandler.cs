using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint5.Collision
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
				SoundManager.Instance.PlaySound("GetItem");
				if (type.Equals("key"))
					Inventory.AddKeys();
				else if (type.Equals("itemHeart"))
					Inventory.AddHealth();
				else if (type.Equals("boomerang"))
					Inventory.AddBoomerang();
				else if (type.Equals("map"))
					Inventory.AddMap();
				else if (type.Equals("compass"))
					Inventory.AddCompass();
				else if (type.Equals("triforce"))
                {
					Win.SetWinCondition(true);
					SoundManager.Instance.WinMusic();
                }
			}
		}
	}
}
