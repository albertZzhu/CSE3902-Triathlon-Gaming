using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Sprint3
{
	public class KeyboardC : IController
	{
		private Dictionary<Keys, ConstructorInfo[]> keyboardD = new Dictionary<Keys, ConstructorInfo[]>();

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
				if (keyboardD.ContainsKey(newState.GetPressedKeys()[0]) && !newState.Equals(oldState))
				{
					keyboardD[newState.GetPressedKeys()[0]][0].Invoke(objects);
				}
			}

			oldState = newState;
		}

		public void InitializeController()
		{
			Type q = typeof(QuitCom);
			keyboardD.Add(Keys.Q, q.GetConstructors());
			Type pI = typeof(PrevItemCom);
			keyboardD.Add(Keys.U, pI.GetConstructors());
			Type nI = typeof(NextItemCom);
			keyboardD.Add(Keys.I, nI.GetConstructors());
			Type a = typeof(AttackCom);
			keyboardD.Add(Keys.Z, a.GetConstructors());
			keyboardD.Add(Keys.N, a.GetConstructors());
			Type d = typeof(DamageCom);
			keyboardD.Add(Keys.E, d.GetConstructors());
			Type r = typeof(ResetCom);
			keyboardD.Add(Keys.R, r.GetConstructors());
			Type pB = typeof(PrevBlockCom);
			keyboardD.Add(Keys.T, pB.GetConstructors());
			Type nB = typeof(NextBlockCom);
			keyboardD.Add(Keys.Y, nB.GetConstructors());
			Type pN = typeof(PrevNPCCom);
			keyboardD.Add(Keys.O, nB.GetConstructors());
			Type nN = typeof(NextNPCCom);
			keyboardD.Add(Keys.P, nN.GetConstructors());

			Type p1 = typeof(ProjectileCom);
			keyboardD.Add(Keys.D1, p1.GetConstructors());
			Type p2 = typeof(Projectile2Com);
			keyboardD.Add(Keys.D2, p2.GetConstructors());
			Type p3 = typeof(Projectile3Com);
			keyboardD.Add(Keys.D3, p3.GetConstructors());

			Type fP = typeof(FireProjectileCom);
			keyboardD.Add(Keys.Space, fP.GetConstructors());

			Type mU = typeof(MoveUpCom);
			keyboardD.Add(Keys.W, mU.GetConstructors());
			Type mL = typeof(MoveLeftCom);
			keyboardD.Add(Keys.A, mL.GetConstructors());
			Type mD = typeof(MoveDownCom);
			keyboardD.Add(Keys.S, mD.GetConstructors());
			Type mR = typeof(MoveRightCom);
			keyboardD.Add(Keys.D, mR.GetConstructors());

			keyboardD.Add(Keys.Up, mU.GetConstructors());
			keyboardD.Add(Keys.Left, mL.GetConstructors());
			keyboardD.Add(Keys.Down, mD.GetConstructors());
			keyboardD.Add(Keys.Right, mR.GetConstructors());

			oldState = Keyboard.GetState();
		}

	}
}
