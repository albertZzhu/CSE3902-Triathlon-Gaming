using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2
{
	class PlayerStateMechine
	{
		private int facing = 0;		//facing variable, 0 means right, 1 means left, 2 means upward, 3 means downward
		private bool attack = false;
		private bool damaged = false;
		private double elapse = 0.0;
		private Player play;
		

		public PlayerStateMechine(Player player)
		{
			this.play = player;
			
		}

		public int FacingState()
		{
			return facing;
		}

		public void Attack()
		{
			if(attack == false)
			{
				attack = true;
			}
		}

		public void Damaged()
		{
			if (damaged == false)
			{
				damaged = true;
			}
		}

		public void ChangeFacing(int facing)
		{
			this.facing = facing;
		}

		public void Update(GameTime gameTime)
		{
			switch (facing)
			{
				case 0:
					if (attack&&damaged)
					{
						play.SetSprite(SpriteFactory.GetSprite("attackRight"));
						elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
					}else if (damaged)
					{

					}else if (attack)
					{
						play.SetSprite(SpriteFactory.GetSprite("attackRight"));
						elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
					}
					else
					{
						play.SetSprite(SpriteFactory.GetSprite("movingRight"));
					}
					break;
				case 1:
					if (attack && damaged)
					{
						play.SetSprite(SpriteFactory.GetSprite("attackRight"));
						elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
					}
					else if (damaged)
					{

					}
					else if (attack)
					{
						play.SetSprite(SpriteFactory.GetSprite("attackRight"));
						elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
					}
					else
					{
						play.SetSprite(SpriteFactory.GetSprite("movingLeft"));
					}
					break;
				case 2:
					if (attack && damaged)
					{
						play.SetSprite(SpriteFactory.GetSprite("attackUp"));
						elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
					}
					else if (damaged)
					{

					}
					else if (attack)
					{
						play.SetSprite(SpriteFactory.GetSprite("attackUp"));
						elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
					}
					else
					{
						play.SetSprite(SpriteFactory.GetSprite("movingUp"));
					}
					break;
				case 3:
					if (attack && damaged)
					{
						play.SetSprite(SpriteFactory.GetSprite("attackDown"));
						elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
					}
					else if (damaged)
					{

					}
					else if (attack)
					{
						play.SetSprite(SpriteFactory.GetSprite("attackDown"));
						elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
					}
					else
					{
						play.SetSprite(SpriteFactory.GetSprite("movingDown"));
					}
					break;
				default:
					break;
			}
			if (elapse > 0.5f)
			{
				attack = false;
				elapse = 0.0;
			}
		}
	}
}
