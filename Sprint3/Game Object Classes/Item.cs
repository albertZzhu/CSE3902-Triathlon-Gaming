using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3
{
    public class Item : Iitem
    {
        private ISprite item = new Sprite();
        private String itemTexture;
        private Vector2 location;
        private int boundWidth;//Get the width of the current window so the figure can go back when hit the boundary
        private int boundHeight;//Get the height of the current window so the figure can go back when hit the boundary
        private bool disappear;

        public Item(int boundWidth, int boundHeight)
        {
            this.boundWidth = boundWidth;
            this.boundHeight = boundHeight;
            disappear = false;
        }

        public void SetLocation(Vector2 newLocation)
        {
            location = newLocation;
        }

        public Rectangle GetRect()
        {
            Rectangle opt = new Rectangle((int)this.location.X, (int)this.location.Y, (int)this.item.getSize().X, (int)this.item.getSize().Y);
            return opt;
        }

        public bool isDisappear()
		{
            return disappear;
		}

        public void goDisappear()
		{
            disappear = true;
		}

        public Vector2 GetLocation()
        {
            return location;
        }

        public void SetSprite(ISprite spr)
        {
            item = spr;
        }

        public ISprite GetItem()
        {
            return item;
        }
        public void SetItem(String itemTexture)
        {
            this.itemTexture = itemTexture;
        }
        public void Update(GameTime gameTime)
        {
            if (!disappear)
            {
                //get key presses here?
                SetSprite(SpriteFactory.GetSprite(this.itemTexture));
                item.Update();
            }
        }

        //maybe get location here???
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!disappear)
            {
                item.Draw(spriteBatch, location);
            }
        }

    }
}
