using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Project2
{
    class KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> controllerMappings;
        private Game1 sprint0;

        public KeyboardController(Game1 game)
        {
            sprint0 = game;
            controllerMappings = new Dictionary<Keys, ICommand>();
            RegisterCommand();
        }
        public void RegisterCommand()
        {
            controllerMappings.Add(Keys.D0, new QuitCommand(sprint0));
            controllerMappings.Add(Keys.D1, new NmovNaniSpriteCommand(sprint0));
            controllerMappings.Add(Keys.D2, new AnimatedSpriteCommand(sprint0));
            controllerMappings.Add(Keys.D3, new MovingNaniSpriteCommand(sprint0));
            controllerMappings.Add(Keys.D4, new MovingAniSpriteCommand(sprint0));
        }

        public void update()
        {
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            foreach (Keys key in pressedKeys)
            {
                if (controllerMappings.ContainsKey(key))
                {
                    controllerMappings[key].Execute();
                }
            }
        }

    }
}

