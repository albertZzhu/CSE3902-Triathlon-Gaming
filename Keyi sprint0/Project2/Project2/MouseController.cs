using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace Project2
{
    class MouseController : IController
    {
        private Dictionary<int, ICommand> controllerMappings;
        private Game1 sprint0;
        private int QuadNum;


        public MouseController(Game1 game)
        {
            sprint0 = game;
            controllerMappings = new Dictionary<int, ICommand>();
            
            RegisterCommand();
        }

        public void RegisterCommand()
        {
            controllerMappings.Add(0, new QuitCommand(sprint0));
            controllerMappings.Add(1, new NmovNaniSpriteCommand(sprint0));
            controllerMappings.Add(2, new AnimatedSpriteCommand(sprint0));
            controllerMappings.Add(3, new MovingNaniSpriteCommand(sprint0));
            controllerMappings.Add(4, new MovingAniSpriteCommand(sprint0));

        }

        public void update()
        {
            QuadNum = 5;

            if (Mouse.GetState().RightButton == ButtonState.Pressed)
            {
                QuadNum = 0;
            }
            else if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (Mouse.GetState().X < sprint0.width / 2 && Mouse.GetState().Y < sprint0.height / 2)
                {
                    QuadNum = 1;
                }
                else if (Mouse.GetState().X > sprint0.width / 2 && Mouse.GetState().Y < sprint0.height / 2)
                {
                    QuadNum = 2;
                }
                else if (Mouse.GetState().X < sprint0.width / 2 && Mouse.GetState().Y > sprint0.height / 2)
                {
                    QuadNum = 3;
                }
                else if (Mouse.GetState().X > sprint0.width / 2 && Mouse.GetState().Y > sprint0.height / 2)
                {
                    QuadNum = 4;
                }
            }
            if (controllerMappings.ContainsKey(QuadNum))
            {
                controllerMappings[QuadNum].Execute();
            }
        }
                
        }
    }

    
