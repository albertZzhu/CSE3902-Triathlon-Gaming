using System;
using System.Collections.Generic;
using System.Text;

namespace Project2
{
    class MovingNaniSpriteCommand : ICommand 
    {
        private Game1 sprint0;

        public MovingNaniSpriteCommand(Game1 game)
        {
            sprint0 = game;
        }

        public void Execute()
        {
            sprint0.setSprite(new MovingNaniSprite(sprint0.texture,sprint0.row, sprint0.columns,sprint0.height,sprint0.width));
        }
    }
}
