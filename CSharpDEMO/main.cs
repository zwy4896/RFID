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
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            QueryAllInfo();
        }
        //查询全部数据
        private void QueryAllInfo()
        {
            //数据库连接串
            string constructorString = "server=localhost;User Id=root;password=1234567890;Database=test";
            MySqlConnection myConnnect = null;
            try
            {
                myConnnect = new MySqlConnection(constructorString);
                myConnnect.Open();
                MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM test.card_info", myConnnect);
                //创建DataSet类的对象
                DataSet ds = new DataSet();
                //使用SqlDataAdapter对象sda将查新结果填充到DataSet对象ds中
                sda.Fill(ds);
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
    }
}
