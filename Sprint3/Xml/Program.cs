using System;
using System.Text;
using System.Xml;
using System.Collections.Generic;
using System.Linq;



namespace Xml
{
    class Program
    {
        static void Main(string[] args)
        {
            String filename = ("E:\\levelData.xml");

            XmlTextWriter xmlWriter = new XmlTextWriter(filename, System.Text.Encoding.UTF8);
            xmlWriter.Formatting = Formatting.Indented;
            XmlDocument xmlDoc = new XmlDocument();
       

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Level1");
            //create number of rooms 
            Console.WriteLine("how many number of rooms :");
            int numR = int.Parse(Console.ReadLine());
            //*loop to generate data for the rooms
            for (int i = 1; i <= numR; i++)
            {
                xmlWriter.WriteStartElement("room" + XmlConvert.ToString(i));
                xmlWriter.WriteStartElement("type");
                    //start blocks
                    Console.WriteLine("how many number of blocks :");
                    int numB = int.Parse(Console.ReadLine());
                    xmlWriter.WriteStartElement("blocks");
                    xmlWriter.WriteAttributeString("num", XmlConvert.ToString(numB));
                    if (numB > 0)
                    {
                        //generating Bs
                        for (int j = 0; j < numB; j++)
                        {
                            //start a new B
                            xmlWriter.WriteStartElement("B");
                            //asking for loc
                            xmlWriter.WriteStartElement("loc");
                            Console.WriteLine("What is the block's X position:");
                            xmlWriter.WriteElementString("x", Console.ReadLine());
                            Console.WriteLine("What is the block's Y position:");
                            xmlWriter.WriteElementString("y", Console.ReadLine());
                            //end loc
                            xmlWriter.WriteEndElement();
                            //asking for texture
                            Console.WriteLine("What is the Texture of this block:");
                            xmlWriter.WriteElementString("B_texture", Console.ReadLine());
                            //end B
                            xmlWriter.WriteEndElement();
                        }
                    } else xmlWriter.WriteString(null);
                    //end blocks
                    xmlWriter.WriteEndElement();
                    
                    //start items
                    Console.WriteLine("how many number of items :");
                    int numI = int.Parse(Console.ReadLine());
                    xmlWriter.WriteStartElement("items");
                    xmlWriter.WriteAttributeString("num", XmlConvert.ToString(numI));
                    if (numI > 0)
                    {
                        //generating Is
                        for (int j = 0; j < numI; j++)
                        {
                            //start a new I
                            xmlWriter.WriteStartElement("I");
                            //asking for loc
                            xmlWriter.WriteStartElement("loc");
                            Console.WriteLine("What is the item's X position:");
                            xmlWriter.WriteElementString("x", Console.ReadLine());
                            Console.WriteLine("What is the item's Y position:");
                            xmlWriter.WriteElementString("y", Console.ReadLine());
                            //end loc
                            xmlWriter.WriteEndElement();
                            //asking for texture
                            Console.WriteLine("What is the Texture of this item:");
                            xmlWriter.WriteElementString("I_texture", Console.ReadLine());
                            //end I
                            xmlWriter.WriteEndElement();
                        }
                    } else xmlWriter.WriteString(null);
                    //end items
                    xmlWriter.WriteEndElement();

                    //start enemy
                    Console.WriteLine("how many number of enemies :");
                    int numE = int.Parse(Console.ReadLine());
                    xmlWriter.WriteStartElement("enemies");
                    xmlWriter.WriteAttributeString("num", XmlConvert.ToString(numE));
                    if (numE > 0)
                    {
                        //generating Es
                        for (int k = 0; k < numE; k++)
                        {
                            //start a new E
                            xmlWriter.WriteStartElement("E");
                            Console.WriteLine("do you prefer this enemy movable? (true/false)");
                            xmlWriter.WriteAttributeString("move", Console.ReadLine());
                            //asking for the orginal loc
                            xmlWriter.WriteStartElement("loc");
                            Console.WriteLine("What is the  enemy's 1's X position:");
                            xmlWriter.WriteElementString("x", Console.ReadLine());
                            Console.WriteLine("What is the enemy's 1's Y position:");
                            xmlWriter.WriteElementString("y", Console.ReadLine());
                            //end loc
                            xmlWriter.WriteEndElement();
                            //asking for the orginal facing direction
                            Console.WriteLine("What is the enemy's 1's facing direction:");
                            xmlWriter.WriteElementString("dir", Console.ReadLine());
                            //asking for different facing textures
                            xmlWriter.WriteStartElement("E_texture");
                            Console.WriteLine("What is the enemy's upward texture:");
                            xmlWriter.WriteElementString("up", Console.ReadLine());
                            Console.WriteLine("What is the enemy's downward texture:");
                            xmlWriter.WriteElementString("down", Console.ReadLine());
                            Console.WriteLine("What is the enemy's rightward texture:");
                            xmlWriter.WriteElementString("right", Console.ReadLine());
                            Console.WriteLine("What is the enemy's leftward texture:");
                            xmlWriter.WriteElementString("left", Console.ReadLine());
                            //end E_texture
                            xmlWriter.WriteEndElement();
                            //asking for different projectile facing textures
                            xmlWriter.WriteStartElement("projectile");
                            Console.WriteLine("do you prefer the enemy fireble? (true/false)");
                            xmlWriter.WriteAttributeString("fire", Console.ReadLine());
                            Console.WriteLine("What is the projectile upward texture:");
                            xmlWriter.WriteElementString("up", Console.ReadLine());
                            Console.WriteLine("What is the projectile downward texture:");
                            xmlWriter.WriteElementString("down", Console.ReadLine());
                            Console.WriteLine("What is the projectile rightward texture:");
                            xmlWriter.WriteElementString("right", Console.ReadLine());
                            Console.WriteLine("What is the projectile leftward texture:");
                            xmlWriter.WriteElementString("left", Console.ReadLine());
                            //end projectile
                            xmlWriter.WriteEndElement();
                            //asking for set routes
                            Console.WriteLine("route set? (true/false)");
                            if (Convert.ToBoolean(Console.ReadLine()) == true)
                            {
                                //if routes setted, ask for how many locs the enemy can move to let it moving in a loop.
                                xmlWriter.WriteStartElement("routes");
                                Console.WriteLine("how many locations:");
                                int numL = int.Parse(Console.ReadLine());
                                //generating the individual route
                                for (int a = 0; a < numL; a++)
                                {
                                    //start a new R
                                    xmlWriter.WriteStartElement("R");
                                    //asking for every single step in this route's loc
                                    xmlWriter.WriteStartElement("loc");
                                    Console.WriteLine("What is the enemy's " + a + 2 + "'s position:");
                                    xmlWriter.WriteElementString("x", Console.ReadLine());
                                    Console.WriteLine("What is the enemy's " + a + 2 + "'s Y position:");
                                    xmlWriter.WriteElementString("y", Console.ReadLine());
                                    //end loc
                                    xmlWriter.WriteEndElement();
                                    //asking for every single facing direction under the current step
                                    Console.WriteLine("What is the enemy's " + a + 2 + "'s facing direction:");
                                    xmlWriter.WriteElementString("dir", Console.ReadLine());
                                    //end R
                                    xmlWriter.WriteEndElement();
                                }
                                //end routes
                                xmlWriter.WriteEndElement();
                            }
                            else
                            {
                                //if no routes setted for this enemy, just create an empty route tag
                                xmlWriter.WriteElementString("routes", null);
                            }
                            //asking for the enemy's fire timspan
                            Console.WriteLine("What is the enemy's fire timspan:");
                            xmlWriter.WriteElementString("timer", Console.ReadLine());
                            //end E
                            xmlWriter.WriteEndElement();
                        }
                    } else xmlWriter.WriteString(null);
                    //end enemy
                    xmlWriter.WriteEndElement();

                //end type
                xmlWriter.WriteEndElement();
                //end room
                xmlWriter.WriteEndElement();
            }   
            //end level1
            xmlWriter.WriteEndElement();
            //end doc
            xmlWriter.WriteEndDocument();
            xmlWriter.Flush();
            xmlWriter.Close();
                


            }
        }
    }

