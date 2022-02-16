using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Sprint2
{
	public class SpriteFactory
	{
		//its a singleton!
		private static SpriteFactory uniqueFactory;

		private static Dictionary<String, Sprite> spriteDict;

		private SpriteFactory()
		{

		}

		public static SpriteFactory GetFactory()
		{
			if (uniqueFactory == null)
			{
				uniqueFactory = new SpriteFactory();
				spriteDict = new Dictionary<string, Sprite>();
			}
			return uniqueFactory;
		}

		//takes in info about whats to be made in create sprite method?
		//encapsulate sprite data? bitmap, col, rows, tFrames?
		public static ISprite CreateSprite(Texture2D bitMap, int columns, int rows, int totalFrames, String spriteName)
		{
			Sprite sprite = new Sprite();
			sprite.SetFrames(bitMap, columns, rows, totalFrames);
			spriteDict.Add(spriteName, sprite);
			return sprite;
		}

		public static ISprite GetSprite(String spriteName)
		{
			return spriteDict[spriteName];
		}

	}
}
