using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint5
{   //make sprite factory
	public class Sprite : ISprite
	{
		//private Texture2D sourceBitMap;
		//frame = bitmap, x, y, ht, width
		//frame = bitmap, sourceRectangle
		//could make frames into objects
		private int width;
		private int height;

		private List<Frame> frames = new List<Frame>();

		//default constructor
		public Sprite()
		{
			currentFrame = 0;
		}

		public List<Frame> GetFrames()
		{
			return frames;
		}

		public void SetFrames(Texture2D bitMap, int columns, int rows, int totalFrames)
		{
			width = bitMap.Width / columns;
			height = bitMap.Height / rows;
			for (int i = 0; i < totalFrames; i++)
			{
				int row = i / columns;
				int column = i % columns;
				Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
				frames.Add(new Frame(bitMap, sourceRectangle));
			}


		}

		public Vector2 getSize()
		{
			Vector2 opt = new Vector2(width, height);
			return opt;
		}

		//animation... could make an "animate" function? or should this be its own interface?
		//but there's so many variables...
		private int currentFrame
		{ get; set; }
		private int buffer
		{ get; set; }

		public void Update()
		{
			//animation
			//if statement for if totalframes > 1 ?
			buffer++;
			if (buffer % 20 == 0)
			{
				currentFrame++;
				if (currentFrame == frames.Count)
					currentFrame = 0;
			}
		}

		//update location with each call to draw? using a property here or...?
		public void Draw(SpriteBatch spriteBatch, Vector2 location)
		{

			if (frames.Count > 0)
				spriteBatch.Draw(frames[currentFrame].GetBitMap(), location, frames[currentFrame].GetSourceRect(), Color.White);
			//it would be nice to implement the damage sprite by changing color.white to color.red... much simpler. 
			//its just tough to implement since this draw function is buried
		}


	}
}