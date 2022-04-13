using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sprint4
{
	public class GameObjectManager
	{
		private List<List<IGameObject>> lists = new List<List<IGameObject>>();
		private List<IGameObject> players = new List<IGameObject>();
		private List<IGameObject> items = new List<IGameObject>();
		private List<IGameObject> blocks = new List<IGameObject>();
		private List<IGameObject> enemies = new List<IGameObject>();
		private List<IGameObject> inventories = new List<IGameObject>();

		public void AddLists()
		{
			lists.Add(blocks);
			lists.Add(players);
			lists.Add(enemies);
			lists.Add(items);
			lists.Add(inventories);
		}

		public void PopulatePlayers(Player player)
		{
			players.Add(player);
		}

		public void PopulateItems(Item[] itemArr)
		{
			foreach(Item item in itemArr)
				items.Add(item);
		}

		public void PopulateBlocks(IBlock[] blockArr)
		{
			foreach (IBlock block in blockArr)
				blocks.Add(block);
		}

		public void PopulateEnemies(NPC1[] enemyArr)
		{
			foreach (NPC1 enemy in enemyArr)
				enemies.Add(enemy);
		}
		public void PopulateInventory(Inventory inventory)
		{
			inventories.Add(inventory);
		}

		public void ClearLists()
        {
			foreach (List<IGameObject> list in lists)
				list.Clear();
			lists.Clear();
        }

		public void Update(GameTime gameTime)
		{
			foreach (List<IGameObject> list in lists)
			{
				foreach (IGameObject gobj in list)
				{
					if (gobj != null)
						gobj.Update(gameTime);
				}
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (List<IGameObject> list in lists)
			{
				foreach (IGameObject gobj in list)
				{
					if (gobj != null)
						gobj.Draw(spriteBatch);
				}
			}
		}
	}
}