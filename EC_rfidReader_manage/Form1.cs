﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using CSharpDEMO;

namespace EC_rfidReader
{
    public partial class Form1 : Form
    {
        DataOperator dataOper = new DataOperator();

        private RFIDLIB.rfidlib_reader reader = new RFIDLIB.rfidlib_reader();
        
        public UIntPtr hTag;
        public Byte enableAFI;
        public Byte AFI;
        public Byte onlyNewTag;
        public UInt32 antennaCount;
        public bool _shouldStop;
        public Byte readerType;
        public Byte[] AntennaSel;
        public Byte AntennaSelCount;
        public ArrayList readerDriverInfoList;

        public Hashtable _htTag;
        public int _nTagCount;

        Thread InvenThread;
        public static bool doInventory = false;

        delegate void HandleInterfaceReport(int op, string uidStr, string blockDataStr, string DSFIDStr, string otherStr); //委托处理接收数据
        HandleInterfaceReport tagReportHandler;
        public Form1()
        {
            InitializeComponent();
            tagReportHandler = new HandleInterfaceReport(tagReport);//实例化委托对象（处理接收数据）
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int nCOMCnt = reader.COMPort_Enum();

            string comName = "";
            for (int i = 0; i < nCOMCnt; i++)
            {
                reader.COMPort_GetEnumItem(i, ref comName);
                cbb_comPort.Items.Add(comName);
            }
            cbb_comPort.Items.Add("USB");
            cbb_comPort.Items.Add("NET");

            if (cbb_comPort.Items.Count > 0)
            {
                cbb_comPort.SelectedIndex = 0;
            }
        }

        private static byte[] HexStrToByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        private void b_open_Click(object sender, EventArgs e)
        {
            int iret = 0;
            string connstr = "";

            if (cbb_comPort.Text == "USB")
            {
                int nCount = reader.HIDDriver_Enum();
                if (nCount > 0)
                {
                    string sernum = "";
                    iret = reader.HIDDriver_GetEnumItem(0, ref sernum);
                    if (iret == 0)
                    {
                        connstr = RFIDLIB.rfidlib_def.CONNSTR_NAME_RDTYPE + "=" + "EC1501" + ";" +
                                  RFIDLIB.rfidlib_def.CONNSTR_NAME_COMMTYPE + "=" + RFIDLIB.rfidlib_def.CONNSTR_NAME_COMMTYPE_USB + ";" +
                                  RFIDLIB.rfidlib_def.CONNSTR_NAME_HIDADDRMODE + "=" + 1 + ";" +
                                  RFIDLIB.rfidlib_def.CONNSTR_NAME_HIDSERNUM + "=" + sernum;
                    }
                }
            }
            else if (cbb_comPort.Text == "NET")
            {
                connstr = RFIDLIB.rfidlib_def.CONNSTR_NAME_RDTYPE + "=" + "EC1501" + ";" +
                          RFIDLIB.rfidlib_def.CONNSTR_NAME_COMMTYPE + "=" + RFIDLIB.rfidlib_def.CONNSTR_NAME_COMMTYPE_NET + ";" +
                          RFIDLIB.rfidlib_def.CONNSTR_NAME_REMOTEIP + "=" + cbb_IPAddr.Text + ";" +
                          RFIDLIB.rfidlib_def.CONNSTR_NAME_REMOTEPORT + "=" + "6688";
            }
            // 测试使用
            else if (cbb_comPort.Text == "TEST")
            {
                connstr = "test";
            }
            else
            {
                connstr = RFIDLIB.rfidlib_def.CONNSTR_NAME_RDTYPE + "=" + "EC1501" + ";" +
                          RFIDLIB.rfidlib_def.CONNSTR_NAME_COMMTYPE + "=" + RFIDLIB.rfidlib_def.CONNSTR_NAME_COMMTYPE_COM + ";" +
                          RFIDLIB.rfidlib_def.CONNSTR_NAME_COMNAME + "=" + cbb_comPort.Text + ";" +
                          RFIDLIB.rfidlib_def.CONNSTR_NAME_COMBARUD + "=" + "38400" + ";" +
                          RFIDLIB.rfidlib_def.CONNSTR_NAME_COMFRAME + "=" + "8E1" + ";" +
                          RFIDLIB.rfidlib_def.CONNSTR_NAME_BUSADDR + "=" + "255";
            }
            if (connstr != "")
            {
                try
                {
                    iret = reader.RDR_Open(connstr);
                    if (iret == 0)
                    {
                        b_open.Enabled = false;
                        b_close.Enabled = true;
                        b_inventory.Enabled = true;
                        b_stopInventory.Enabled = false;

                        get_DriverInfo();
                    }
                    else
                    {
                        MessageBox.Show("端口错误 " + iret.ToString());
                    }
                }
                catch (ArgumentException)
                {
                    MessageBox.Show("端口错误: " + "ArgumentException");
                }
                catch (IOException)
                {
                    MessageBox.Show("端口错误 " + "IOException");
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("端口错误 " + "InvalidOperationException");
                }
                //iret = reader.RDR_Open(connstr);
                //if (iret == 0 | connstr == "test")
                //{
                //    b_open.Enabled = false;
                //    b_close.Enabled = true;
                //    b_inventory.Enabled = true;
                //    b_stopInventory.Enabled = false;

                //    get_DriverInfo();
                //}
                //else
                //{
                //    MessageBox.Show("open fail " + iret.ToString());
                //}
            }

        }

        private void get_DriverInfo()
        {
            int iret = 0;
            string devInfo = "";
            tb_deviceInfo.Clear();
            //获取读写器信息
            iret = reader.RDR_GetReaderInfor(ref devInfo);
            if (iret == 0)
            {
                string[] devInfo_arr = devInfo.Split('|');
                tb_deviceInfo.AppendText("Version: " + "1.0.0" + "\r\n");
                tb_deviceInfo.AppendText("Device Type: " + "HD Tech reader");
                //tb_deviceInfo.AppendText("Serial Number:" + devInfo_arr[2]);
            }
        }

        private void b_close_Click(object sender, EventArgs e)
        {
            int iret = 0;
            iret = reader.RDR_Close();
            if (iret == 0)
            {
                b_open.Enabled = true;
                b_close.Enabled = false;
                b_inventory.Enabled = false;
                b_stopInventory.Enabled = false;

                tb_deviceInfo.Clear();
            }
        }

        private void b_inventory_Click(object sender, EventArgs e)
        {
            _shouldStop = false;
            InvenThread = new Thread(Inventory);
            InvenThread.Start();

            b_close.Enabled = false;
            b_inventory.Enabled = false;
            b_stopInventory.Enabled = true;
        }

        private void Inventory()
        {
            Byte AIType = RFIDLIB.rfidlib_def.AI_TYPE_NEW;
            AntennaSelCount = 0;

            while (!_shouldStop)
            {
                int iret;
                iret = reader.RDR_TagInventory(AIType, AntennaSelCount, AntennaSel);//盘点标签
                if (iret == 0)
                {
                    Invoke(tagReportHandler, new object[] { 0, null, null, null, null });
                    Invoke(tagReportHandler, new object[] { 2, null, null, null, reader.RDR_GetTagDataReportCount().ToString() });

                    int TagDataReport;
                    TagDataReport = reader.RDR_GetTagDataReportCount();//获取标签数量
                    while (TagDataReport > 0)
                    {
                        TagDataReport--;
                        int ant_id = 0;
                        Byte dsfid = 0;
                        Byte[] uid = new Byte[8];

                        //获取标签数据（数据列表序号，天线ID号，dsfid，标签ID）
                        iret = reader.ISO15693_ParseTagDataReport(TagDataReport, ref ant_id, ref dsfid, ref uid);
                        if (iret == 0)
                        {
                            string uidStr = BitConverter.ToString(uid).Replace("-", string.Empty);
                            //test_char = test_readTxt(uidStr);
                            //object[] pList = { 1, uidStr, "", dsfid.ToString("X2") + " - AFI:" + afi.ToString("X2") + " - BlockData:" + blockData, ant_id.ToString().PadLeft(2, '0') };
                            object[] pList = { 1, uidStr, null, null, null };
                            Invoke(tagReportHandler, pList);
                        }
                    }
                }
                Thread.Sleep(5);
            }
        }

        public void tagReport(int op, string uidStr, string blockDataStr, string DSFIDStr, string otherStr)
        {
            if (op == 0)//清空
            {
                richTextBox2.Text = "";
                label2.Text = "数量: " + "0";
            }
            else if (op == 1)//扫描
            {
                //richTextBox2.AppendText(uidStr + " - dsfid:" + DSFIDStr + " - antid:" + otherStr + "\r\n");
                richTextBox2.AppendText(uidStr + "\r\n");
            }
            else if (op == 2)//数量
            {
                label2.Text = "数量: " + otherStr;
            }
        }

        private void b_stopInventory_Click(object sender, EventArgs e)
        {
            _shouldStop = true;

            b_close.Enabled = true;
            b_inventory.Enabled = true;
            b_stopInventory.Enabled = false;
        }

        private void cbb_comPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_comPort.SelectedIndex == cbb_comPort.Items.Count - 1)
            {
                splitContainer1.Panel1Collapsed = false;
            }
            else
            {
                splitContainer1.Panel1Collapsed = true;
            }
        }

        private void b_getNetDriver_Click(object sender, EventArgs e)
        {
            b_getNetDriver.Enabled = false;
            b_open.Enabled = false;
            cbb_IPAddr.Items.Clear();
            int nNetDriverCnt = reader.NETDriver_Enum();
            string netDriverPart = "";
            string IPAddr = "";
            for (int i = 0; i < nNetDriverCnt; i++)
            {
                //获取符合条件的网络设备
                reader.NETDriver_GetEnumItem(i, ref netDriverPart);
                string[] connParameter = netDriverPart.Split(';');
                foreach (string parameter in connParameter)
                {
                    if (parameter.Contains("IP")) { IPAddr = parameter.Split('=')[1]; break; }
                }
                cbb_IPAddr.Items.Add(IPAddr);
            }
            if (nNetDriverCnt > 0) { cbb_IPAddr.SelectedIndex = 0; }
            b_getNetDriver.Enabled = true;
            b_open.Enabled = true;
        }

        private void b_setOutput_Click(object sender, EventArgs e)
        {
            //设置设备输出端口
            reader.RDR_SetOutput(RFIDLIB.rfidlib_def.OUTPUT_RELAY, 0x00, 0x02);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (string charRFID in richTextBox2.Lines)
                {
                    string constructorString = "SELECT 1 FROM test1 WHERE RFID='{0}'";
                    if (charRFID == "")
                    {
                        continue;
                    }
                    constructorString = string.Format(constructorString, charRFID);
                    int num = dataOper.ExecSQL(constructorString);
                    if (num == 1)   // 更新数据
                    {
                        string updateCmd = "UPDATE test1 SET name='{0}',price={1} WHERE RFID='{2}'";
                        updateCmd = string.Format(updateCmd, textBox1.Text, textBox2.Text, charRFID);
                        dataOper.UpdateDB(updateCmd);
                    }
                    else if (num == 0)  // 插入数据
                    {
                        string insertCmd = "INSERT INTO test1(RFID,name,price) VALUES('{0}','{1}',{2})";
                        insertCmd = string.Format(insertCmd, charRFID, textBox1.Text, textBox2.Text);
                        dataOper.UpdateDB(insertCmd);
                    }
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
        }
        private void TextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }
        private void TextBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
        }
        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //允许输入数字、小数点、删除键和负号  
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != (char)('.') && e.KeyChar != (char)('-'))
            {
                MessageBox.Show("请输入正确的数字");
                this.textBox1.Text = "";
                e.Handled = true;
            }
            if (e.KeyChar == (char)('-'))
            {
                if (textBox1.Text != "")
                {
                    MessageBox.Show("请输入正确的数字");
                    this.textBox1.Text = "";
                    e.Handled = true;
                }
            }
            /*小数点只能输入一次*/
            if (e.KeyChar == (char)('.') && ((TextBox)sender).Text.IndexOf('.') != -1)
            {
                MessageBox.Show("请输入正确的数字");
                this.textBox2.Text = "";
                e.Handled = true;
            }
            /*第一位不能为小数点*/
            if (e.KeyChar == (char)('.') && ((TextBox)sender).Text == "")
            {
                MessageBox.Show("请输入正确的数字");
                this.textBox2.Text = "";
                e.Handled = true;
            }
            /*第一位是0，第二位必须为小数点*/
            if (e.KeyChar != (char)('.') && ((TextBox)sender).Text == "0")
            {
                MessageBox.Show("请输入正确的数字");
                this.textBox2.Text = "";
                e.Handled = true;
            }
            /*第一位是负号，第二位不能为小数点*/
            if (((TextBox)sender).Text == "-" && e.KeyChar == (char)('.'))
            {
                MessageBox.Show("请输入正确的数字");
                this.textBox2.Text = "";
                e.Handled = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
