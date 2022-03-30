using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint4
{
	public interface IGameObject
	{

		void Update(GameTime gameTime);

		public void Draw(SpriteBatch spriteBatch);
	}
}
