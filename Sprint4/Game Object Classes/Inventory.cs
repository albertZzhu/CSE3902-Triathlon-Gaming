using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint4.Game_Object_Classes;

namespace Sprint4
{
    public class Inventory : IGameObject
    {
		private static Inventory uniqueInventory;
		private ContentManager content;
		private SpriteFont font;
		private Level1 level;
		private int rupees;
		private int keys;
		private int bombs;
		private int health;
		private bool boomerang;
		private bool map;

		private MapMarker marker = new MapMarker();

		public Inventory(ContentManager content, Level1 level)
        {
			rupees = 0;
			keys = 0;
			bombs = 0;
			health = 5;
			boomerang = false;
			map = false;
			this.content = content;
			this.level = level;
			font = content.Load<SpriteFont>("coortest");
		}

		public static Inventory GetInventory(ContentManager content, Level1 level)
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

		public static void AddItem(Iitem item)
        {
			string type = item.GetItemTexture();
			if (type.Equals("key"))
				uniqueInventory.AddKeys();
			else if (type.Equals("itemHeart"))
				uniqueInventory.AddHealth();
			else if (type.Equals("boomerang"))
				uniqueInventory.AddBoomerang();
			else if (type.Equals("map"))
				uniqueInventory.AddMap();
			else
				uniqueInventory.AddRupees();
        }

		public void AddRupees()
		{
			rupees++;
		}

		public void AddKeys()
        {
			keys++;
        }

		public void AddBombs()
		{
			bombs++;
		}
		public void AddHealth()
		{
			health++;
		}

		public static void SubtractHealth()
		{
			uniqueInventory.health--;
		}

		public void AddBoomerang()
        {
			boomerang = true;
        }

		public void AddMap()
		{
			map = true;
		}

		public void UpdateContent(ContentManager content)
        {
			this.content = content;
        }
		public static void Reset()
        {
			uniqueInventory.rupees = 0;
			uniqueInventory.keys = 0;
			uniqueInventory.bombs = 0;
			uniqueInventory.health = 5;
			uniqueInventory.boomerang = false;
			uniqueInventory.map = false;
		}
		public void Update(GameTime gametime)
        {
			marker.Update(level.GetIndex());
		}
		public void Update()
		{
			marker.Update(level.GetIndex());
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			Item item = new Item();
			spriteBatch.DrawString(font, "x" + rupees +"\n\nx" + keys + "\nx" + bombs, new Vector2(400, 600), Color.White);
			spriteBatch.DrawString(font, "1      2", new Vector2(450, 600), Color.White);
			spriteBatch.DrawString(font, "-----HEALTH-----", new Vector2(550, 600), Color.Red);
			item.SetSprite(SpriteFactory.GetSprite("fireballdown"));
			item.SetLocation(new Vector2(450, 650));
			item.Draw(spriteBatch);
			if (boomerang)
			{
				item.SetSprite(SpriteFactory.GetSprite("boomerang"));
				item.SetLocation(new Vector2(520, 655));
				item.Draw(spriteBatch);
			}
			item.SetSprite(SpriteFactory.GetSprite("key"));
			item.SetLocation(new Vector2(350, 650));
			item.Draw(spriteBatch);
			for (int i = 0; i < health; i++)
			{
				item.SetSprite(SpriteFactory.GetSprite("heart"));
				item.SetLocation(new Vector2(550 + 50 * i, 650));
				item.Draw(spriteBatch);
			}
			if (map)
			{
				item.SetSprite(SpriteFactory.GetSprite("dungeonmap"));
				item.SetLocation(new Vector2(10, 575));
				item.Draw(spriteBatch);
			}

			marker.Draw(spriteBatch);
		}
	}
}
