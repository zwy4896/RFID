namespace CSharpDEMO
{
    partial class UpdateForm
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
            this.tb_RFID = new System.Windows.Forms.TextBox();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.tb_chongzhi = new System.Windows.Forms.TextBox();
            this.btn_queren = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_RFID
            // 
            this.tb_RFID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_RFID.Location = new System.Drawing.Point(132, 114);
            this.tb_RFID.Name = "tb_RFID";
            this.tb_RFID.ReadOnly = true;
            this.tb_RFID.Size = new System.Drawing.Size(161, 21);
            this.tb_RFID.TabIndex = 0;
            // 
            // tb_name
            // 
            this.tb_name.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_name.Location = new System.Drawing.Point(132, 141);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(161, 21);
            this.tb_name.TabIndex = 0;
            // 
            // tb_chongzhi
            // 
            this.tb_chongzhi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tb_chongzhi.Location = new System.Drawing.Point(132, 168);
            this.tb_chongzhi.Name = "tb_chongzhi";
            this.tb_chongzhi.Size = new System.Drawing.Size(161, 21);
            this.tb_chongzhi.TabIndex = 0;
            // 
            // btn_queren
            // 
            this.btn_queren.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_queren.Location = new System.Drawing.Point(132, 206);
            this.btn_queren.Name = "btn_queren";
            this.btn_queren.Size = new System.Drawing.Size(67, 26);
            this.btn_queren.TabIndex = 1;
            this.btn_queren.Text = "确认";
            this.btn_queren.UseVisualStyleBackColor = true;
            this.btn_queren.Click += new System.EventHandler(this.Btn_queren_Click);
            // 
            // btn_close
            // 
            this.btn_close.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_close.Location = new System.Drawing.Point(226, 206);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(67, 26);
            this.btn_close.TabIndex = 1;
            this.btn_close.Text = "关闭";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.Btn_close_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "卡号";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "姓名";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "金额";
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 332);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_queren);
            this.Controls.Add(this.tb_chongzhi);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.tb_RFID);
            this.MaximizeBox = false;
            this.Name = "UpdateForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "激活";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_RFID;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.TextBox tb_chongzhi;
        private System.Windows.Forms.Button btn_queren;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}