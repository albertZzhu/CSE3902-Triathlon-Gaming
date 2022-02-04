using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class MASprite : ISprite 
    {   //i shouldnt have copied this... what do I do instead?
        private Texture2D sprite;
        private bool visible;
        private int rows;
        private int columns;
        private int currentFrame;
        private int buffer;
        private int iter = 0;
        private int totalFrames;
        private int x = 0;
        private Vector2 pos;

        //default constructor
        public MASprite()
        {
            currentFrame = 0;
        }

        public MASprite(int newRows, int newCol, int buff, int totFrames)
        {
            rows = newRows;
            columns = newCol;
            currentFrame = 0;
            totalFrames = totFrames;
            buffer = buff;
        }

        public MASprite(Texture2D texture, int newRows, int newCol, int buff)
        {
            sprite = texture;
            rows = newRows;
            columns = newCol;
            currentFrame = 0;
            totalFrames = rows * columns;
            buffer = buff;
        }

        public MASprite(Texture2D texture, int newRows, int newCol, int buff, int totFrames)
        {
            sprite = texture;
            rows = newRows;
            columns = newCol;
            currentFrame = 0;
            totalFrames = totFrames;
            buffer = buff;
        }

        public void Update()
        {
            if (IsVisible())
            {
                //to bounce back and forth, use screen size?
                //GraphicsDevice.DisplayMode.Width
                //GraphicsDevice.DisplayMode.Height

                if (x < 500)
                {
                    pos.X++;
                    x++;
                }
                else
                    pos.X--;
                if (pos.X == 0)
                    x = 0;

                //not sure if this is where the buffer should go
                //information for this particular sprite is spread across a couple files
                buffer++;
                if (buffer % 5 == 0)
                {
                    currentFrame++;
                    if (currentFrame == totalFrames)
                        currentFrame = 0;
                }
                
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (IsVisible())
            {
                int width = sprite.Width / columns;
                int height = sprite.Height / rows;
                int row = currentFrame / columns;
                int column = currentFrame % columns;

                //DEST RECT NOT USED
                Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
                //Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

                spriteBatch.Draw(sprite, pos, sourceRectangle, Color.White);
            }
        }

        public int GetRows()
        {
            return rows;
        }

        public void SetRows(int newRows)
        {
            rows = newRows;
        }

        public int GetColumns()
        {
            return columns;
        }

        public void SetColumns(int newCol)
        {
            columns = newCol;
        }

        public bool IsVisible()
        {
            return visible;
        }

        public bool SetVisible(bool value)
        {
            visible = value;
            return true;
        }

        public bool SetSprite(Texture2D newSprite)
        {
            sprite = newSprite;
            return true;
        }

        public Texture2D GetSprite()
        {
            return sprite;
        }

        public int getBuffer()
        {
            return buffer;
        }

        public bool setBuffer(int newBuff)
        {
            buffer = newBuff;
            return true;
        }
    }
}
