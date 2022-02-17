using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Sprint2
{
	public class KeyboardC : IController
	{
		private Dictionary<Keys, ICommand> keyboardD = new Dictionary<Keys, ICommand>();

		private KeyboardState oldState;

		public KeyboardC()
		{
		}

		public void CompareStates(Player player, ISprite item, Block block, NPC1 enemy)
		{
			KeyboardState newState = Keyboard.GetState();
			Keys[] current = newState.GetPressedKeys();

			if (Array.IndexOf(current, Keys.W) == -1 &&
				Array.IndexOf(current, Keys.A) == -1 &&
				Array.IndexOf(current, Keys.S) == -1 &&
				Array.IndexOf(current, Keys.D) == -1 &&
				Array.IndexOf(current, Keys.Up) == -1 &&
				Array.IndexOf(current, Keys.Down) == -1 &&
				Array.IndexOf(current, Keys.Left) == -1 &&
				Array.IndexOf(current, Keys.Right) == -1)
			{
				ICommand tempCom = new StandCom();
				tempCom.Execute(player, item, block, enemy);
			}


			foreach (Keys key in current)
			{
				if (keyboardD.ContainsKey(key))
				{
					keyboardD[key].Execute(player, item, block, enemy);
				}
			}

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

			keyboardD.Add(Keys.Space, new ProjectileCom());

			keyboardD.Add(Keys.W, new MoveUpCom());
			keyboardD.Add(Keys.A, new MoveLeftCom());
			keyboardD.Add(Keys.S, new MoveDownCom());
			keyboardD.Add(Keys.D, new MoveRightCom());

			keyboardD.Add(Keys.Up, new MoveUpCom());
			keyboardD.Add(Keys.Left, new MoveLeftCom());
			keyboardD.Add(Keys.Down, new MoveDownCom());
			keyboardD.Add(Keys.Right, new MoveRightCom());

			//keyboardD.Add(Keys.T, new BlockBackwardCom());
			//keyboardD.Add(Keys.Y, new BlockForwardCom());

			oldState = Keyboard.GetState();
		}

	}
}
