using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
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
        {
            items.Add("movingLeft");
            items.Add("movingRight");
            items.Add("movingUp");
            items.Add("movingDown");
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
