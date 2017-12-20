using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Design;
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
            public static ICaptureDevice device = Form1.Globals.devices[Form1.Globals.index];

        }
        List<string[]> trees = new List<string[]>();
        List<string> PacketListInfo = new List<string>();
        List<byte[]> packetsBytes = new List<byte[]>();
        List<RawCapture> packets = new List<RawCapture>();
        
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

        private static CaptureFileWriterDevice captureFileWriter;
        ByteViewer byt = new ByteViewer();

        SaveFileDialog saveFile = new SaveFileDialog();
        OpenFileDialog openFile = new OpenFileDialog();
        bool openfileFlag = false;
        string Filt = "";
        int ind = 0;
       
        public Form2()
        {
           
            InitializeComponent();
            button1.Enabled = false;
            button4.Enabled = true;
            button6.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;

            toolTip1.Draw += new DrawToolTipEventHandler(toolTip1_Draw);

            //initializing hex viewer
            byt.Location = new Point(0, 414) ;
            byt.Size = new Size(1018,157);
            byte[] inithex = new byte[64];
            
            byt.SetBytes(inithex);
            Controls.Add(byt);
            
            //popup button name

            button1.MouseHover += new EventHandler(mouseHoverResponse_button);
            button2.MouseHover += new EventHandler(mouseHoverResponse_button);
            button3.MouseHover += new EventHandler(mouseHoverResponse_button);
            button4.MouseHover += new EventHandler(mouseHoverResponse_button);
            button5.MouseHover += new EventHandler(mouseHoverResponse_button);
            button6.MouseHover += new EventHandler(mouseHoverResponse_button);
            button7.MouseHover += new EventHandler(mouseHoverResponse_button);
            button8.MouseHover += new EventHandler(mouseHoverResponse_button);
            button9.MouseHover += new EventHandler(mouseHoverResponse_button);




            //save nodes initial text
            bframe = treeView1.Nodes[0].Text;
            bframeNum = treeView1.Nodes[0].Nodes[4].Text; ;
            bframelentgh = treeView1.Nodes[0].Nodes[5].Text;
            bcapturelength = treeView1.Nodes[0].Nodes[6].Text;
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

            getPackets();

        }

        private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            //tool tip draw handler
            //setting backcolor
            e.DrawBackground();
            e.DrawBorder();
            e.DrawText();
        }
        void getPackets()
        {

            // Register our handler function to the 'packet arrival' event
            Globals.device.OnPacketArrival +=
                new PacketArrivalEventHandler(device_OnPacketArrival);

            // Open the device for capturing
            int readTimeoutMilliseconds = 1000;
            if (openfileFlag == true)
            {
                Globals.device.Open();
            }
            else
            {
                Globals.device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);
            }
            // Start the capturing process
            Globals.device.StartCapture();

           


        }

        private void mouseHoverResponse_button(object sender, EventArgs e)
        {
            //mouse over handler
            string buttonName = "";
            
            switch(((Control)sender).Name)
            {
                case "button1":
                    buttonName = "start new capture";
                    break;
                case "button2":
                    buttonName = "restart the running capture";
                    break;
                case "button3":
                    buttonName = "stop the running capture";
                    break;
                case "button4":
                    buttonName = "Apply this filter string to display";
                    break;
                case "button5":
                    buttonName = "clear this filter string from display and update display";
                    break;
                case "button6":
                    buttonName = "close this capture file";
                    break;
                case "button7":
                    buttonName = "Exit the program";
                    break;
                case "button8":
                    buttonName = "save this capture file";
                    break;
                case "button9":
                    buttonName = "open a capture file";
                    break;
                default:
                    return;
            }
            
            toolTip1.SetToolTip((Control) sender, buttonName);
            
            
        }
        

        private void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {

            initialvalues();
        
            

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

            // write the packet to the file
            packets.Add(e.Packet);
            Packet p = PacketDotNet.Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);

            packetsBytes.Add(p.Bytes);
            String y = " ";
            int j = 0, k = 1, z = 1, Sq = 1;
            string temp = " ";

            // retrieving data from packets

            if (p != null)
            {
                y = p.ToString();
                
                for (int i = 0; i < y.Length ; i++)
                {
                    if (y[i] == ' ' )
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
                PacketListInfo.Add(y);
                //packetarrayinfo[ind] = y;
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
                if (Filt != "")
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
                PacketListInfo.Add(y);
                //packetarrayinfo[ind] = y;
                No = ind.ToString();
                frameNum = No;
                Tim = time.ToString();
                if (protocol == "UDP")
                    destPort = DestPort;

                //making filter
                if (Filt != "")
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
            if (Filt != "")
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
                ListViewItem packetitem = new ListViewItem(No);
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
             
                  //add packet data to list
                  string[] tree = new string[16];
                  // add data to list
                  tree[0] = No;//0
                  tree[1] = Tim;//1
                  tree[2] = frameNum;//2
                  tree[3] = framelentgh;//3
                  tree[4] = capturelength;//4
                  tree[5] = destMac;//5
                  tree[6] = sourceMac;//6
                  tree[7] = type;//7
                  tree[8] = HeaderLength;//8
                  tree[9] = TimeToLive;//9
                  tree[10] = protocol;//10
                  tree[11] = source;//11
                  tree[12] = dest;//12
                  tree[13] = sourcePort;//13
                  tree[14] = destPort;//14
                  tree[15] = Flags;//15

                  trees.Add(tree);
                 
            
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

            button6.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            indexOfSelected = 0;

            trees.Clear();
            initialvalues();
        
        }



        private void button3_Click(object sender, EventArgs e)
        {
            //stop button
            label5.Text = Globals.device.Statistics.ToString();
            Globals.device.StopCapture();
            Globals.device.Close();
            button2.Enabled = false;
            button3.Enabled = false;
            button1.Enabled = true;

            button6.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //restart button
            listView1.Items.Clear();
            ind = 0;
            Globals.device.StopCapture();
            Globals.device.Close();
            indexOfSelected = 0;

            trees.Clear();

            button6.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;

            initialvalues();
        
            getPackets();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //back button
            if (Form1.Globals.devices.Count > 0)
            {
                Globals.device.StopCapture();
                Globals.device.Close();
            }
            
            Form1 x = new Form1();
            x.Show();
            this.Hide();
        }

     
      
        int indexOfSelected = 0;

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            initialvalues();
        

            //get index of selected item
            if (listView1.SelectedIndices.Count > 0)
            {
                if (Filt == "")
                {
                    indexOfSelected = listView1.SelectedIndices[0];
                }
                else { indexOfSelected = int.Parse(listView1.Items[listView1.SelectedIndices[0]].Text); }

                //draw treeView of packed data of selected item
                drawTreeView(trees[indexOfSelected][0], trees[indexOfSelected][2], trees[indexOfSelected][3], trees[indexOfSelected][4], 
                    trees[indexOfSelected][6], trees[indexOfSelected][5], trees[indexOfSelected][7], trees[indexOfSelected][11], 
                    trees[indexOfSelected][12], trees[indexOfSelected][13], trees[indexOfSelected][14], trees[indexOfSelected][1], 
                   trees[indexOfSelected][8], trees[indexOfSelected][9], trees[indexOfSelected][10], trees[indexOfSelected][15]);

                drawHex(indexOfSelected);
            
            }
           
        }



        private void button5_Click(object sender, EventArgs e)
        {
            //clear filter button
           textBox1.Text = "";
           listView1.Items.Clear();
           Filt = "";
           indexOfSelected = 0;
           for (int i = 0; i < trees.Count; i++)
           {
               drawListView(trees[i][0], trees[i][1], trees[i][11], trees[i][12], trees[i][10], trees[i][3], PacketListInfo[i]);

               drawTreeView(trees[i][0], trees[i][2], trees[i][3], trees[i][4], trees[i][6], trees[i][5], trees[i][7], trees[i][11],
                   trees[i][12], trees[i][13], trees[i][14], trees[i][1], trees[i][8], trees[i][9], trees[i][10], trees[i][15]);
               
           }
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //apply filter  button
            Filt = textBox1.Text;
            if (Filt == "")
            {
                MessageBox.Show("Please enter a valid protocol!", "Error");
                return;
            }
            if ((Filt == "UDP") || (Filt == "TCP") || (Filt == "IGMP") || (Filt == "ICMPV6"))
            {
                listView1.Items.Clear();
                indexOfSelected = 0;
                for (int i = 0; i < trees.Count; i++)
                {
                    if (trees[i][10] == Filt)
                    {
                        drawListView(trees[i][0], trees[i][1], trees[i][11], trees[i][12], trees[i][10], trees[i][3], PacketListInfo[i]);

                        drawTreeView(trees[i][0], trees[i][2], trees[i][3], trees[i][4], trees[i][6], trees[i][5], trees[i][7], trees[i][11],
                            trees[i][12], trees[i][13], trees[i][14], trees[i][1], trees[i][8], trees[i][9], trees[i][10], trees[i][15]);

                        
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid protocol!", "Error");
                return;
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Close App button
            Globals.device.StopCapture();
            Globals.device.Close();
            Application.Exit();
        }



        public static string ByteArrayToString(byte[] ba)
        {
            //convert byte[] to hex
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", " ");
        }

        private void drawHex(int packetIndex)
        {
            //draw hex of packets
            if (packetsBytes.Count != 0){
                byt.SetBytes(packetsBytes[packetIndex]);
               
                Controls.Add(byt);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //save capture to file in system
            saveFileDialog1.Title = "save capture file as";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                captureFileWriter = new CaptureFileWriterDevice(saveFileDialog1.FileName);
                if (packets.Count > 0)
                {
                    for (int i = 0; i < packets.Count; i++)
                    {
                        captureFileWriter.Write(packets[i]);
                    }
                }

            }
            

        }

        private void button9_Click(object sender, EventArgs e)
        {
           
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button6.Enabled = true;
            if (packets.Count == 0)
                button8.Enabled = false;

            //open file from system
            openFileDialog1.Title = "open capture file";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                button8.Enabled = false;
                listView1.Items.Clear();
                ind = 0;
                indexOfSelected = 0;
                trees.Clear();
                initialvalues();
                packets.Clear();
                openfileFlag = true;
            
                try
                {
                    // Get an offline device
                    Globals.device = new CaptureFileReaderDevice(openFileDialog1.FileName);
                    getPackets();
                }
                catch (Exception error)
                {
                    MessageBox.Show(("Caught exception when opening file \n" + error.ToString()), "Error");
                    return;
                }



            }
            openfileFlag = false;
        }


        void initialvalues()
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
        }


    }
}

