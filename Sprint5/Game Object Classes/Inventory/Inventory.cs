using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.Game_Object_Classes;
using System.Collections.Generic;

namespace Sprint5
{
    public class Inventory : IGameObject
    {
		private static Inventory uniqueInventory;
		private ContentManager content;
		private SpriteFont font;
		private Level level;
		private int rupees;
		private int keys;
		private int bombs;
		private int health;
		private int score;
		private int hiscore;
		private bool boomerang;
		private bool map;
		private bool compass;
		private Item item2 = new Item("mapmarker2");

		private MapMarker marker = new MapMarker();

		public Inventory(ContentManager content, Level level)
        {
			rupees = 0;
			keys = 0;
			bombs = 0;
			score = 0;
			hiscore = 0;
			health = 5;
			boomerang = false;
			map = false;
			compass = false;
			this.content = content;
			this.level = level;
			font = content.Load<SpriteFont>("coortest");
		}

		public static Inventory GetInventory(ContentManager content, Level level)
		{
			if (uniqueInventory == null)
			{
				uniqueInventory = new Inventory(content, level);
			}
			return uniqueInventory;
		}

		public static Inventory GetInventory()
		{
			return uniqueInventory;
		}

		public static bool GetBoomerang()
        {
			return uniqueInventory.boomerang;
        }
		public static void AddRupees()
		{
			uniqueInventory.rupees++;
		}

		public static void AddScore()
		{
			if (uniqueInventory.level is Level2)
				uniqueInventory.score+=10;
		}

		public static void AddHiScore()
		{
			if (uniqueInventory.level is Level2)
				if (uniqueInventory.score > uniqueInventory.hiscore)
					uniqueInventory.hiscore = uniqueInventory.score;
		}

		public static void AddKeys()
        {
			uniqueInventory.keys++;
        }

		public static void SubtractKeys()
		{
			uniqueInventory.keys--;
		}
		public static int KeyCount()
		{
			return uniqueInventory.keys;
		}
		public static void AddBombs()
		{
			uniqueInventory.bombs++;
		}
		public static void AddHealth()
		{
			uniqueInventory.health++;
		}

		public static void SubtractHealth()
		{
			uniqueInventory.health--;
		}

		public static void AddBoomerang()
        {
			uniqueInventory.boomerang = true;
        }

		public static void AddMap()
		{
			uniqueInventory.map = true;
		}

		public static void AddCompass()
		{
			uniqueInventory.compass = true;
		}

		public static void UpdateLevel(Level level)
        {
			uniqueInventory.level = level;
        }
		public static List<Item> GetItems()
		{
			List<Item> items = new List<Item>();
			items.Add(new Item("fireballdown"));
			if (uniqueInventory.boomerang)
				items.Add(new Item("boomerang"));
			else if (uniqueInventory.map)
				items.Add(new Item("map"));
			else if (uniqueInventory.compass)
				items.Add(new Item("compass"));
			return items;
		}
		public static void Reset()
        {
			uniqueInventory.rupees = 0;
			uniqueInventory.keys = 0;
			uniqueInventory.bombs = 0;
			if (uniqueInventory.score > uniqueInventory.hiscore)
				uniqueInventory.hiscore = uniqueInventory.score;
			uniqueInventory.score = 0;
			uniqueInventory.health = 5;
			uniqueInventory.boomerang = false;
			uniqueInventory.map = false;
			uniqueInventory.compass = false;
		}
		public void Update(GameTime gametime)
        {
			if (level is Level1)
			{
				marker.Update(level.GetIndex());
				item2.Update(gametime);
			}
            else
            {

            }
		}

		public static void Draw(SpriteBatch spriteBatch)
		{

			//this will need to be added to the xml file or its own class next sprint
			if(uniqueInventory.level is Level1) { 
				Item item = new Item();
				spriteBatch.DrawString(uniqueInventory.font, "x" + uniqueInventory.rupees +"\n\nx" + uniqueInventory.keys + "\nx" + uniqueInventory.bombs, new Vector2(400, 600), Color.White);
				spriteBatch.DrawString(uniqueInventory.font, "1      2", new Vector2(450, 600), Color.White);
				spriteBatch.DrawString(uniqueInventory.font, "-----HEALTH-----", new Vector2(550, 600), Color.Red);
				item.SetSprite(SpriteFactory.GetSprite("fireballdown"));
				item.SetLocation(new Vector2(450, 650));
				item.Draw(spriteBatch);
				if (uniqueInventory.boomerang)
				{
					item.SetSprite(SpriteFactory.GetSprite("boomerang"));
					item.SetLocation(new Vector2(520, 655));
					item.Draw(spriteBatch);
				}
				item.SetSprite(SpriteFactory.GetSprite("key"));
				item.SetLocation(new Vector2(350, 650));
				item.Draw(spriteBatch);
				for (int i = 0; i < uniqueInventory.health; i++)
				{
					item.SetSprite(SpriteFactory.GetSprite("heart"));
					item.SetLocation(new Vector2(550 + 50 * i, 650));
					item.Draw(spriteBatch);
				}
				if (uniqueInventory.map)
				{
					item.SetSprite(SpriteFactory.GetSprite("dungeonmap"));
					item.SetLocation(new Vector2(10, 575));
					item.Draw(spriteBatch);
				}
				if (uniqueInventory.compass)
				{
					uniqueInventory.item2.SetLocation(new Vector2(305, 620));
					uniqueInventory.item2.Draw(spriteBatch);
				}

				uniqueInventory.marker.Draw(spriteBatch);
			}
            else
            {
				spriteBatch.DrawString(uniqueInventory.font, "SCORE: " + uniqueInventory.score + "\nHIGH SCORE: " + uniqueInventory.hiscore, new Vector2(0, 0), Color.White);
				spriteBatch.DrawString(uniqueInventory.font, "HEALTH: ", new Vector2(850, 0), Color.Red);
				Item item = new Item();
				for (int i = 0; i < uniqueInventory.health; i++)
				{
					item.SetSprite(SpriteFactory.GetSprite("heart"));
					item.SetLocation(new Vector2(1000 + 50 * i, 0));
					item.Draw(spriteBatch);
				}
			}
		}
	}
}
