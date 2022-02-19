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
		private NpcStatementMachine state;
		private NpcProjectileSeq proj;
		private int i = 0;
		private float timer;
		public int index;
		private int enemynum;
		private float timespan;
		private bool movingRight;
		private bool movingUp;
		private Vector2[] location;
		private List<List<int>> routeMap;
		public List<List<string>> npcHolder;
		private List<List<string>> fireballHolder;
		private List<bool> fireHolder, moveHolder;

		public NPC1(int boundWidth, int boundHeight)
		{
			index = 0;
			state = new NpcStatementMachine(this);
			this.proj = new NpcProjectileSeq();
			this.boundWidth = boundWidth;
			this.boundHeight = boundHeight;
			this.initialize(3);
		}

		private void initialize(int enemynums)
		{
			this.setTimer(60f);
			this.setEnemyNum(enemynums);
			this.npcHolder = new List<List<string>>();
			this.fireballHolder = new List<List<string>>();
			this.routeMap = new List<List<int>>();
			this.fireHolder = new List<bool>();
			this.moveHolder = new List<bool>();
			this.location = new Vector2[enemynum];
			this.loadMap(this.routeMap);
			this.loadNpc(this.npcHolder);
			this.loadFireBall(this.fireballHolder);
			this.loadLocations(this.location);
			this.loadFireBool(this.fireHolder);
			this.loadMoveBool(this.moveHolder);
		}

		public void Move(int facing)
		{
			state.ChangeFacing(facing);
			if(moveHolder[index]) {
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
		}

		private void DistantAttack(int index)
		{

	

			this.proj.NewProjectile(new Vector2(location[index].X + 15, location[index].Y + 15), state.FacingState(), fireballHolder[index]);

		}

		public void SetLocation(Vector2 newLocation)
		{
			location[index] = newLocation;
		}
		public void SetIndx(int i)
		{
			this.index = i;
		}
		public void SetI(int i)
		{
			this.i = i;
		}
		public void setTimer(float i)
		{
			this.timespan = i;
		}
		public void SetNpc(ISprite npc)
		{
			this.npc = npc;
		}
		
		public Vector2 GetLocation()
		{
			return location[index];
		}
		public ISprite GetNpc()
		{
			return npc;
		}
		public int GetEnemyNum()
        {
			return this.enemynum;
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
			if (fireHolder[index]) {
				timer += 1f;
				if (timer == 100f)
				{
					this.DistantAttack(this.index);
					timer = 0f;
				}
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

		private void loadMap(List<List<int>> Map)
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
			Map.Add(new List<int> { 2 });
		}

		private void loadFireBall(List<List<string>> fireballHolder)
		{
			fireballHolder.Add(new List<string> { "fireballright", "fireballleft", "fireballup", "fireballdown" });
			fireballHolder.Add(new List<string> { "fireballright", "fireballleft", "fireballup", "fireballdown" });
			fireballHolder.Add(new List<string> { "fireballright", "fireballleft", "fireballup", "fireballdown" });
		}

		private void loadNpc(List<List<string>> npcHolder)
		{
			npcHolder.Add(new List<string> { "kirito_move_right", "kirito_move_left" , "kirito_back_move", "kirito_move_front" });
			npcHolder.Add(new List<string> { "skeletonRight", "skeletonLeft", "skeletonBack", "skeletonFront" });
			npcHolder.Add(new List<string> { "kirito_right_still", "kirito_left_still", "kirito_back_still", "kirito_front_still" });
		}

		private void loadLocations(Vector2[] locations)
		{
			locations[0] = new Vector2(50, 50);
			locations[1] = new Vector2(200, 200);
			locations[2] = new Vector2(100, 233);
		}

		private void loadFireBool(List<bool> fireHolder)
        {
			fireHolder.Add(true);
			fireHolder.Add(true);
			fireHolder.Add(true);
		}
		private void loadMoveBool(List<bool> moveHolder)
        {
			moveHolder.Add(true);
			moveHolder.Add(true);
			moveHolder.Add(false);
		}
		private void setEnemyNum(int i)
		{
			this.enemynum = i;
		}

	}
}
