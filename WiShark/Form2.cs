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
        private List<string> PacketQueue = new List<string>();
        Dictionary<string, object> treeCommponents = new Dictionary<string, object>();
        private string[] trees = new string[16];
        ArrayList tree = new ArrayList();
        string [,] Trees = new string[2000, 16];

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
        string bHeaderLength = " ";
        string bTimeToLive = " ";
        string bprotocol = " ";
        string bFlags = " ";
        string bsourcePort = " ";
        string bdestPort = " ";
        string bip = " ";
        string bTransmission = " ";

        public Form2()
        {
            InitializeComponent();
            //getdevices();
            button1.Enabled = false;
            button4.Enabled = true;
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
        ICaptureDevice device = Form1.Globals.devices[Form1.Globals.index];
        System.IO.StreamWriter file = new System.IO.StreamWriter("Packet.txt");
        System.IO.StreamWriter File = new System.IO.StreamWriter("Packets.txt");
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



        }

        int ind = 0;
        
        private void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
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
            treeView1.Nodes[2].Nodes[1].Text = bHeaderLength;
            treeView1.Nodes[2].Nodes[2].Text = bTimeToLive;
            treeView1.Nodes[2].Nodes[3].Text = bprotocol;
            treeView1.Nodes[2].Nodes[4].Text = bsource;
            treeView1.Nodes[2].Nodes[5].Text = bdest;
            treeView1.Nodes[3].Nodes[0].Text = bsourcePort;
            treeView1.Nodes[3].Nodes[1].Text = bdestPort;
            treeView1.Nodes[3].Nodes[2].Text = bFlags;
        
            trees.Initialize();
            

            //
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

            if (p.ToString().Length < 500)
            {
                y = p.ToString();
                for (int i = 0; i < y.Length - 1; i++)
                {
                    if (NextHeader == "UDP" && j > 8)
                    { continue; }
                        if (y[i] == ' ')
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
                        temp = " ";
                }
            }


            DateTime time = e.Packet.Timeval.Date;
            var len = e.Packet.Data.Length;
            File.WriteLine(p);
            PacketQueue.Add(y);
            Tim = time.Hour.ToString() + ":" + time.Minute.ToString() + ":" + time.Second.ToString() + "." + time.Millisecond.ToString();
            Len = len.ToString();
            framelentgh = Len;
            capturelength = framelentgh;
            ind--;
            //handling IPV6
            if (Typ == "IpV6")
            {
                ind++;
                No = ind.ToString();
                destPort = TimeToLive;
                sourcePort = protocol;

                frameNum = No;
                protocol = NextHeader;
                HeaderLength = " ";
                TimeToLive = " ";
                Flags = " ";
                Tim = time.ToString();

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
                No = ind.ToString();
                frameNum = No;
                Tim = time.ToString();
                if (protocol == "UDP")
                    destPort = DestPort;
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
            ListViewItem packetitem = new ListViewItem((ind).ToString());
            packetitem.SubItems.Add(Tim);
            packetitem.SubItems.Add(source);
            packetitem.SubItems.Add(dest);
            packetitem.SubItems.Add(protocol);
            packetitem.SubItems.Add(Len);
            packetitem.SubItems.Add(info);

            listView1.Items.Add(packetitem);


        }

        void drawTreeView(string No, string frameNum, string framelentgh, string capturelength, string sourceMac, string destMac, string type, string source, string dest,
            string sourcePort, string destPort, string Tim, string HeaderLength, string TimeToLive, string protocol, string Flags)
        {
            
            // add data of packet to treeview
            //add data of roots
            treeView1.Nodes[0].Text += (No + ": " + framelentgh + " bytes on wire (" + (int.Parse(framelentgh) * 8).ToString() + 
                " bits), " + framelentgh + " bytes captured (" + (int.Parse(framelentgh) * 8).ToString() + " bits) on interface " + Form1.Globals.index.ToString());
            treeView1.Nodes[1].Text += (sourceMac + ", Dst: " + destMac);
            treeView1.Nodes[2].Text += (source + ", Dst: " + dest);
            if (protocol == "UDP")
            { treeView1.Nodes[3].Text = ("User Datagram Protocol, Src Port: " + sourcePort + ", Dst Port: " + destPort); }
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
            treeView1.Nodes[2].Nodes[1].Text += HeaderLength;
            treeView1.Nodes[2].Nodes[2].Text += TimeToLive;
            treeView1.Nodes[2].Nodes[3].Text += protocol;
            treeView1.Nodes[2].Nodes[4].Text += source;
            treeView1.Nodes[2].Nodes[5].Text += dest;
            //add data to nades of root 3 (Transmission)
            treeView1.Nodes[3].Nodes[0].Text += sourcePort;
            treeView1.Nodes[3].Nodes[1].Text += destPort;
            treeView1.Nodes[3].Nodes[2].Text += Flags;
        }

          void addItemsToList(string No, string frameNum, string framelentgh, string capturelength, string sourceMac, string destMac, string type, string source, string dest,
              string sourcePort, string destPort, string Tim, string HeaderLength, string TimeToLive, string protocol, string Flags)
          {
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
              // add data to list
              trees[0]=No;//0
              trees[1]=Tim;//1
              trees[2]=frameNum;//2
              trees[3]=framelentgh;//3
              trees[4]=capturelength;//4
              trees[5]=destMac;//5
              trees[6]=sourceMac;//6
              trees[7]=type;//7
              trees[8]=HeaderLength;//8
              trees[9]=TimeToLive;//9
              trees[10]=protocol;//10
              trees[11]=source;//11
              trees[12]=dest;//12
              trees[13]=sourcePort;//13
              trees[14]=destPort;//14
              trees[15]=Flags;//15
            
              treeCommponents.Add(No, trees) ;
            
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
            device.StopCapture();
            device.Close();
            button2.Enabled = false;
            button3.Enabled = false;
            button1.Enabled = true;
            button4.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //restart button
            listView1.Items.Clear();
            ind = 0;
            device.StopCapture();
            device.Close();
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
            file.Close();
            File.Close();
            Form1 x = new Form1();
            x.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //apply filter  button
            //getPackets();
        }

      
        int indexOfSelected = 0;

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                indexOfSelected = listView1.SelectedIndices[0];

                drawTreeView(Trees[indexOfSelected, 0], Trees[indexOfSelected, 2], Trees[indexOfSelected, 3], Trees[indexOfSelected, 4], Trees[indexOfSelected, 6], Trees[indexOfSelected, 5],
                   Trees[indexOfSelected, 7], Trees[indexOfSelected, 11], Trees[indexOfSelected, 12], Trees[indexOfSelected, 13], Trees[indexOfSelected, 14], Trees[indexOfSelected, 1], 
                   Trees[indexOfSelected, 8], Trees[indexOfSelected, 9], Trees[indexOfSelected, 10], Trees[indexOfSelected, 15]);
            }
           
        }




        void initialNodes()
        {
            // retrieve nodes initial text
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
            treeView1.Nodes[2].Nodes[1].Text = bHeaderLength;
            treeView1.Nodes[2].Nodes[2].Text = bTimeToLive;
            treeView1.Nodes[2].Nodes[3].Text = bprotocol;
            treeView1.Nodes[2].Nodes[4].Text = bsource;
            treeView1.Nodes[2].Nodes[5].Text = bdest;
            treeView1.Nodes[3].Nodes[0].Text = bsourcePort;
            treeView1.Nodes[3].Nodes[1].Text = bdestPort;
            treeView1.Nodes[3].Nodes[2].Text = bFlags;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //clear filter button
            MessageBox.Show(indexOfSelected.ToString());
            textBox1.Text = "";

        }

        














    }
}

