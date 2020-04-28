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
            this.btn_insert = new System.Windows.Forms.Button();
            this.btn_recharge = new System.Windows.Forms.Button();
            this.btn_research = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(991, 417);
            this.dataGridView1.TabIndex = 0;
            // 
            // btn_insert
            // 
            this.btn_insert.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_insert.Location = new System.Drawing.Point(136, 474);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(75, 23);
            this.btn_insert.TabIndex = 1;
            this.btn_insert.Text = "写入数据";
            this.btn_insert.UseVisualStyleBackColor = true;
            // 
            // btn_recharge
            // 
            this.btn_recharge.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_recharge.Location = new System.Drawing.Point(281, 474);
            this.btn_recharge.Name = "btn_recharge";
            this.btn_recharge.Size = new System.Drawing.Size(75, 23);
            this.btn_recharge.TabIndex = 1;
            this.btn_recharge.Text = "充值";
            this.btn_recharge.UseVisualStyleBackColor = true;
            // 
            // btn_research
            // 
            this.btn_research.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_research.Location = new System.Drawing.Point(427, 474);
            this.btn_research.Name = "btn_research";
            this.btn_research.Size = new System.Drawing.Size(75, 23);
            this.btn_research.TabIndex = 1;
            this.btn_research.Text = "查询";
            this.btn_research.UseVisualStyleBackColor = true;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 553);
            this.Controls.Add(this.btn_research);
            this.Controls.Add(this.btn_recharge);
            this.Controls.Add(this.btn_insert);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "main";
            this.Text = "HD Tech 会员卡管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.Button btn_recharge;
        private System.Windows.Forms.Button btn_research;
    }
}