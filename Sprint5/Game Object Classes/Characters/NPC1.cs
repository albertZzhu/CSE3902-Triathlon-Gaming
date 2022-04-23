using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.State_Machines;
using Sprint5;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Sprint5
{
    public class NPC1 : INPC
	{
		private int boundWidth;//Get the width of the current window so the figure can go back when hit the boundary
		private int boundHeight;//Get the height of the current window so the figure can go back when hit the boundary
		private ISprite npc = new Sprite();
		private ISprite spawn = new Sprite();
		private NpcStatementMachine state;
		private NpcProjectileSeq proj;
		private bool movebool;
		private bool firebool;
		private Vector2 location;
		private FacingEnum direction;
		private float timer, timespan;
		public List<string> npcHolder;
		private List<string> fireballHolder;
		private List<KeyValuePair<Vector2, int>> route;
		private Vector2 nextpos;
		private FacingEnum nextface;
		private FacingEnum dragonuse;
		private int routesCounter;
		private bool dead;
		private double deadClock = 0.0;
        private int spawneffectframecount;
		private Item[] itemdropped;
		private IRoom room;
        private int dropornot;
        private int whichone;
		private bool canMoveUp = true;
		private bool canMoveDown = true;
		private bool canMoveRight = true;
		private bool canMoveLeft = true;

        //constructor
        public NPC1(int boundWidth, int boundHeight, IRoom room)
		{
			this.room = room;
			state = new NpcStatementMachine(this);
			proj = new NpcProjectileSeq();
			this.boundWidth = boundWidth;
			this.boundHeight = boundHeight;
			routesCounter = 0;
			dead = false;
			spawn = SpriteFactory.GetSprite("animatedDamage");
			this.spawneffectframecount = 0;
			this.initializeItemDropped();
		}

		private void initializeItemDropped()
        {
			this.itemdropped = new Item[2];
			this.itemdropped[0] = new Item("key");
			this.itemdropped[1] = new Item("itemHeart");
			Random rand = new Random();
			dropornot = rand.Next(0, 2);
			whichone = rand.Next(0, 2);
		}
		public bool isDead()
		{
			return dead;
		}

		public void die()
		{
			if (state.GetHealth() <= 1)
			{
				dead = true;
				SetNpc(SpriteFactory.GetSprite("EnemyDeath"));
			}
		}

		public void moveLock(FacingEnum direction)
		{
			switch (direction)
			{
				case FacingEnum.RIGHT:
					canMoveRight = false;
					break;
				case FacingEnum.LEFT:
					canMoveLeft = false;
					break;
				case FacingEnum.UP:
					canMoveUp = false;
					break;
				case FacingEnum.DOWN:
					canMoveDown = false;
					break;
			}
			if (!(this.canMoveRight && this.canMoveLeft && this.canMoveUp && this.canMoveDown))
			{
				Move((FacingEnum)((int)state.FacingState() % 2 == 0 ? (int)state.FacingState() + 1 : (int)state.FacingState() - 1));
			}
		}

		public void moveunLock(FacingEnum direction)
		{
			switch (direction)
			{
				case FacingEnum.RIGHT:
					canMoveRight = true;
					break;
				case FacingEnum.LEFT:
					canMoveLeft = true;
					break;
				case FacingEnum.UP:
					canMoveUp = true;
					break;
				case FacingEnum.DOWN:
					canMoveDown = true;
					break;
			}
		}

		//check direction and update location.
		public void Move(FacingEnum facing)
		{
			if(movebool) {
				switch (facing)
				{
					case FacingEnum.RIGHT:
						if (canMoveRight)
						{
							state.ChangeFacing(FacingEnum.RIGHT);
							location = new Vector2(location.X + 1, location.Y);
							if (location.X + 10 > boundWidth - 20)
							{
								location = new Vector2(location.X - 1, location.Y);
							}
						}
						break;
					case FacingEnum.LEFT:
						if (canMoveLeft)
						{
							state.ChangeFacing(FacingEnum.LEFT);
							location = new Vector2(location.X - 1, location.Y);
							if (location.X < 0)
							{
								location = new Vector2(location.X + 1, location.Y);
							}
						}
						break;
					case FacingEnum.UP:
						if (canMoveUp)
						{
							state.ChangeFacing(FacingEnum.UP);
							location = new Vector2(location.X, location.Y - 1);
							if (location.Y < 0)
							{
								location = new Vector2(location.X, location.Y + 1);
							}
						}
						break;
					case FacingEnum.DOWN:
						if (canMoveDown)
						{
							state.ChangeFacing(FacingEnum.DOWN);
							location = new Vector2(location.X, location.Y + 1);
							if (location.Y + 10 > boundHeight - 20)
							{
								location = new Vector2(location.X, location.Y - 1);
							}
						}
						break;
					default:
						break;
				}
			} else state.ChangeFacing(facing);
		}
		//npc projectile used
		private void DistantAttack()
		{

			if (((Sprite)npc).GetFrames()[0].GetBitMap().Name == "dragon")
			{
				proj.NewProjectile(new Vector2(location.X + 15, location.Y + 15), dragonuse, fireballHolder);
				proj.NewProjectile(new Vector2(location.X + 15, location.Y + 15), dragonuse + 10, fireballHolder);
				proj.NewProjectile(new Vector2(location.X + 15, location.Y + 15), dragonuse - 10, fireballHolder);
			}
			else
			{
				proj.NewProjectile(new Vector2(location.X + 15, location.Y + 15), state.FacingState(), fireballHolder);
			}
		}
		//room class used
		public void SetLocation(Vector2 newLocation)
		{
			location = newLocation;
			nextpos = newLocation;
		}
		//client used
		public Vector2 GetLocation()
		{
			return location;
		}
		//room class used
		public void setTimer(float i)
		{
			timespan = i;
		}
		//client used
		public float GetTimer()
        {
			return timespan;
        }
		//state machine used
		public void SetNpc(ISprite npc)
		{
			this.npc = npc;
		}
		//client used
		public ISprite GetNpc()
		{
			return npc;
		}
		//room class used
		public void SetDirection(FacingEnum f)
        {
			direction = f;
			nextface = f;
			dragonuse = f;
		}
		//client used
		public FacingEnum GetDirection()
        {
			return direction;
        }
		//room class used
		public void SetFireBallList(List<string> fireballHolder)
		{
			this.fireballHolder = fireballHolder;
		}
		//client used
		public List<string> GetFireBallList()
        {
			return fireballHolder;
        }
		//room class used
		public void SetNpcList(List<string> npcHolder)
		{
			this.npcHolder = npcHolder;
			state.SetHealth();
		}
		//client used
		public List<string> GetNpcList()
		{
			return npcHolder;
		}
		//room class used
		public void SetFireBool(bool firebool)
		{
			this.firebool = firebool;
		}
		//client used
		public bool GetFireBool()
		{
			return firebool;
		}
		//room class used
		public void SetMoveBool(bool movebool)
		{
			this.movebool = movebool;
		}
		//client used
		public bool GetMoveBool()
		{
			return movebool;
		}
		//room class used(optional loaded in xml)
		public void SetRoute(List<KeyValuePair<Vector2,int>> route)
		{
			this.route = route;
			if (this.route != null)
			{
				//hm... direction is being cast to an int here.
				this.route.Add(new KeyValuePair<Vector2, int>(location, (int)direction));
			}
			
			
		}

		public Rectangle GetRect()
		{
			Rectangle opt = new Rectangle((int)this.location.X, (int)this.location.Y, (int)this.npc.getSize().X, (int)this.npc.getSize().Y);
			return opt;
		}

		//client used(may obtain null if not loaded in the respective xml block)
		public List<KeyValuePair<Vector2, int>> GetRoute()
		{
			return this.route;
		}
		//state machine used
		public void GoDamaged()
		{
			state.Damaged();
		}
		//boru will use to check the collision, if collision detected change to the opposite moving direction.
		public void BouncedBack()
        {
            switch (direction) {
				case FacingEnum.RIGHT:
					direction = FacingEnum.LEFT;
					break;
				case FacingEnum.LEFT:
					direction = FacingEnum.RIGHT;
					break;
				case FacingEnum.UP:
					direction = FacingEnum.DOWN;
					break;
				case FacingEnum.DOWN:
					direction = FacingEnum.UP;
					break;
				default:
					break;
			}
			next();
        }
		internal List<IProjectile> GetSeqList()
		{
			if (firebool)
			{
				return proj.GetProjList();
			}
			else return new List<IProjectile>();
		}
		//update func
		public void Update(GameTime gameTime)
		{
			if ( spawneffectframecount >= (((Sprite)spawn).GetFrames()).Count) {
				if (!dead)
				{
					if (route != null && (location.Equals(nextpos)))
					{
						direction = nextface;
						next();
					}
					Move(direction);
					state.Update(gameTime);
					npc.Update();
					if (firebool)
					{
						timer += 1f;
						if (timer == timespan)
						{
							DistantAttack();
							timer = 0f;
						}
					}
					proj.Update(gameTime);
				}
				else if (deadClock < 1f)
				{
					deadClock += (float)gameTime.ElapsedGameTime.TotalSeconds;
					npc.Update();
				} else if(dead)
                {
					if (dropornot == 1) {
						this.room.AddItem(this.itemdropped[whichone]);
						this.itemdropped[whichone].SetLocation(this.location);
						if (!this.itemdropped[whichone].isDisappear())
						{
							this.itemdropped[whichone].Update(gameTime);
						}
					}
				}
			} else
            {
				this.spawn.Update();
				this.dead = false;

			}
		}
		//draw func
		public void Draw(SpriteBatch spriteBatch)
		{
			if (spawneffectframecount >= (((Sprite)spawn).GetFrames()).Count)
			{
				if (!dead)
				{
					npc.Draw(spriteBatch, location);
					proj.Draw(spriteBatch);
				}
				else if (deadClock < 1f)
				{
					npc.Draw(spriteBatch, location);
				} else if(dead)
                {	
					if (this.dropornot == 1) {
						if (!this.itemdropped[whichone].isDisappear())
						{
							this.itemdropped[whichone].Draw(spriteBatch);
						}
					}

				}
			} else
            {
				this.spawn.Draw(spriteBatch, location);
				spawneffectframecount++;
			}


		}

		public List<string> GetNPCHolder()
		{
			return npcHolder;
		}

		private void next()
		{
			nextpos = route[routesCounter].Key;
			nextface = (FacingEnum)route[routesCounter].Value;
			routesCounter++;
			if (routesCounter == route.Count)
			{
				routesCounter = 0;
			}
		}

	}
}
