using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4
{
    public class Item : Iitem
    {
        private ISprite item = new Sprite();
        private String itemTexture;
        private Vector2 location;
        private bool disappear;

        public Item()
        {
            disappear = false;
        }

        public void SetLocation(Vector2 newLocation)
        {
            location = newLocation;
        }

        public Rectangle GetRect()
        {
            Rectangle opt = new Rectangle((int)location.X, (int)location.Y, (int)item.getSize().X, (int)item.getSize().Y);
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
                SetSprite(SpriteFactory.GetSprite(itemTexture));
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