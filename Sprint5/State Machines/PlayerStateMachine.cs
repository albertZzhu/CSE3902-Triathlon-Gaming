using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint5.State_Machines;

namespace Sprint5
{
	public class PlayerStateMachine
	{
		//should replace with FacingEnum enum 
		//private int FacingEnum = 0;     //FacingEnum variable, 0 means right, 1 means left, 2 means upward, 3 means downward
		FacingEnum facing;
		private bool attack = false;
		private bool damaged = false;
		private double elapse = 0.0;
		private double attackElapse = 0.0;
		private bool isMoving = false;
		private int health;



		private Player play;


		public PlayerStateMachine(Player player, int spawnHealth)
		{
			play = player;
			health = spawnHealth;
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
			if (!(health == 0 || damaged))
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

		public void ChangeFacing(FacingEnum facing)
		{
			this.facing = facing;
		}

		public void Update(GameTime gameTime)
		{
			switch (facing)
			{
				case FacingEnum.RIGHT:
					if (attack && damaged)
					{
						play.SetSprite(SpriteFactory.GetSprite("right_throw"));
						elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
						attackElapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
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
						attackElapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
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
				case FacingEnum.LEFT:
					if (attack && damaged)
					{
						play.SetSprite(SpriteFactory.GetSprite("left_throw"));
						elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
						attackElapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
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
						attackElapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
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
				case FacingEnum.UP:
					if (attack && damaged)
					{
						play.SetSprite(SpriteFactory.GetSprite("front_throw"));
						elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
						attackElapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
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
						attackElapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
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
				case FacingEnum.DOWN:
					if (attack && damaged)
					{
						play.SetSprite(SpriteFactory.GetSprite("back_throw"));
						elapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
						attackElapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
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
						attackElapse += (float)gameTime.ElapsedGameTime.TotalSeconds;
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
			if (elapse > 3f)
			{
				damaged = false;
				elapse = 0.0;
			}
			if (attackElapse > 0.5f)
			{
				attack = false;
				attackElapse = 0.0;
			}
		}
	}
}
