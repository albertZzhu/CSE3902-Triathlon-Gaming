using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Sprint2
{
	public class Block
	{
		private Vector2[] locations;
		private ISprite blockSprite;
		private string[] blockTypeList;
		private int listPos = 0;
		private int listlen;

		public Block(Vector2[] locations, string[] blockTypeList, int len)
		{
			this.locations = locations;
			this.blockTypeList = blockTypeList;
			this.listlen = len;
		}

		public void SwitchingForward()
		{
			listPos = (listPos < listlen-1 ? listPos+1 : 0);
		}

		public void SwitchingBackward()
		{
			listPos = listPos > 0 ? listPos - 1 : listlen - 1;
		}

		public void Update(GameTime gameTime)
		{
			this.blockSprite = SpriteFactory.GetSprite(blockTypeList[listPos]);
			blockSprite.Update();
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			this.blockSprite = SpriteFactory.GetSprite(blockTypeList[listPos]);
			foreach (Vector2 location in locations)
			{
				blockSprite.Draw(spriteBatch, location);
			}
		}
	}
}
