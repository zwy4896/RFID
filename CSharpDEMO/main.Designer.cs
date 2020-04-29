namespace CSharpDEMO
{
    partial class main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_activation = new System.Windows.Forms.Button();
            this.btn_recharge = new System.Windows.Forms.Button();
            this.btn_research = new System.Windows.Forms.Button();
            this.tb_rfid = new System.Windows.Forms.TextBox();
            this.btn_readCard = new System.Windows.Forms.Button();
            this.btn_diplayAll = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1280, 585);
            this.dataGridView1.TabIndex = 0;
            // 
            // btn_activation
            // 
            this.btn_activation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_activation.Location = new System.Drawing.Point(1019, 11);
            this.btn_activation.Name = "btn_activation";
            this.btn_activation.Size = new System.Drawing.Size(75, 23);
            this.btn_activation.TabIndex = 1;
            this.btn_activation.Text = "激活";
            this.btn_activation.UseVisualStyleBackColor = true;
            this.btn_activation.Click += new System.EventHandler(this.Btn_activation_Click);
            // 
            // btn_recharge
            // 
            this.btn_recharge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_recharge.Location = new System.Drawing.Point(1100, 11);
            this.btn_recharge.Name = "btn_recharge";
            this.btn_recharge.Size = new System.Drawing.Size(75, 23);
            this.btn_recharge.TabIndex = 1;
            this.btn_recharge.Text = "充值";
            this.btn_recharge.UseVisualStyleBackColor = true;
            this.btn_recharge.Click += new System.EventHandler(this.Btn_recharge_Click);
            // 
            // btn_research
            // 
            this.btn_research.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_research.Location = new System.Drawing.Point(278, 11);
            this.btn_research.Name = "btn_research";
            this.btn_research.Size = new System.Drawing.Size(75, 23);
            this.btn_research.TabIndex = 1;
            this.btn_research.Text = "查询";
            this.btn_research.UseVisualStyleBackColor = true;
            this.btn_research.Click += new System.EventHandler(this.Btn_research_Click);
            // 
            // tb_rfid
            // 
            this.tb_rfid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_rfid.Location = new System.Drawing.Point(10, 11);
            this.tb_rfid.Name = "tb_rfid";
            this.tb_rfid.Size = new System.Drawing.Size(181, 21);
            this.tb_rfid.TabIndex = 2;
            // 
            // btn_readCard
            // 
            this.btn_readCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_readCard.Location = new System.Drawing.Point(197, 11);
            this.btn_readCard.Name = "btn_readCard";
            this.btn_readCard.Size = new System.Drawing.Size(75, 23);
            this.btn_readCard.TabIndex = 3;
            this.btn_readCard.Text = "读卡";
            this.btn_readCard.UseVisualStyleBackColor = true;
            this.btn_readCard.Click += new System.EventHandler(this.Btn_readCard_Click_1);
            // 
            // btn_diplayAll
            // 
            this.btn_diplayAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_diplayAll.Location = new System.Drawing.Point(359, 11);
            this.btn_diplayAll.Name = "btn_diplayAll";
            this.btn_diplayAll.Size = new System.Drawing.Size(75, 23);
            this.btn_diplayAll.TabIndex = 1;
            this.btn_diplayAll.Text = "显示全部";
            this.btn_diplayAll.UseVisualStyleBackColor = true;
            this.btn_diplayAll.Click += new System.EventHandler(this.Btn_diplayAll_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_recharge);
            this.panel1.Controls.Add(this.btn_readCard);
            this.panel1.Controls.Add(this.btn_activation);
            this.panel1.Controls.Add(this.btn_research);
            this.panel1.Controls.Add(this.tb_rfid);
            this.panel1.Controls.Add(this.btn_diplayAll);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 591);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1280, 201);
            this.panel1.TabIndex = 4;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 792);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HD Tech 会员卡管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_activation;
        private System.Windows.Forms.Button btn_recharge;
        private System.Windows.Forms.Button btn_research;
        private System.Windows.Forms.TextBox tb_rfid;
        private System.Windows.Forms.Button btn_readCard;
        private System.Windows.Forms.Button btn_diplayAll;
        private System.Windows.Forms.Panel panel1;
    }
}