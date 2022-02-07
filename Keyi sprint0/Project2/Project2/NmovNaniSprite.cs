using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project2
{
    class NmovNaniSprite : ISprite 
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Height;
        public int Width;

        public NmovNaniSprite(Texture2D texture, int rows, int columns,int height,int width)
        {
            Texture = texture;
            Columns = columns;
            Rows = rows;
            Width = width;
            Height = height;

        }

        public void update()
        {
            //no update needed because this is a fixed sprite
        }

        public void draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width/Columns;
            int height = Texture.Height/Rows;


            Rectangle sourceRectangle = new Rectangle(0 , 0, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();

        }
    }
}
