using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4
{

	class InventoryCom : IGameControlCom
	{
		private ItemSelect inventory;
		public InventoryCom(ItemSelect inventory)
		{
			this.inventory = inventory;
		}

		public void Execute()
		{
			//inventory.OpenMenu();
			//how to get spriteBatch??
		}
	}
}
