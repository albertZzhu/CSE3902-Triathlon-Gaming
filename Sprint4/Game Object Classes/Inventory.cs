using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint4
{
    public class Inventory : IGameObject
    {
		private static Inventory uniqueInventory;
		private Player player;
		private PlayerStateMachine psm;
		private ContentManager content;
		private SpriteFont font;
		private int rupees;
		private int keys;
		private int bombs;
		private int health;

		public Inventory(ContentManager content)
        {
			rupees = 0;
			keys = 0;
			bombs = 0;
			this.content = content;
			font = content.Load<SpriteFont>("coortest");
		}

		public static Inventory GetInventory(ContentManager Content)
		{
			if (uniqueInventory == null)
			{
				uniqueInventory = new Inventory(Content);
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

		public void UpdateContent(ContentManager content)
        {
			this.content = content;
        }
		public void Update(GameTime gametime)
        {
			
        }

		public void Draw(SpriteBatch spriteBatch)
		{
			Item item = new Item();
			spriteBatch.DrawString(font, "x" + rupees +"\n\nx" + keys + "\nx" + bombs, new Vector2(300, 600), Color.White);
			spriteBatch.DrawString(font, "-----HEALTH-----", new Vector2(550, 600), Color.Red);
			item.SetSprite(SpriteFactory.GetSprite("key"));
			item.SetLocation(new Vector2(275, 600));
			item.Draw(spriteBatch);
			item.SetSprite(SpriteFactory.GetSprite("heart"));
			item.SetLocation(new Vector2(550, 700));
			item.Draw(spriteBatch);
		}
	}
}
