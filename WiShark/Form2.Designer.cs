namespace WiShark
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Interface id: ");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Encapsulation type: Ethernet");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Arrival Time: ");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Epoch Time: ");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Frame Number: ");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Frame Length: ");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Capture Length: ");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Frame ", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Destination: ");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Source: ");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Type: ");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Ethernet II, Src: ", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Version: 4");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Header Length: ");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Time to live: ");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Protocol: ");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Source: ");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Destination: ");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Internet Protocol Version, Src: ", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Source Port: ");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Destination Port: ");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Flags: ");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Transmission Control Protocol, Src Port: ", new System.Windows.Forms.TreeNode[] {
            treeNode20,
            treeNode21,
            treeNode22});
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Nom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Time = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Source = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Destination = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Protocol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Length = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Info = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1017, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // button6
            // 
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.Location = new System.Drawing.Point(21, 9);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(45, 45);
            this.button6.TabIndex = 8;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(519, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "restart";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(361, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "stop";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(191, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "start";
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(340, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(65, 33);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(503, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 33);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(174, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 33);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(383, 81);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(53, 27);
            this.button4.TabIndex = 4;
            this.button4.Text = "Apply";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filter: ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(62, 85);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(195, 20);
            this.textBox1.TabIndex = 0;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(281, 81);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(49, 27);
            this.button5.TabIndex = 3;
            this.button5.Text = "Clear";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(0, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1018, 33);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nom,
            this.Time,
            this.Source,
            this.Destination,
            this.Protocol,
            this.Length,
            this.Info});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 117);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1018, 192);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // Nom
            // 
            this.Nom.Text = "No.";
            this.Nom.Width = 50;
            // 
            // Time
            // 
            this.Time.Text = "Time";
            this.Time.Width = 150;
            // 
            // Source
            // 
            this.Source.Text = "Source";
            this.Source.Width = 200;
            // 
            // Destination
            // 
            this.Destination.Text = "Destination";
            this.Destination.Width = 200;
            // 
            // Protocol
            // 
            this.Protocol.Text = "Protocol";
            this.Protocol.Width = 100;
            // 
            // Length
            // 
            this.Length.Text = "Length";
            this.Length.Width = 70;
            // 
            // Info
            // 
            this.Info.Text = "Info";
            this.Info.Width = 738;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(0, 306);
            this.treeView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Interface id";
            treeNode1.Text = "Interface id: ";
            treeNode2.Name = "Encapsulation type";
            treeNode2.Text = "Encapsulation type: Ethernet";
            treeNode3.Name = "Arrival Time";
            treeNode3.Text = "Arrival Time: ";
            treeNode4.Name = "Epoch Time";
            treeNode4.Text = "Epoch Time: ";
            treeNode5.Name = "Frame Number";
            treeNode5.Text = "Frame Number: ";
            treeNode6.Name = "Frame Length";
            treeNode6.Text = "Frame Length: ";
            treeNode7.Name = "Capture Length";
            treeNode7.Text = "Capture Length: ";
            treeNode8.Name = "Frame";
            treeNode8.Text = "Frame ";
            treeNode9.Name = "Destination";
            treeNode9.Text = "Destination: ";
            treeNode10.Name = "Source";
            treeNode10.Text = "Source: ";
            treeNode11.Name = "Type";
            treeNode11.Text = "Type: ";
            treeNode12.Name = "Ethernet";
            treeNode12.Text = "Ethernet II, Src: ";
            treeNode13.Name = "Version";
            treeNode13.Text = "Version: 4";
            treeNode14.Name = "Header Length";
            treeNode14.Text = "Header Length: ";
            treeNode15.Name = "Time to live";
            treeNode15.Text = "Time to live: ";
            treeNode16.Name = "Protocol";
            treeNode16.Text = "Protocol: ";
            treeNode17.Name = "Source";
            treeNode17.Text = "Source: ";
            treeNode18.Name = "Destination";
            treeNode18.Text = "Destination: ";
            treeNode19.Name = "IP";
            treeNode19.Text = "Internet Protocol Version, Src: ";
            treeNode20.Name = "Source Port";
            treeNode20.Text = "Source Port: ";
            treeNode21.Name = "Destinaton Port";
            treeNode21.Text = "Destination Port: ";
            treeNode22.Name = "Flags";
            treeNode22.Text = "Flags: ";
            treeNode23.Name = "Transmission Control Protocol";
            treeNode23.Text = "Transmission Control Protocol, Src Port: ";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode12,
            treeNode19,
            treeNode23});
            this.treeView1.Size = new System.Drawing.Size(1018, 127);
            this.treeView1.TabIndex = 6;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 607);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WiShark";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ColumnHeader Nom;
        private System.Windows.Forms.ColumnHeader Time;
        private System.Windows.Forms.ColumnHeader Source;
        private System.Windows.Forms.ColumnHeader Destination;
        private System.Windows.Forms.ColumnHeader Protocol;
        private System.Windows.Forms.ColumnHeader Length;
        private System.Windows.Forms.ColumnHeader Info;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TreeView treeView1;
    }
}