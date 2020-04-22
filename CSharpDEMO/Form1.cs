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
using CSharpDEMO;
using System.Text.RegularExpressions;

namespace CSharpDEMO
{
    public partial class Form1 : Form
    {
        //转换错误代码
        private string FormatErrorCode(byte[] byteArray)
        {
            string strErrorCode = "";
            switch (byteArray[0])
            {
                case 0x80:
                    strErrorCode = "Success";
                    break;

                case 0x81:
                    strErrorCode = "Parameter Error";
                    break;

                case 0x82:
                    strErrorCode = "communication TimeOut";
                    break;

                case 0x83:
                    strErrorCode = "Couldn't Find Card ";
                    break;

                default:
                    strErrorCode = "Commond Error";
                    break;
            }

            return strErrorCode;
        }
        //输出日志文本
        private void WriteLog(string strText, int nRet, string strErrcode)
        {
            if (nRet != 0)
            {

                textResponse.Text += System.DateTime.Now.ToLocalTime().ToString() + " " + strText + "\r\n" + strErrcode + "\r\n";
            }
            else
            {
                textResponse.Text += System.DateTime.Now.ToLocalTime().ToString() + " " + strText + " " + "\r\n";
            }

            textResponse.Select(textResponse.TextLength, 0);//光标定位到文本最后
            textResponse.ScrollToCaret();//滚动到光标处
        }

        //转换卡号专用
        private byte[] convertSNR(string str, int keyN)
        {
            string regex = "[^a-fA-F0-9]";
            string tmpJudge = Regex.Replace(str,regex,"");    
       
            //长度不对，直接退回错误
            if (tmpJudge.Length != 12) return null;

            string[] tmpResult= Regex.Split(str,regex);
            byte[] result = new byte[keyN];
            int i = 0;
            foreach (string tmp in tmpResult)
            {
                result[i] = Convert.ToByte(tmp,16);
                i++;
            }
            return result;
        }

        //数据输入判断函数2个
        private string formatStr(string str, int num_blk)
        {
            
            string tmp=Regex.Replace(str,"[^a-fA-F0-9]","");
            //长度不对直接报错
            //num_blk==-1指示不用检查位数
            if (num_blk == -1) return tmp;
            //num_blk==其它负数，为-1/num_blk
            if (num_blk < -1)
            {
                if (tmp.Length != -16 / num_blk * 2) return null;
                else return tmp;
            }
            if (tmp.Length != 16*num_blk*2) return null;
            else return tmp;
        }
        private void convertStr(byte[] after, string before, int length)
        {
            for (int i = 0; i < length; i++)
            {
                after[i] = Convert.ToByte(before.Substring(2 * i, 2), 16);
            }
        }

        //显示结果
        private void showData(string text, byte[] data, int s, int e)
        {
            //非负转换
            for (int i = 0; i < e; i++)
            {
                if (data[s + i] < 0)
                    data[s + i] = Convert.ToByte(Convert.ToInt32(data[s + i]) + 256);
            }
            textResponse.Text += text;

            //for (int i = s; i < e; i++)
            //{
            //    textResponse.Text += data[i].ToString("X2")+" ";
            //}
            //textResponse.Text += "\r\n";

            for (int i = 0; i < e; i++)
            {
                textResponse.Text += data[s + i].ToString("X2")+" ";
            }
            textResponse.Text += "\r\n\r\n";

        }
        //显示命令执行结果
        private void showStatue(int Code)
        {
            string msg="";
            switch (Code)
            {
                case 0x00:
                    msg = "命令执行成功 .....";
                    break;
                case 0x01:
                    msg = "命令操作失败 .....";
                    break;
                case 0x02:
                    msg = "地址校验错误 .....";
                    break;
                case 0x03:
                    msg = "找不到已选择的端口 .....";
                    break;
                case 0x04:
                    msg = "读写器返回超时 .....";
                    break;
                case 0x05:
                    msg = "数据包流水号不正确 .....";
                    break;
                case 0x07:
                    msg = "接收异常 .....";
                    break;
                case 0x0A:
                    msg = "参数值超出范围 .....";
                    break;
                case 0x80:
                    msg = "参数设置成功 .....";
                    break;
                case 0x81:
                    msg = "参数设置失败 .....";
                    break;
                case 0x82:
                    msg = "通讯超时.....";
                    break;
                case 0x83:
                    msg = "卡不存在.....";
                    break;
                case 0x84:
                    msg = "接收卡数据出错.....";
                    break;
                case 0x85:
                    msg = "未知的错误.....";
                    break;
                case 0x87:
                    msg = "输入参数或者输入命令格式错误.....";
                    break;
                case 0x89:
                    msg = "输入的指令代码不存在.....";
                    break;
                case 0x8A:
                    msg = "在对于卡块初始化命令中出现错误.....";
                    break;
                case 0x8B:
                    msg = "在防冲突过程中得到错误的序列号.....";
                    break;
                case 0x8C:
                    msg = "密码认证没通过.....";
                    break;
                case 0x8F:
                    msg = "读取器接收到未知命令.....";
                    break;
                case 0x90:
                    msg = "卡不支持这个命令.....";
                    break;
                case 0x91:
                    msg = "命令格式有错误.....";
                    break;
                case 0x92:
                    msg = "在命令的FLAG参数中，不支持OPTION 模式.....";
                    break;
                case 0x93:
                    msg = "要操作的BLOCK不存在.....";
                    break;
                case 0x94:
                    msg = "要操作的对象已经别锁定，不能进行修改.....";
                    break;
                case 0x95:
                    msg = "锁定操作不成功.....";
                    break;
                case 0x96:
                    msg = "写操作不成功.....";
                    break;
                default:
                    msg = "未知错误2.....";
                    break;
            }
            textResponse.Text += msg + "\r\n";
        }

        public Form1()
        {
            InitializeComponent();
            UL_readBlock.SelectedIndex = 0;
            UL_writeBlock.SelectedIndex = 0;
        }

        //14443A-MF

        /*MF_Read_Func*/
        private void btn_MF_Read_Click(object sender, EventArgs e)
        {
            byte mode1 = (readKeyB.Checked) ? (byte)0x01 : (byte)0x00;
            byte mode2 = (readAll.Checked) ? (byte)0x01 : (byte)0x00;
            byte mode = (byte)((mode1<<1)|mode2);
            byte blk_add = Convert.ToByte(readStart.Text,16);
            byte num_blk = Convert.ToByte(readNum.Text,16);

            byte[] snr = new byte[6];
            snr = convertSNR(readKey.Text, 6);
            if (snr == null)
            {
                MessageBox.Show("序列号无效！", "错误");
                return;
            }

            byte[] buffer = new byte[16 * num_blk];

            int nRet = Reader.MF_Read(mode, blk_add, num_blk, snr, buffer);
            //string strErrorCode;

            showStatue(nRet);
            if (nRet != 0)
            {
                //strErrorCode = FormatErrorCode(buffer);
                //WriteLog("Failed: ", nRet, strErrorCode);
                showStatue(buffer[0]);
            }
            else
            {
                showData("卡号：", snr, 0, 4);
                //showData("数据：", buffer, 0, 16 * num_blk);
            }
            string constructorString = "server=localhost;User Id=root;password=1234567890;Database=test";
            MySqlConnection myConnnect = new MySqlConnection(constructorString);
            myConnnect.Open();
            MySqlCommand myCmd = new MySqlCommand("SELECT * FROM test.card_info where RFID='" + snr + "'", myConnnect);
        }

        /*MF_Write_Func*/
        private void btn_MF_Write_Click(object sender, EventArgs e)
        {
            byte mode1 = (writeKeyB.Checked) ? (byte)0x01 : (byte)0x00;
            byte mode2 = (writeAll.Checked) ? (byte)0x01 : (byte)0x00;
            byte mode = (byte)((mode1 << 1) | mode2);
            byte blk_add = Convert.ToByte(writeStart.Text,16);
            byte num_blk = Convert.ToByte(writeNum.Text, 16);

            byte[] snr = new byte[6];
            snr = convertSNR(writeKey.Text, 16);
            if (snr == null)
            {
                MessageBox.Show("序列号无效！","错误");
                return;
            }

            byte[] buffer = new byte[16 * num_blk];
            string bufferStr = formatStr(writeData.Text,num_blk);
            if (bufferStr == null)
            {
                MessageBox.Show("序列号无效！","错误");
                return;
            }
            convertStr(buffer, bufferStr, 16 * num_blk);

            int nRet = Reader.MF_Write(mode,blk_add,num_blk,snr, buffer);
            //string strErrorCode;

            showStatue(nRet);
            if (nRet != 0)
            {
                //strErrorCode = FormatErrorCode(buffer);
                //WriteLog("Failed:", nRet, strErrorCode);
                showStatue(buffer[0]);
            }
            else
            {
                showData("卡号：",snr,0,4);
            }
        }

        private void btn_MF_InitValue_Click(object sender, EventArgs e)
        {
            byte mode1 = (initKeyB.Checked) ? (byte)0x01 : (byte)0x00;
            byte mode2=(initAll.Checked)?(byte)0x01:(byte)0x00;
            byte mode = (byte)((mode1 << 1) | mode2);
            byte SectNum = Convert.ToByte(initSector.Text, 16);

            byte[] snr = new byte[6];
            snr = convertSNR(initKey.Text, 16);
            if (snr == null)
            {
                MessageBox.Show("序列号无效！", "错误");
                return;
            }

            byte[] value = new byte[4];
            string valueStr = formatStr(initValue.Text,-1);
            convertStr(value, valueStr, 4);

            int nRet = Reader.MF_InitValue(mode, SectNum, snr, value);
            //string strErrorCode;

            showStatue(nRet);
            if (nRet != 0)
            {
                //strErrorCode = FormatErrorCode(value);
                //WriteLog("Failed:", nRet, strErrorCode);
                showStatue(snr[0]);
            }
            else
            {
                showData("卡号：", snr, 0, 4);
            }

        }

        private void btn_MF_Dec_Click(object sender, EventArgs e)
        {
            byte mode1 = (decKeyB.Checked) ? (byte)0x01 : (byte)0x00;
            byte mode2 = (decAll.Checked) ? (byte)0x01 : (byte)0x00;
            byte mode = (byte)((mode1 << 1) | mode2);
            byte SectNum = Convert.ToByte(decSector.Text, 16);

            byte[] snr = new byte[6];
            snr = convertSNR(decKey.Text, 16);
            if (snr == null)
            {
                MessageBox.Show("序列号无效！", "错误");
                return;
            }

            byte[] value = new byte[4];

            string valueStr = formatStr(decValue.Text, -1);
            convertStr(value, valueStr, 4);

            int nRet=Reader.MF_Dec(mode,SectNum,snr,value);
            //string strErrorCode;

            showStatue(nRet);
            if (nRet != 0)
            {
                //strErrorCode = FormatErrorCode(value);
                //WriteLog("Failed:", nRet, strErrorCode);
                showStatue(snr[0]);
            }
            else
            {
                showData("卡号：", snr, 0, 4);
            }

        }

        private void btn_MF_Inc_Click(object sender, EventArgs e)
        {
            byte mode1 = (incKeyB.Checked) ? (byte)0x01 : (byte)0x00;
            byte mode2 = (incAll.Checked) ? (byte)0x01 : (byte)0x00;
            byte mode = (byte)((mode1 << 1) | mode2);
            byte SectNum = Convert.ToByte(incSector.Text, 16);

            byte[] snr = new byte[6];
            snr = convertSNR(incKey.Text, 16);
            if (snr == null)
            {
                MessageBox.Show("序列号无效！", "错误");
                return;
            }

            byte[] value = new byte[4];

            string valueStr = formatStr(incValue.Text, -1);
            convertStr(value, valueStr, 4);

            int nRet = Reader.MF_Inc(mode, SectNum, snr, value);
            //string strErrorCode;

            showStatue(nRet);
            if (nRet != 0)
            {
                //strErrorCode = FormatErrorCode(value);
                //WriteLog("Failed:", nRet, strErrorCode);
                showStatue(snr[0]);
            }
            else
            {
                showData("卡号：", snr, 0, 4);
            }
        }

        private void btn_MF_Getsnr_Click(object sender, EventArgs e)
        {
            byte mode = (snrAll.Checked) ? (byte)0x52 : (byte)0x26;
            byte halt = (snrHalt.Checked) ? (byte)0x01 : (byte)0x00;

            byte[] snr = new byte[1];

            byte[] value = new byte[4];
            string valueStr = formatStr(incValue.Text, -1);
            convertStr(value, valueStr, 4);

            int nRet = Reader.MF_Getsnr(mode, halt, snr, value);
            //string strErrorCode;

            showStatue(nRet);
            if (nRet != 0)
            {
                //strErrorCode = FormatErrorCode(value);
                //WriteLog("Failed:", nRet, strErrorCode);
                showStatue(snr[0]);
            }
            else
            {
                if (snr[0] == 0x00)
                    textResponse.Text += "只有一张卡……\r\n";
                else
                    textResponse.Text += "有多张卡……\r\n";
                showData("卡号：", value, 0, 4);
            }

        }

        private void btn_UL_Request_Click(object sender, EventArgs e)
        {
            byte[] snr = new byte[7];
            byte mode = (UL_snreadAll.Checked) ? (byte)0x01 : (byte)0x00;

            int nRet = Reader.UL_Request(mode, snr);
            //string strErrorCode;

            showStatue(nRet);
            if (nRet != 0)
            {
                //strErrorCode = FormatErrorCode(snr);
                //WriteLog("Failed:", nRet, strErrorCode);
                showStatue(snr[0]);
            }
            else
            {
                showData("卡号：", snr, 0, 7);
            }
        }

        private void btn_UL_Halt_Click(object sender, EventArgs e)
        {
            int nRet = Reader.MF_Halt();

            //textResponse.Text += "命令执行成功。\r\n";
            showStatue(nRet);
        }

        private void btn_UL_HLRead_Click(object sender, EventArgs e)
        {
            byte mode = (UL_readAll.Checked) ? (byte)0x01 : (byte)0x01;
            byte blk_add = Convert.ToByte(UL_readBlock.SelectedItem.ToString(), 16);

            byte[] snr = new byte[7];
            byte[] buffer = new byte[16];

            int nRet = Reader.UL_HLRead(mode, blk_add, snr, buffer);
            //string strErrorCode;

            showStatue(nRet);
            if (nRet != 0)
            {
                //strErrorCode = FormatErrorCode(buffer);
                //WriteLog("Failed:", nRet, strErrorCode);
                showStatue(buffer[0]);
            }
            else
            {
                showData("卡号",snr,0,7);
                showData("数据：", buffer, 0, 16);
            }

        }

        private void btn_UL_HLWrite_Click(object sender, EventArgs e)
        {
            byte mode = (UL_writeAll.Checked) ? (byte)0x01 : (byte)0x00;
            byte blk_add = Convert.ToByte(UL_writeBlock.SelectedItem.ToString(), 16);

            byte[] snr = new byte[7] { 0, 0, 0, 0, 0, 0, 0 };
            byte[] buffer = new byte[4];

            string bufferStr = formatStr(UL_writeData.Text, -1);
            convertStr(buffer, bufferStr, 4);

            int nRet = Reader.UL_HLWrite(mode, blk_add, snr, buffer);
            string strErrorCode;

            if (nRet != 0)
            {
                if (nRet == 10)
                {
                    //Something Different
                    strErrorCode = FormatErrorCode(buffer);
                    WriteLog("错误: ",nRet,strErrorCode);
                    showStatue(nRet);
                }
                else
                {
                    //textResponse.Text += "命令执行成功。\r\n";
                    showStatue(snr[0]);
                }
            }
            else
            {
                showData("卡号：",snr,0,7);
            }

        }
    }
}

