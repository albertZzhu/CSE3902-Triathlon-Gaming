using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint3.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Sprint3
{
    class Room : IRoom
    {   
        //block and item variables
        private Block block;
        private Item item;
        private Vector2[] loc;
        private String[] Texture;
        //npc variables
        private NPC1 npc;
        private int[] npcTexture;
        private int[] fireballTexture;
        private int[] route;
        private float[] timer;
        private bool[] moveornot;
        private bool[] fireornot;
        //player variables
        private Player player;
        private int boundWidth;
        private int boundHeight;
        public Room(String room, int boundWidth, int boundHeight)
        {
            this.boundWidth = boundWidth;
            this.boundHeight = boundHeight;
            loadRoom(room);
        }

        private void loadRoom(String room)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("some directory of this xml file");
            XmlNode root = xml.SelectSingleNode(room);
            if (root != null)
            {
                XmlNodeList Rinfo = root.ChildNodes;
                //loading blocks into the Block class.
                XmlNode block = Rinfo[0];
                if (block != null)
                {
                    int i = 0;
                    int num = int.Parse(block.Attributes["num"].Value);
                    this.loc = new Vector2[num];
                    this.Texture = new string[num];
                    XmlNodeList list = block.ChildNodes;
                    foreach (XmlNode element in list)
                    {
                        if (element != null) {
                            XmlNodeList Binfo = element.ChildNodes;
                            loc[i] = new Vector2(int.Parse((Binfo[0].FirstChild).InnerText), int.Parse((Binfo[0].LastChild).InnerText));
                            this.Texture[i] = Binfo[1].InnerText;
                        }
                        i++;
                    }
                    this.block = new Block(loc, this.Texture, i);

                }

                //loading items into the item class.
                XmlNode item = Rinfo[1];
                if (item != null)
                {
                    int i = 0;
                    int num = int.Parse(item.Attributes["num"].Value);
                    this.loc = new Vector2[num];
                    this.Texture = new string[num];
                    XmlNodeList list = item.ChildNodes;
                    foreach (XmlNode element in list)
                    {
                        if (element != null)
                        {
                            XmlNodeList Binfo = element.ChildNodes;
                            loc[i] = new Vector2(int.Parse((Binfo[0].FirstChild).InnerText), int.Parse((Binfo[0].LastChild).InnerText));
                            this.Texture[i] = Binfo[1].InnerText;
                        }
                        i++;
                    }
                    this.item = new Item(loc, this.Texture, i);

                }

                //loading enemys into the npc class.
                XmlNode enemy = Rinfo[2];
                if (enemy != null)
                {
                    int i = 0;
                    int num = int.Parse(enemy.Attributes["num"].Value);
                    this.loc = new Vector2[num];
                    this.npcTexture = new int[num];
                    this.fireballTexture = new int[num];
                    this.route = new int[num];
                    this.moveornot = new bool[num];
                    this.fireornot = new bool[num];
                    this.timer = new float[num];
                    XmlNodeList list = enemy.ChildNodes;
                    foreach (XmlNode element in list)
                    {
                        if (element != null)
                        {
                            this.moveornot[i] = Convert.ToBoolean(enemy.Attributes["move"].Value);
                            XmlNodeList Binfo = element.ChildNodes;
                            loc[i] = new Vector2(int.Parse((Binfo[0].FirstChild).InnerText), int.Parse((Binfo[0].LastChild).InnerText));
                            this.npcTexture[i] = int.Parse(Binfo[1].InnerText);
                            this.fireornot[i] = Convert.ToBoolean(Binfo[2].Attributes["fire"].Value);
                            this.fireballTexture[i] = int.Parse(Binfo[2].InnerText);
                            this.route[i] = int.Parse(Binfo[3].InnerText);
                            this.timer[i] = float.Parse(Binfo[4].InnerText);
                        }
                        i++;
                    }
                    this.npc = new NPC1(loc, this.npcTexture, this.fireballTexture, this.route, this.moveornot, this.fireornot, this.timer, i);

                }

                //loading player into the player class.
                player = new Player(this.boundWidth, this.boundHeight);
            }

        }
        public void Update(GameTime gameTime)
        {
            this.block.Update(gameTime);
            this.item.Update(gameTime);
            this.npc.Update(gameTime);
            this.player.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.block.Draw( spriteBatch);
            this.item.Draw( spriteBatch);
            this.npc.Draw( spriteBatch);
            this.player.Draw( spriteBatch);
        }
    }
}
