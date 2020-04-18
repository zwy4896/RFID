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
            //cbb_comPort.Items.Add("TEST");

            if (cbb_comPort.Items.Count > 0)
            {
                cbb_comPort.SelectedIndex = 0;
            }
            cbb_startAddress.SelectedIndex = 0;
            cbb_blockNumber.SelectedIndex = 0;
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
                iret = reader.RDR_Open(connstr);
                if (iret == 0 | connstr == "test")
                {
                    b_open.Enabled = false;
                    b_close.Enabled = true;
                    b_inventory.Enabled = true;
                    b_stopInventory.Enabled = false;
                    b_readMultiple.Enabled = true;
                    b_writeMultiple.Enabled = true;
                    b_writeAFI.Enabled = true;
                    b_writeDSFID.Enabled = true;
                    b_lockAFI.Enabled = true;
                    b_lockDSFID.Enabled = true;
                    b_getTagSysInfo.Enabled = true;

                    b_setOutput.Enabled = true;

                    get_DriverInfo();
                }
                else
                {
                    MessageBox.Show("open fail " + iret.ToString());
                }
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
                tb_deviceInfo.AppendText("Version:" + "1.0.0" + "\r\n");
                tb_deviceInfo.AppendText("Device Type:" + "HD Tech reader");
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

                b_readMultiple.Enabled = false;
                b_writeMultiple.Enabled = false;
                b_writeAFI.Enabled = false;
                b_writeDSFID.Enabled = false;
                b_lockAFI.Enabled = false;
                b_lockDSFID.Enabled = false;
                b_getTagSysInfo.Enabled = false;

                b_setOutput.Enabled = false;

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

            clb_antIDList.Enabled = false;
        }

        private void Inventory()
        {
            Byte AIType = RFIDLIB.rfidlib_def.AI_TYPE_NEW;
            int checkedItemsIndex = 0;
            AntennaSelCount = 0;

            while (!_shouldStop)
            {
                /*//设置天线，用于多天线读写器轮询工作，单天线读写器不需要设置。*/
                int checkedItemsCount = clb_antIDList.CheckedItems.Count;
                byte selectAntID = 0;
                if (checkedItemsCount > 0)
                {
                    string checkedItemsIndexText = clb_antIDList.GetItemText(clb_antIDList.CheckedItems[checkedItemsIndex]);
                    selectAntID = byte.Parse(checkedItemsIndexText.Substring(checkedItemsIndexText.Length - 1));
                    if (reader.RDR_SetAcessAntenna(selectAntID) == 0) { AntennaSelCount = 1; }
                    checkedItemsIndex++;
                    if (checkedItemsIndex >= checkedItemsCount) { checkedItemsIndex = 0; }
                }

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
                        Byte afi = 0xFF;
                        string blockData = "";
                        Byte[] uid = new Byte[8];

                        //获取标签数据（数据列表序号，天线ID号，dsfid，标签ID）
                        iret = reader.ISO15693_ParseTagDataReport(TagDataReport, ref ant_id, ref dsfid, ref uid);
                        if (iret == 0)
                        {
                            if (cb_AFIToRead.Checked)
                            {
                                Byte icref = 0;
                                int blkSize = 0;
                                int blkNum = 0;
                                //获取标签信息(标签ID，dsfid，afi，数据块大小，数据块数量，标签信息IC引用）
                                iret = reader.RDR_GetSystemInfo(uid, ref dsfid, ref afi, ref blkSize, ref blkNum, ref icref);
                            }
                            if (cb_blockToRead.Checked)//读块数据
                            {
                                int blockToRead = 0;
                                int blocksRead = 0;
                                byte[] BlockBuffer = new Byte[40];
                                int nSize = 0;
                                //读多块（标签ID-值null时为无地址模式，读取安全位0|1，开始块地址，要读取块数量0为读1个块，已读到的数据块数量，读到的块数据缓冲区，缓冲区最大长度0：无限制，已写入缓冲区的字节数）
                                iret = reader.ISO15693_ReadMultiBlocks(uid, 0, 0, 1, ref blockToRead, ref BlockBuffer, nSize, ref blocksRead);
                                if (iret == 0)
                                {
                                    blockData = BitConverter.ToString(BlockBuffer).Replace("-", string.Empty);
                                }
                                else
                                {
                                    blockData = "read error";
                                }
                            }
                            if (cb_blockToWrite.Checked && tb_blockToWrite.Text.Length >= 8)//写块数据
                            {
                                int numOfBlks = (tb_blockToWrite.Text.Length / 8);
                                byte[] newBlksData = HexStrToByte(tb_blockToWrite.Text + "00000000");
                                //写多块（标签ID-值null时为无地址模式，写块地址，写块数量，写块数据，写块数据长度）
                                iret = reader.ISO15693_WriteMultipleBlocks(uid, 0, numOfBlks, newBlksData, newBlksData.Length);
                            }

                            if (checkedItemsCount > 0) { ant_id = selectAntID; }
                            string uidStr = BitConverter.ToString(uid).Replace("-", string.Empty);
                            //object[] pList = { 1, uidStr, "", dsfid.ToString("X2") + " - AFI:" + afi.ToString("X2") + " - BlockData:" + blockData, ant_id.ToString().PadLeft(2, '0') };
                            object[] pList = { 1, uidStr, null, null, null};
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
                label1.Text = "0";
            }
            else if (op == 1)//扫描
            {
                //richTextBox2.AppendText(uidStr + " - dsfid:" + DSFIDStr + " - antid:" + otherStr + "\r\n");
                richTextBox2.AppendText(uidStr + "\r\n");
            }
            else if (op == 2)//数量
            {
                label1.Text = otherStr;
            }
        }

        private void b_stopInventory_Click(object sender, EventArgs e)
        {
            _shouldStop = true;

            b_close.Enabled = true;
            b_inventory.Enabled = true;
            b_stopInventory.Enabled = false;

            clb_antIDList.Enabled = true;
        }

        private void b_readMultiple_Click(object sender, EventArgs e)
        {
            int blockToRead = 0;
            int blocksRead = 0;
            byte[] BlockBuffer = new Byte[40];
            int nSize = 0;
            byte[] uid;
            byte readSecSta = cb_readSecSta.Checked ? (byte)1 : (byte)0;
            if (reader.RDR_SetAcessAntenna(byte.Parse(tb_antID.Text)) == 0)//指定天线工作
            {
                uid = HexStrToByte(tb_selecttagID.Text);//指定读多块的标签
                //读多块（标签ID-值null时为无地址模式，读取安全位0|1，开始块地址，要读取块数量，已读到的数据块数量，读到的块数据缓冲区，缓冲区最大长度0：无限制，已写入缓冲区的字节数）
                if (reader.ISO15693_ReadMultiBlocks(uid, readSecSta, cbb_startAddress.SelectedIndex, cbb_blockNumber.SelectedIndex, ref blockToRead, ref BlockBuffer, nSize, ref blocksRead) == 0)
                {
                    tb_blockData.Text = BitConverter.ToString(BlockBuffer, 0, blocksRead).Replace("-", string.Empty);
                }
            }
        }

        private void b_writeMultiple_Click(object sender, EventArgs e)
        {
            int iret;
            byte[] uid;
            int blkAddr;
            int numOfBlks;
            blkAddr = cbb_startAddress.SelectedIndex;
            numOfBlks = cbb_blockNumber.SelectedIndex + 1;
            byte[] newBlksData = HexStrToByte(tb_blockData.Text + "00000000");
            if (reader.RDR_SetAcessAntenna(byte.Parse(tb_antID.Text)) == 0)//指定天线工作
            {
                uid = HexStrToByte(tb_selecttagID.Text);//指定读多块的标签
                //写多块（标签ID-值null时为无地址模式，写块地址，写块数量，写块数据，写块数据长度）
                iret = reader.ISO15693_WriteMultipleBlocks(uid, blkAddr, numOfBlks, newBlksData, newBlksData.Length);
                if (iret != 0)
                {
                    MessageBox.Show("write fail " + iret.ToString());
                }
            }
        }

        private void b_getTagSysInfo_Click(object sender, EventArgs e)
        {
            Byte dsfid = 0;
            Byte afi = 0;
            Byte icref = 0;
            int blkSize = 0;
            int blkNum = 0;
            if (tb_antID.Text != "" && tb_selecttagID.Text != "")
            {
                if (reader.RDR_SetAcessAntenna(byte.Parse(tb_antID.Text)) == 0)
                {
                    byte[] uid = HexStrToByte(tb_selecttagID.Text);
                    reader.RDR_GetSystemInfo(uid, ref dsfid, ref afi, ref blkSize, ref blkNum, ref icref);
                    tb_afi.Text = afi.ToString("X2");
                    tb_dsfid.Text = dsfid.ToString("X2");
                    l_blockSize.Text = blkSize.ToString("X2");
                    l_blockNumber.Text = blkNum.ToString("X2");
                    l_ICreference.Text = icref.ToString("X2");
                }
            }
        }

        private void b_writeAFI_Click(object sender, EventArgs e)
        {
            int iret;
            byte[] uid = HexStrToByte(tb_selecttagID.Text);
            iret = reader.ISO15693_WriteAFI(uid, HexStrToByte(tb_afi.Text)[0]);
            if (iret != 0) { MessageBox.Show(iret.ToString()); }
        }

        private void b_lockAFI_Click(object sender, EventArgs e)
        {
            byte[] uid = HexStrToByte(tb_selecttagID.Text);
            reader.ISO15693_LockAFI(uid);
        }

        private void b_writeDSFID_Click(object sender, EventArgs e)
        {
            int iret;
            byte[] uid = HexStrToByte(tb_selecttagID.Text);
            iret = reader.ISO15693_WriteDSFID(uid, HexStrToByte(tb_dsfid.Text)[0]);
            if (iret != 0) { MessageBox.Show(iret.ToString()); }
        }

        private void b_lockDSFID_Click(object sender, EventArgs e)
        {
            byte[] uid = HexStrToByte(tb_selecttagID.Text);
            reader.ISO15693_LockDSFID(uid);
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

        private void richTextBox2_Click(object sender, EventArgs e)
        {
            try
            {
                if (richTextBox2.Text.Trim().Length > 0)
                {
                    int selectIndexChr = richTextBox2.GetFirstCharIndexOfCurrentLine();
                    string lineStr = richTextBox2.Lines[richTextBox2.GetLineFromCharIndex(selectIndexChr)].ToString();
                    if (selectIndexChr >= 0 && lineStr.Length > 16)
                    {
                        tb_antID.Text = lineStr.Substring(lineStr.Length - 2);

                        richTextBox2.Select(selectIndexChr, lineStr.Length);
                        tb_selecttagID.Text = lineStr.Substring(0, 16);
                    }
                }
            }
            catch
            {

            }
        }

        private void b_setOutput_Click(object sender, EventArgs e)
        {
            //设置设备输出端口
            reader.RDR_SetOutput(RFIDLIB.rfidlib_def.OUTPUT_RELAY, 0x00, 0x02);
        }

        private void cb_blockToWrite_CheckedChanged(object sender, EventArgs e)
        {
            tb_blockToWrite.Visible = cb_blockToWrite.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //byte[] cfgdata = new byte[8];
            //int cfgsize = 8;
            //reader.RDR_ConfigBlockRead(4, ref cfgdata, cfgsize);
            //cfgdata[0] = 0x00;
            //reader.RDR_ConfigBlockWrite(4, cfgdata, 8, 0xFFFF);
            //reader.RDR_ConfigBlockSave(4);
            MessageBox.Show( reader.RDR_LoadFactoryDefault().ToString());
        }
    }
}
