using System;
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
        private List<List<string>> treeCommponents = new List<List<string>>();
        private List<string> trees = new List<string>();

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
        System.IO.StreamWriter file = new System.IO.StreamWriter("Packet.txt");
        System.IO.StreamWriter File = new System.IO.StreamWriter("Packets.txt");
        private void device_OnPacketArrival(object sender, CaptureEventArgs e)
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
                            if ((Sq - k) < y.Length && (Sq - k) > 0)
                                temp = y.Substring(k + 1, (Sq - k) - 1);

                            TimeToLive = temp;
                        }
                        if (j == 9) //Transmission source port
                        {
                            sourcePort = temp;
                        }
                        if (j == 10) //Transmission destination port
                        {
                            destPort = temp;
                        }
                        if (j == 11) //Transmission flags
                        {
                            Flags = temp;
                        }
                    
                }
            }


            DateTime time = e.Packet.Timeval.Date;
            var len = e.Packet.Data.Length;
            file.WriteLine();
            File.WriteLine(p);
            PacketQueue.Add(y);
            Tim = time.Hour.ToString() + ":" + time.Minute.ToString() + ":" + time.Second.ToString() + "." + time.Millisecond.ToString();
            Len = len.ToString();
            framelentgh = Len;
            capturelength = framelentgh;
            ind--;
            //handling UDP
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

            if (protocol == "UDP")
            {
                ind++;
                No = ind.ToString();
                frameNum = No;
                Flags = " ";
                Tim = time.ToString();

                // adding data to list view
                drawListView(No, Tim, source, dest, protocol, Len, p.ToString());
            

                // add data of packet to treeview
                drawTreeView(No, frameNum, framelentgh, capturelength, sourceMac, destMac, Typ, source, dest, sourcePort, destPort, Tim, HeaderLength, TimeToLive, protocol, Flags);

                addItemsToList(No, frameNum, framelentgh, capturelength, sourceMac, destMac, Typ, source, dest, sourcePort, destPort, Tim, HeaderLength, TimeToLive, protocol, Flags);

            }
            //assigning packet data to views
            if (protocol == "TCP")
            {
                ind++;
                No = ind.ToString();
                frameNum = No;
                Tim = time.ToString();

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
            ListViewItem packetitem = new ListViewItem((ind + 1).ToString());
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
            treeView1.Nodes[0].Text += No;
            treeView1.Nodes[1].Text += (sourceMac + ", Dst: " + destMac);
            treeView1.Nodes[2].Text += (source + ", Dst: " + dest);
            if (protocol == "UDP")
            { treeView1.Nodes[3].Text = ("User Datagram Protocol, Src Port: " + sourcePort + ", Dst Port: " + destPort); }
            else { treeView1.Nodes[3].Text += (sourcePort + ", Dst Port: " + destPort); }
            //add data to nades of root 0 (frame)
            treeView1.Nodes[0].Nodes[0].Text += (Form1.Globals.index.ToString() + Form1.Globals.devices[Form1.Globals.index].Name.ToString());
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

            // add data to list
            trees.Add(No);//0
            trees.Add(Tim);//1
            trees.Add(frameNum);//2
            trees.Add(framelentgh);//3
            trees.Add(capturelength);//4
            trees.Add(destMac);//5
            trees.Add(sourceMac);//6
            trees.Add(type);//7
            trees.Add(HeaderLength);//8
            trees.Add(TimeToLive);//9
            trees.Add(protocol);//10
            trees.Add(source);//11
            trees.Add(dest);//12
            trees.Add(sourcePort);//13
            trees.Add(destPort);//14
            trees.Add(Flags);//15

            treeCommponents.Add(trees);
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
        }



        private void button3_Click(object sender, EventArgs e)
        {
            //stop button
            device.StopCapture();
            device.Close();
            file.Close();
            File.Close();
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

        private void button4_Click(object sender, EventArgs e)
        {
            //apply filter  button
            //getPackets();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //clear filter button
            textBox1.Text = "";

        }
        int indexOfSelected = 0;

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
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

                
                    for (int lcount = 0; lcount <= (listView1.Items.Count - 1); lcount++)
                    {
                        if (listView1.Items[lcount].Selected == true)
                        {
                            indexOfSelected = lcount;
                            break;
                        }
                    }
                
                indexOfSelected = listView1.SelectedIndices[indexOfSelected];

                drawTreeView(treeCommponents[indexOfSelected][0], treeCommponents[indexOfSelected][2], treeCommponents[indexOfSelected][3], treeCommponents[indexOfSelected][4],
                    treeCommponents[indexOfSelected][6], treeCommponents[indexOfSelected][5], treeCommponents[indexOfSelected][7], treeCommponents[indexOfSelected][11],
                    treeCommponents[indexOfSelected][12], treeCommponents[indexOfSelected][13], treeCommponents[indexOfSelected][14],
                    treeCommponents[indexOfSelected][1], treeCommponents[indexOfSelected][8], treeCommponents[indexOfSelected][9], treeCommponents[indexOfSelected][10],
                    treeCommponents[indexOfSelected][15]);
            }
            else
            {
                return;
            }
           

        }

       

















    }
}

