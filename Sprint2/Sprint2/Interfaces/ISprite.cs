using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
	public interface ISprite
	{

		public void Update();

		public void Draw(SpriteBatch spriteBatch, Vector2 location);
	}
}
