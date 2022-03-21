using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

		public void NewProjectile(Vector2 newLocation, int direction, int sprite)
		{
			switch (sprite)
			{ //add more
				case 2:
					{
						switch (direction)
						{
							case 0:
								list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite("projectileRight")));
								break;
							case 1:
								list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite("projectileLeft")));
								break;
							case 2:
								list.Add(new Projectile(new Vector2(newLocation.X - bias, newLocation.Y), direction, SpriteFactory.GetSprite("projectileUp")));
								break;
							case 3:
								list.Add(new Projectile(new Vector2(newLocation.X - bias, newLocation.Y), direction, SpriteFactory.GetSprite("projectileDown")));
								break;
						}
					}
					break;
				case 0:
					{
						switch (direction)
						{
							case 0:
								list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite("fireballright")));
								break;
							case 1:
								list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite("fireballleft")));
								break;
							case 2:
								list.Add(new Projectile(new Vector2(newLocation.X - biasfireball, newLocation.Y), direction, SpriteFactory.GetSprite("fireballup")));
								break;
							case 3:
								list.Add(new Projectile(new Vector2(newLocation.X - biasfireball, newLocation.Y), direction, SpriteFactory.GetSprite("fireballdown")));
								break;
						}
					}
					break;
				case 1:
					{
						switch (direction)
						{
							case 0:
								list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite("heart")));
								break;
							case 1:
								list.Add(new Projectile(newLocation, direction, SpriteFactory.GetSprite("heart")));
								break;
							case 2:
								list.Add(new Projectile(new Vector2(newLocation.X - bias, newLocation.Y), direction, SpriteFactory.GetSprite("heart")));
								break;
							case 3:
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
			return this.list;
		}
	}
}