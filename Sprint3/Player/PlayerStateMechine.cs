using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Sprint3.Player;

namespace Sprint3
{
	class PlayerStateMechine
	{
		private static Sprint3.Player.Facing currentFacing = Sprint3.Player.Facing.RIGHT;

		//should these be their own classes?
		private bool attack = false;
		private bool damaged = false;
		private double elapse = 0.0;
		private bool isMoving = false;

		private Player player;


		public PlayerStateMechine(Player play)
		{
			this.player = play;

		}

		public Player GetPlayer()
        {
			return player;
        }

		//other things shouldnt be able to access the facing and know what it is, right?
		//should the facing enum be public...?
		public Sprint3.Player.Facing FacingState()
		{
			return currentFacing;
		}

		public void ChangeMovingState(bool moving)
		{
			this.isMoving = moving;
			//key hold here and move?
		}

		public void Attack()
		{
			attack = true;
		}

		public void Damaged()
		{
			damaged = !damaged;
		}

		//not right
		public void ChangeFacing(string facing)
		{
			if (facing.ToUpper().Equals("RIGHT"))
				currentFacing = Sprint3.Player.Facing.RIGHT;
			if (facing.ToUpper().Equals("LEFT"))
				currentFacing = Sprint3.Player.Facing.LEFT;
			if (facing.ToUpper().Equals("UP"))
				currentFacing = Sprint3.Player.Facing.UP;
			if (facing.ToUpper().Equals("DOWN"))
				currentFacing = Sprint3.Player.Facing.DOWN;
		}

		public void Update(GameTime gameTime)
		{
			switch (facing)
			{
				case 0:
					if (attack && damaged)
					{
						player.SetSprite(SpriteFactory.GetSprite("right_throw"));
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
				case 1:
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
				case 2:
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
						play.SetSprite(SpriteFactory.GetSprite("front_move"));
					}
					else
					{
						play.SetSprite(SpriteFactory.GetSprite("front_still"));
					}
					break;
				case 3:
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
						play.SetSprite(SpriteFactory.GetSprite("back_move"));
					}
					else
					{
						play.SetSprite(SpriteFactory.GetSprite("back_still"));
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
