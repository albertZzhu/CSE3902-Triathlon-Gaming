﻿using System;
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


            //*loop to generate data for the rooms
            for (int i = 2; i < 4; i++)
            {
                xmlWriter.WriteStartElement("room");

                xmlWriter.WriteAttributeString("id", XmlConvert.ToString(i));

                //create number of objects 
                Console.WriteLine("how many number of objects in this room"+ XmlConvert.ToString(i)+" :");
                int numOb = int.Parse(Console.ReadLine());
                for (int j = 0; j < numOb; j++) {


                    xmlWriter.WriteStartElement("object");
                    Console.WriteLine("what is the type of this object:");
                    xmlWriter.WriteElementString("type", Console.ReadLine());
                    Console.WriteLine("what is the name of this object:");
                    xmlWriter.WriteElementString("name", Console.ReadLine());
                    Console.WriteLine("what is the file name of the texture");
                    xmlWriter.WriteElementString("texture", Console.ReadLine());
                    xmlWriter.WriteStartElement("position");
                    Console.WriteLine("What is the X position:");
                    xmlWriter.WriteElementString("x", Console.ReadLine());
                    Console.WriteLine("What is the Y position:");
                    xmlWriter.WriteElementString("y", Console.ReadLine());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();

            }
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndDocument();
                xmlWriter.Flush();
                xmlWriter.Close();
                


            }
        }
    }
