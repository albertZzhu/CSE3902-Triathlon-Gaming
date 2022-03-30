using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint4.State_Machines;
using System.Collections;
using System.Collections.Generic;

namespace Sprint4
{
	class ProjectileSeq
	{
		private List<Projectile> list;
		float bias = 30;
		float biasfireball = 16;
		public ProjectileSeq()
		{
			list = new List<Projectile>();
		}

		public void NewProjectile(Vector2 newLocation, Facing direction, int sprite)
		{
			switch (sprite)
			{ //add more
				case 2:
					{
						switch (direction)
						{
							case Facing.RIGHT:
								list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite("projectileRight")));
								break;
							case Facing.LEFT:
								list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite("projectileLeft")));
								break;
							case Facing.UP:
								list.Add(new Projectile(new Vector2(newLocation.X - bias, newLocation.Y), direction, SpriteFactory.GetSprite("projectileUp")));
								break;
							case Facing.DOWN:
								list.Add(new Projectile(new Vector2(newLocation.X - bias, newLocation.Y), direction, SpriteFactory.GetSprite("projectileDown")));
								break;
						}
					}
					break;
				case 0:
					{
						switch (direction)
						{
							case Facing.RIGHT:
								list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite("fireballright")));
								break;
							case Facing.LEFT:
								list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite("fireballleft")));
								break;
							case Facing.UP:
								list.Add(new Projectile(new Vector2(newLocation.X - biasfireball, newLocation.Y), direction, SpriteFactory.GetSprite("fireballup")));
								break;
							case Facing.DOWN:
								list.Add(new Projectile(new Vector2(newLocation.X - biasfireball, newLocation.Y), direction, SpriteFactory.GetSprite("fireballdown")));
								break;
						}
					}
					break;
				case 1:
					{
						switch (direction)
						{
							case Facing.RIGHT:
								list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite("heart")));
								break;
							case Facing.LEFT:
								list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite("heart")));
								break;
							case Facing.UP:
								list.Add(new Projectile(new Vector2(newLocation.X - bias, newLocation.Y), direction, SpriteFactory.GetSprite("heart")));
								break;
							case Facing.DOWN:
								list.Add(new Projectile(new Vector2(newLocation.X - bias, newLocation.Y), direction, SpriteFactory.GetSprite("heart")));
								break;
						}
					}
					break;
				default:
					break;

			}

		}

		public void Update(GameTime gametime)
		{
			for(int i=0;i<list.Count;i++)
			{
				if (!list[i].isDead())
				{
					list[i].Update(gametime);
				}
				else
				{
					list.Remove(list[i]);
				}
			}
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (Projectile p in list)
			{
				p.Draw(spriteBatch);
			}
		}
		public List<Projectile> GetProjList()
		{
			return list;
		}
	}
}