﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint4.State_Machines;

namespace Sprint4
{
	public class PlayerStateMachine
	{
		//should replace with facing enum 
		//private int facing = 0;     //facing variable, 0 means right, 1 means left, 2 means upward, 3 means downward
		Facing facing;
		private bool attack = false;
		private bool damaged = false;
		private double elapse = 0.0;
		private bool isMoving = false;
		private int health = 6;



		private Player play;


		public PlayerStateMachine(Player player)
		{
			play = player;

		}

		public int FacingState()
		{
			return (int)facing;
		}


		public void changeMovingState(bool moving)
		{
			isMoving = moving;
		}

		public void Attack()
		{
			attack = true;
		}

		public bool IsAttacking()
		{
			return attack;
		}

		public void Damaged()
		{
			if (!(health == 0||damaged))
			{
				damaged = true;
				health--;
				Inventory.SubtractHealth();
			}
		}

		public int playerHealth()
		{
			return health;
		}

		public void addHealth()
		{
			health++;
		}

		public bool IfDie()
		{
			return health == 0;
		}

		public void ChangeFacing(Facing facing)
		{
			this.facing = facing;
		}

		public void Update(GameTime gameTime)
		{
			switch (facing)
			{
				case Facing.RIGHT:
					if (attack && damaged)
					{
						play.SetSprite(SpriteFactory.GetSprite("right_throw"));
						elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
					}
					else if (damaged)
					{
						if (isMoving)   //Damange and moving state, fill in the damange sprite to finish
						{
							play.SetSprite(SpriteFactory.GetSprite("damage_right_move"));
							elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
						}
						else            //Damange stand state, fill in the sprite to finish
						{
							play.SetSprite(SpriteFactory.GetSprite("damage_right"));
							elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
						}
					}
					else if (attack)
					{
						play.SetSprite(SpriteFactory.GetSprite("right_throw"));
						elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
					}
					else if (isMoving)
					{
						play.SetSprite(SpriteFactory.GetSprite("right_move"));
					}
					else
					{
						play.SetSprite(SpriteFactory.GetSprite("right_still"));
					}
					break;
				case Facing.LEFT:
					if (attack && damaged)
					{
						play.SetSprite(SpriteFactory.GetSprite("left_throw"));
						elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
					}
					else if (damaged)
					{
						if (isMoving)   //TODO: Damange and moving state, fill in the damange sprite to finish
						{
							play.SetSprite(SpriteFactory.GetSprite("damage_left_move"));
							elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
						}
						else            //TODO: Damange stand state, fill in the sprite to finish
						{
							play.SetSprite(SpriteFactory.GetSprite("damage_left"));
							elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
						}
					}
					else if (attack)
					{
						play.SetSprite(SpriteFactory.GetSprite("left_throw"));
						elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
					}
					else if (isMoving)
					{
						play.SetSprite(SpriteFactory.GetSprite("left_move"));
					}
					else
					{
						play.SetSprite(SpriteFactory.GetSprite("left_still"));
					}
					break;
				case Facing.UP:
					if (attack && damaged)
					{
						play.SetSprite(SpriteFactory.GetSprite("front_throw"));
						elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
					}
					else if (damaged)
					{
						if (isMoving)   //Damange and moving state, fill in the damange sprite to finish
						{
							play.SetSprite(SpriteFactory.GetSprite("damage_back_move"));
							elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
						}
						else            //Damange stand state, fill in the sprite to finish
						{
							play.SetSprite(SpriteFactory.GetSprite("damage_back"));
							elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
						}
					}
					else if (attack)
					{
						play.SetSprite(SpriteFactory.GetSprite("back_throw"));
						elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
					}
					else if (isMoving)
					{
						play.SetSprite(SpriteFactory.GetSprite("back_move"));
					}
					else
					{
						play.SetSprite(SpriteFactory.GetSprite("back_still"));
					}
					break;
				case Facing.DOWN:
					if (attack && damaged)
					{
						play.SetSprite(SpriteFactory.GetSprite("back_throw"));
						elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
					}
					else if (damaged)
					{
						if (isMoving)   //Damange and moving state, fill in the damange sprite to finish
						{
							play.SetSprite(SpriteFactory.GetSprite("damage_front_move"));
							elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
						}
						else            //Damange stand state, fill in the sprite to finish
						{
							play.SetSprite(SpriteFactory.GetSprite("damage_front"));
							elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
						}
					}
					else if (attack)
					{
						play.SetSprite(SpriteFactory.GetSprite("front_throw"));
						elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
					}
					else if (isMoving)
					{
						play.SetSprite(SpriteFactory.GetSprite("front_move"));
					}
					else
					{
						play.SetSprite(SpriteFactory.GetSprite("front_still"));
					}
					break;
				default:
					break;
			}
			if (elapse > 0.5f)
			{
				damaged = false;
				attack = false;
				elapse = 0.0;
			}
		}
	}
}
