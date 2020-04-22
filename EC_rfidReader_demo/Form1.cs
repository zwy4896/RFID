using System;
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
using System.Text.RegularExpressions;
using CSharpDEMO;

namespace EC_rfidReader
{
    public partial class Form1 : Form
    {
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

        delegate void HandleInterfaceReport(int op, string uidStr, string blockDataStr, string DSFIDStr, string otherStr, string[] testChar); //委托处理接收数据
        HandleInterfaceReport tagReportHandler;
        float total_price = 0;  // 菜品总价
        float out_totalPrice = 0;
        public Form1()
        {
            InitializeComponent();
            tagReportHandler = new HandleInterfaceReport(tagReport);//实例化委托对象（处理接收数据）
        }

        //转换卡号专用
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
                catch(ArgumentException)
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
                //if (iret == 0)
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
                    Invoke(tagReportHandler, new object[] { 0, null, null, null, null, null});
                    Invoke(tagReportHandler, new object[] { 2, null, null, null, reader.RDR_GetTagDataReportCount().ToString(), null});

                    int TagDataReport;
                    TagDataReport = reader.RDR_GetTagDataReportCount();//获取标签数量
                    //int tagData = TagDataReport;
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
                            string[] test_char;

                            string uidStr = BitConverter.ToString(uid).Replace("-", string.Empty);
                            test_char = Read_Menu(uidStr);
                            total_price += float.Parse(test_char[2]);
                            //object[] pList = { 1, uidStr, "", dsfid.ToString("X2") + " - AFI:" + afi.ToString("X2") + " - BlockData:" + blockData, ant_id.ToString().PadLeft(2, '0') };
                            object[] pList = {1, uidStr, null, null, null, test_char};
                            //Console.WriteLine(count.ToString() + " " + tagData.ToString());
                            Invoke(tagReportHandler, pList);
                        }
                    }
                }
                out_totalPrice = total_price;
                total_price = 0;
                Thread.Sleep(5);
            }
            //MessageBox.Show(out_totalPrice.ToString());
        }

        public void tagReport(int op, string uidStr, string blockDataStr, string DSFIDStr, string otherStr, string[] testChar)
        {
            if (op == 0)//清空
            {
                richTextBox2.Text = "";
                label1.Text = "金额: " + "0";
                label2.Text = "数量: " + "0";
            }
            else if (op == 1)//扫描
            {
                //richTextBox2.AppendText(uidStr + " - dsfid:" + DSFIDStr + " - antid:" + otherStr + "\r\n");
                //richTextBox2.AppendText(uidStr + "\r\n");
                richTextBox2.AppendText(testChar[1] + "  |  ￥ " + testChar[2] + "\r\n");
                richTextBox2.AppendText("---------------------------" + "\r\n");
                label1.Text = "金额: ￥" + total_price.ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            //byte[] cfgdata = new byte[8];
            //int cfgsize = 8;
            //reader.RDR_ConfigBlockRead(4, ref cfgdata, cfgsize);
            //cfgdata[0] = 0x00;
            //reader.RDR_ConfigBlockWrite(4, cfgdata, 8, 0xFFFF);
            //reader.RDR_ConfigBlockSave(4);
            //MessageBox.Show(reader.RDR_LoadFactoryDefault().ToString());
            //MessageBox.Show("TEST ONLY");
            richTextBox2.Clear();
            label2.Text = "数量: ";
            label1.Text = "金额: ";
        }

        private string[] Read_Menu(string uidStr)
        {
            string[] strSplit = {"", "", ""};
            MySqlDataReader reader = null;
            string constructorString = "server=localhost;User Id=root;password=1234567890;Database=test";
            MySqlConnection myConnnect = new MySqlConnection(constructorString);
            myConnnect.Open();
            MySqlCommand myCmd = new MySqlCommand("SELECT * FROM test.test where RFID='" + uidStr + "'", myConnnect);
            // 查询结果返回给读取器
            reader = myCmd.ExecuteReader();
            if (reader.Read())
            {
                strSplit[0] = reader[1].ToString();
                strSplit[1] = reader[2].ToString();
                strSplit[2] = reader[3].ToString();
            }
            if (reader != null)
            {
                reader.Close();
            }
            if(myConnnect != null)
            {
                myConnnect.Close();
            }
            return strSplit;
        }
        private void Read_Card_Info(string rfid)
        {
            //string balance = ""; // 账户余额
            string constructorString = "server=localhost;User Id=root;password=1234567890;Database=test";
            MySqlConnection myConnnect = new MySqlConnection(constructorString);
            myConnnect.Open();
            MySqlCommand myCmd = new MySqlCommand("SELECT * FROM test.card_info where RFID='" + rfid + "'", myConnnect);
            myCmd.ExecuteNonQuery();
            MySqlCommand insertCmd = new MySqlCommand("INSERT INTO card_info(RFID,name,bal) VALUES('" + rfid + "','" + "张三" + "','" + 1000 + "');", myConnnect);
            Console.WriteLine(insertCmd.CommandText);
            insertCmd.ExecuteNonQuery();
            myConnnect.Close();

            //return balance;
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
        private void Button2_Click_1(object sender, EventArgs e)
        {
            string rfid = Read_Card();
            MessageBox.Show("卡号:" + rfid);
            Read_Card_Info(rfid);
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

    }
}
