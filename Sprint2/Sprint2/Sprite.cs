using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{   //make sprite factory
    public class Sprite : ISprite
    {
        //private Texture2D sourceBitMap;
        //frame = bitmap, x, y, ht, width
        //frame = bitmap, sourceRectangle
        //could make frames into objects

        public Texture2D GetSprite()
        {
            return sourceBitMap;
        }

        //params(sourcebitmap, srcRectangle) or equiv obj
        //or load in frame collection
        public void SetSprite(framecollection)
        {
            sourceBitMap = spr;
        }

        //animation... could make an "animate" function? or should this be its own interface?
        //but there's so many variables...
        private int rows
        { get; set; }
        private int columns
        { get; set; }
        private int currentFrame
        { get; set; }
        private int buffer
        { get; set; }
        private int totalFrames
        { get; set; }

        //default constructor
        public Sprite()
        {
            currentFrame = 0;
        }

        public void Update()
        {
            //animation
            //if statement for if totalframes > 1 ?
            buffer++;
            if (buffer % 5 == 0)
            {
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;
            }
        }

        //update location with each call to draw? using a property here or...?
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = sourceBitMap.Width / columns;
            int height = sourceBitMap.Height / rows;
            int row = currentFrame / columns;
            int column = currentFrame % columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(sourceBitMap, destinationRectangle, sourceRectangle, Color.White);
        }


    }
}
