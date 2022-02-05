using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class SpriteFactory
    {
        //its a singleton!
        private static SpriteFactory uniqueFactory;
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
        public static Sprite CreateSprite(spritesheet)
        {
            //uniquefactory.createframes
            return null;
        }

    }
}
