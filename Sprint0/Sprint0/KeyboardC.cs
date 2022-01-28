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
        
        private QuitCom quitCom = new QuitCom();
        //Non-moving, non-animated sprite command
        private NMNACom NMNACom = new NMNACom();
        //Moving, non-animated sprite command
        private MNACom MNACom = new MNACom();
        //Non-moving, animated sprite command
        private NMACom NMACom = new NMACom();
        //Moving, animated sprite command
        private MACom MACom = new MACom();

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
            keyboardD.Add(Keys.D0, quitCom);
            keyboardD.Add(Keys.D1, NMNACom);
            keyboardD.Add(Keys.D2, NMACom);
            keyboardD.Add(Keys.D3, MNACom);
            keyboardD.Add(Keys.D4, MACom);
            oldState = Keyboard.GetState();
        }

    }
}
