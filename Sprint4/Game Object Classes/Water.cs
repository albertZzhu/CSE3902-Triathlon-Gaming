using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4
{
    public class Water : IBlock
    {
		private Vector2 location;
		private ISprite waterSprite = new Sprite();
		private String waterTexture;

		public void SetLocation(Vector2 newLocation)
		{
			location = newLocation;
		}

		public Rectangle GetRect()
		{
			Rectangle opt = new Rectangle((int)location.X, (int)location.Y, (int)waterSprite.getSize().X, (int)waterSprite.getSize().Y);
			return opt;
		}

		public Vector2 GetLocation()
		{
			return location;
		}

		public ISprite GetItem()
		{
			return waterSprite;
		}
		public void SetWater(String waterTexture)
		{
			waterSprite = SpriteFactory.GetSprite(waterTexture);
		}

		public void Update(GameTime gameTime)
		{
			waterSprite.Update();
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			waterSprite.Draw(spriteBatch, location);
		}
	}
}
