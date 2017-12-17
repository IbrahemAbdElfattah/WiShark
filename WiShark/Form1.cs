using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;
using SharpPcap.AirPcap;
using SharpPcap.WinPcap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace WiShark
{
    public partial class Form1 : Form
    {
        public static class Globals
        {
            public static CaptureDeviceList devices = CaptureDeviceList.Instance;
            public static int index = 0;
        }
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
            GetDevices();
        }

        void GetDevices() {
            int i = 0;

            if(Globals.devices.Count < 1)
            {
                MessageBox.Show("No devices were found on this machine");
                return;
            }

            foreach (ICaptureDevice dev in Globals.devices)
            {
                checkedListBox1.Items.Add(dev.Description.ToString());

                i++;
            }

        }

        private int lastCheck = -1;
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int toUncheck = lastCheck;
            if (toUncheck != -1)
                checkedListBox1.SetItemChecked(toUncheck, false);
            lastCheck = checkedListBox1.SelectedIndex;
            checkedListBox1.SetItemChecked(lastCheck, true);

            Globals.index = checkedListBox1.SelectedIndex; 
            if (checkedListBox1.SelectedItems.Count != 0)
            {
                button1.Enabled = true;
            }
            
            
         }
        private static CaptureFileWriterDevice captureFileWriter;

        private void button1_Click(object sender, EventArgs e)
        {

            Form2 m = new Form2();
            m.Show();
            this.Hide();
        }

       
        
    }
}
