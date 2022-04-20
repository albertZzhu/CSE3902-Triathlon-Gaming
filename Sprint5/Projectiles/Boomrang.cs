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
            this.dead = true;
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

        public void Update(GameTime gameTime)
        {
            if (!dead)
            {
                switch (direction)
                {
                    case FacingEnum.RIGHT:
                        if (this.location.X >= this.playerlocation.X + 150 || back)
                        {
                            back = true;
                            boomerangBack = this.player.GetLocation() - this.location;
                            if (boomerangBack.X <= 0) {
                                boomerangBack.Normalize();
                                this.location += boomerangBack * 5;
                            } else
                            {
                                this.direction = FacingEnum.LEFT;
                            }
                        }
                        else
                        {
                            this.location = new Vector2(location.X + 5, location.Y);
                        }
                        break;
                    case FacingEnum.LEFT:  
                        if (this.location.X <= this.playerlocation.X - 150 || back)
                        {
                            back = true;
                            boomerangBack = this.player.GetLocation() - this.location;
                            if (boomerangBack.X >= 0) {
                                boomerangBack.Normalize();
                                this.location += boomerangBack * 5;
                            }
                            else
                            {
                                this.direction = FacingEnum.RIGHT;
                            }
                        } else
                        {
                            this.location = new Vector2(location.X - 5, location.Y);
                        }
                        break;
                    case FacingEnum.UP:
                        if (this.location.Y <= this.playerlocation.Y - 150 || back)
                        {
                            back = true;
                            boomerangBack = this.player.GetLocation() - this.location;
                            if (boomerangBack.Y >= 0) {
                                boomerangBack.Normalize();
                                this.location += boomerangBack * 5;
                            } else
                            {
                                this.direction = FacingEnum.DOWN;
                            }
                        } else
                        {
                            this.location = new Vector2(location.X, location.Y - 5);
                        }
                        break;
                    case FacingEnum.DOWN:
                        if (this.location.Y >= this.playerlocation.Y + 150 || back)
                        {
                            back = true;
                            boomerangBack = this.player.GetLocation() - this.location;
                            if (boomerangBack.Y <= 0) {
                                boomerangBack.Normalize();
                                this.location += boomerangBack * 5;
                            } else
                            {
                                this.direction = FacingEnum.UP;
                            }
                        } else
                        {
                            this.location = new Vector2(location.X, location.Y + 5);
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
