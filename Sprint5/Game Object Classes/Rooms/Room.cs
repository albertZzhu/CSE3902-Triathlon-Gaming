﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprint5.State_Machines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Sprint5
{
    public class Room
    {
        //block obj holder variables
        private IBlock[] block;
        //MOVABLE_Block obj holder variables
        private IBlock[] Mblock;
        //door pair holder variables
        private KeyValuePair<IBlock, String>[] door;
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
        private NPC1[] npc;
        private List<String> Textureholder;
        //player variables
        //game window edges
        private int boundWidth;
        private int boundHeight;
        private List<IProjectile> list;
        private GameObjectManager gom;
        public Room(String room, GameObjectManager gom, int boundWidth, int boundHeight, Player player=null)
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
            xml.Load("Content\\LevelData2.xml");
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
                        else {
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
                    //loading doors into the door pair holder.
                    XmlNode door = type.SelectSingleNode("door");
                    if (door != null)
                    {
                        int i = 0;
                        int num = int.Parse(door.Attributes["num"].Value);
                        if (num != 0)
                        {
                            this.door = new KeyValuePair<IBlock, String>[num];
                            XmlNodeList list = door.ChildNodes;
                            foreach (XmlElement element in list)
                            {
                                if (!element.IsEmpty)
                                {
                                    XmlNodeList Dinfo = element.ChildNodes;
                                    loc = new Vector2(int.Parse((Dinfo[0].FirstChild).InnerText), int.Parse((Dinfo[0].LastChild).InnerText));
                                    Texture = Dinfo[1].InnerText;
                                    switch (i)
                                    {
                                        case 0:
                                            this.door[i] = new KeyValuePair<IBlock, String>(new Door(Texture, loc, Side.side.up), Dinfo[2].InnerText);
                                            break;
                                        case 1:
                                            this.door[i] = new KeyValuePair<IBlock, String>(new Door(Texture, loc, Side.side.right), Dinfo[2].InnerText);
                                            break;
                                        case 2:
                                            this.door[i] = new KeyValuePair<IBlock, String>(new Door(Texture, loc, Side.side.down), Dinfo[2].InnerText);
                                            break;
                                        case 3:
                                            this.door[i] = new KeyValuePair<IBlock, String>(new Door(Texture, loc, Side.side.left), Dinfo[2].InnerText);
                                            break;
                                    }
                                }
                                else this.door[i] = new KeyValuePair<IBlock, String>(null, "nothing");
                                i++;
                            }
                        }
                        else
                        {
                            this.door = new KeyValuePair<IBlock, String>[0];
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
                        else { 
                            this.item = new Item[0];
                        }
                    }
                    //loading npcs into the npc obj holder.
                    XmlNode enemy = type.SelectSingleNode("enemies");
                    if (enemy != null)
                    {
                        int i = 0;
                        int num = int.Parse(enemy.Attributes["num"].Value);
                        if (num != 0)
                        {
                            npc = new NPC1[num];
                            XmlNodeList list = enemy.ChildNodes;
                            foreach (XmlElement element in list)
                            {
                                if (!element.IsEmpty)
                                {
                                    XmlNodeList Einfo = element.ChildNodes;
                                    npc[i] = new NPC1(boundWidth, boundHeight);
                                    npc[i].SetMoveBool(Convert.ToBoolean(element.Attributes["move"].Value));
                                    npc[i].SetLocation(new Vector2(int.Parse((Einfo[0].FirstChild).InnerText), int.Parse((Einfo[0].LastChild).InnerText)));
                                    //cast here......
                                    npc[i].SetDirection((FacingEnum)int.Parse(Einfo[1].InnerText));
                                    XmlNodeList npctextures = Einfo[2].ChildNodes;
                                    Textureholder = new List<string>();
                                    Textureholder.Add(npctextures[2].InnerText);
                                    Textureholder.Add(npctextures[3].InnerText);
                                    Textureholder.Add(npctextures[0].InnerText);
                                    Textureholder.Add(npctextures[1].InnerText);
                                    npc[i].SetNpcList(Textureholder);
                                    npc[i].SetFireBool(Convert.ToBoolean(Einfo[3].Attributes["fire"].Value));
                                    bool fire = Convert.ToBoolean(Einfo[3].Attributes["fire"].Value);
                                    if (fire)
                                    {
                                        XmlNodeList firetextures = Einfo[3].ChildNodes;
                                        Textureholder = new List<string>();
                                        Textureholder.Add(firetextures[2].InnerText);
                                        Textureholder.Add(firetextures[3].InnerText);
                                        Textureholder.Add(firetextures[0].InnerText);
                                        Textureholder.Add(firetextures[1].InnerText);
                                        npc[i].SetFireBallList(Textureholder);
                                    }
                                    if (Einfo[4].ChildNodes.Count != 0)
                                    {
                                        var routes = new List<KeyValuePair<Vector2, int>>();
                                        XmlNodeList route = Einfo[4].ChildNodes;
                                        foreach (XmlNode r in route)
                                        {
                                            routes.Add(new KeyValuePair<Vector2, int>(new Vector2(int.Parse((r.FirstChild.FirstChild).InnerText), int.Parse((r.FirstChild.LastChild).InnerText)), int.Parse((r.LastChild).InnerText)));

                                        }
                                        npc[i].SetRoute(routes);
                                    }
                                    else npc[i].SetRoute(null);
                                    if (fire)
                                    {
                                        npc[i].setTimer(float.Parse(Einfo[5].InnerText));
                                    }
                                    i++;
                                }
                            }
                        }
                        else
                        {
                            this.npc = new NPC1[0];
                        }
                    }
                    if(oldPlayer != null)
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
            //gom.PopulateWater(water);
            //gom.PopulateDoor(door);
            //gom.PopulateSand(sand);
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
            }else 
            {
                opt = location;
            }
            return opt;
        }

        //collision will need these func to check objects interactions.(boru might use these funcs)
        public IBlock[] GetBlockObj()
        {

            List<IBlock> door1 = new List<IBlock>();
            for (int i = 0; i < 4; i++)
            {
                if (door[i].Key != null)
                {
                    door1.Add(door[i].Key);
                }
            }
                return Enumerable.Concat(Enumerable.Concat(Enumerable.Concat(Enumerable.Concat(block, door1.ToArray()).ToArray(), water).ToArray(), sand).ToArray(), Mblock).ToArray();
        }

        public IBlock[] getMovableBlock()
        {
            return this.Mblock;
        }
        public IProjectile[] GetNPCProjObj()
		{   
            foreach (NPC1 element in npc) {
                list.AddRange(element.GetSeqList());
            }
            return list.ToArray();
		}

        public Item[] GetItemObj()
        {
            return item;
        }

        public NPC1[] GetNpcObj()
        {
            return npc;
        }

        public KeyValuePair<IBlock, String>[] GetDoorPair()
        {
            return door;
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

    }
}