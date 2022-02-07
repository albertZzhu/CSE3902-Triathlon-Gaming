using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project2
{
    class MovingNaniSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int Width;
        public int Height;
        bool movingUp = false;
        public Vector2 position;


        public MovingNaniSprite(Texture2D texture, int rows, int columns, int height, int width)
        {
            Texture = texture;
            Columns = columns;
            Rows = rows;
            Width = width;
            Height = height;

            position = new Vector2(0, Height / 2);
        }

        public void update()
        {

            if (!movingUp)
            {
                position.Y += 1;
                if (position.Y > Height)
                {
                    movingUp = true;
                }
            }
            else
            {
                position.Y -= 1;
                if (position.Y == 0)
                {
                    movingUp = false;
                }
            }
        }

            public void draw(SpriteBatch spriteBatch, Vector2 location)
            {
                int width = Texture.Width / Columns;
                int height = Texture.Height / Rows;


                Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
                Rectangle destinationRectangle = new Rectangle((int)location.X, (int)position.Y, width, height);

                spriteBatch.Begin();
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
        }
    }
