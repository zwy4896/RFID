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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string user = textBox_user.Text.ToString();
            string pswd = textBox_pswd.Text.ToString();
            if (Check_ID("admin", "admin"))
            {
                main form = new main();
                form.Show();
                this.Visible = false;
            }
        }
        private bool Check_ID(string user, string pswd)
        {
            bool state = false;
            MySqlDataReader reader = null;
            string constructorString = "server=localhost;User Id=root;password=1234567890;Database=test";
            MySqlConnection myConnnect = new MySqlConnection(constructorString);
            myConnnect.Open();
            MySqlCommand myCmd = new MySqlCommand("SELECT * FROM test.admin where user='" + user + "'", myConnnect);
            // 查询结果返回给读取器
            if (myCmd.ExecuteScalar() != null)
            {
                reader = myCmd.ExecuteReader();
                if (reader.Read())
                {
                    if ((user == reader[1].ToString()) && (pswd == reader[2].ToString()))
                    {
                        state = true;
                    }
                    else
                    {
                        MessageBox.Show("账号或密码错误");
                        state = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("账号或密码错误");
                state = false;
            }
            if (reader != null)
            {
                reader.Close();
            }
            if (myConnnect != null)
            {
                myConnnect.Close();
            }
            myConnnect.Close();

            return state;
        }
    }
}
