using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4.Game_Object_Classes
{
    public class ItemSelect
    {
        //calls pause?
        //pulls up its own screen (draw on top..?)
        public ItemSelect(Game1 game)
        {
            IGameControlCom pauseStartCom = new GamePauseStartCom(game);
            //get current items?
        }

        public void OpenMenu()
        {
            //user activates a command with a key press (i for inventory, maybe) to call this method
        }

        public void Draw()
        {
            //black background
            //"item select"
            //pictures of items with square cursor (select with WASD)
        }
    }
}
