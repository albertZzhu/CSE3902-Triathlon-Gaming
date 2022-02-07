using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project2
{
    class MovingAniSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        public int Height;
        public int Width;
        bool movingLeft = false;

        public Vector2 position;
        public MovingAniSprite(Texture2D texture, int rows, int columns, int height, int width)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            Width = width;
            Height = height;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            position = new Vector2(width/2, 0);
        }

        public void update()
        {
            

            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;
            if (!movingLeft) {
                position.X += 1;
                if(position.X > Width)
                {
                    movingLeft = true;
                }
            }
            else
            {
                position.X -= 1;
                if(position.X == 0)
                {
                    movingLeft = false;
                }
            }
            
        }

        public void draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;


            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)location.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
