using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Sprint2
{
	public class NPC1
	{
		private int boundWidth;//Get the width of the current window so the figure can go back when hit the boundary
		private int boundHeight;//Get the height of the current window so the figure can go back when hit the boundary
		private ISprite npc = new Sprite();
		private Vector2[] location;
		private NpcStatementMachine state;
		private ProjectileSeq proj;
		private List<List<int>> routeMap;
		private int i = 0;
		private float timer;
		private bool movingRight;
		private bool movingUp;
		public List<List<string>> npcHolder;
		public int index;
		public int enemynum;
		public NPC1(List<List<int>> route, int boundWidth, int boundHeight, List<List<string>> npcHolder, int enemynum, Vector2[] locations)
		{
			this.npcHolder = npcHolder;
			index = 0;
			state = new NpcStatementMachine(this);
			this.routeMap = route;
			this.proj = new ProjectileSeq();
			this.boundWidth = boundWidth;
			this.boundHeight = boundHeight;
			this.enemynum = enemynum;
			this.location = locations;
		}

		public void Move(int facing)
		{
			state.ChangeFacing(facing);
			switch (facing)
			{
				case 0:
					if (movingRight)
					{
						state.ChangeFacing(0);
						location[index] = new Vector2(location[index].X + 1, location[index].Y);
						if (location[index].X + 10 > boundWidth - 20)
						{
							movingRight = false;
							state.ChangeFacing(1);
							location[index] = new Vector2(location[index].X - 1, location[index].Y);
						}
					}
					else
					{
						state.ChangeFacing(1);
						location[index] = new Vector2(location[index].X - 1, location[index].Y);
						if (location[index].X - 10 < 0)
						{
							movingRight = true;
							state.ChangeFacing(0);
							location[index] = new Vector2(location[index].X + 1, location[index].Y);
						}
					}
					break;
				case 2:
					if (movingUp)
					{
						state.ChangeFacing(2);
						location[index] = new Vector2(location[index].X, location[index].Y - 1);
						if (location[index].Y - 10 < 0)
						{
							movingUp = false;
							state.ChangeFacing(3);
							location[index] = new Vector2(location[index].X, location[index].Y + 1);
						}
					}
					else
					{
						state.ChangeFacing(3);
						location[index] = new Vector2(location[index].X, location[index].Y + 1);
						if (location[index].Y + 10 > boundHeight - 30)
						{
							movingUp = true;
							state.ChangeFacing(2);
							location[index] = new Vector2(location[index].X, location[index].Y - 1);
						}
					}
					break;

				default:
					break;
			}
		}

		private void DistantAttack()
		{
			this.proj.NewProjectile(new Vector2(location[index].X + 15, location[index].Y + 15), state.FacingState(), 0);
		}

		public void SetLocation(Vector2 newLocation)
		{
			location[index] = newLocation;
		}

		public Vector2 GetLocation()
		{
			return location[index];
		}

		public ISprite GetNpc()
		{
			return npc;
		}
		public void SetIndx(int i)
		{
			this.index = i;
		}
		public void SetI(int i)
		{
			this.i = i;
		}
		public void SetNpc(ISprite npc)
		{
			this.npc = npc;
		}

		public void GoDamaged()
		{
			state.Damaged();
		}

		public void Update(GameTime gameTime)
		{
			Move(modFunc(routeMap[index]));
			state.Update(gameTime);
			npc.Update();
			timer += 1f;
			if (timer == 100f)
			{
				this.DistantAttack();
				timer = 0f;
			}
			proj.Update();
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			npc.Draw(spriteBatch, location[index]);
			proj.Draw(spriteBatch);
		}

		//read routeMap's value on each bucket.
		private int modFunc(List<int> route)
		{
			int index;
			if (i == route.Count)
			{
				i = 0;
			}
			index = route[i];
			i++;
			return index;
		}

		public static List<List<int>> loadMap(List<List<int>> Map)
		{
			Map.Add(new List<int> {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
				2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
				2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
				0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0,
				0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
				0, 0, 0, 0, 0, 0, 0});
			Map.Add(new List<int> { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
				2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0});
			return Map;
		}

		public static List<List<string>> loadNpc(List<List<string>> npcHolder)
		{
			npcHolder.Add(new List<string> { "movingRight", "movingLeft", "movingUp", "movingDown" });
			npcHolder.Add(new List<string> { "movingRight", "movingLeft", "movingUp", "movingDown" });
			return npcHolder;
		}

		public static Vector2[] loadLocations(Vector2[] locations)
		{
			locations[0] = new Vector2(50, 50);
			locations[1] = new Vector2(200, 200);
			return locations;
		}

		public static int setEnemyNum(int i)
		{
			return i;
		}
	}
}
