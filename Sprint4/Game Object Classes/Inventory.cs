using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint4
{
    public class Inventory : IGameObject
    {
		private Player player;
		private PlayerStateMachine psm;
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
			font = content.Load<SpriteFont>("coortest");
		}

		public static void AddItem(Iitem item)
        {

        }

		public void SetRupees(int rupees)
		{
			this.rupees = rupees;
		}

		public void SetKeys(int keys)
        {
			this.keys = keys;
        }

		public void SetBombs(int bombs)
		{
			this.bombs = bombs;
		}
		public void Update(GameTime gametime)
        {
			
        }

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.DrawString(font, "x" + rupees +"\n\nx" + keys + "\nx" + bombs, new Vector2(400, 600), Color.White);
		}
	}
}
