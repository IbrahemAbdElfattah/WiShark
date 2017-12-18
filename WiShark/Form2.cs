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
        
        public Form2()
        {
            InitializeComponent();
            //getdevices();
            button1.Enabled = false;
            button4.Enabled = true;
            getPackets();
        }
        void getdevices()
        {
            Form1 n = new Form1();
            n.Show();
            this.Hide();
        }
        ICaptureDevice device = Form1.Globals.devices[Form1.Globals.index];

        void getPackets() {
            
                        
            // Register our handler function to the 'packet arrival' event
            device.OnPacketArrival +=
                new PacketArrivalEventHandler(device_OnPacketArrival);

            // Open the device for capturing
            int readTimeoutMilliseconds = 1000;
            device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);
            // Start the capturing process
            device.StartCapture();

            
           
        }
        /*
        void Sendpackets() 
        {
            string Tim;
            string Len;
            string Typ;
            
            
            int i =0;
            while (i < PacketQueue.Count)
            {
                var time = PacketQueue[i].Timeval.Date;
                var len = PacketQueue[i].Data.Length;
                var type = PacketQueue[i].LinkLayerType.GetType();
                Tim = time.Hour.ToString() + ":" + time.Minute.ToString() + ":" + time.Second.ToString() + "." + time.Millisecond.ToString();
                Len = len.ToString();
                Typ = type.ToString();
                ListViewItem packetitem = new ListViewItem((i+1).ToString());
                packetitem.SubItems.Add(Tim);
                packetitem.SubItems.Add(Tim);
                packetitem.SubItems.Add(Tim);
                packetitem.SubItems.Add(Typ);
                packetitem.SubItems.Add(Len);
                packetitem.SubItems.Add(Tim);
                listView1.Items.Add(packetitem);
                i++;
            }
        }*/
        int ind = 0;
        private  void device_OnPacketArrival(object sender, CaptureEventArgs e)
        {
            string Tim = " " ;
            string Len = " ";
            string Typ = " ";
            string source=" ";
            string sourceMac = " ";
            string dest=" ";
            string destMac= " ";
            string protocol=" ";

            Packet p = PacketDotNet.Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
            String y = " ";
            int j = 0, k = 1, z = 1;
            string temp = " ";


            if (p.ToString().Length < 500)
            {
                y = p.ToString();
                for (int i = 0; i < y.Length - 1; i++)
                {
                    if (y[i] == ' ')
                        j++;
                    
                    if (y[i] == '=')
                            k = i;
                    if (y[i] == ',')
                            z = i;
                    if ((z - k) < y.Length && (z - k) > 0)
                            temp = y.Substring(k + 1, (z - k) - 1);

                    if (j == 1)
                        sourceMac = temp;

                    if (j == 2)
                        destMac = temp;

                    if (j == 3)
                        Typ = temp;
                    
                    if (j == 4)
                    {
                        source = temp;
                    }
                    if (j == 5)
                    {
                        dest = temp;
                    }
                    if (j == 7)
                    {
                        protocol = temp;
                    }
                }
            }
            var time = e.Packet.Timeval.Date;
            var len = e.Packet.Data.Length;

            PacketQueue.Add(y);
            Tim = time.Hour.ToString() + ":" + time.Minute.ToString() + ":" + time.Second.ToString() + "." + time.Millisecond.ToString();
            Len = len.ToString();

            if (protocol == "TCP" || protocol == "UDP")
            {
                ListViewItem packetitem = new ListViewItem((ind + 1).ToString());
                packetitem.SubItems.Add(Tim);
                packetitem.SubItems.Add(source);
                packetitem.SubItems.Add(dest);
                packetitem.SubItems.Add(protocol);
                packetitem.SubItems.Add(Len);
                packetitem.SubItems.Add(p.ToString());

                listView1.Items.Add(packetitem);
            }
            List<string> trees = new List<string>();

            treeCommponents.Add(trees);
           ind++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
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
                device.StopCapture();
                device.Close();
            button2.Enabled = false;
            button3.Enabled = false;
            button1.Enabled = true;
            button4.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            ind = 0;
            getPackets();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            device.StopCapture();
            device.Close();
            
            Form1 x = new Form1();
            x.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //getPackets();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text="";
            
        }

       

        

       

        

       

        
    }
}
