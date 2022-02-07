using System;
using System.Collections.Generic;
using System.Text;

namespace Project2
{
    class MovingAniSpriteCommand : ICommand
    {
        private Game1 sprint0;

        public MovingAniSpriteCommand(Game1 game)
        {
            sprint0 = game;
        }

        public void Execute()
        {
            sprint0.setSprite(new MovingAniSprite(sprint0.texture, sprint0.row, sprint0.columns,sprint0.height,sprint0.width));
        }
    }
}
