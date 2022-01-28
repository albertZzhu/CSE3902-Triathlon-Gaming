using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    class MouseC : IController
    {
        private Dictionary<Rectangle, ICommand> mouseD = new Dictionary<Rectangle, ICommand>();

        private QuitCom quitCom = new QuitCom();
        //Non-moving, non-animated sprite command
        private NMNACom NMNACom = new NMNACom();
        //Moving, non-animated sprite command
        private MNACom MNACom = new MNACom();
        //Non-moving, animated sprite command
        private NMACom NMACom = new NMACom();
        //Moving, animated sprite command
        private MACom MACom = new MACom();

        private MouseState oldState;

        private Rectangle quad1;
        private Rectangle quad2;
        private Rectangle quad3;
        private Rectangle quad4;

        public MouseC() 
            {
            }

        public void CompareStates(NMNASprite _nmna, MNASprite _mna, NMASprite _nma, MASprite _ma)
        {
            MouseState NewState = Mouse.GetState();

            Vector2 Pos = new Vector2(NewState.X, NewState.Y);
            //quit
            if (NewState.RightButton == ButtonState.Pressed)
            {
                quitCom.Execute(_nmna, _mna, _nma, _ma);

            } else if (NewState.LeftButton == ButtonState.Pressed && !NewState.Equals(oldState))
            {   //quads
                foreach (KeyValuePair<Rectangle, ICommand> quad in mouseD) 
                {
                    if (quad.Key.Contains(Pos))
                    {
                        quad.Value.Execute(_nmna, _mna, _nma, _ma);
                    }
                }
            }

            //UPDATE STATE
            oldState = NewState;
        }

        public void InitializeController(int screenWidth, int screenHeight)
        {
            quad1 = new Rectangle(new Point(0), new Point(screenWidth / 2, screenHeight / 2));
            quad2 = new Rectangle(new Point(screenWidth / 2, 0), new Point(screenWidth / 2, screenHeight / 2));
            quad3 = new Rectangle(new Point(0, screenHeight / 2), new Point(screenWidth / 2, screenHeight / 2));
            quad4 = new Rectangle(new Point(screenWidth / 2, screenHeight / 2), new Point(screenWidth / 2, screenHeight / 2));
            mouseD.Add(quad1, NMNACom);
            mouseD.Add(quad2, NMACom);
            mouseD.Add(quad3, MNACom);
            mouseD.Add(quad4, MACom);
            oldState = Mouse.GetState();
        }

        public void InitializeController()
        {
            oldState = Mouse.GetState();
        }
    }
}
