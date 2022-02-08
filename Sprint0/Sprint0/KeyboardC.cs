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

        private PrevItemCom prevItemCom = new PrevItemCom();

        private NextItemCom nextItemCom = new NextItemCom();

        private AttackCom attackCom = new AttackCom();

        private DamageCom damageCom = new DamageCom();

        private ResetCom resetCom = new ResetCom();

        private PrevBlockCom prevBlockCom = new PrevBlockCom();

        private NextBlockCom nextBlockCom = new NextBlockCom();

        private PrevNPCCom prevNPCCom = new PrevNPCCom();

        private NextNPCCom nextNPCCom = new NextNPCCom();

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
            keyboardD.Add(Keys.Q, quitCom);
            keyboardD.Add(Keys.D1, NMNACom);
            keyboardD.Add(Keys.D2, NMACom);
            keyboardD.Add(Keys.D3, MNACom);
            keyboardD.Add(Keys.D4, MACom);
            keyboardD.Add(Keys.U, prevItemCom);
            keyboardD.Add(Keys.I, nextItemCom);
            keyboardD.Add(Keys.Z, attackCom);
            keyboardD.Add(Keys.N, attackCom);
            keyboardD.Add(Keys.E, damageCom);
            keyboardD.Add(Keys.R, resetCom);
            keyboardD.Add(Keys.T, prevBlockCom);
            keyboardD.Add(Keys.Y, nextBlockCom);
            keyboardD.Add(Keys.O, prevNPCCom);
            keyboardD.Add(Keys.P, nextNPCCom);
            oldState = Keyboard.GetState();
        }

    }
}
