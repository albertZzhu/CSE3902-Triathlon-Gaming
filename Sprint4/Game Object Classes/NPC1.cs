using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Sprint4
{
	public class NPC1 : INPC
	{
		private int boundWidth;//Get the width of the current window so the figure can go back when hit the boundary
		private int boundHeight;//Get the height of the current window so the figure can go back when hit the boundary
		private ISprite npc = new Sprite();
		private NpcStatementMachine state;
		private NpcProjectileSeq proj;
		private bool movebool;
		private bool firebool;
		private Vector2 location;
		private int direction;
		private float timer, timespan;
		public List<string> npcHolder;
		private List<string> fireballHolder;
		private List<KeyValuePair<Vector2, int>> route;
		private Vector2 nextpos;
		private int nextface;
		private int dragonuse;
		private int routesCounter;
		private bool dead;
		//constructor
		public NPC1(int boundWidth, int boundHeight)
		{
			state = new NpcStatementMachine(this);
			this.proj = new NpcProjectileSeq();
			this.boundWidth = boundWidth;
			this.boundHeight = boundHeight;
			this.routesCounter = 0;
			this.dead = false;
		}

		public bool isDead()
		{
			return dead;
		}

		public void die()
		{
			dead = true;
		}

		//check direction and update location.
		public void Move(int facing)
		{
			if(movebool) {
				switch (facing)
				{
					case 0:
						state.ChangeFacing(0);
						location = new Vector2(location.X + 1, location.Y);
						if (location.X + 10 > boundWidth - 20)
						{
							location = new Vector2(location.X - 1, location.Y);
						}
						break;
					
					case 1:
						state.ChangeFacing(1);
						location = new Vector2(location.X - 1, location.Y);
						if (location.X < 0)
						{
							location = new Vector2(location.X + 1, location.Y);
						}
						break;

					case 2:
						state.ChangeFacing(2);
						location = new Vector2(location.X, location.Y - 1);
						if (location.Y < 0)
						{
							location = new Vector2(location.X, location.Y + 1);
						}
						break;
					
					case 3:
						state.ChangeFacing(3);
						location = new Vector2(location.X, location.Y + 1);
						if (location.Y + 10 > boundHeight - 20)
						{
							location = new Vector2(location.X, location.Y - 1);
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
				this.proj.NewProjectile(new Vector2(location.X + 15, location.Y + 15), this.dragonuse, fireballHolder);
				this.proj.NewProjectile(new Vector2(location.X + 15, location.Y + 15), this.dragonuse + 10, fireballHolder);
				this.proj.NewProjectile(new Vector2(location.X + 15, location.Y + 15), this.dragonuse - 10, fireballHolder);
			}
			else
			{
				this.proj.NewProjectile(new Vector2(location.X + 15, location.Y + 15), state.FacingState(), fireballHolder);
			}
		}
		//room class used
		public void SetLocation(Vector2 newLocation)
		{
			location = newLocation;
			this.nextpos = newLocation;
		}
		//client used
		public Vector2 GetLocation()
		{
			return location;
		}
		//room class used
		public void setTimer(float i)
		{
			this.timespan = i;
		}
		//client used
		public float GetTimer()
        {
			return this.timespan;
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
		public void SetDirection(int i)
        {
			this.direction = i;
			this.nextface = i;
			this.dragonuse = i;
		}
		//client used
		public int GetDirection()
        {
			return this.direction;
        }
		//room class used
		public void SetFireBallList(List<string> fireballHolder)
		{
			this.fireballHolder = fireballHolder;
		}
		//client used
		public List<string> GetFireBallList()
        {
			return this.fireballHolder;
        }
		//room class used
		public void SetNpcList(List<string> npcHolder)
		{
			this.npcHolder = npcHolder;
		}
		//client used
		public List<string> GetNpcList()
		{
			return this.npcHolder;
		}
		//room class used
		public void SetFireBool(bool firebool)
		{
			this.firebool = firebool;
		}
		//client used
		public bool GetFireBool()
		{
			return this.firebool;
		}
		//room class used
		public void SetMoveBool(bool movebool)
		{
			this.movebool = movebool;
		}
		//client used
		public bool GetMoveBool()
		{
			return this.movebool;
		}
		//room class used(optional loaded in xml)
		public void SetRoute(List<KeyValuePair<Vector2,int>> route)
		{
			this.route = route;
			if (this.route != null)
			{
				this.route.Add(new KeyValuePair<Vector2, int>(location, direction));
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
				case 0:
					this.direction = 1;
					break;
				case 1:
					this.direction = 0;
					break;
				case 2:
					this.direction = 3;
					break;
				case 3:
					this.direction = 2;
					break;
				default:
					break;
			}

        }
		internal List<IProjectile> GetSeqList()
		{
			if (this.firebool)
			{
				return this.proj.GetProjList();
			}
			else return new List<IProjectile>();
		}
		//update func
		public void Update(GameTime gameTime)
		{
			if (!this.dead)
			{
				if (route != null && (this.location.Equals(this.nextpos)))
				{
					this.direction = this.nextface;
					this.next();
				}
				Move(direction);
				state.Update(gameTime);
				npc.Update();
				if (firebool)
				{
					timer += 1f;
					if (timer == this.timespan)
					{
						this.DistantAttack();
						timer = 0f;
					}
				}
				proj.Update(gameTime);
			}
		}
		//draw func
		public void Draw(SpriteBatch spriteBatch)
		{
			if (!this.dead) {
				npc.Draw(spriteBatch, location);
				proj.Draw(spriteBatch);
			}
			
		}

		private void next()
		{
			this.nextpos = this.route[routesCounter].Key;
			this.nextface = this.route[routesCounter].Value;
			routesCounter++;
			if (routesCounter == this.route.Count)
			{
				routesCounter = 0;
			}
		}

	}
}
