using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint5
{
    class Boomrang : IProjectile
    {
        private ISprite sprite;
        private Vector2 location;
        private FacingEnum direction;
        private bool dead;
        private Player player;
        private Vector2 boomerangBack;
        private bool back;
        private Vector2 playerlocation;
        public Boomrang(ISprite sprite, Player player)
        {
            location = player.GetLocation();
            this.playerlocation = location;
            this.direction = (FacingEnum)player.state.FacingState();
            this.sprite = sprite;
            dead = false;
            this.player = player;
            this.back = false;
        }
        public void die()
        {
            this.dead = false;
            /*
            if (this.direction == FacingEnum.RIGHT)
            {
                this.direction = FacingEnum.LEFT;
            } else if(this.direction == FacingEnum.LEFT) {
                this.direction = FacingEnum.RIGHT;
            } else if(this.direction == FacingEnum.UP)
            {
                this.direction = FacingEnum.DOWN;
            } else if(this.direction == FacingEnum.DOWN)
            {
                this.direction = FacingEnum.UP;
            }
            */
            //this.FlyingBack(this.player, this.location);
            this.back = true;
        }
        public Rectangle GetRect()
        {
            Rectangle opt = new Rectangle((int)location.X, (int)location.Y, (int)sprite.getSize().X, (int)sprite.getSize().Y);
            return opt;
        }

        public bool isDead()
        {
            return this.dead;
        }

        public Vector2 GetLocation()
        {
            return this.location;
        }

        public void SetLocation(Vector2 location)
        {
            this.location = location;
        }

        private void FlyingBack(Player player, Vector2 location)
        {
            boomerangBack = player.GetLocation() - location;
            boomerangBack.Normalize();
            Vector2 loc = location + boomerangBack * 5;
            this.SetLocation(loc);
        }
        public void Update(GameTime gameTime)
        {
            if (!dead)
            {
                switch (direction)
                {
                    case FacingEnum.RIGHT:
                        if (back)
                        {
                            this.FlyingBack(this.player, this.location);
                        }
                        else
                        {
                            this.location = new Vector2(location.X + 5, location.Y);
                            if(this.location.X >= this.playerlocation.X + 150)
                            {
                                back = true;
                            }
                        }
                        break;
                    case FacingEnum.LEFT:  
                        if (back)
                        {
                            this.FlyingBack(this.player, this.location);
                        } else
                        {
                            this.location = new Vector2(location.X - 5, location.Y);
                            if (this.location.X <= this.playerlocation.X - 150)
                            {
                                back = true;
                            }
                        }
                        break;
                    case FacingEnum.UP:
                        if (back)
                        {
                            this.FlyingBack(this.player, this.location);
                        } else
                        {
                            this.location = new Vector2(location.X, location.Y - 5);
                            if(this.location.Y <= this.playerlocation.Y - 150)
                            {
                                back = true;
                            }
                        }
                        break;
                    case FacingEnum.DOWN:
                        if (back)
                        {
                            this.FlyingBack(this.player, this.location);
                        } else
                        {
                            this.location = new Vector2(location.X, location.Y + 5);
                            if(this.location.Y >= this.playerlocation.Y + 150)
                            {
                                back = true;
                            }
                        }
                        break;
                }
            }
            this.sprite.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!dead)
            {
                sprite.Draw(spriteBatch, this.location);
            }
        }
    }
}
