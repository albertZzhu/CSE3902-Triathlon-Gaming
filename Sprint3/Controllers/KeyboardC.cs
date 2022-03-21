﻿using Microsoft.Xna.Framework.Input;
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

		private MouseState oldMouseState;
		private MouseState newMouseState;

		public KeyboardC()
		{
		}

		public void CompareStates(Player player, Level1 level1)
		{
			newState = Keyboard.GetState();
			newMouseState = Mouse.GetState();


			Keys[] current = newState.GetPressedKeys();

			if (Mouse.GetState().LeftButton == ButtonState.Pressed)
			{
				if (!newMouseState.Equals(oldMouseState))
				{
					level1.switchPre();
					level1.loadRoom();
				}
			}
			else if (Mouse.GetState().RightButton == ButtonState.Pressed)
			{
				if (!newMouseState.Equals(oldMouseState))
				{
					level1.switchNext();
					level1.loadRoom();
				}
			}

			if (oldState != newState)
			{
				ICommand tempCom = new StandCom();
				tempCom.Execute(player);
			}

			foreach (Keys key in current)
			{
				if (playerMove.ContainsKey(key))
				{
					playerMove[key].Execute(player);
				}
				if(Array.IndexOf(current, Keys.Space) != 1)
                {
					break;
                }
			}

			if (newState.GetPressedKeys().Length > 0)
			{
				if (keydict.ContainsKey(newState.GetPressedKeys()[0]) && !newState.Equals(oldState))
				{
					keydict[newState.GetPressedKeys()[0]].Execute(player);
				}
			}

			oldMouseState = newMouseState;
			oldState = newState;
		}

		public void InitializeController()
		{
			keydict.Add(Keys.Q, new QuitCom());
			keydict.Add(Keys.Z, new AttackCom());
			keydict.Add(Keys.N, new AttackCom());
			keydict.Add(Keys.E, new DamageCom());
			//keydict.Add(Keys.R, new ResetCom());

			keydict.Add(Keys.D1, new ProjectileCom());
			keydict.Add(Keys.D2, new Projectile2Com());
			keydict.Add(Keys.D3, new Projectile3Com());

			keydict.Add(Keys.Space, new FireProjectileCom());

			playerMove.Add(Keys.W, new MoveUpCom());
			playerMove.Add(Keys.A, new MoveLeftCom());
			playerMove.Add(Keys.S, new MoveDownCom());
			playerMove.Add(Keys.D, new MoveRightCom());

			playerMove.Add(Keys.Up, new MoveUpCom());
			playerMove.Add(Keys.Left, new MoveLeftCom());
			playerMove.Add(Keys.Down, new MoveDownCom());
			playerMove.Add(Keys.Right, new MoveRightCom());

			//keydict.Add(Keys.T, new BlockBackwardCom());
			//keydict.Add(Keys.Y, new BlockForwardCom());

			oldState = Keyboard.GetState();
			oldMouseState = Mouse.GetState();
		}

	}
}
