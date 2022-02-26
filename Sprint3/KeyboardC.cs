using Microsoft.Xna.Framework.Input;
using Sprint3.Commands;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Sprint3
{
	public class KeyboardC : IController
	{
		private Dictionary<Keys, ConstructorInfo> dict = new Dictionary<Keys, ConstructorInfo>();

		private KeyboardState oldState;

		public KeyboardC()
		{
		}

		public void CompareStates(Player player, Item item, Block block, NPC1 enemy)
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
				ICommand tempCom = new StandCom(player);
				tempCom.Execute();
			}
			IGameObject[] objects = new IGameObject[4];
			objects[0] = player;
			objects[1] = item;
			objects[2] = block;
			objects[3] = enemy;
			if (newState.GetPressedKeys().Length > 0)
			{
				if (dict.ContainsKey(newState.GetPressedKeys()[0]) && !newState.Equals(oldState))
				{
					dict[newState.GetPressedKeys()[0]].Invoke(objects);
				}
			}

			oldState = newState;
		}

		public void InitializeController()
		{
			CommandManager manager = new CommandManager();
			//Can i put the keybinds somewhere that makes this method more simple...?
			//perhaps a keybind class that the user can interact with
			dict.Add(Keys.Q, manager.GetConstructor("QuitCom"));
			dict.Add(Keys.U, manager.GetConstructor("PrevItemCom"));
			dict.Add(Keys.I, manager.GetConstructor("NextItemCom"));
			dict.Add(Keys.Z, manager.GetConstructor("AttackCom"));
			dict.Add(Keys.N, manager.GetConstructor("AttackCom"));
			dict.Add(Keys.E, manager.GetConstructor("DamageCom"));
			dict.Add(Keys.R, manager.GetConstructor("ResetCom"));
			dict.Add(Keys.T, manager.GetConstructor("PrevBlockCom"));
			dict.Add(Keys.Y, manager.GetConstructor("NextBlockCom"));
			dict.Add(Keys.O, manager.GetConstructor("PrevNPCCom"));
			dict.Add(Keys.P, manager.GetConstructor("NextNPCCom"));

			dict.Add(Keys.D1, manager.GetConstructor("ProjectileCom"));
			dict.Add(Keys.D2, manager.GetConstructor("Projectile2Com"));
			dict.Add(Keys.D3, manager.GetConstructor("Projectile3Com"));
			dict.Add(Keys.Space, manager.GetConstructor("FireProjectileCom"));

			dict.Add(Keys.W, manager.GetConstructor("MoveUpCom"));
			dict.Add(Keys.A, manager.GetConstructor("MoveLeftCom"));
			dict.Add(Keys.S, manager.GetConstructor("MoveDownCom"));
			dict.Add(Keys.D, manager.GetConstructor("MoveRightCom"));

			dict.Add(Keys.Up, manager.GetConstructor("MoveUpCom"));
			dict.Add(Keys.Left, manager.GetConstructor("MoveLeftCom"));
			dict.Add(Keys.Down, manager.GetConstructor("MoveDownCom"));
			dict.Add(Keys.Right, manager.GetConstructor("MoveRightCom"));

			oldState = Keyboard.GetState();
		}

	}
}
