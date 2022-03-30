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

        private Level1 level;

        public MouseC(Level1 level)
        {
            this.level = level;
        }

        public void CompareStates(Player player)
        {
            MouseState NewState = Mouse.GetState();
            //quit
            if (NewState.RightButton == ButtonState.Pressed && !NewState.Equals(oldState))
            {
                ICommand tempCom = new SwitchRoomForwardCom(level);
                tempCom.Execute();
            }
            else if (NewState.LeftButton == ButtonState.Pressed && !NewState.Equals(oldState))
            {
                ICommand tempCom = new SwitchRoomBackwardCom(level);
                tempCom.Execute();
            }

            //UPDATE STATE
            oldState = NewState;
        }

        public void InitializeController()
        {
            oldState = Mouse.GetState();
        }
    }
}
