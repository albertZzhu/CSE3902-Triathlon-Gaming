using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4
{
    class MouseC : IController
    {
        private Dictionary<ButtonState, ICommand> mouseD = new Dictionary<ButtonState, ICommand>();

        private MouseState oldState;

        private Game1 game;

        public MouseC(Game1 game)
        {
            this.game = game;
        }

        public void CompareStates(Player player)
        {
            MouseState NewState = Mouse.GetState();
            

            //UPDATE STATE
            oldState = NewState;
        }

        public void InitializeController()
        {
            oldState = Mouse.GetState();
        }
    }
}
