using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;
using SharpPcap.AirPcap;
using SharpPcap.WinPcap;

namespace WiShark
{
    public partial class Form2 : Form
    {
        public static class Globals
        {

        }
        string [,] Trees = new string[2000, 16];
        string[] packetarrayinfo = new string[2000];

        string bframe = " ";
        string bTim = " ";
        string bframeNum = " ";
        string bframelentgh = " ";
        string bcapturelength = " ";
        string binterface = " ";
        string bethernet = " ";
        string bsource = " ";
        string bsourceMac = " ";
        string bdest = " ";
        string bdestMac = " ";
        string btype;
        string bversion = " ";
        string bHeaderLength = " ";
        string bTimeToLive = " ";
        string bprotocol = " ";
        string bFlags = " ";
        string bsourcePort = " ";
        string bdestPort = " ";
        string bip = " ";
        string bTransmission = " ";

        string Filt = " ";
        int ind = 0;
        bool Flag = false;
        ICaptureDevice device = Form1.Globals.devices[Form1.Globals.index];
       // System.IO.StreamWriter file = new System.IO.StreamWriter("Packet.txt");
        //System.IO.StreamWriter File = new System.IO.StreamWriter("Packets.txt");


        public Form2()
        {
            InitializeComponent();
            //getdevices();
            button1.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = false;

            getPackets();

            //save nodes initial text
            bframe = treeView1.Nodes[0].Text;
            bframeNum = treeView1.Nodes[0].Nodes[4].Text; ;
            bframelentgh = treeView1.Nodes[0].Nodes[5].Text; ;
            bcapturelength = treeView1.Nodes[0].Nodes[6].Text; ;
            bethernet = treeView1.Nodes[1].Text;
            bip = treeView1.Nodes[2].Text;
            bTransmission = treeView1.Nodes[3].Text;
            binterface = treeView1.Nodes[0].Nodes[0].Text;
            bTim = treeView1.Nodes[0].Nodes[2].Text;
            bsourceMac = treeView1.Nodes[1].Nodes[1].Text;
            bdestMac = treeView1.Nodes[1].Nodes[0].Text;
            btype = treeView1.Nodes[1].Nodes[2].Text;
            bversion = treeView1.Nodes[2].Nodes[0].Text;
            bHeaderLength = treeView1.Nodes[2].Nodes[1].Text;
            bTimeToLive = treeView1.Nodes[2].Nodes[2].Text;
            bprotocol = treeView1.Nodes[2].Nodes[3].Text;
            bsource = treeView1.Nodes[2].Nodes[4].Text;
            bdest = treeView1.Nodes[2].Nodes[5].Text;
            bsourcePort = treeView1.Nodes[3].Nodes[0].Text;
            bdestPort = treeView1.Nodes[3].Nodes[1].Text;
            bFlags = treeView1.Nodes[3].Nodes[2].Text;

        }
        void getdevices()
        {
            Form1 n = new Form1();
            n.Show();
            this.Hide();
        }
       
        void getPackets()
        {

            
            // Register our handler function to the 'packet arrival' event
            device.OnPacketArrival +=
                new PacketArrivalEventHandler(device_OnPacketArrival);

            // Open the device for capturing
            int readTimeoutMilliseconds = 1000;
            device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);
            // Start the capturing process
            device.StartCapture();

            if (ind >= 2000)
            {
                device.StopCapture();
            }


        }

        
        private void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            if (ind >= 2000)
                return;
            //retrieve initial state of treeView
            treeView1.Nodes[0].Text = bframe;
            treeView1.Nodes[1].Text = bethernet;
            treeView1.Nodes[2].Text = bip;
            treeView1.Nodes[3].Text = bTransmission;
            treeView1.Nodes[0].Nodes[0].Text = binterface;
            treeView1.Nodes[0].Nodes[2].Text = bTim;
            treeView1.Nodes[0].Nodes[4].Text = bframeNum;
            treeView1.Nodes[0].Nodes[5].Text = bframelentgh;
            treeView1.Nodes[0].Nodes[6].Text = bcapturelength;
            treeView1.Nodes[1].Nodes[1].Text = bsourceMac;
            treeView1.Nodes[1].Nodes[0].Text = bdestMac;
            treeView1.Nodes[1].Nodes[2].Text = btype;
            treeView1.Nodes[2].Nodes[0].Text = bversion;
            treeView1.Nodes[2].Nodes[1].Text = bHeaderLength;
            treeView1.Nodes[2].Nodes[2].Text = bTimeToLive;
            treeView1.Nodes[2].Nodes[3].Text = bprotocol;
            treeView1.Nodes[2].Nodes[4].Text = bsource;
            treeView1.Nodes[2].Nodes[5].Text = bdest;
            treeView1.Nodes[3].Nodes[0].Text = bsourcePort;
            treeView1.Nodes[3].Nodes[1].Text = bdestPort;
            treeView1.Nodes[3].Nodes[2].Text = bFlags;
        
            

            //define names of packet data
            string No = " ";
            string Tim = " ";
            string Len = " ";
            string Typ = " ";
            string source = " ";
            string sourceMac = " ";
            string dest = " ";
            string destMac = " ";
            string HeaderLength = " ";
            string TimeToLive = " ";
            string protocol = " ";
            string Flags = " ";
            string sourcePort = " ";
            string destPort = " ";
            string DestPort = " ";
            string frameNum = " ";
            string framelentgh = " ";
            string capturelength = " ";
            string NextHeader = " ";
        


            Packet p = PacketDotNet.Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
            String y = " ";
            int j = 0, k = 1, z = 1, Sq = 1;
            string temp = " ";

            // retrieving data from packets

            if (p != null)
            {
                y = p.ToString();
                
                for (int i = 0; i < y.Length ; i++)
                {
                    /*if (j == 8 && Sq < (y.Length - 1))
                        j++;
                   /* if ()
                    { continue; }*/
                    if (y[i] == ' ' )//&& Sq < (y.Length - 1))
                            j++;

                        if (y[i] == '=')
                            k = i;

                        if (y[i] == ']')
                            Sq = i;

                        if (j < 11)
                        {
                            if (y[i] == ',')
                                z = i;
                        }
                        else
                        {
                            z = (y.Length - 1);
                        }
                        if ((z - k) < y.Length && (z - k) > 0)
                            temp = y.Substring(k + 1, (z - k) - 1);

                        if (j == 1) //ethernet source
                            sourceMac = temp;

                        if (j == 2) //ethernet destination
                            destMac = temp;

                        if (j == 3) //ethernet type
                        {
                            if ((Sq - k) < y.Length && (Sq - k) > 0)
                                temp = y.Substring(k + 1, (Sq - k) - 1);

                            Typ = temp;
                        }

                        if (j == 4) //IP source
                        {
                            source = temp;
                        }
                        if (j == 5) //IP destination
                        {
                            dest = temp;
                        }
                        if (j == 6) //IP Header length
                        {
                            if (Sq > z)
                            {
                                if ((Sq - k) < y.Length && (Sq - k) > 0)
                                    temp = y.Substring(k + 1, (Sq - k) - 1);
                                NextHeader = temp;
                            }
                            else
                            {
                                HeaderLength = temp;
                            }
                        }

                        if (j == 7) //IP Protocol
                        {
                            protocol = temp;
                        }
                        if (j == 8) //IP Time To Live
                        {
                            if (Sq > z)
                            {
                                if ((Sq - k) < y.Length && (Sq - k) > 0)
                                    temp = y.Substring(k + 1, (Sq - k) - 1);
                                TimeToLive = temp;
                            }
                            else
                            {
                                TimeToLive = temp;
                            }
                        }
                        if (j == 9) //Transmission source port
                        {
                            sourcePort = temp;
                        }
                        if (j == 10) //Transmission destination port
                        {
                            if (Sq > z)
                            {
                                if ((Sq - k) < y.Length && (Sq - k) > 0)
                                    temp = y.Substring(k + 1, (Sq - k) - 1);
                                DestPort = temp;
                            }
                            else
                            {
                                destPort = temp;
                            }
                            
                        }
                        if (j == 11) //Transmission flags
                        {
                            Flags = temp;
                        }
                       // temp = " ";
                }
            }


            DateTime time = e.Packet.Timeval.Date;
            var len = e.Packet.Data.Length;
            Tim = time.Hour.ToString() + ":" + time.Minute.ToString() + ":" + time.Second.ToString() + "." + time.Millisecond.ToString();
            Len = len.ToString();
            framelentgh = Len;
            capturelength = framelentgh;
            ind--;
            //handling IPV6
            if (Typ == "IpV6")
            {
                ind++;
                packetarrayinfo[ind] = y;
                No = ind.ToString();
                destPort = TimeToLive;
                sourcePort = protocol;

                frameNum = No;
                protocol = NextHeader;
                HeaderLength = " ";
                TimeToLive = " ";
                Flags = " ";
                Tim = time.ToString();

                //making filter
                if (Filt != " ")
                {
                    if (protocol != Filt)
                    {
                        return;
                    }
                }
                
                // adding data to list view
                drawListView(No, Tim, source, dest, protocol, Len, p.ToString());


                // add data of packet to treeview
                drawTreeView(No, frameNum, framelentgh, capturelength, sourceMac, destMac, Typ, source, dest, sourcePort, destPort, Tim, HeaderLength, TimeToLive, protocol, Flags);

               addItemsToList(No, frameNum, framelentgh, capturelength, sourceMac, destMac, Typ, source, dest, sourcePort, destPort, Tim, HeaderLength, TimeToLive, protocol, Flags);

            }

            //handling IPV4
            if (Typ == "IpV4")
            {
                ind++;
                packetarrayinfo[ind] = y;
                No = ind.ToString();
                frameNum = No;
                Tim = time.ToString();
                if (protocol == "UDP")
                    destPort = DestPort;

                //making filter
                if (Filt != " ")
                {
                    if (protocol != Filt)
                    {
                        return;
                    }
                }
                // adding data to list view
                drawListView(No, Tim, source, dest, protocol, Len, p.ToString());



                // add data of packet to treeview
                drawTreeView(No, frameNum, framelentgh, capturelength, sourceMac, destMac, Typ, source, dest, sourcePort, destPort, Tim, HeaderLength, TimeToLive, protocol, Flags);

                addItemsToList(No, frameNum, framelentgh, capturelength, sourceMac, destMac, Typ, source, dest, sourcePort, destPort, Tim, HeaderLength, TimeToLive, protocol, Flags);



            }
            
          
            ind++;
        }

        void drawListView(string No, string Tim, string source, string dest, string protocol, string Len, string info)
        {
            // adding data to list view
            if (Filt != " ")
            {
                ListViewItem packetitem = new ListViewItem(No);
                packetitem.SubItems.Add(Tim);
                packetitem.SubItems.Add(source);
                packetitem.SubItems.Add(dest);
                packetitem.SubItems.Add(protocol);
                packetitem.SubItems.Add(Len);
                packetitem.SubItems.Add(info);

                listView1.Items.Add(packetitem);
            }
            else
            {
                ListViewItem packetitem = new ListViewItem((ind).ToString());
                packetitem.SubItems.Add(Tim);
                packetitem.SubItems.Add(source);
                packetitem.SubItems.Add(dest);
                packetitem.SubItems.Add(protocol);
                packetitem.SubItems.Add(Len);
                packetitem.SubItems.Add(info);

                listView1.Items.Add(packetitem);
            }


        }

        void drawTreeView(string No, string frameNum, string framelentgh, string capturelength, string sourceMac, string destMac, string type, string source, string dest,
            string sourcePort, string destPort, string Tim, string HeaderLength, string TimeToLive, string protocol, string Flags)
        {
            
            // add data of packet to treeview
            //add data of roots
            treeView1.Nodes[0].Text += (No + ": " + framelentgh + " bytes on wire (" + (int.Parse(framelentgh) * 8).ToString() + 
                " bits), " + framelentgh + " bytes captured (" + (int.Parse(framelentgh) * 8).ToString() + " bits) on interface " + Form1.Globals.index.ToString());
            treeView1.Nodes[1].Text += (sourceMac + ", Dst: " + destMac);
            treeView1.Nodes[2].Text += (type[(type.Length - 1)].ToString() + ", Src: " + source + ", Dst: " + dest);
            if (protocol == "UDP")
            { treeView1.Nodes[3].Text = ("User Datagram Protocol, Src Port: " + sourcePort + ", Dst Port: " + destPort); }
            else if (protocol == "IGMP")
            { treeView1.Nodes[3].Text = "Internet Group Management Protocol"; }
            else if (protocol == "ICMPV6")
            { treeView1.Nodes[3].Text = "Internet Control Message Protocol v6"; }
            else { treeView1.Nodes[3].Text += (sourcePort + ", Dst Port: " + destPort); }
            //add data to nades of root 0 (frame)
            treeView1.Nodes[0].Nodes[0].Text += (Form1.Globals.index.ToString() + " " + Form1.Globals.devices[Form1.Globals.index].Name.ToString());
            treeView1.Nodes[0].Nodes[2].Text += Tim;
            treeView1.Nodes[0].Nodes[4].Text += frameNum;
            treeView1.Nodes[0].Nodes[5].Text += framelentgh + " bytes";
            treeView1.Nodes[0].Nodes[6].Text += capturelength + " bytes";
            //add data to nades of root 1 (ethernet)
            treeView1.Nodes[1].Nodes[1].Text += sourceMac;
            treeView1.Nodes[1].Nodes[0].Text += destMac;
            treeView1.Nodes[1].Nodes[2].Text += type;
            //add data to nades of root 2 (IP)
            treeView1.Nodes[2].Nodes[0].Text += type[(type.Length - 1)];
            treeView1.Nodes[2].Nodes[1].Text += HeaderLength;
            treeView1.Nodes[2].Nodes[2].Text += TimeToLive;
            treeView1.Nodes[2].Nodes[3].Text += protocol;
            treeView1.Nodes[2].Nodes[4].Text += source;
            treeView1.Nodes[2].Nodes[5].Text += dest;
            //add data to nades of root 3 (Transmission)
            if (protocol == "IGMP")
            {
                treeView1.Nodes[3].Nodes[0].Text = "Type: " + sourcePort;
                treeView1.Nodes[3].Nodes[1].Text = "Max Resp Time: " + destPort;
                treeView1.Nodes[3].Nodes[2].Text = "Multicast Address: " + Flags;
            }
            else if (protocol == "ICMPV6")
            {
                treeView1.Nodes[3].Nodes[0].Text = "Type: " + sourcePort;
                treeView1.Nodes[3].Nodes[1].Text =  "Code: 0" + destPort;
                treeView1.Nodes[3].Nodes[2].Text += Flags;
            }
                
            else
            {
                treeView1.Nodes[3].Nodes[0].Text += sourcePort;
                treeView1.Nodes[3].Nodes[1].Text += destPort;
                treeView1.Nodes[3].Nodes[2].Text += Flags;
            }
        }

          void addItemsToList(string No, string frameNum, string framelentgh, string capturelength, string sourceMac, string destMac, string type, string source, string dest,
              string sourcePort, string destPort, string Tim, string HeaderLength, string TimeToLive, string protocol, string Flags)
          {
              if (int.Parse(No) < 2000)
              {
                  //add packet data to 2D array
                  Trees[int.Parse(No), 0] = No;
                  Trees[int.Parse(No), 1] = Tim;
                  Trees[int.Parse(No), 2] = frameNum;
                  Trees[int.Parse(No), 3] = framelentgh;
                  Trees[int.Parse(No), 4] = capturelength;
                  Trees[int.Parse(No), 5] = destMac;
                  Trees[int.Parse(No), 6] = sourceMac;
                  Trees[int.Parse(No), 7] = type;
                  Trees[int.Parse(No), 8] = HeaderLength;
                  Trees[int.Parse(No), 9] = TimeToLive;
                  Trees[int.Parse(No), 10] = protocol;
                  Trees[int.Parse(No), 11] = source;
                  Trees[int.Parse(No), 12] = dest;
                  Trees[int.Parse(No), 13] = sourcePort;
                  Trees[int.Parse(No), 14] = destPort;
                  Trees[int.Parse(No), 15] = Flags;
              }
            
          }


        private void button1_Click(object sender, EventArgs e)
        {
            
            //start button
            listView1.Items.Clear();
            ind = 0;
            getPackets();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = false;

            //retrieve initial state of treeView
            treeView1.Nodes[0].Text = bframe;
            treeView1.Nodes[1].Text = bethernet;
            treeView1.Nodes[2].Text = bip;
            treeView1.Nodes[3].Text = bTransmission;
            treeView1.Nodes[0].Nodes[0].Text = binterface;
            treeView1.Nodes[0].Nodes[2].Text = bTim;
            treeView1.Nodes[0].Nodes[4].Text = bframeNum;
            treeView1.Nodes[0].Nodes[5].Text = bframelentgh;
            treeView1.Nodes[0].Nodes[6].Text = bcapturelength;
            treeView1.Nodes[1].Nodes[1].Text = bsourceMac;
            treeView1.Nodes[1].Nodes[0].Text = bdestMac;
            treeView1.Nodes[1].Nodes[2].Text = btype;
            treeView1.Nodes[2].Nodes[0].Text = bversion;
            treeView1.Nodes[2].Nodes[1].Text = bHeaderLength;
            treeView1.Nodes[2].Nodes[2].Text = bTimeToLive;
            treeView1.Nodes[2].Nodes[3].Text = bprotocol;
            treeView1.Nodes[2].Nodes[4].Text = bsource;
            treeView1.Nodes[2].Nodes[5].Text = bdest;
            treeView1.Nodes[3].Nodes[0].Text = bsourcePort;
            treeView1.Nodes[3].Nodes[1].Text = bdestPort;
            treeView1.Nodes[3].Nodes[2].Text = bFlags;
        
        }



        private void button3_Click(object sender, EventArgs e)
        {
            //stop button
            Flag = true;
            device.StopCapture();
            device.Close();
            button2.Enabled = false;
            button3.Enabled = false;
            button1.Enabled = true;
            button5.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //restart button
            listView1.Items.Clear();
            ind = 0;
            device.StopCapture();
            device.Close();
            button5.Enabled = false;

            //retrieve initial state of treeView
            treeView1.Nodes[0].Text = bframe;
            treeView1.Nodes[1].Text = bethernet;
            treeView1.Nodes[2].Text = bip;
            treeView1.Nodes[3].Text = bTransmission;
            treeView1.Nodes[0].Nodes[0].Text = binterface;
            treeView1.Nodes[0].Nodes[2].Text = bTim;
            treeView1.Nodes[0].Nodes[4].Text = bframeNum;
            treeView1.Nodes[0].Nodes[5].Text = bframelentgh;
            treeView1.Nodes[0].Nodes[6].Text = bcapturelength;
            treeView1.Nodes[1].Nodes[1].Text = bsourceMac;
            treeView1.Nodes[1].Nodes[0].Text = bdestMac;
            treeView1.Nodes[1].Nodes[2].Text = btype;
            treeView1.Nodes[2].Nodes[0].Text = bversion;
            treeView1.Nodes[2].Nodes[1].Text = bHeaderLength;
            treeView1.Nodes[2].Nodes[2].Text = bTimeToLive;
            treeView1.Nodes[2].Nodes[3].Text = bprotocol;
            treeView1.Nodes[2].Nodes[4].Text = bsource;
            treeView1.Nodes[2].Nodes[5].Text = bdest;
            treeView1.Nodes[3].Nodes[0].Text = bsourcePort;
            treeView1.Nodes[3].Nodes[1].Text = bdestPort;
            treeView1.Nodes[3].Nodes[2].Text = bFlags;
        
            getPackets();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //back button
            device.StopCapture();
            device.Close();
            
            Form1 x = new Form1();
            x.Show();
            this.Hide();
        }

     
      
        int indexOfSelected = 0;

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //retrieve initial state of treeView
            treeView1.Nodes[0].Text = bframe;
            treeView1.Nodes[1].Text = bethernet;
            treeView1.Nodes[2].Text = bip;
            treeView1.Nodes[3].Text = bTransmission;
            treeView1.Nodes[0].Nodes[0].Text = binterface;
            treeView1.Nodes[0].Nodes[2].Text = bTim;
            treeView1.Nodes[0].Nodes[4].Text = bframeNum;
            treeView1.Nodes[0].Nodes[5].Text = bframelentgh;
            treeView1.Nodes[0].Nodes[6].Text = bcapturelength;
            treeView1.Nodes[1].Nodes[1].Text = bsourceMac;
            treeView1.Nodes[1].Nodes[0].Text = bdestMac;
            treeView1.Nodes[1].Nodes[2].Text = btype;
            treeView1.Nodes[2].Nodes[0].Text = bversion;
            treeView1.Nodes[2].Nodes[1].Text = bHeaderLength;
            treeView1.Nodes[2].Nodes[2].Text = bTimeToLive;
            treeView1.Nodes[2].Nodes[3].Text = bprotocol;
            treeView1.Nodes[2].Nodes[4].Text = bsource;
            treeView1.Nodes[2].Nodes[5].Text = bdest;
            treeView1.Nodes[3].Nodes[0].Text = bsourcePort;
            treeView1.Nodes[3].Nodes[1].Text = bdestPort;
            treeView1.Nodes[3].Nodes[2].Text = bFlags;
        


            if (listView1.SelectedIndices.Count > 0)
            {
                if (Filt == " ")
                {
                    indexOfSelected = listView1.SelectedIndices[0];
                }
                else { indexOfSelected = int.Parse(listView1.Items[listView1.SelectedIndices[0]].Text); }
                drawTreeView(Trees[indexOfSelected, 0], Trees[indexOfSelected, 2], Trees[indexOfSelected, 3], Trees[indexOfSelected, 4], 
                    Trees[indexOfSelected, 6], Trees[indexOfSelected, 5], Trees[indexOfSelected, 7], Trees[indexOfSelected, 11], 
                    Trees[indexOfSelected, 12], Trees[indexOfSelected, 13], Trees[indexOfSelected, 14], Trees[indexOfSelected, 1], 
                   Trees[indexOfSelected, 8], Trees[indexOfSelected, 9], Trees[indexOfSelected, 10], Trees[indexOfSelected, 15]);
            }
           
        }



        private void button5_Click(object sender, EventArgs e)
        {
            //clear filter button
           textBox1.Text = " ";
           listView1.Items.Clear();
           
            for (int i = 0; i < ind; i++)
           {
               drawListView(Trees[i, 0], Trees[i, 1], Trees[i, 11], Trees[i, 12], Trees[i, 10], Trees[i, 3], packetarrayinfo[i]);
               drawTreeView(Trees[i, 0], Trees[i, 2], Trees[i, 3], Trees[i, 4], Trees[i, 6], Trees[i, 5], Trees[i, 7],
               Trees[i, 11], Trees[i, 12], Trees[i, 13], Trees[i, 14], Trees[i, 1], Trees[i, 8], Trees[i, 9], Trees[i, 10], Trees[i, 15]);
           }
           ind++;
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //apply filter  button
            Filt = textBox1.Text;
            listView1.Items.Clear();
            indexOfSelected = 0;
           
            for (int i = 0; i < ind; i++)
            {
                if (Trees[i, 10] == Filt)
                {
                    drawListView(Trees[i, 0], Trees[i, 1], Trees[i, 11], Trees[i, 12], Trees[i, 10], Trees[i, 3], packetarrayinfo[i]);
                    drawTreeView(Trees[i, 0], Trees[i, 2], Trees[i, 3], Trees[i, 4], Trees[i, 6], Trees[i, 5], Trees[i, 7], 
                        Trees[i, 11], Trees[i, 12], Trees[i, 13], Trees[i, 14], Trees[i, 1], Trees[i, 8], Trees[i, 9], Trees[i, 10], Trees[i, 15]);
                }
            }
            ind++;
            
            //getPackets();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Close App button
            device.StopCapture();
            device.Close();
            Application.Exit();
        }

       

        

       

        














    }
}

