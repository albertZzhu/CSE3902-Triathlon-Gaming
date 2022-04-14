using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint5
{
    public class ItemSelect
    {
        IGameControlCom gameControlCom;
        Game1 game;
        List<Item> items = new List<Item>();
        //pulls up its own screen (draw on top..?)
        public ItemSelect(Game1 game)
        {
            this.game = game;
            items = Inventory.GetItems();
            //get current items?
        }

        public void OpenMenu(SpriteBatch spriteBatch)
        {
            //calls pause
            gameControlCom = new GamePauseStartCom(game);
            gameControlCom.Execute();
            Draw(spriteBatch);
            gameControlCom.Execute();
            //user activates a command with a key press (i for inventory, maybe) to call this method
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //black background
            //"item select"
            //pictures of items with square cursor (select with WASD)
            //needs to be a changing sprite like inventory
        }
    }
}
