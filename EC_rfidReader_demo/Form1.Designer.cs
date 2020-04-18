namespace EC_rfidReader
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
            this.b_setOutput = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cbb_IPAddr = new System.Windows.Forms.ComboBox();
            this.b_getNetDriver = new System.Windows.Forms.Button();
            this.b_open = new System.Windows.Forms.Button();
            this.b_close = new System.Windows.Forms.Button();
            this.tb_deviceInfo = new System.Windows.Forms.TextBox();
            this.cbb_comPort = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.b_readMultiple = new System.Windows.Forms.Button();
            this.cbb_startAddress = new System.Windows.Forms.ComboBox();
            this.cbb_blockNumber = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.b_writeMultiple = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.b_getTagSysInfo = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_dsfid = new System.Windows.Forms.TextBox();
            this.tb_afi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.b_writeAFI = new System.Windows.Forms.Button();
            this.b_writeDSFID = new System.Windows.Forms.Button();
            this.l_UID = new System.Windows.Forms.Label();
            this.l_blockSize = new System.Windows.Forms.Label();
            this.l_blockNumber = new System.Windows.Forms.Label();
            this.l_ICreference = new System.Windows.Forms.Label();
            this.b_lockAFI = new System.Windows.Forms.Button();
            this.b_lockDSFID = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.tb_blockData = new System.Windows.Forms.TextBox();
            this.tb_selecttagID = new System.Windows.Forms.TextBox();
            this.tb_antID = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cb_readSecSta = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.b_inventory = new System.Windows.Forms.Button();
            this.b_stopInventory = new System.Windows.Forms.Button();
            this.cb_blockToRead = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cb_blockToWrite = new System.Windows.Forms.CheckBox();
            this.tb_blockToWrite = new System.Windows.Forms.TextBox();
            this.clb_antIDList = new System.Windows.Forms.CheckedListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cb_AFIToRead = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.b_setOutput);
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Controls.Add(this.cbb_comPort);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(884, 50);
            this.panel3.TabIndex = 6;
            // 
            // b_setOutput
            // 
            this.b_setOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.b_setOutput.Enabled = false;
            this.b_setOutput.Location = new System.Drawing.Point(797, 10);
            this.b_setOutput.Name = "b_setOutput";
            this.b_setOutput.Size = new System.Drawing.Size(75, 29);
            this.b_setOutput.TabIndex = 9;
            this.b_setOutput.Text = "setOutput";
            this.b_setOutput.UseVisualStyleBackColor = true;
            this.b_setOutput.Click += new System.EventHandler(this.b_setOutput_Click);
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
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(120, 32);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(884, 511);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.cb_readSecSta);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.tb_antID);
            this.tabPage2.Controls.Add(this.tb_selecttagID);
            this.tabPage2.Controls.Add(this.tb_blockData);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.b_getTagSysInfo);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.b_writeMultiple);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.cbb_blockNumber);
            this.tabPage2.Controls.Add(this.cbb_startAddress);
            this.tabPage2.Controls.Add(this.b_readMultiple);
            this.tabPage2.Location = new System.Drawing.Point(4, 36);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(876, 471);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "单标签";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // b_readMultiple
            // 
            this.b_readMultiple.Enabled = false;
            this.b_readMultiple.Location = new System.Drawing.Point(190, 91);
            this.b_readMultiple.Name = "b_readMultiple";
            this.b_readMultiple.Size = new System.Drawing.Size(107, 22);
            this.b_readMultiple.TabIndex = 0;
            this.b_readMultiple.Text = "Read Multiple";
            this.b_readMultiple.UseVisualStyleBackColor = true;
            this.b_readMultiple.Click += new System.EventHandler(this.b_readMultiple_Click);
            // 
            // cbb_startAddress
            // 
            this.cbb_startAddress.FormattingEnabled = true;
            this.cbb_startAddress.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59",
            "60",
            "61",
            "62",
            "63",
            "64"});
            this.cbb_startAddress.Location = new System.Drawing.Point(107, 92);
            this.cbb_startAddress.Name = "cbb_startAddress";
            this.cbb_startAddress.Size = new System.Drawing.Size(72, 20);
            this.cbb_startAddress.TabIndex = 1;
            // 
            // cbb_blockNumber
            // 
            this.cbb_blockNumber.FormattingEnabled = true;
            this.cbb_blockNumber.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cbb_blockNumber.Location = new System.Drawing.Point(107, 118);
            this.cbb_blockNumber.Name = "cbb_blockNumber";
            this.cbb_blockNumber.Size = new System.Drawing.Size(72, 20);
            this.cbb_blockNumber.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Start Address：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Block Number：";
            // 
            // b_writeMultiple
            // 
            this.b_writeMultiple.Enabled = false;
            this.b_writeMultiple.Location = new System.Drawing.Point(190, 117);
            this.b_writeMultiple.Name = "b_writeMultiple";
            this.b_writeMultiple.Size = new System.Drawing.Size(107, 22);
            this.b_writeMultiple.TabIndex = 5;
            this.b_writeMultiple.Text = "Write Multiple";
            this.b_writeMultiple.UseVisualStyleBackColor = true;
            this.b_writeMultiple.Click += new System.EventHandler(this.b_writeMultiple_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "Block Data：";
            // 
            // b_getTagSysInfo
            // 
            this.b_getTagSysInfo.Enabled = false;
            this.b_getTagSysInfo.Location = new System.Drawing.Point(10, 154);
            this.b_getTagSysInfo.Name = "b_getTagSysInfo";
            this.b_getTagSysInfo.Size = new System.Drawing.Size(107, 22);
            this.b_getTagSysInfo.TabIndex = 8;
            this.b_getTagSysInfo.Text = "Get Tag Info";
            this.b_getTagSysInfo.UseVisualStyleBackColor = true;
            this.b_getTagSysInfo.Click += new System.EventHandler(this.b_getTagSysInfo_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.b_lockDSFID);
            this.groupBox1.Controls.Add(this.b_lockAFI);
            this.groupBox1.Controls.Add(this.l_ICreference);
            this.groupBox1.Controls.Add(this.l_blockNumber);
            this.groupBox1.Controls.Add(this.l_blockSize);
            this.groupBox1.Controls.Add(this.l_UID);
            this.groupBox1.Controls.Add(this.b_writeDSFID);
            this.groupBox1.Controls.Add(this.b_writeAFI);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tb_afi);
            this.groupBox1.Controls.Add(this.tb_dsfid);
            this.groupBox1.Location = new System.Drawing.Point(10, 182);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 104);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tag system info";
            // 
            // tb_dsfid
            // 
            this.tb_dsfid.Location = new System.Drawing.Point(60, 71);
            this.tb_dsfid.MaxLength = 2;
            this.tb_dsfid.Name = "tb_dsfid";
            this.tb_dsfid.Size = new System.Drawing.Size(72, 21);
            this.tb_dsfid.TabIndex = 12;
            // 
            // tb_afi
            // 
            this.tb_afi.Location = new System.Drawing.Point(60, 44);
            this.tb_afi.MaxLength = 2;
            this.tb_afi.Name = "tb_afi";
            this.tb_afi.Size = new System.Drawing.Size(72, 21);
            this.tb_afi.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "DSFID：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(346, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "Block Size：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "AFI：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(346, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 15;
            this.label9.Text = "Block Number：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(346, 75);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 16;
            this.label10.Text = "IC reference：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "UID：";
            // 
            // b_writeAFI
            // 
            this.b_writeAFI.Enabled = false;
            this.b_writeAFI.Location = new System.Drawing.Point(142, 44);
            this.b_writeAFI.Name = "b_writeAFI";
            this.b_writeAFI.Size = new System.Drawing.Size(88, 22);
            this.b_writeAFI.TabIndex = 18;
            this.b_writeAFI.Text = "Write AFI";
            this.b_writeAFI.UseVisualStyleBackColor = true;
            this.b_writeAFI.Click += new System.EventHandler(this.b_writeAFI_Click);
            // 
            // b_writeDSFID
            // 
            this.b_writeDSFID.Enabled = false;
            this.b_writeDSFID.Location = new System.Drawing.Point(142, 71);
            this.b_writeDSFID.Name = "b_writeDSFID";
            this.b_writeDSFID.Size = new System.Drawing.Size(88, 22);
            this.b_writeDSFID.TabIndex = 19;
            this.b_writeDSFID.Text = "Write DSFID";
            this.b_writeDSFID.UseVisualStyleBackColor = true;
            this.b_writeDSFID.Click += new System.EventHandler(this.b_writeDSFID_Click);
            // 
            // l_UID
            // 
            this.l_UID.AutoSize = true;
            this.l_UID.Location = new System.Drawing.Point(60, 21);
            this.l_UID.Name = "l_UID";
            this.l_UID.Size = new System.Drawing.Size(11, 12);
            this.l_UID.TabIndex = 18;
            this.l_UID.Text = "-";
            // 
            // l_blockSize
            // 
            this.l_blockSize.AutoSize = true;
            this.l_blockSize.Location = new System.Drawing.Point(438, 21);
            this.l_blockSize.Name = "l_blockSize";
            this.l_blockSize.Size = new System.Drawing.Size(11, 12);
            this.l_blockSize.TabIndex = 20;
            this.l_blockSize.Text = "-";
            // 
            // l_blockNumber
            // 
            this.l_blockNumber.AutoSize = true;
            this.l_blockNumber.Location = new System.Drawing.Point(438, 48);
            this.l_blockNumber.Name = "l_blockNumber";
            this.l_blockNumber.Size = new System.Drawing.Size(11, 12);
            this.l_blockNumber.TabIndex = 21;
            this.l_blockNumber.Text = "-";
            // 
            // l_ICreference
            // 
            this.l_ICreference.AutoSize = true;
            this.l_ICreference.Location = new System.Drawing.Point(438, 75);
            this.l_ICreference.Name = "l_ICreference";
            this.l_ICreference.Size = new System.Drawing.Size(11, 12);
            this.l_ICreference.TabIndex = 22;
            this.l_ICreference.Text = "-";
            // 
            // b_lockAFI
            // 
            this.b_lockAFI.Enabled = false;
            this.b_lockAFI.Location = new System.Drawing.Point(236, 44);
            this.b_lockAFI.Name = "b_lockAFI";
            this.b_lockAFI.Size = new System.Drawing.Size(75, 22);
            this.b_lockAFI.TabIndex = 23;
            this.b_lockAFI.Text = "Lock AFI";
            this.b_lockAFI.UseVisualStyleBackColor = true;
            this.b_lockAFI.Click += new System.EventHandler(this.b_lockAFI_Click);
            // 
            // b_lockDSFID
            // 
            this.b_lockDSFID.Enabled = false;
            this.b_lockDSFID.Location = new System.Drawing.Point(236, 71);
            this.b_lockDSFID.Name = "b_lockDSFID";
            this.b_lockDSFID.Size = new System.Drawing.Size(75, 22);
            this.b_lockDSFID.TabIndex = 24;
            this.b_lockDSFID.Text = "Lock DSFID";
            this.b_lockDSFID.UseVisualStyleBackColor = true;
            this.b_lockDSFID.Click += new System.EventHandler(this.b_lockDSFID_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 12);
            this.label11.TabIndex = 19;
            this.label11.Text = "Select TagID：";
            // 
            // tb_blockData
            // 
            this.tb_blockData.Location = new System.Drawing.Point(107, 65);
            this.tb_blockData.Name = "tb_blockData";
            this.tb_blockData.Size = new System.Drawing.Size(611, 21);
            this.tb_blockData.TabIndex = 6;
            // 
            // tb_selecttagID
            // 
            this.tb_selecttagID.Location = new System.Drawing.Point(107, 36);
            this.tb_selecttagID.Name = "tb_selecttagID";
            this.tb_selecttagID.Size = new System.Drawing.Size(190, 21);
            this.tb_selecttagID.TabIndex = 18;
            // 
            // tb_antID
            // 
            this.tb_antID.Location = new System.Drawing.Point(107, 9);
            this.tb_antID.Name = "tb_antID";
            this.tb_antID.Size = new System.Drawing.Size(72, 21);
            this.tb_antID.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(50, 12);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 12);
            this.label12.TabIndex = 21;
            this.label12.Text = "AntID：";
            // 
            // cb_readSecSta
            // 
            this.cb_readSecSta.AutoSize = true;
            this.cb_readSecSta.Location = new System.Drawing.Point(303, 95);
            this.cb_readSecSta.Name = "cb_readSecSta";
            this.cb_readSecSta.Size = new System.Drawing.Size(144, 16);
            this.cb_readSecSta.TabIndex = 22;
            this.cb_readSecSta.Text = "Read Security Status";
            this.cb_readSecSta.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(301, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(179, 12);
            this.label13.TabIndex = 23;
            this.label13.Text = "Select in Multi-tag test list";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.richTextBox2);
            this.tabPage1.Controls.Add(this.panel5);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 36);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(876, 471);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "多标签";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.cb_AFIToRead);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.clb_antIDList);
            this.panel2.Controls.Add(this.tb_blockToWrite);
            this.panel2.Controls.Add(this.cb_blockToWrite);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.cb_blockToRead);
            this.panel2.Controls.Add(this.b_stopInventory);
            this.panel2.Controls.Add(this.b_inventory);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(740, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(133, 465);
            this.panel2.TabIndex = 6;
            // 
            // b_inventory
            // 
            this.b_inventory.Enabled = false;
            this.b_inventory.Location = new System.Drawing.Point(31, 22);
            this.b_inventory.Name = "b_inventory";
            this.b_inventory.Size = new System.Drawing.Size(75, 32);
            this.b_inventory.TabIndex = 5;
            this.b_inventory.Text = "开始";
            this.b_inventory.UseVisualStyleBackColor = true;
            this.b_inventory.Click += new System.EventHandler(this.b_inventory_Click);
            // 
            // b_stopInventory
            // 
            this.b_stopInventory.Enabled = false;
            this.b_stopInventory.Location = new System.Drawing.Point(31, 71);
            this.b_stopInventory.Name = "b_stopInventory";
            this.b_stopInventory.Size = new System.Drawing.Size(75, 32);
            this.b_stopInventory.TabIndex = 6;
            this.b_stopInventory.Text = "停止";
            this.b_stopInventory.UseVisualStyleBackColor = true;
            this.b_stopInventory.Click += new System.EventHandler(this.b_stopInventory_Click);
            // 
            // cb_blockToRead
            // 
            this.cb_blockToRead.AutoSize = true;
            this.cb_blockToRead.Location = new System.Drawing.Point(13, 173);
            this.cb_blockToRead.Name = "cb_blockToRead";
            this.cb_blockToRead.Size = new System.Drawing.Size(90, 16);
            this.cb_blockToRead.TabIndex = 7;
            this.cb_blockToRead.Text = "BlockToRead";
            this.cb_blockToRead.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(11, 127);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(110, 1);
            this.panel4.TabIndex = 12;
            // 
            // cb_blockToWrite
            // 
            this.cb_blockToWrite.AutoSize = true;
            this.cb_blockToWrite.Location = new System.Drawing.Point(13, 202);
            this.cb_blockToWrite.Name = "cb_blockToWrite";
            this.cb_blockToWrite.Size = new System.Drawing.Size(96, 16);
            this.cb_blockToWrite.TabIndex = 13;
            this.cb_blockToWrite.Text = "BlockToWrite";
            this.cb_blockToWrite.UseVisualStyleBackColor = true;
            this.cb_blockToWrite.CheckedChanged += new System.EventHandler(this.cb_blockToWrite_CheckedChanged);
            // 
            // tb_blockToWrite
            // 
            this.tb_blockToWrite.Location = new System.Drawing.Point(13, 221);
            this.tb_blockToWrite.MaxLength = 16;
            this.tb_blockToWrite.Name = "tb_blockToWrite";
            this.tb_blockToWrite.Size = new System.Drawing.Size(108, 21);
            this.tb_blockToWrite.TabIndex = 14;
            this.tb_blockToWrite.Visible = false;
            // 
            // clb_antIDList
            // 
            this.clb_antIDList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clb_antIDList.CheckOnClick = true;
            this.clb_antIDList.FormattingEnabled = true;
            this.clb_antIDList.Items.AddRange(new object[] {
            "ANT_ID - 1",
            "ANT_ID - 2",
            "ANT_ID - 3",
            "ANT_ID - 4",
            "ANT_ID - 5",
            "ANT_ID - 6",
            "ANT_ID - 7",
            "ANT_ID - 8"});
            this.clb_antIDList.Location = new System.Drawing.Point(13, 257);
            this.clb_antIDList.Name = "clb_antIDList";
            this.clb_antIDList.Size = new System.Drawing.Size(108, 130);
            this.clb_antIDList.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 437);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cb_AFIToRead
            // 
            this.cb_AFIToRead.AutoSize = true;
            this.cb_AFIToRead.Location = new System.Drawing.Point(14, 144);
            this.cb_AFIToRead.Name = "cb_AFIToRead";
            this.cb_AFIToRead.Size = new System.Drawing.Size(78, 16);
            this.cb_AFIToRead.TabIndex = 17;
            this.cb_AFIToRead.Text = "AFIToRead";
            this.cb_AFIToRead.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel5.Controls.Add(this.label1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(3, 415);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(737, 53);
            this.panel5.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Font = new System.Drawing.Font("宋体", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(307, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 52);
            this.label1.TabIndex = 8;
            this.label1.Text = "0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // richTextBox2
            // 
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox2.Location = new System.Drawing.Point(3, 3);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(737, 412);
            this.richTextBox2.TabIndex = 10;
            this.richTextBox2.Text = "";
            this.richTextBox2.Click += new System.EventHandler(this.richTextBox2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(884, 511);
            this.panel1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HD Tech";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button b_setOutput;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox cb_AFIToRead;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckedListBox clb_antIDList;
        private System.Windows.Forms.TextBox tb_blockToWrite;
        private System.Windows.Forms.CheckBox cb_blockToWrite;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox cb_blockToRead;
        private System.Windows.Forms.Button b_stopInventory;
        private System.Windows.Forms.Button b_inventory;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox cb_readSecSta;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tb_antID;
        private System.Windows.Forms.TextBox tb_selecttagID;
        private System.Windows.Forms.TextBox tb_blockData;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button b_lockDSFID;
        private System.Windows.Forms.Button b_lockAFI;
        private System.Windows.Forms.Label l_ICreference;
        private System.Windows.Forms.Label l_blockNumber;
        private System.Windows.Forms.Label l_blockSize;
        private System.Windows.Forms.Label l_UID;
        private System.Windows.Forms.Button b_writeDSFID;
        private System.Windows.Forms.Button b_writeAFI;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_afi;
        private System.Windows.Forms.TextBox tb_dsfid;
        private System.Windows.Forms.Button b_getTagSysInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button b_writeMultiple;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbb_blockNumber;
        private System.Windows.Forms.ComboBox cbb_startAddress;
        private System.Windows.Forms.Button b_readMultiple;
        private System.Windows.Forms.Panel panel1;
    }
}

