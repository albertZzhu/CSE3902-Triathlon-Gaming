﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4
{
    public class lose
    {
        private ISprite LoseSprite = new Sprite();
        private static bool LoseCondition;
        public lose(String Losepic)
        {
            this.LoseSprite = SpriteFactory.GetSprite(Losepic);
        }
        public void Update(GameTime gametime)
        {
            this.LoseSprite.Update();
        }
        public static void SetLoseCondition(bool condition)
        {
            LoseCondition = condition;
        }

        public static bool GetLoseCondition()
        {
            return LoseCondition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.LoseSprite.Draw(spriteBatch, new Vector2(0, 0));
        }
    }
}
