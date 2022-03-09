using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sprint3
{
	public class Block
	{
		private Vector2 location;
		private ISprite blockSprite;
		private string[] blockTypeList;
		private int listPos = 0;
		private int listlen;

		public Block(Vector2 location, string[] blockTypeList, int len)
		{
			this.location = location;
			this.blockTypeList = blockTypeList;
			this.listlen = len;
		}
		public void Reset()
        {
			listPos = 0;
        }
		public void SwitchingForward()
		{
			listPos = listPos < listlen-1 ? listPos+1 : 0;
		}

		public void SwitchingBackward()
		{
			listPos = listPos > 0 ? listPos - 1 : listlen - 1;
		}

		public Rectangle GetRect()
		{
			Rectangle opt = new Rectangle((int)this.location.X, (int)this.location.Y, (int)this.blockSprite.getSize().X, (int)this.blockSprite.getSize().Y);
			return opt;
		}

		public void Update(GameTime gameTime)
		{
			this.blockSprite = SpriteFactory.GetSprite(blockTypeList[listPos]);
			blockSprite.Update();
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			this.blockSprite = SpriteFactory.GetSprite(blockTypeList[listPos]);
			blockSprite.Draw(spriteBatch, location);
		}
	}
}
