using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace SerialTool
{
    public partial class frmSerialTool : Form
    {
        ArrayBuffer<Char> DataBuf;
        ArrayBuffer<Char> DataHex;
        ArrayBuffer<Byte> DataByte;
        private Int32 SendCount;
        private Int32 ReceiveCount;
        private String[] ArrayPortNames;
        private String[] ArrayBaudRate = { "110", "300", "600", "1200", "2400", "4800", "9600", "14400", "19200", "38400", "56000", "57600", "115200", "128000", "256000" };
        private String[] ArrayDataBit = { "5", "6", "7", "8" };
        private String[] ArrayStopBit = { "1", "1.5", "2", };
        private String[] ArrayParityBit = { "None", "Odd", "Even", "Mark", "Space" };
        private String[] ArrayFlowControl = { "None", "Software", "Hardware", "Custom", };
        private String PortName;
        private Int32 BaudRate;
        private Int32 DataBit;
        private StopBits StopBit;
        private Parity ParityBit;
        private delegate void ShowData(String dataHex); //代理
        

        public frmSerialTool()
        {
            InitializeComponent();
        }

        private void frmSerialTool_Load(object sender, EventArgs e)
        {
            ArrayPortNames = SerialPort.GetPortNames();
            cmbSerialNum.Items.AddRange(ArrayPortNames);
            cmbBaudRate.Items.AddRange(ArrayBaudRate);
            cmbDataBit.Items.AddRange(ArrayDataBit);
            cmbStopBit.Items.AddRange(ArrayStopBit);
            cmbParityBit.Items.AddRange(ArrayParityBit);
            cmbFlowControl.Items.AddRange(ArrayFlowControl);

           cmbSerialNum.SelectedIndex = 0;
           cmbBaudRate.SelectedIndex = 6;
           cmbDataBit.SelectedIndex = 3;
           cmbStopBit.SelectedIndex = 0;
           cmbParityBit.SelectedIndex = 0;
           cmbFlowControl.SelectedIndex = 0;

           PortName = cmbSerialNum.Text;
           BaudRate = Int32.Parse(cmbBaudRate.Text);
           DataBit = Int32.Parse(cmbDataBit.Text);
           StopBit = StopBits.One;
           ParityBit = Parity.None;

           DataBuf = new ArrayBuffer<Char>(1024 * 1024 * 8);
           DataHex = new ArrayBuffer<Char>(1024 * 1024 * 24);
           DataByte = new ArrayBuffer<Byte>(1024 * 1024 * 8);

           SendCount = 0;
           ReceiveCount = 0;
           ChangeStatus();
           ChangeDTRRTSStatus();
        }

        private void frmSerialTool_SizeChanged(object sender, EventArgs e)
        {
            Size FromClientSize;
            FromClientSize = this.ClientSize;
            FromClientSize.Height -= (grpSerial.Size.Height + ssrSerialInfo.Size.Height);
            FromClientSize.Height = (FromClientSize.Height < 80) ? 80 : FromClientSize.Height;
            txtReceiveData.Size = FromClientSize;
            grpSerial.Top = txtReceiveData.Size.Height;
        }

        private void cmbSerialNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            PortName = cmbSerialNum.Text;
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                serialPort1.PortName = PortName;
                serialPort1.Open();
            }
            ChangeStatus();
        }

        private void btnOpenSerial_Click(object sender, EventArgs e)
        {
            if (btnOpenSerial.Text == "打开串口")
            {
                try
                {
                    serialPort1.PortName = PortName;
                    serialPort1.BaudRate = BaudRate;
                    serialPort1.DataBits = DataBit;
                    serialPort1.StopBits = StopBit;
                    serialPort1.Parity = ParityBit;
                    serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    serialPort1.Open();
                    btnOpenSerial.Text = "关闭串口";
                }
                catch(Exception)
                {
                    MessageBox.Show("警告,打开失败。\n可能是串口设置不支持。\n也可能是您要打开的串口号不存在,或被占用。");
                }
            }
            else
            {
                serialPort1.Close();
                btnOpenSerial.Text = "打开串口";
            }

            ChangeStatus();
        }

        private void cmbBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            BaudRate = Int32.Parse(cmbBaudRate.Text);
            serialPort1.BaudRate = BaudRate;
            ChangeStatus();
        }

        private void cmbDataBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataBit = Int32.Parse(cmbDataBit.Text);
            serialPort1.DataBits = DataBit;
            ChangeStatus();
        }

        private void cmbParityBit_SelectedIndexChanged(object sender, EventArgs e)
        {
           switch(cmbParityBit.SelectedIndex)
           {
               case 0:
                   ParityBit = Parity.None;
                   break;
               case 1:
                   ParityBit = Parity.Odd;
                   break;
               case 2:
                   ParityBit = Parity.Even;
                   break;
               case 3:
                   ParityBit = Parity.Mark;
                   break;
               case 4:
                   ParityBit = Parity.Space;
                   break;
               default:
                   ParityBit = Parity.None;
                   break;
           }
           serialPort1.Parity = ParityBit;
           ChangeStatus();
        }

        private void cmbStopBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbParityBit.SelectedIndex)
            {
                case 0:
                    StopBit = StopBits.One;
                    break;
                case 1:
                    StopBit = StopBits.OnePointFive;
                    break;
                case 2:
                    StopBit = StopBits.Two;
                    break;
                default:
                    StopBit = StopBits.One;
                    break;
            }
            serialPort1.Parity = ParityBit;
            ChangeStatus();
        }

        private void chkDTR_CheckedChanged(object sender, EventArgs e)
        {
            serialPort1.DtrEnable = chkDTR.Checked; 
            ChangeDTRRTSStatus();
        }

        private void chkRTS_CheckedChanged(object sender, EventArgs e)
        {
            serialPort1.RtsEnable = chkRTS.Checked;
            ChangeDTRRTSStatus();
        }

        private void DataReceivedHandler( object sender, SerialDataReceivedEventArgs e)
        {
            int ReceivedLength;
            int DataLen;
            Char[] InDataChars;
            Byte[] InDataHex;
            String InDataHexChar = "";

            SerialPort sp = (SerialPort)sender;
            ReceivedLength = sp.BytesToRead;
            InDataChars = new Char[ReceivedLength];
            InDataHex = new Byte[ReceivedLength];

            DataLen = sp.Read(InDataHex, 0, ReceivedLength);

            foreach (Byte d in InDataHex)
            {
                InDataHexChar += String.Format("{0:X2} ", d);
            }
            InDataChars = System.Text.Encoding.Default.GetChars(InDataHex);
            for (int i=0; i < InDataChars.Length;i++ )
            {
                if(InDataChars[i] == 0x00)
                {
                    InDataChars[i] = ' ';
                }
            }
            DataByte.Write(InDataHex);
            DataBuf.Write(InDataChars);
            DataHex.Write(InDataHexChar.ToCharArray());
            
            if(chkShowHEX.Checked)
            {
                txtReceiveData_ShowData(InDataHexChar);
            }
            else
            {
                txtReceiveData_ShowData(new String(InDataChars));
            }
            ReceiveCount += DataLen;
            tsslReceiveCount.Text = String.Format("接收：{0}", ReceiveCount);
        }

        private void txtReceiveData_ShowData(String data)
        {
            if (this.txtReceiveData.InvokeRequired)//等待异步
            {
                ShowData fc = new ShowData(txtReceiveData_ShowData);
                this.Invoke(fc, (object)data); //通过代理调用刷新方法
            }
            else
            {

                txtReceiveData.AppendText(data);
            }
        }

        private void txtReceiveData_TextChanged(object sender, EventArgs e)
        {
            txtReceiveData.ScrollToCaret();
        }

        private void btnClearData_Click(object sender, EventArgs e)
        {
            txtReceiveData.Text = "";
            SendCount = 0;
            ReceiveCount = 0;
            DataBuf.Clear();
            DataHex.Clear();
            DataByte.Clear();
            tsslSendCount.Text = "发送：0";
            tsslReceiveCount.Text = "接收：0";
        }

        private void chkShowHEX_CheckedChanged(object sender, EventArgs e)
        {
            int len;
            Char[] data;
            if(chkShowHEX.Checked)
            {
                len = DataHex.Available;
                data = new Char[len];
                DataHex.Read(data);
                txtReceiveData.Text = new String(data);
            }
            else
            {
                len = DataBuf.Available;
                data = new Char[len];
                DataBuf.Read(data);
                txtReceiveData.Text = new String(data);
            }
        }

        private void btnSendData_Click(object sender, EventArgs e)
        {
            if(serialPort1.IsOpen)
            {
                SendData();
            }
        }

        private void chkTimingSend_CheckedChanged(object sender, EventArgs e)
        {
            int TimeInterval;
            if (chkTimingSend.Checked)
            {
                try
                {
                    TimeInterval = Convert.ToInt32(txtTimeInterval.Text);
                    timerSend.Interval = TimeInterval;
                    timerSend.Start();
                }
                catch (Exception) { }
            }
            else
            {
                timerSend.Stop();
            }
        }

        private void timerSend_Tick(object sender, EventArgs e)
        {
            if(serialPort1.IsOpen)
            {
                SendData();
            }
        }

        private void SendData()
        {
            String sData;
            Byte[] bData;
            sData = txtSendData.Text;
            if (chkSendHEX.Checked)
            {
                sData = sData.Replace(" ", "");
                if ((sData.Length % 2) != 0)
                    sData += " ";
                bData = new byte[sData.Length / 2];
                try
                {
                    for (int i = 0; i < bData.Length; i++)
                    {
                        bData[i] = Convert.ToByte(sData.Substring(i * 2, 2), 16);
                    }
                }
                catch (Exception)
                {

                }
                serialPort1.Write(bData, 0, bData.Length);
                SendCount += bData.Length;
                tsslSendCount.Text = String.Format("发送：{0}", SendCount);
            }
            else
            {
                if (chkSendNewLine.Checked)
                {
                    sData += "\r\n";
                }
                serialPort1.Write(sData);
                SendCount += sData.Length;
                tsslSendCount.Text = String.Format("发送：{0}", SendCount);
            }            
        }

        private void ChangeStatus()
        {
            String status;
            String sPortName;
            String sBaudRate;
            String sDataBit;
            String sStopBit;
            String sParityBit;
            String sFlowControl;
            String[] ParityBits = { "无校验", "偶校验", "奇校验", "保持1", "保持0" };
            String[] FlowControls = { "无流控", "软流控", "硬流控", "自定义" };

            if (serialPort1.IsOpen)
            {
                sPortName = String.Format("{0}已打开", cmbSerialNum.Text);
            }
            else
            {
                sPortName = String.Format("{0}已关闭", cmbSerialNum.Text);
            }
            sBaudRate = String.Format("{0}bps", cmbBaudRate.Text);
            sDataBit = cmbDataBit.Text;
            sStopBit = cmbStopBit.Text;
            switch(cmbParityBit.Text)
            {
                case "None":
                    sParityBit = ParityBits[0];
                    break;
                case "Odd":
                    sParityBit = ParityBits[1];
                    break;
                case "Even":
                    sParityBit = ParityBits[2];
                    break;
                case "Mark":
                    sParityBit = ParityBits[3];
                    break;
                case "Space":
                    sParityBit = ParityBits[4];
                    break;
                default:
                    sParityBit = ParityBits[0];
                    break;
            }
            switch(cmbFlowControl.Text)
            {
                case "None":
                    sFlowControl = FlowControls[0];
                    break;
                case "Software":
                    sFlowControl = FlowControls[1];
                    break;
                case "Hardware":
                    sFlowControl = FlowControls[2];
                    break;
                case "Custom":
                    sFlowControl = FlowControls[3];
                    break;
                default:
                    sFlowControl = FlowControls[0];
                    break;
            }
            status = String.Format("{0} {1},{2},{3},{4},{5}", sPortName, sBaudRate, sDataBit, sStopBit, sParityBit, sFlowControl);
            tsslSerialInfo.Text = status;
        }

        private void ChangeDTRRTSStatus()
        {
            String status;
            int DTR, RTS;
            DTR = chkDTR.Checked ? 1 : 0;
            RTS = chkRTS.Checked ? 1 : 0;
            status = String.Format("DTR={0} RTS={1}", DTR, RTS);
            tsslCTSDSR.Text = status;
        }

        private void cmbFlowControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeStatus();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            String fName;
            long fileLen;
            Byte[] fileData;
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {                
                fName = fd.FileName;
                txtFileNme.Text = fName;
                try
                {
                    FileStream fs = File.Open(fName, FileMode.Open);
                    fileLen = fs.Length;
                    fileData = new Byte[fileLen];
                    fs.Read(fileData, 0, (int)fileLen);
                    txtReceiveData.Text = System.Text.Encoding.UTF8.GetString(fileData);
                    fs.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("文件发送失败！");
                }
            }
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            String fileName;
            long fileLen;
            Byte[] fileData;

            fileName = txtFileNme.Text;
            try
            {
                FileStream fs = File.Open(fileName, FileMode.Open);
                fileLen = fs.Length;
                fileData = new Byte[fileLen];
                fs.Read(fileData, 0, (int)fileLen);
                if(serialPort1.IsOpen)
                {
                    serialPort1.Write(fileData, 0, fileData.Length);
                    SendCount += (int)fileLen;
                    tsslSendCount.Text = String.Format("发送：{0}", SendCount);
                }
                fs.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("文件打开失败！");
            }

        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                String fName;
                long fileLen;
                Byte[] fileData;
                fName = fd.FileName;
                try
                {
                    FileStream fs = File.Open(fName, FileMode.Create);
                    fileLen = DataByte.Available;
                    fileData = new Byte[fileLen];
                    fileLen = DataByte.Read(fileData);
                    fs.Write(fileData, 0, (int)fileLen);
                    fs.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("文件保存失败！");
                }
            }
        }


    }
}
