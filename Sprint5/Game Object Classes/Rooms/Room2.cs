using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Sprint5
{
    class Room2 : IRoom
    {
        //block obj holder variables
        private IBlock[] block;
        //MOVABLE_Block obj holder variables
        private IBlock[] Mblock;
        //water obj holder variables
        private IBlock[] water;
        //sand obj holder variables
        private IBlock[] sand;
        //item obj holder variables
        private Item[] item;
        //used by both block and item variables
        private Vector2 loc;
        private String Texture;
        private Player player;
        private Vector2 spawnLocation = new Vector2(100, 250);
        private int spawnHealth = 5;

        //npc obj holder variables
        private NPC1[] npc = new NPC1[0];
        //player variables
        //game window edges
        private int boundWidth;
        private int boundHeight;
        private List<IProjectile> list;
        private GameObjectManager gom;
        public Room2(String room, GameObjectManager gom, int boundWidth, int boundHeight, Player player = null)
        {
            this.boundWidth = boundWidth;
            this.boundHeight = boundHeight;
            this.gom = gom;
            list = new List<IProjectile>();
            loadRoom(room, player);
        }
        private void loadRoom(String room, Player oldPlayer)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("..\\Level2Data2.xml");
            XmlNode level1 = xml.SelectSingleNode("level2");
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
                            this.block = new IBlock[num];
                            XmlNodeList list = block.ChildNodes;
                            foreach (XmlElement element in list)
                            {
                                if (!element.IsEmpty)
                                {
                                    XmlNodeList Binfo = element.ChildNodes;
                                    loc = new Vector2(int.Parse((Binfo[0].FirstChild).InnerText), int.Parse((Binfo[0].LastChild).InnerText));
                                    Texture = Binfo[1].InnerText;
                                    this.block[i] = new Block();
                                    this.block[i].SetLocation(loc);
                                    this.block[i].SetBlock(Texture);
                                    i++;
                                }
                            }
                        }
                        else
                        {
                            this.block = new IBlock[0];
                        }

                    }
                    //loading movable_blocks into the movable_block obj holder.
                    XmlNode Mblock = type.SelectSingleNode("movable_block");
                    if (Mblock != null)
                    {
                        int i = 0;
                        int num = int.Parse(Mblock.Attributes["num"].Value);
                        if (num != 0)
                        {
                            this.Mblock = new IBlock[num];
                            XmlNodeList list = Mblock.ChildNodes;
                            foreach (XmlElement element in list)
                            {
                                if (!element.IsEmpty)
                                {
                                    XmlNodeList MBinfo = element.ChildNodes;
                                    loc = new Vector2(int.Parse((MBinfo[0].FirstChild).InnerText), int.Parse((MBinfo[0].LastChild).InnerText));
                                    Texture = MBinfo[1].InnerText;
                                    this.Mblock[i] = new MoveableBlock();
                                    this.Mblock[i].SetLocation(loc);
                                    this.Mblock[i].SetBlock(Texture);
                                    i++;
                                }
                            }
                        }
                        else
                        {
                            this.Mblock = new IBlock[0];
                        }

                    }
                    //loading water into the water obj holder.
                    XmlNode water = type.SelectSingleNode("water");
                    if (water != null)
                    {
                        int i = 0;
                        int num = int.Parse(water.Attributes["num"].Value);
                        if (num != 0)
                        {
                            this.water = new Water[num];
                            XmlNodeList list = water.ChildNodes;
                            foreach (XmlElement element in list)
                            {
                                if (!element.IsEmpty)
                                {
                                    XmlNodeList Winfo = element.ChildNodes;
                                    loc = new Vector2(int.Parse((Winfo[0].FirstChild).InnerText), int.Parse((Winfo[0].LastChild).InnerText));
                                    Texture = Winfo[1].InnerText;
                                    this.water[i] = new Water();
                                    this.water[i].SetLocation(loc);
                                    this.water[i].SetBlock(Texture);
                                    i++;
                                }
                            }
                        }
                        else
                        {
                            this.water = new Water[0];
                        }

                    }
                    //loading sand into the sand obj holder.
                    XmlNode sand = type.SelectSingleNode("sand");
                    if (sand != null)
                    {
                        int i = 0;
                        int num = int.Parse(sand.Attributes["num"].Value);
                        if (num != 0)
                        {
                            this.sand = new Sand[num];
                            XmlNodeList list = sand.ChildNodes;
                            foreach (XmlElement element in list)
                            {
                                if (!element.IsEmpty)
                                {
                                    XmlNodeList Sinfo = element.ChildNodes;
                                    loc = new Vector2(int.Parse((Sinfo[0].FirstChild).InnerText), int.Parse((Sinfo[0].LastChild).InnerText));
                                    Texture = Sinfo[1].InnerText;
                                    this.sand[i] = new Sand();
                                    this.sand[i].SetLocation(loc);
                                    this.sand[i].SetBlock(Texture);
                                    i++;
                                }
                            }
                        }
                        else
                        {
                            this.sand = new Sand[0];
                        }

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
                                if (element.InnerText != null)
                                {
                                    XmlNodeList Iinfo = element.ChildNodes;
                                    loc = new Vector2(int.Parse((Iinfo[0].FirstChild).InnerText), int.Parse((Iinfo[0].LastChild).InnerText));
                                    Texture = Iinfo[1].InnerText;
                                    this.item[i] = new Item();
                                    this.item[i].SetLocation(loc);
                                    this.item[i].SetItem(Texture);
                                    i++;
                                }
                            }
                        }
                        else
                        {
                            this.item = new Item[0];
                        }
                    }
                    if (oldPlayer != null)
                    {
                        player = new Player(boundWidth, boundHeight, playerPositionTransition(oldPlayer.GetLocation()), oldPlayer.GetState().playerHealth());
                    }
                    else
                    {
                        player = new Player(boundWidth, boundHeight, spawnLocation, spawnHealth);
                    }
                }
            }
            gom.ClearLists();
            gom.PopulateBlocks(GetBlockObj());
            gom.PopulatePlayers(player);
            gom.PopulateItems(item);
            gom.PopulateEnemies(npc);
            gom.PopulateInventory(Inventory.GetInventory());
            gom.AddLists();
        }

        public Vector2 playerPositionTransition(Vector2 location)
        {
            Vector2 opt;
            if (location.Y < 150)
            {
                opt = new Vector2(location.X, 400);
            }
            else if (location.Y > 350)
            {
                opt = new Vector2(location.X, 110);
            }
            else if (location.X > 600)
            {
                opt = new Vector2(120, location.Y);
            }
            else if (location.X < 200)
            {
                opt = new Vector2(650, location.Y);
            }
            else
            {
                opt = location;
            }
            return opt;
        }
        public IBlock[] GetBlockObj()
        {
            return Enumerable.Concat(Enumerable.Concat(Enumerable.Concat(block, water).ToArray(), sand).ToArray(), Mblock).ToArray();
        }
        public IBlock[] getMovableBlock()
        {
            return this.Mblock;
        }
        public Item[] GetItemObj()
        {
            return item;
        }
        public NPC1[] GetNpcObj()
        {
            return npc;
        }
        public IBlock[] GetWaterObj()
        {
            return water;
        }
        public IBlock[] GetSandObj()
        {
            return sand;
        }
        public Player GetPlayerObj()
        {
            return player;
        }
        public IProjectile[] GetNPCProjObj()
        {
            foreach (NPC1 element in npc)
            {
                list.AddRange(element.GetSeqList());
            }
            return list.ToArray();
        }

        //not used
        public KeyValuePair<IBlock, String>[] GetDoorPair()
        {
            return null;
        }
    }
}
