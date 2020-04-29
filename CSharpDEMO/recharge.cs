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
    public partial class recharge : Form
    {
        DataOperator dataOper = new DataOperator();  //创建数据操作类的对象

        public recharge(string RFID, string name, string balance)
        {
            InitializeComponent();
            tb_RFID.Text = RFID;
            tb_name.Text = name;
            tb_balance_1.Text = balance;
        }

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void Btn_queren_Click(object sender, EventArgs e)
        {
            //数据库连接串
            tb_balance_1.Text = (float.Parse(tb_balance_1.Text) + float.Parse(tb_chongzhi.Text)).ToString();
            string constructorString = "UPDATE card_info SET balance='{0}' WHERE RFID='{1}'";
            MySqlConnection myConnnect = null;
            try
            {
                //填充占位符
                constructorString = string.Format(constructorString, tb_balance_1.Text, tb_RFID.Text);
                //执行insert操作的SQL
                int execSqlResult = dataOper.ExecSQLResult(constructorString);
                //弹出成功提示
                MessageBox.Show("充值成功！");
                //设置当前窗体DislogResult结果为OK
                this.DialogResult = DialogResult.OK;
                //关闭窗体
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("充值失败！" + ex.Message);
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
    }
}
