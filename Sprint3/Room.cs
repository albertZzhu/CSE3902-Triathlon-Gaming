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
        //block obj holder variables
        private Block[] block;
        //item obj holder variables
        private Item[] item;
        //used by both block and item variables
        private Vector2 loc;
        private String Texture;
        //npc obj holder variables
        private NPC1[] npc;
        private List<String> Textureholder;
        //player variables
        private Player player;
        //game window edges
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
            xml.Load("E:\\levelData.xml");
            XmlNode level1 = xml.SelectSingleNode("Level1");
            XmlNode root = level1.SelectSingleNode(room);
            if (root != null)
            {
                XmlNode type = root.SelectSingleNode("type");
                if (type != null)
                {
                    //loading blocks into the block obj holder.
                    XmlNode block = type.SelectSingleNode("blocks");
                    if (block != null)
                    {
                        int i = 0;
                        int num = int.Parse(block.Attributes["num"].Value);
                        if (num != 0)
                        {
                            this.block = new Block[num];
                            XmlNodeList list = block.ChildNodes;
                            foreach (XmlNode element in list)
                            {
                                if (element != null)
                                {
                                    XmlNodeList Binfo = element.ChildNodes;
                                    loc = new Vector2(int.Parse((Binfo[0].FirstChild).InnerText), int.Parse((Binfo[0].LastChild).InnerText));
                                    this.Texture = Binfo[1].InnerText;
                                    this.block[i] = new Block(this.boundWidth, this.boundHeight);
                                    this.block[i].SetLocation(loc);
                                    this.block[i].SetBlock(this.Texture);
                                    i++;
                                }
                            }
                        }
                        else this.block = null;
                    }
                    //loading items into the item obj holder.
                    XmlNode item = type.SelectSingleNode("items");
                    if (item != null)
                    {
                        int i = 0;
                        int num = int.Parse(item.Attributes["num"].Value);
                        if (num != 0)
                        {
                            this.item = new Item[num];
                            XmlNodeList list = item.ChildNodes;
                            foreach (XmlNode element in list)
                            {
                                if (element != null)
                                {
                                    XmlNodeList Iinfo = element.ChildNodes;
                                    loc = new Vector2(int.Parse((Iinfo[0].FirstChild).InnerText), int.Parse((Iinfo[0].LastChild).InnerText));
                                    this.Texture = Iinfo[1].InnerText;
                                    this.item[i] = new Item(this.boundWidth, this.boundHeight);
                                    this.item[i].SetLocation(loc);
                                    this.item[i].SetItem(this.Texture);
                                    i++;
                                }
                            }
                        }
                        else this.item = null;
                    }
                    //loading npcs into the npc obj holder.
                    XmlNode enemy = type.SelectSingleNode("enemies");
                    if (enemy != null)
                    {
                        int i = 0;
                        int num = int.Parse(enemy.Attributes["num"].Value);
                        if (num != 0)
                        {
                            this.npc = new NPC1[num];
                            XmlNodeList list = enemy.ChildNodes;
                            foreach (XmlNode element in list)
                            {
                                if (element != null)
                                {
                                    XmlNodeList Einfo = element.ChildNodes;
                                    this.npc[i] = new NPC1(this.boundWidth, this.boundHeight);
                                    this.npc[i].SetMoveBool(Convert.ToBoolean(element.Attributes["move"].Value));
                                    this.npc[i].SetLocation(new Vector2(int.Parse((Einfo[0].FirstChild).InnerText), int.Parse((Einfo[0].LastChild).InnerText)));
                                    this.npc[i].SetDirection(int.Parse(Einfo[1].InnerText));
                                    XmlNodeList npctextures = Einfo[2].ChildNodes;
                                    this.Textureholder = new List<string>();
                                    this.Textureholder.Add(npctextures[2].InnerText);
                                    this.Textureholder.Add(npctextures[3].InnerText);
                                    this.Textureholder.Add(npctextures[0].InnerText);
                                    this.Textureholder.Add(npctextures[1].InnerText);
                                    this.npc[i].SetNpcList(this.Textureholder);
                                    this.npc[i].SetFireBool(Convert.ToBoolean(Einfo[3].Attributes["fire"].Value));
                                    XmlNodeList firetextures = Einfo[3].ChildNodes;
                                    this.Textureholder = new List<string>();
                                    this.Textureholder.Add(firetextures[2].InnerText);
                                    this.Textureholder.Add(firetextures[3].InnerText);
                                    this.Textureholder.Add(firetextures[0].InnerText);
                                    this.Textureholder.Add(firetextures[1].InnerText);
                                    this.npc[i].SetFireBallList(this.Textureholder);
                                    if (Einfo[4].ChildNodes.Count != 0)
                                    {
                                        var routes = new List<KeyValuePair<Vector2, int>>();
                                        XmlNodeList route = Einfo[4].ChildNodes;
                                        foreach (XmlNode r in route)
                                        {
                                            routes.Add(new KeyValuePair<Vector2, int>(new Vector2(int.Parse((r.FirstChild.FirstChild).InnerText), int.Parse((r.FirstChild.LastChild).InnerText)), int.Parse((r.LastChild).InnerText)));

                                        }
                                        this.npc[i].SetRoute(routes);
                                    }
                                    else this.npc[i].SetRoute(null);
                                    this.npc[i].setTimer(float.Parse(Einfo[5].InnerText));
                                    i++;
                                }
                            }
                        }
                        else this.npc = null;
                    }

                    //loading player into the player class.
                    player = new Player(this.boundWidth, this.boundHeight);

                }

            }


        }
        public void Update(GameTime gameTime)
        {
            foreach(Block block in this.block)
            {
                block.Update(gameTime);
            }
            foreach (Item item in this.item)
            {
                item.Update(gameTime);
            }
            foreach (NPC1 npc in this.npc)
            {
                npc.Update(gameTime);
            }
            this.player.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Block block in this.block)
            {
                block.Draw(spriteBatch);
            }
            foreach (Item item in this.item)
            {
                item.Draw(spriteBatch);
            }
            foreach (NPC1 npc in this.npc)
            {
                npc.Draw(spriteBatch);
            }
            this.player.Draw(spriteBatch);
        }

        //collision will need these func to check objects interactions.(boru might use these funcs)
        public Block[] GetBlockObj()
        {
            return this.block;
        }

        public Item[] GetItemObj()
        {
            return this.item;
        }

        public NPC1[] GetNpcObj()
        {
            return this.npc;
        }

        public Player GetPlayerObj()
        {
            return this.player;
        }
    }
}
