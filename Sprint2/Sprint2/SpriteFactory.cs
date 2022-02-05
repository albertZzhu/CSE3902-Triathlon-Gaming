using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class SpriteFactory
    {
        //its a singleton!
        private static SpriteFactory uniqueFactory;

        private static Dictionary<String, Sprite> spriteDict;

        private SpriteFactory()
        {

        }

        public static SpriteFactory GetFactory()
        {
            if (uniqueFactory == null)
            {
                uniqueFactory = new SpriteFactory();
            }
            return uniqueFactory; 
        }

        //takes in info about whats to be made in create sprite method?
        public static Sprite CreateSprite(Texture2D bitMap, String spriteName)
        {
            //uniquefactory.createframes
            return null;
        }

    }
}
