using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Sprint3
{
	class KeyboardC : IController
	{
		private Dictionary<Keys, ICommand> keydict = new Dictionary<Keys, ICommand>();

		private Dictionary<Keys, ICommand> playerMove = new Dictionary<Keys, ICommand>();

		private KeyboardState oldState;
		private KeyboardState newState;
        private Level1 level;
        private Player player;


		public KeyboardC(Level1 level, Player player)
		{
            this.level = level;
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
                if (keydict.ContainsKey(newState.GetPressedKeys()[0]) && !newState.Equals(oldState))
                {
                    keydict[newState.GetPressedKeys()[0]].ChangePlayer(player);
                    keydict[newState.GetPressedKeys()[0]].Execute();
                }
            }
            oldState = newState;
        }
        public void InitializeController()
		{
			keydict.Add(Keys.Q, new QuitCom());
			keydict.Add(Keys.Z, new AttackCom(player));
			keydict.Add(Keys.N, new AttackCom(player));
			keydict.Add(Keys.E, new DamageCom(player));
			//keydict.Add(Keys.R, new ResetCom());

			keydict.Add(Keys.D1, new ProjectileCom(player));
			keydict.Add(Keys.D2, new Projectile2Com(player));
			keydict.Add(Keys.D3, new Projectile3Com(player));
            keydict.Add(Keys.D9, new SwitchRoomBackwardCom(level));
            keydict.Add(Keys.D0, new SwitchRoomForwardCom(level));


            keydict.Add(Keys.Space, new FireProjectileCom(player));

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
