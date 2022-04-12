using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint4
{
	public class Frame
	{
		private Texture2D bitMap1;

		public Texture2D GetBitMap()
		{
			return bitMap1;
		}

		public void SetBitMap(Texture2D value)
		{
			bitMap1 = value;
		}

		private Rectangle sourceRect1;

		public Rectangle GetSourceRect()
		{
			return sourceRect1;
		}

		public void SetSourceRect(Rectangle value)
		{
			sourceRect1 = value;
		}

		public Frame(Texture2D map, Rectangle src)
		{
			SetBitMap(map);
			SetSourceRect(src);
		}

	}
}
