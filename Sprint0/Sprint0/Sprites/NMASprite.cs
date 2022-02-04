using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    public class NMASprite : ISprite 
    {
        Texture2D sprite;
        private bool visible;
        private int rows;
        private int columns;
        private int currentFrame;
        private int iter = 0;
        private int buffer;
        private int totalFrames;

        public NMASprite(Texture2D texture, int newRows, int newCol, int buff)
        {
            sprite = texture;
            rows = newRows;
            columns = newCol;
            currentFrame = 0;
            totalFrames = rows * columns;
            buffer = buff;
        }
        public NMASprite(Texture2D texture, int newRows, int newCol, int buff, int totFrames)
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
                iter++;
                if (iter % buffer == 0)
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

                Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
                Rectangle destRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

                spriteBatch.Draw(sprite, destRectangle, sourceRectangle, Color.White);
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
