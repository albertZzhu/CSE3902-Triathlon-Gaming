using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint3
{
	public interface ISprite
	{

		public void Update();

		public void Draw(SpriteBatch spriteBatch, Vector2 location);

		public Vector2 getSize();
	}
}
