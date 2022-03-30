using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint4.State_Machines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Sprint4
{
    public class Room
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
        private List<IProjectile> list;
        private GameObjectManager gom;
        public Room(String room, GameObjectManager gom,  int boundWidth, int boundHeight)
        {
            this.boundWidth = boundWidth;
            this.boundHeight = boundHeight;
            this.gom = gom;
            list = new List<IProjectile>();
            loadRoom(room);
        }

        private void loadRoom(String room)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load("../levelData.xml");
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
                                    this.block[i] = new Block();
                                    this.block[i].SetLocation(loc);
                                    this.block[i].SetBlock(this.Texture);
                                    i++;
                                }
                            }
                        }
                        else {
                            this.block = new Block[0];
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
                                if (element != null)
                                {
                                    XmlNodeList Iinfo = element.ChildNodes;
                                    loc = new Vector2(int.Parse((Iinfo[0].FirstChild).InnerText), int.Parse((Iinfo[0].LastChild).InnerText));
                                    this.Texture = Iinfo[1].InnerText;
                                    this.item[i] = new Item();
                                    this.item[i].SetLocation(loc);
                                    this.item[i].SetItem(this.Texture);
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
                                    //cast here......
                                    this.npc[i].SetDirection((Facing)int.Parse(Einfo[1].InnerText));
                                    XmlNodeList npctextures = Einfo[2].ChildNodes;
                                    this.Textureholder = new List<string>();
                                    this.Textureholder.Add(npctextures[2].InnerText);
                                    this.Textureholder.Add(npctextures[3].InnerText);
                                    this.Textureholder.Add(npctextures[0].InnerText);
                                    this.Textureholder.Add(npctextures[1].InnerText);
                                    this.npc[i].SetNpcList(this.Textureholder);
                                    this.npc[i].SetFireBool(Convert.ToBoolean(Einfo[3].Attributes["fire"].Value));
                                    bool fire = Convert.ToBoolean(Einfo[3].Attributes["fire"].Value);
                                    if (fire)
                                    {
                                        XmlNodeList firetextures = Einfo[3].ChildNodes;
                                        this.Textureholder = new List<string>();
                                        this.Textureholder.Add(firetextures[2].InnerText);
                                        this.Textureholder.Add(firetextures[3].InnerText);
                                        this.Textureholder.Add(firetextures[0].InnerText);
                                        this.Textureholder.Add(firetextures[1].InnerText);
                                        this.npc[i].SetFireBallList(this.Textureholder);
                                    }
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
                                    if (fire)
                                    {
                                        this.npc[i].setTimer(float.Parse(Einfo[5].InnerText));
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

                    //loading player into the player class.
                    player = new Player(this.boundWidth, this.boundHeight);

                }

            }
            gom.ClearLists();
            gom.PopulatePlayers(player);
            gom.PopulateBlocks(block);
            gom.PopulateItems(item);
            gom.PopulateEnemies(npc);
            gom.AddLists();

        }

        //collision will need these func to check objects interactions.(boru might use these funcs)
        public Block[] GetBlockObj()
        {
            return block;
        }

        public IProjectile[] GetNPCProjObj()
		{   
            foreach (NPC1 element in this.npc) {
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

        public Player GetPlayerObj()
        {
            return player;
        }

       
    }
}
