using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4
{
    class Win
    {
        private ISprite WinSprite = new Sprite();
        private static bool WinCondition;
        public Win(String Winpic)
        {
            this.WinSprite = SpriteFactory.GetSprite(Winpic);
        }
        public void Update(GameTime gametime)
        {
            this.WinSprite.Update();
        }
        public static void SetWinCondition(bool condition)
        {
            WinCondition = condition;
        }

        public static bool GetWinCondition()
        {
            return WinCondition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.WinSprite.Draw(spriteBatch, new Vector2(0,0));
        }
    }
}
