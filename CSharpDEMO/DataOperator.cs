using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace CSharpDEMO
{
    class DataOperator
    {
        // 数据库连接字符串
        //private static string connString = @"server=localhost;User Id=root;password=1234567890;Database=test";
        private static string connString = @"Data Source=localhost;Database=test;User ID=root;Pwd=1234567890;";
        //private static string connString = @"Data Source=localhost;Database=test;User ID=root;Pwd=1235;";
        // 数据库连接对象
        public MySqlConnection connection = new MySqlConnection(connString);

        public int ExecSQL(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, connection);  //指定要执行的sql语句
            if (connection.State == ConnectionState.Closed)  // 如果当前数据库连接处于关闭状态
            {
                connection.Open();  // 打开数据库连接
            }
            int num = Convert.ToInt32(command.ExecuteScalar());  //执行查询
            connection.Close();
            return num;
        }

        public int ExecSQLResult(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, connection);  // 指定要执行的sql语句
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            int result = command.ExecuteNonQuery();  //执行SQL语句
            connection.Close();  //关闭数据库连接
            return result;
        }

        public DataSet GetDataSet(string sql)
        {
            //Console.WriteLine("OK");
            if (connection.State == ConnectionState.Closed)  // 如果当前数据库连接处于关闭状态
            {
                connection.Open();  // 打开数据库连接
            }
            MySqlDataAdapter sqlda = new MySqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();  //创建数据集对象
            sqlda.Fill(ds);  // 填充数据集
            return ds;  //返回数据集
        }

        //  GetDataReader方法，用来执行SQL查询，并返回SqlDataReader。
        public MySqlDataReader GetDataReader(string sql)
        {
            if (connection.State == ConnectionState.Closed)  // 如果当前数据库连接处于关闭状态
            {
                connection.Open();  // 打开数据库连接
            }
            MySqlCommand command = new MySqlCommand(sql, connection);
            //if (connection.State == ConnectionState.Open)  //如果当前数据库连接处于打开状态
            //{
            //    connection.Close();  //关闭数据库连接
            //}
            //connection.Open();  //  打开连接
            MySqlDataReader dataReader = command.ExecuteReader();
            return dataReader;
        }
        public bool ExcuteTransactionSQL(List<string> strSQL)
        {
            connection.Open();
            MySqlTransaction transaction = connection.BeginTransaction();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            cmd.Transaction = transaction;
            try
            {
                for (int n = 0; n < strSQL.Count; n++)
                {
                    string strsql = strSQL[n];
                    if (strsql.Trim().Length > 1)
                    {
                        cmd.CommandText = strsql;
                        cmd.ExecuteNonQuery();
                        Console.WriteLine(strsql);
                    }
                }
                //cmd.ExecuteNonQuery();
                transaction.Commit();
                connection.Close();
                return true;
            }
            catch
            {
                transaction.Rollback();
                connection.Close();
                return false;
            }
        }
    }
}
