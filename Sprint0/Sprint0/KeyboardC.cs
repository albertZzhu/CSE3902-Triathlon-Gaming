using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0
{
    public class KeyboardC : IController
    {
        private Dictionary<Keys, ICommand> keyboardD = new Dictionary<Keys, ICommand>();
        
        private KeyboardState oldState;

        public KeyboardC()
        {
        }

        public void CompareStates(NMNASprite _nmna, MNASprite _mna, NMASprite _nma, MASprite _ma)
        {
            KeyboardState newState = Keyboard.GetState();

            //PRESS
            if (newState.GetPressedKeys().Length > 0) { 
                if (keyboardD.ContainsKey(newState.GetPressedKeys()[0]) && !newState.Equals(oldState))
                {
                    keyboardD[newState.GetPressedKeys()[0]].Execute(_nmna, _mna, _nma, _ma);
                }
        } 

            //UPDATE STATE
            oldState = newState;
        }

    public void InitializeController()
        {
            keyboardD.Add(Keys.Q, new QuitCom());
            keyboardD.Add(Keys.D1, new NMNACom());
            keyboardD.Add(Keys.D2, new NMACom());
            keyboardD.Add(Keys.D3, new MNACom());
            keyboardD.Add(Keys.D4, new MACom());
            keyboardD.Add(Keys.U, new PrevItemCom());
            keyboardD.Add(Keys.I, new NextItemCom());
            keyboardD.Add(Keys.Z, new NextItemCom());
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
