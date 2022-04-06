using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint4.Game_Object_Classes
{
    class MapMarker
    {
        //each room number has a corresponding location on the map
        //this implementation will probably be very limited and for the current data: must be refactored

        Dictionary<int, Vector2> roomLocations = new Dictionary<int, Vector2>();
        Vector2 currentLocation;
        ISprite sprite;

        //could have level number be a param but that would become obsolete pretty fast
        public MapMarker()
        {
            sprite = SpriteFactory.GetSprite("mapmarker");
            roomLocations.Add(1, new Vector2(90, 590));
            currentLocation = roomLocations[1];
        }

        public void Update(int roomNum)
        {
            currentLocation = roomLocations[roomNum];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, currentLocation);
        }

    }
}
