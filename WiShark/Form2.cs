using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpPcap;
using PacketDotNet;
namespace WiShark
{
    public partial class Form2 : Form
    {
        public static class Globals
        {
            
        }
        bool button3isClicked = false;
        public Form2()
        {
            InitializeComponent();
            getPackets();
        }
        void getPackets() {
            
            var   device = Form1.Globals.devices[Form1.Globals.index];
            

            int readTimeoutMilliseconds = 1000;
            device.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);

            RawCapture packet = null;
            string Time;
            string Len;
            string Type;
            int i = 1;
            // Keep capture packets using GetNextPacket()
            while ((packet = device.GetNextPacket()) != null )
            {
                var time = packet.Timeval.Date;
                var len = packet.Data.Length;
                var type = packet.LinkLayerType.GetType();
                Time = time.Hour.ToString() + ":" + time.Minute.ToString() + ":" + time.Second.ToString() + "." + time.Millisecond.ToString();
                Len = len.ToString();
                Type = type.ToString();
                ListViewItem packetitem = new ListViewItem(i.ToString());
                packetitem.SubItems.Add(Time);
                packetitem.SubItems.Add(Time);
                packetitem.SubItems.Add(Time);
                packetitem.SubItems.Add(Type);
                packetitem.SubItems.Add(Len);
                packetitem.SubItems.Add(Time);
                listView1.Items.Add(packetitem);
                i++;

                if (button3isClicked == true) { return; }
            }

            device.Close();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getPackets();
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            button3isClicked = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getPackets();
        }

        

       

        

       

        
    }
}
