using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3
{
    public class Item
    {
        private ISprite item = new Sprite();
        private Vector2 location = new Vector2(300, 100);
        private int boundWidth;//Get the width of the current window so the figure can go back when hit the boundary
        private int boundHeight;//Get the height of the current window so the figure can go back when hit the boundary
        
        private int index = 0;
        private List<string> items = new List<string>();

        public Item(int boundWidth, int boundHeight)
        {
            this.boundWidth = boundWidth;
            this.boundHeight = boundHeight;
            InitializeItems();
            items = GetItemList();
        }

        public void SetLocation(Vector2 newLocation)
        {
            location = newLocation;
        }

        public Vector2 GetLocation()
        {
            return location;
        }

        public void SetSprite(ISprite spr)
        {
            item = spr;
        }

        public ISprite GetSprite()
        {
            return item;
        }

        public void SetIndex(int i)
        {
            index = i;
        }

        public int GetIndex()
        {
            return index;
        }
        public List<string> GetItemList()
        {
            return items;
        }
        public void InitializeItems()
        {   //change these to items
            items.Add("magicPortion");
            items.Add("heart");
            items.Add("sword");
          
        }

        public void SwitchingForward()
        {
            index = (index < items.Count - 1 ? index + 1 : 0);
        }

        public void SwitchingBackward()
        {
            index = index > 0 ? index - 1 : items.Count - 1;
        }
        public void Reset()
        {
            SetIndex(0);
        }
        public void Update(GameTime gameTime)
        {
            //get key presses here?
            SetSprite(SpriteFactory.GetSprite(items[index]));
            item.Update();
        }

        //maybe get location here???
        public void Draw(SpriteBatch spriteBatch)
        {
                item.Draw(spriteBatch, location);
            
        }

    }
}
