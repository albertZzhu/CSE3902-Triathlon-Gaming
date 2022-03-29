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

		public void AddLists()
		{
			lists.Add(items);
			lists.Add(blocks);
			lists.Add(players);
			lists.Add(enemies);
		}

		public void PopulatePlayers(Player player)
		{
			players.Add(player);
		}

		public void PopulateItems(Item item)
		{
			items.Add(item);
		}

		public void PopulateBlocks(Block block)
		{
			blocks.Add(block);
		}

		public void PopulateEnemies(NPC1 enemy)
		{
			enemies.Add(enemy);
		}

		public void ClearLists()
        {
			players.Clear();
			items.Clear();
			blocks.Clear();
			enemies.Clear();
        }

		public void Update(GameTime gameTime)
		{
			foreach (List<IGameObject> list in lists)
			{
				foreach (IGameObject gobj in list)
				{
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
					gobj.Draw(spriteBatch);
				}
			}
		}
	}
}