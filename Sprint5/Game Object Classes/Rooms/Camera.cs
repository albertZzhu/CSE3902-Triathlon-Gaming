using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint5
{
    class Camera
    {
        private int boundWidth;
        private int boundHeight;
        private int c, f, CWidth, FWidth, CHeight, FHeight;
        private String current, future;
        private ContentManager Content;
        private bool right, left, up, down;

        public Camera(int boundWidth, int boundHeight, ContentManager Content)
        {
            this.boundWidth = boundWidth;
            this.boundHeight = boundHeight;
            this.CWidth = 0;
            this.FWidth = this.boundWidth;
            this.CHeight = 0;
            this.FHeight = this.boundHeight;
            this.Content = Content;
            this.right = false;
            this.left = false;
            this.up = false;
            this.down = false;
        }
        public void reset()
        {
            this.CWidth = 0;
            this.FWidth = this.boundWidth;
            this.CHeight = 0;
            this.FHeight = this.boundHeight;
            this.right = false;
            this.left = false;
            this.up = false;
            this.down = false;
        }
        public void Update(GameTime gametime, String currentRoom, String futureRoom, int doordirection)
        {
            this.current = currentRoom;
            this.future = futureRoom;
            this.c = int.Parse(currentRoom.Substring(4));
            this.f = int.Parse(futureRoom.Substring(4));
            if (doordirection == 1)
            {
                
                    right = true;
                    rightUpdate();
                    
                
            }
            else if (doordirection == 3) {
                
                    left = true;
                    leftUpdate();
                    
               
            }
            else if (doordirection == 0)
            {
                up = true;
                UpUpdate();
            }
            else if (doordirection == 2)
            {
                down = true;
                DownUpdate();
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (right) {
                Rectangle sourceRectangleL = new Rectangle(this.CWidth, 0, this.boundWidth - this.CWidth, this.boundHeight);

                Rectangle sourceRectangleR = new Rectangle(0, 0, this.CWidth, this.boundHeight);
                spriteBatch.Draw(Content.Load<Texture2D>(this.current), new Vector2(0, 0), sourceRectangleL, Color.White);
                spriteBatch.Draw(Content.Load<Texture2D>(this.future), new Vector2(this.boundWidth - this.CWidth, 0), sourceRectangleR, Color.White);

               
            }
            else if (left)
            {
                Rectangle sourceRectangleL = new Rectangle(this.FWidth, 0, this.boundWidth, this.boundHeight);

                Rectangle sourceRectangleR = new Rectangle(0, 0, this.FWidth, this.boundHeight);
                spriteBatch.Draw(Content.Load<Texture2D>(this.future), new Vector2(0, 0), sourceRectangleL, Color.White);
                spriteBatch.Draw(Content.Load<Texture2D>(this.current), new Vector2(this.boundWidth - this.FWidth, 0), sourceRectangleR, Color.White);
                
                
            }
            else if (up)
            {
                Rectangle sourceRectangleU = new Rectangle(0, this.FHeight, this.boundWidth, this.boundHeight);

                Rectangle sourceRectangleD = new Rectangle(0, 0, this.boundWidth, this.FHeight);
                spriteBatch.Draw(Content.Load<Texture2D>(this.future), new Vector2(0, 0), sourceRectangleU, Color.White);
                spriteBatch.Draw(Content.Load<Texture2D>(this.current), new Vector2(0, this.boundHeight - this.FHeight), sourceRectangleD, Color.White);
            }
            else if(down)
            {
                Rectangle sourceRectangleU = new Rectangle(0, this.CHeight, this.boundWidth, this.boundHeight - this.CHeight);

                Rectangle sourceRectangleD = new Rectangle(0, 0, this.boundWidth, this.CHeight);
                spriteBatch.Draw(Content.Load<Texture2D>(this.current), new Vector2(0, 0), sourceRectangleU, Color.White);
                spriteBatch.Draw(Content.Load<Texture2D>(this.future), new Vector2(0, this.boundHeight - this.CHeight), sourceRectangleD, Color.White);
            }
        }
        public void rightUpdate()
        {
            CWidth += 10;
        }

        public void leftUpdate()
        {
            FWidth -= 10;
        }
        public void UpUpdate()
        {
            FHeight -= 10;
        }
        public void DownUpdate()
        {
            CHeight += 10;
        }

        public bool done()
        {
            if (this.CWidth > this.boundWidth || this.FWidth < 0 || this.CHeight > this.boundHeight || this.FHeight < 0)
            {
                return true;
            }
            return false;
        }
    }
}
