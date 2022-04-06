using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint4.Game_Object_Classes;

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
		private bool boomerang;

		private MapMarker marker = new MapMarker();

		public Inventory(ContentManager content)
        {
			rupees = 0;
			keys = 0;
			bombs = 0;
			health = 5;
			boomerang = false;
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
			else if (type.Equals("boomerang"))
				uniqueInventory.AddBoomerang();
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

		public void UpdateContent(ContentManager content)
        {
			this.content = content;
        }
		public void Update(GameTime gametime)
        {
			
        }
		public void Update(int index)
		{

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
			item.SetSprite(SpriteFactory.GetSprite("dungeonmap"));
			item.SetLocation(new Vector2(10, 575));
			item.Draw(spriteBatch);

			marker.Draw(spriteBatch);


		}
	}
}
