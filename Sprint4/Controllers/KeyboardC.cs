using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Sprint4
{
	class KeyboardC : IController
	{
		private Dictionary<Keys, ICommand> keyDict = new Dictionary<Keys, ICommand>();

		private Dictionary<Keys, ICommand> playerMove = new Dictionary<Keys, ICommand>();

		private KeyboardState oldState;
		private KeyboardState newState;

        private Player player;


		public KeyboardC(Player player)
		{
            this.player = player;
		}

        public void CompareStates(Player player)
        {
            newState = Keyboard.GetState();
            this.player = player;
            Keys[] current = newState.GetPressedKeys();

            if (oldState != newState)
            {
                ICommand tempCom = new StandCom(player);
                tempCom.Execute();
            }

            foreach (Keys key in current)
            {
                if (playerMove.ContainsKey(key))
				{
					if(Array.IndexOf(current, Keys.Space) != 1)
            		{
                    	playerMove[key].ChangePlayer(player);
                    	playerMove[key].Execute();
						break;
                	}
				}
			}

            if (newState.GetPressedKeys().Length > 0)
            {
                if (keyDict.ContainsKey(newState.GetPressedKeys()[0]) && !newState.Equals(oldState))
                {
                    keyDict[newState.GetPressedKeys()[0]].ChangePlayer(player);
                    keyDict[newState.GetPressedKeys()[0]].Execute();
                }
            }
            oldState = newState;
        }
        public void InitializeController()
		{
			keyDict.Add(Keys.Q, new QuitCom());
			keyDict.Add(Keys.Z, new AttackCom(player));
			keyDict.Add(Keys.N, new AttackCom(player));
			//keyDict.Add(Keys.E, new DamageCom(player));
			//keydict.Add(Keys.R, new ResetCom());

			keyDict.Add(Keys.D1, new ProjectileCom(player));
			keyDict.Add(Keys.D2, new Projectile2Com(player));
			keyDict.Add(Keys.D3, new Projectile3Com(player));


            keyDict.Add(Keys.Space, new FireProjectileCom(player));

			playerMove.Add(Keys.W, new MoveUpCom(player));
			playerMove.Add(Keys.A, new MoveLeftCom(player));
			playerMove.Add(Keys.S, new MoveDownCom(player));
			playerMove.Add(Keys.D, new MoveRightCom(player));

			playerMove.Add(Keys.Up, new MoveUpCom(player));
			playerMove.Add(Keys.Left, new MoveLeftCom(player));
			playerMove.Add(Keys.Down, new MoveDownCom(player));
			playerMove.Add(Keys.Right, new MoveRightCom(player));

			//keydict.Add(Keys.T, new BlockBackwardCom());
			//keydict.Add(Keys.Y, new BlockForwardCom());

			oldState = Keyboard.GetState();
		}

	}
}
