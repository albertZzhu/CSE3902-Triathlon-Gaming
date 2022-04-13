using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Sprint4
{
	public class SpriteFactory
	{
		//its a singleton!
		private static SpriteFactory uniqueFactory;

		private static Dictionary<string, Sprite> spriteDict;

		private SpriteFactory(Microsoft.Xna.Framework.Content.ContentManager Content)
		{
			string[] lines = System.IO.File.ReadAllLines("Content\\spriteList.txt");
			foreach (String line in lines)
            {
				if (!line.Equals(""))
				{
					int firstCommaIndex = line.IndexOf(',');
					String colString = line.Substring(0, firstCommaIndex);
					int columns = Int32.Parse(colString);

					String AfterFirstComma = line.Substring(firstCommaIndex + 1); //we want to start after the comma
					int secondCommaIndex = firstCommaIndex + AfterFirstComma.IndexOf(',') + 1; // to account for the 0th index in this "new" string
					//it's confusing but the second parameter is length, not the second index
					//(after first comma, length of number) have to - 1 to get rid of second comma
					String rowsString = line.Substring(firstCommaIndex + 1, secondCommaIndex - firstCommaIndex - 1); 
					int rows = Int32.Parse(rowsString);

					int thirdCommaIndex = secondCommaIndex + line.Substring(secondCommaIndex + 1).IndexOf(',') + 1;
					String totFra = line.Substring(secondCommaIndex + 1, thirdCommaIndex - secondCommaIndex - 1);
					int totalFrames = Int32.Parse(totFra);

					String spriteName = line.Substring(thirdCommaIndex + 1);

					Texture2D bitMap = Content.Load<Texture2D>(spriteName);
					CreateSprite(bitMap, columns, rows, totalFrames, spriteName);
				}
			}
		}

		public static SpriteFactory GetFactory(Microsoft.Xna.Framework.Content.ContentManager Content)
		{
			if (uniqueFactory == null)
			{
				spriteDict = new Dictionary<string, Sprite>();
				uniqueFactory = new SpriteFactory(Content);
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
