using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class KeyboardC : IController
    {
        private Dictionary<Keys, ICommand> keyboardD = new Dictionary<Keys, ICommand>();
        
        private KeyboardState oldState;

        public KeyboardC()
        {
        }

        public void CompareStates(Player player, ISprite item, ISprite block, ISprite enemy)
        {
            KeyboardState newState = Keyboard.GetState();

            //PRESS
            if (newState.GetPressedKeys().Length > 0) { 
                if (keyboardD.ContainsKey(newState.GetPressedKeys()[0]) && !newState.Equals(oldState))
                {
                    keyboardD[newState.GetPressedKeys()[0]].Execute(player, item, block, enemy);
                }
        } 

            //UPDATE STATE
            oldState = newState;
        }

    public void InitializeController()
        {
            keyboardD.Add(Keys.Q, new QuitCom());
            keyboardD.Add(Keys.U, new PrevItemCom());
            keyboardD.Add(Keys.I, new NextItemCom());
            keyboardD.Add(Keys.Z, new AttackCom());
            keyboardD.Add(Keys.N, new AttackCom());
            keyboardD.Add(Keys.E, new DamageCom());
            keyboardD.Add(Keys.R, new ResetCom());
            keyboardD.Add(Keys.T, new PrevBlockCom());
            keyboardD.Add(Keys.Y, new NextBlockCom());
            keyboardD.Add(Keys.O, new PrevNPCCom());
            keyboardD.Add(Keys.P, new NextNPCCom());
            oldState = Keyboard.GetState();
        }

    }
}
