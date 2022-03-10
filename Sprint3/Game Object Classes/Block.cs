using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sprint3
{
	public class Block : IBlock
	{
		private Vector2 location;
		private ISprite blockSprite = new Sprite();
		private String blockTexture;
        private int boundWidth;
        private int boundHeight;

        public Block(int boundWidth, int boundHeight)
		{
			this.boundWidth = boundWidth;
			this.boundHeight = boundHeight;
		}
		public void SetLocation(Vector2 newLocation)
		{
			location = newLocation;
		}

		public Rectangle GetRect()
		{
			Rectangle opt = new Rectangle((int)this.location.X, (int)this.location.Y, (int)this.blockSprite.getSize().X, (int)this.blockSprite.getSize().Y);
			return opt;
		}

		public void Reset()
		{
		}

		public Vector2 GetLocation()
		{
			return location;
		}

		public void SetSprite(ISprite spr)
		{
			this.blockSprite = spr;
		}

		public ISprite GetItem()
		{
			return this.blockSprite;
		}
		public void SetBlock(String blockTexture)
		{
			this.blockTexture = blockTexture;
		}

		public void Update(GameTime gameTime)
		{
			SetSprite(SpriteFactory.GetSprite(this.blockTexture));
			blockSprite.Update();
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			blockSprite.Draw(spriteBatch, location);
		}
	}
}
