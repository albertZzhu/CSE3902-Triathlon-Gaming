﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class Player
    {
        private ISprite sprite = new Sprite();
        private Vector2 location = new Vector2(50, 50);
        private PlayerStateMechine state;
        private ProjectileSeq proj;
        private int boundWidth;//Get the width of the current window so the figure can go back when hit the boundary
        private int boundHeight;//Get the height of the current window so the figure can go back when hit the boundary

        public Player(int boundWidth, int boundHeight)
        {
            state = new PlayerStateMechine(this);
            this.proj = new ProjectileSeq();
            this.boundWidth = boundWidth;
            this.boundHeight = boundHeight;
        }

        //positive x, increment to the right. negative x, decrement to the left.
        //positive y, increment down. negative y, decrement up. 
        //x could be 1 for walking or 5 for sprinting 
        public void Move(int facing)
        {
            //location = new Vector2(location.X + x, location.Y + y);
            //return location;
            state.ChangeFacing(facing);
            switch (facing)
            {
                case 0:
                    if(location.X + 10 < boundWidth-20) {
                        location = new Vector2(location.X + 10, location.Y);
                    }
                    break;
                case 1:
                    if (location.X - 10 > 0)
                    {
                        location = new Vector2(location.X - 10, location.Y);
                    }
                    break;
                case 2:
                    if (location.Y - 10 > 0)
                    {
                        location = new Vector2(location.X, location.Y - 10);
                    }
                    break;
                case 3:
                    if (location.Y + 10 < boundHeight-30)
                    {
                        location = new Vector2(location.X, location.Y + 10);
                    }
                    break;
                default:
                    break;
            }
        }

        public void DistantAttack()
        {
            this.proj.NewProjectile(new Vector2(location.X + 15, location.Y + 15), state.FacingState());
        }

        public void SetLocation(Vector2 newLocation)
        {
            location = newLocation;
        }

        public Vector2 GetLocation()
        {
            return location;
        }


        public void SetSprite(ISprite spr)
        {
            sprite = spr;
        }

        public ISprite GetSprite()
        {
            return sprite;
        }

        public void GoAttack()
		{
            state.Attack();
		}

        public void GoDamaged()
        {
            state.Damaged();
        }

        public void Update(GameTime gameTime)
        {
            //get key presses here?
            state.Update(gameTime);
            sprite.Update();
            proj.Update();
        }

        //maybe get location here???
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
            proj.Draw(spriteBatch);
        }

    }
}