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
            string constructorString = "INSERT INTO card_info(RFID,name,balance) VALUES('{0}','{1}','{2}');";
            MySqlConnection myConnnect = null;

            try
            {
                //填充占位符
                constructorString = string.Format(constructorString, tb_RFID.Text, tb_name.Text, tb_chongzhi.Text);
                //执行insert操作的SQL
                int execSqlResult = dataOper.ExecSQLResult(constructorString);
                //弹出成功提示
                MessageBox.Show("激活成功！");
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
    }
}
