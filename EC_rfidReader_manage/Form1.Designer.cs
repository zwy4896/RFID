﻿namespace EC_rfidReader
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cbb_IPAddr = new System.Windows.Forms.ComboBox();
            this.b_getNetDriver = new System.Windows.Forms.Button();
            this.b_open = new System.Windows.Forms.Button();
            this.b_close = new System.Windows.Forms.Button();
            this.tb_deviceInfo = new System.Windows.Forms.TextBox();
            this.cbb_comPort = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.b_stopInventory = new System.Windows.Forms.Button();
            this.b_inventory = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Controls.Add(this.cbb_comPort);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(964, 50);
            this.panel3.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(105, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cbb_IPAddr);
            this.splitContainer1.Panel1.Controls.Add(this.b_getNetDriver);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.b_open);
            this.splitContainer1.Panel2.Controls.Add(this.b_close);
            this.splitContainer1.Panel2.Controls.Add(this.tb_deviceInfo);
            this.splitContainer1.Size = new System.Drawing.Size(541, 50);
            this.splitContainer1.SplitterDistance = 216;
            this.splitContainer1.TabIndex = 7;
            // 
            // cbb_IPAddr
            // 
            this.cbb_IPAddr.Font = new System.Drawing.Font("宋体", 16F);
            this.cbb_IPAddr.FormattingEnabled = true;
            this.cbb_IPAddr.Location = new System.Drawing.Point(4, 11);
            this.cbb_IPAddr.Name = "cbb_IPAddr";
            this.cbb_IPAddr.Size = new System.Drawing.Size(176, 29);
            this.cbb_IPAddr.TabIndex = 8;
            // 
            // b_getNetDriver
            // 
            this.b_getNetDriver.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_getNetDriver.Location = new System.Drawing.Point(180, 10);
            this.b_getNetDriver.Name = "b_getNetDriver";
            this.b_getNetDriver.Size = new System.Drawing.Size(32, 31);
            this.b_getNetDriver.TabIndex = 9;
            this.b_getNetDriver.Text = "::";
            this.b_getNetDriver.UseVisualStyleBackColor = true;
            this.b_getNetDriver.Click += new System.EventHandler(this.b_getNetDriver_Click);
            // 
            // b_open
            // 
            this.b_open.Location = new System.Drawing.Point(3, 10);
            this.b_open.Name = "b_open";
            this.b_open.Size = new System.Drawing.Size(75, 31);
            this.b_open.TabIndex = 0;
            this.b_open.Text = "连接";
            this.b_open.UseVisualStyleBackColor = true;
            this.b_open.Click += new System.EventHandler(this.b_open_Click);
            // 
            // b_close
            // 
            this.b_close.Enabled = false;
            this.b_close.Location = new System.Drawing.Point(84, 10);
            this.b_close.Name = "b_close";
            this.b_close.Size = new System.Drawing.Size(75, 31);
            this.b_close.TabIndex = 3;
            this.b_close.Text = "断开";
            this.b_close.UseVisualStyleBackColor = true;
            this.b_close.Click += new System.EventHandler(this.b_close_Click);
            // 
            // tb_deviceInfo
            // 
            this.tb_deviceInfo.BackColor = System.Drawing.SystemColors.Control;
            this.tb_deviceInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_deviceInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.tb_deviceInfo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_deviceInfo.Location = new System.Drawing.Point(165, 5);
            this.tb_deviceInfo.Multiline = true;
            this.tb_deviceInfo.Name = "tb_deviceInfo";
            this.tb_deviceInfo.ReadOnly = true;
            this.tb_deviceInfo.Size = new System.Drawing.Size(207, 40);
            this.tb_deviceInfo.TabIndex = 4;
            // 
            // cbb_comPort
            // 
            this.cbb_comPort.Font = new System.Drawing.Font("宋体", 16F);
            this.cbb_comPort.FormattingEnabled = true;
            this.cbb_comPort.Location = new System.Drawing.Point(7, 11);
            this.cbb_comPort.Name = "cbb_comPort";
            this.cbb_comPort.Size = new System.Drawing.Size(92, 29);
            this.cbb_comPort.TabIndex = 5;
            this.cbb_comPort.SelectedIndexChanged += new System.EventHandler(this.cbb_comPort_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(120, 32);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(964, 559);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBox2);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel5);
            this.tabPage1.Location = new System.Drawing.Point(4, 36);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(956, 519);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "清单";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox2.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox2.Location = new System.Drawing.Point(3, 3);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(390, 460);
            this.richTextBox2.TabIndex = 10;
            this.richTextBox2.Text = "";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.b_stopInventory);
            this.panel2.Controls.Add(this.b_inventory);
            this.panel2.Location = new System.Drawing.Point(399, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(554, 460);
            this.panel2.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(28, 231);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 30);
            this.button1.TabIndex = 16;
            this.button1.Text = "录入";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(25, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "单价(数字)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(25, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "菜品";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(28, 174);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(261, 29);
            this.textBox2.TabIndex = 17;
            this.textBox2.Text = "请输入单价";
            this.textBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBox2_MouseClick);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox2_KeyPress);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(28, 108);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(261, 29);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = "请输入菜品名";
            this.textBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TextBox1_MouseClick);
            // 
            // b_stopInventory
            // 
            this.b_stopInventory.Enabled = false;
            this.b_stopInventory.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_stopInventory.Location = new System.Drawing.Point(167, 33);
            this.b_stopInventory.Name = "b_stopInventory";
            this.b_stopInventory.Size = new System.Drawing.Size(122, 27);
            this.b_stopInventory.TabIndex = 6;
            this.b_stopInventory.Text = "停止";
            this.b_stopInventory.UseVisualStyleBackColor = true;
            this.b_stopInventory.Click += new System.EventHandler(this.b_stopInventory_Click);
            // 
            // b_inventory
            // 
            this.b_inventory.Enabled = false;
            this.b_inventory.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.b_inventory.Location = new System.Drawing.Point(28, 33);
            this.b_inventory.Name = "b_inventory";
            this.b_inventory.Size = new System.Drawing.Size(133, 27);
            this.b_inventory.TabIndex = 5;
            this.b_inventory.Text = "读取";
            this.b_inventory.UseVisualStyleBackColor = true;
            this.b_inventory.Click += new System.EventHandler(this.b_inventory_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(3, 463);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(950, 53);
            this.panel5.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("宋体", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(0, -3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(950, 56);
            this.label2.TabIndex = 9;
            this.label2.Text = "数量: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(964, 559);
            this.panel1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 609);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HD Tech 智慧食堂标签管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button b_open;
        private System.Windows.Forms.Button b_close;
        private System.Windows.Forms.TextBox tb_deviceInfo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbb_comPort;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button b_getNetDriver;
        private System.Windows.Forms.ComboBox cbb_IPAddr;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button b_stopInventory;
        private System.Windows.Forms.Button b_inventory;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}

