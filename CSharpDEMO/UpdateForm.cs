using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CSharpDEMO
{
    public partial class UpdateForm : Form
    {
        DataOperator dataOper = new DataOperator();  //创建数据操作类的对象

        public UpdateForm(string RFID)
        {
            InitializeComponent();
            tb_RFID.Text = RFID;
        }

        private void Btn_queren_Click(object sender, EventArgs e)
        {

            //数据库连接串
            string constructorString = "INSERT INTO card_info(RFID,name,balance) VALUES('{0}','{1}',{2});";
            MySqlConnection myConnnect = null;

            try
            {
                //填充占位符
                constructorString = string.Format(constructorString, tb_RFID.Text, tb_name.Text, tb_chongzhi.Text);
                //执行insert操作的SQL
                int execSqlResult = dataOper.ExecSQLResult(constructorString);
                //弹出成功提示
                if (execSqlResult == 1) {
                    MessageBox.Show("激活成功！");
                }else {
                    MessageBox.Show("激活失败！");
                }
                    
                //设置当前窗体DislogResult结果为OK
                this.DialogResult = DialogResult.OK;
                //关闭窗体
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("激活失败！" + ex.Message);
            }
            finally
            {
                if (myConnnect != null)
                {
                    //关闭数据库连接
                    myConnnect.Close();
                }
            }
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tb_chongzhi_KeyPress(object sender, KeyPressEventArgs e)
        {
            //允许输入数字、小数点、删除键和负号  
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != (char)('.') && e.KeyChar != (char)('-'))
            {
                MessageBox.Show("请输入正确的数字");
                this.tb_chongzhi.Text = "";
                e.Handled = true;
            }
            if (e.KeyChar == (char)('-'))
            {
                if (tb_chongzhi.Text != "")
                {
                    MessageBox.Show("请输入正确的数字");
                    this.tb_chongzhi.Text = "";
                    e.Handled = true;
                }
            }
            /*小数点只能输入一次*/
            if (e.KeyChar == (char)('.') && ((TextBox)sender).Text.IndexOf('.') != -1)
            {
                MessageBox.Show("请输入正确的数字");
                this.tb_chongzhi.Text = "";
                e.Handled = true;
            }
            /*第一位不能为小数点*/
            if (e.KeyChar == (char)('.') && ((TextBox)sender).Text == "")
            {
                MessageBox.Show("请输入正确的数字");
                this.tb_chongzhi.Text = "";
                e.Handled = true;
            }
            /*第一位是0，第二位必须为小数点*/
            if (e.KeyChar != (char)('.') && ((TextBox)sender).Text == "0")
            {
                MessageBox.Show("请输入正确的数字");
                this.tb_chongzhi.Text = "";
                e.Handled = true;
            }
            /*第一位是负号，第二位不能为小数点*/
            if (((TextBox)sender).Text == "-" && e.KeyChar == (char)('.'))
            {
                MessageBox.Show("请输入正确的数字");
                this.tb_chongzhi.Text = "";
                e.Handled = true;
            }
        }
    }
}
