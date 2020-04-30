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
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;


namespace CSharpDEMO
{
    public partial class main : Form
    {
        DataOperator dataOper = new DataOperator();  //创建数据操作类的对象

        public main()
        {
            InitializeComponent();
            QueryAllInfo();
        }
        //查询全部数据
        private void QueryAllInfo()
        {
            //数据库连接串
            string constructorString = "SELECT * FROM test.card_info";
            MySqlConnection myConnnect = null;
            //Console.WriteLine("OK");
            try
            {
                DataSet ds = dataOper.GetDataSet(constructorString);
                //设置表格控件的DataSource属性
                dataGridView1.DataSource = ds.Tables[0];
                //设置数据表格上显示的列标题
                dataGridView1.Columns[0].HeaderText = "ID";
                dataGridView1.Columns[1].HeaderText = "卡号";
                dataGridView1.Columns[2].HeaderText = "姓名";
                dataGridView1.Columns[3].HeaderText = "余额";
                //设置数据表格为只读
                dataGridView1.ReadOnly = true;
                //不允许添加行
                dataGridView1.AllowUserToAddRows = false;
                //背景为白色
                dataGridView1.BackgroundColor = Color.White;
                //只允许选中单行
                dataGridView1.MultiSelect = false;
                //整行选中
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询错误！" + ex.Message);
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

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Btn_research_Click(object sender, EventArgs e)
        {
            if (tb_rfid.Text != "")
            {
                //数据库连接串
                string constructorString = "select * from test.card_info where RFID like '%{0}%'";
                try
                {
                    constructorString = string.Format(constructorString, tb_rfid.Text);
                    DataSet ds = dataOper.GetDataSet(constructorString);
                    if (ds != null)
                    {
                        dataGridView1.DataSource = ds.Tables[0];
                    }
                    if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("此卡未激活！");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("出现错误！" + ex.Message);
                }
                finally
                {
                    if (dataOper.connection != null)
                    {
                        //关闭数据库连接
                        dataOper.connection.Close();
                    }
                }
            }
            if(tb_rfid.Text == "")
            {
                MessageBox.Show("未检测到卡！");
            }
        }
        private string ConvertData(byte[] data, int s, int e)
        {
            string dataOut = "";
            //非负转换
            for (int i = 0; i < e; i++)
            {
                if (data[s + i] < 0)
                    data[s + i] = Convert.ToByte(Convert.ToInt32(data[s + i]) + 256);
            }
            for (int i = 0; i < e; i++)
            {
                dataOut += data[s + i].ToString("X2");
            }
            return dataOut;
        }
        private byte[] convertSNR(string str, int keyN)
        {
            string regex = "[^a-fA-F0-9]";
            string tmpJudge = Regex.Replace(str, regex, "");

            //长度不对，直接退回错误
            if (tmpJudge.Length != 12) return null;

            string[] tmpResult = Regex.Split(str, regex);
            byte[] result = new byte[keyN];
            int i = 0;
            foreach (string tmp in tmpResult)
            {
                result[i] = Convert.ToByte(tmp, 16);
                i++;
            }
            return result;
        }
        private string Read_Card()
        {
            byte mode1 = (byte)0x00;
            byte mode2 = (byte)0x00;
            byte mode = (byte)((mode1 << 1) | mode2);
            byte blk_add = Convert.ToByte(10.ToString(), 16);
            byte num_blk = Convert.ToByte(01.ToString(), 16);

            string rfid = "";
            byte[] snr = new byte[6];
            snr = convertSNR("FF FF FF FF FF FF", 6);
            if (snr == null)
            {
                MessageBox.Show("序列号无效！", "错误");
                //return rfid;
            }

            byte[] buffer = new byte[16 * num_blk];
            int nRet = Reader.MF_Read(mode, blk_add, num_blk, snr, buffer);
            if (nRet != 0)
            {
                MessageBox.Show("test: " + buffer[0].ToString());
            }
            else
            {
                rfid = ConvertData(snr, 0, 4);
                //MessageBox.Show("卡号: " + rfid);
            }
            return rfid;
        }

        private void Btn_readCard_Click_1(object sender, EventArgs e)
        {
            string rfid = Read_Card();
            tb_rfid.Text = rfid;
        }

        private void Btn_activation_Click(object sender, EventArgs e)
        {
            string rfid = Read_Card();
            UpdateForm updateform = new UpdateForm(rfid);
            DialogResult dr = updateform.ShowDialog();
            //判断是否单击确定按钮
            if (dr == DialogResult.OK)
            {
                QueryAllInfo();
            }
        }

        private void Btn_diplayAll_Click(object sender, EventArgs e)
        {
            tb_rfid.Text = "";
            QueryAllInfo();
        }

        private void Btn_recharge_Click(object sender, EventArgs e)
        {
            string rfid = Read_Card();
            string name = "";
            string balance = "";

            //数据库连接串
            string constructorString = "SELECT name, balance FROM test.card_info where RFID like '%{0}%'";
            //Console.WriteLine("OK");
            try
            {
                constructorString = string.Format(constructorString, rfid);
                MySqlDataReader reader = dataOper.GetDataReader(constructorString);
                if (reader.Read())
                {
                    name = reader["name"].ToString();
                    balance = reader["balance"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询错误！" + ex.Message);
            }
            finally
            {
                if (dataOper.connection != null)
                {
                    //关闭数据库连接
                    dataOper.connection.Close();
                }
            }
            recharge rechargeForm = new recharge(rfid, name, balance);
            DialogResult dr = rechargeForm.ShowDialog();
            //判断是否单击确定按钮
            if (dr == DialogResult.OK)
            {
                QueryAllInfo();
            }
        }
    }
}
