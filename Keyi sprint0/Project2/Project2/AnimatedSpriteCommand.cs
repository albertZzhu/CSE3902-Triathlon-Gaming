using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace Project2
{
    class AnimatedSpriteCommand : ICommand
    {
        private Game1 sprint0;
        
        public AnimatedSpriteCommand(Game1 game)
        {
            sprint0 = game;
        }

        public void Execute()
        {
            sprint0.setSprite(new AnimatedSprite(sprint0.texture, sprint0.row, sprint0.columns, sprint0.height,sprint0.width));
        }
    }
}
