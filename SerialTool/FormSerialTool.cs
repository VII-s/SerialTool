using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Diagnostics;


namespace SerialTool
{
    public partial class frmSerialTool : Form
    {
        ArrayBuffer<Byte> DataByte;
        private Int32 SendCount = 0;
        private Int32 ReceiveCount = 0;
        private String[] ArrayPortNames;
        private String[] ArrayBaudRate = { "110", "300", "600", "1200", "2400", "4800", "9600", "14400", "19200", "38400", "56000", "57600", "115200", "128000", "256000" };
        private String[] ArrayDataBit = { "5", "6", "7", "8" };
        private String[] ArrayStopBit = {"1", "1.5", "2", };
        private String[] ArrayParityBit = { "None", "Odd", "Even", "Mark", "Space" };
        private String[] ArrayFlowControl = { "None", "Software", "Hardware", "Custom", };
        private String   PortName = "";
        private Int32    BaudRate = 9600;
        private Int32    DataBit = 8;
        private StopBits StopBit = StopBits.One;
        private Parity   ParityBit = Parity.None;
        private Int32    FlowCtrl = 0;
        private Boolean  DTR = false;
        private Boolean  RTS = false;

        private String   SendDataAsc = "";
        private String   SendDataHex = "";
        private Int32    TimeInterval = 1000;
        private Boolean  SendHex = false;
        private Boolean  SendNewLine = false;
        private Boolean  ShowHex = false;

        private String RecFileName = "";
        private const Int32 MaxBytes = 128 * 1024;

        private delegate void ChangeText(object sender, String Text); //代理
               

        public frmSerialTool()
        {
            InitializeComponent();
        }

        private void frmSerialTool_Load(object sender, EventArgs e)
        {
            LoadConfig();
            ArrayPortNames = SerialPort.GetPortNames();
            cmbSerialNum.Items.AddRange(ArrayPortNames);
            cmbBaudRate.Items.AddRange(ArrayBaudRate);
            cmbDataBit.Items.AddRange(ArrayDataBit);
            cmbStopBit.Items.AddRange(ArrayStopBit);
            cmbParityBit.Items.AddRange(ArrayParityBit);
            cmbFlowControl.Items.AddRange(ArrayFlowControl);

            cmbSerialNum.SelectedItem = this.PortName;
            cmbBaudRate.SelectedText = this.BaudRate.ToString();
            cmbDataBit.SelectedItem = this.DataBit.ToString();
            cmbStopBit.SelectedIndex = (Int32)this.StopBit - 1;
            cmbParityBit.SelectedIndex = (Int32)this.ParityBit;
            cmbFlowControl.SelectedIndex = this.FlowCtrl;
            chkDTR.Checked = this.DTR;
            chkRTS.Checked = this.RTS;

            chkSendHEX.Checked = this.SendHex;
            chkSendNewLine.Checked = this.SendNewLine;
            chkShowHEX.Checked = this.ShowHex;
            txtTimeInterval.Text = (this.TimeInterval == 0) ? "" : this.TimeInterval.ToString();
            txtSendData.Text = chkSendHEX.Checked ? this.SendDataHex : this.SendDataAsc;

            DataByte = new ArrayBuffer<Byte>(MaxBytes);

            SendCount = 0;
            ReceiveCount = 0;
            ChangeStatus();
            ChangeDTRRTSStatus();
        }

        private void frmSerialTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            this.ShowHex = chkShowHEX.Checked;
            this.SendHex = chkSendHEX.Checked;
            this.SendNewLine = chkSendNewLine.Checked;
            try
            {
                this.TimeInterval = Convert.ToInt32(txtTimeInterval.Text);
            }
            catch (Exception) { this.TimeInterval = 0; }
            SaveConfig();
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
            this.PortName = cmbSerialNum.Text;
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
                serialPort1.PortName = this.PortName;
                serialPort1.Open();
            }
            ChangeStatus();
        }

        private void cmbBaudRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            BaudRate = Int32.Parse(cmbBaudRate.Text);
            serialPort1.BaudRate = BaudRate;
            ChangeStatus();
        }

        private void cmbBaudRate_Leave(object sender, EventArgs e)
        {
            this.BaudRate = Int32.Parse(cmbBaudRate.Text);
            serialPort1.BaudRate = this.BaudRate;
            ChangeStatus();
        }

        private void cmbDataBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DataBit = Int32.Parse(cmbDataBit.Text);
            serialPort1.DataBits = this.DataBit;
            ChangeStatus();
        }

        private void cmbParityBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ParityBit = (Parity)cmbParityBit.SelectedIndex;
            serialPort1.Parity = ParityBit;
            ChangeStatus();
        }

        private void cmbStopBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.StopBit = (StopBits)(cmbStopBit.SelectedIndex + 1);
            serialPort1.StopBits = this.StopBit;
            ChangeStatus();
        }

        private void cmbFlowControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FlowCtrl = cmbFlowControl.SelectedIndex;
            ChangeStatus();
        }

        private void chkDTR_CheckedChanged(object sender, EventArgs e)
        {
            this.DTR = chkDTR.Checked;
            serialPort1.DtrEnable = this.DTR; 
            ChangeDTRRTSStatus();
        }

        private void chkRTS_CheckedChanged(object sender, EventArgs e)
        {
            this.RTS = chkRTS.Checked;
            serialPort1.RtsEnable = this.RTS;
            ChangeDTRRTSStatus();
        }

        private void chkSendHEX_CheckedChanged(object sender, EventArgs e)
        {
            this.SendHex = chkSendHEX.Checked;
            if (chkSendHEX.Checked)
            {
                txtSendData.Text = this.SendDataHex;
            }
            else
            {
                txtSendData.Text = this.SendDataAsc;
            }
        }

        private void chkShowHEX_CheckedChanged(object sender, EventArgs e)
        {
            int len;
            Byte[] data;
            String text = "";
            this.ShowHex = chkShowHEX.Checked;

            try
            {
                len = DataByte.Available;
                data = new Byte[len];
                DataByte.Read(data);
                if (chkShowHEX.Checked)
                {
                    foreach (Byte d in data)
                    {
                        text += String.Format("{0:X2} ", d);
                        if (text.Length > MaxBytes / 2)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    text = System.Text.Encoding.Default.GetString(data);
                }
                if (text.Length > MaxBytes / 2)
                {
                    txtReceiveData.Text = text.Substring(text.Length - MaxBytes / 2);
                }
            }
            catch (Exception) { }
        }

        private void chkSaveToFile_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSaveToFile.Checked)
            {
                SaveFileDialog fd = new SaveFileDialog();
                fd.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    this.RecFileName = fd.FileName;
                    if (File.Exists(this.RecFileName))
                    {
                        DialogResult result = MessageBox.Show("文件已经存在是否覆盖！", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                        if (DialogResult.Yes == result)
                        {
                            try
                            {
                                FileStream fs = File.Create(this.RecFileName);
                                fs.Close();
                            }
                            catch (Exception) { }

                            txtReceiveData.Text = "接收数据将保存到文件" + this.RecFileName;
                            txtReceiveData.Enabled = false;
                        }
                        else if (DialogResult.No == result)
                        {
                            txtReceiveData.Text = "接收数据将保存到文件" + this.RecFileName;
                            txtReceiveData.Enabled = false;
                        }
                        else if (DialogResult.Cancel == result)
                        {
                            this.RecFileName = "";
                        }
                    }
                }
            }
            else
            {
                this.RecFileName = "";
                txtReceiveData.Enabled = true;
                txtReceiveData.Text = "";
            }
        }

        private void txtSendData_Leave(object sender, EventArgs e)
        {
            if (this.SendHex)
            {
                this.SendDataHex = txtSendData.Text;
            }
            else
            {
                this.SendDataAsc = txtSendData.Text;
            }
        }

        private void txtReceiveData_TextChanged(object sender, EventArgs e)
        {
            txtReceiveData.ScrollToCaret();
        }

        private void llbBlog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.llbBlog.Links[0].LinkData = "http://blog.csdn.net/u011471873";
            System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
        }

        private void btnOpenSerial_Click(object sender, EventArgs e)
        {
            if (btnOpenSerial.Text == "打开串口")
            {
                try
                {
                    BaudRate = Int32.Parse(cmbBaudRate.Text);
                    serialPort1.PortName = this.PortName;
                    serialPort1.BaudRate = this.BaudRate;
                    serialPort1.DataBits = this.DataBit;
                    serialPort1.StopBits = this.StopBit;
                    serialPort1.Parity = this.ParityBit;
                    serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    serialPort1.Open();
                    btnOpenSerial.Text = "关闭串口";
                }
                catch (Exception)
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

        private void btnClearData_Click(object sender, EventArgs e)
        {
            if (chkSaveToFile.Checked)
            {
                try
                {
                    FileStream fs = File.Create(this.RecFileName);
                    fs.Close();
                }
                catch (Exception)
                { }
            }
            else
            {
                txtReceiveData.Text = "";
                DataByte.Clear();
            }
            SendCount = 0;
            ReceiveCount = 0;

            tsslSendCount.Text = "发送：0";
            tsslReceiveCount.Text = "接收：0";
        }

        private void DataReceivedHandler( object sender, SerialDataReceivedEventArgs e)
        {
            int ReceivedLength;
            int DataLen;
            Byte[] InDataHex;
            String InData = "";

            SerialPort sp = (SerialPort)sender;
            ReceivedLength = sp.BytesToRead;
            InDataHex = new Byte[ReceivedLength];

            DataLen = sp.Read(InDataHex, 0, ReceivedLength);
            if (chkSaveToFile.Checked)
            {
                FileStream fs = null;
                try
                {
                    fs = File.Open(this.RecFileName, FileMode.Append);
                    fs.Position = fs.Length;  
                    fs.Write(InDataHex, 0, DataLen);
                }
                catch (Exception ex)
                {
                    txtReceiveData.Text += "\r\n";
                    txtReceiveData.Text += ex.Message;
                    MessageBox.Show("文件操作失败！");
                }
                finally
                {
                    fs.Close();
                }
            }
            else
            {
                DataByte.Write(InDataHex);
                if(chkShowHEX.Checked)
                {
                    foreach (Byte d in InDataHex)
                    {
                        InData += String.Format("{0:X2} ", d);
                    }
                }
                else
                {
                    InData = System.Text.Encoding.Default.GetString(InDataHex);
                }
            }

            ReceiveCount += DataLen;
            txtReceiveData_ShowData(txtReceiveData ,InData);
        }

        private void txtReceiveData_ShowData(object sender, String data)
        {
            if (this.txtReceiveData.InvokeRequired)//等待异步
            {
                ChangeText fc = new ChangeText(txtReceiveData_ShowData);
                this.Invoke(fc, new object[]{sender,data}); //通过代理调用刷新方法
            }
            else
            {
                txtReceiveData.AppendText(data);
                tsslReceiveCount.Text = String.Format("接收：{0}", ReceiveCount);
            }
        }

        private void chkTimingSend_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTimingSend.Checked)
            {
                try
                {
                    this.TimeInterval = Convert.ToInt32(txtTimeInterval.Text);
                    timerSend.Interval = this.TimeInterval;
                    timerSend.Start();
                }
                catch (Exception) { }
            }
            else
            {
                timerSend.Stop();
            }
        }

        private void btnSendData_Click(object sender, EventArgs e)
        {
            if(serialPort1.IsOpen)
            {
                SendData();
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
            String sData= txtSendData.Text;

            if (chkSendHEX.Checked)
            {
                Byte[] bData;
                sData = sData.Replace(" ", "");
                if ((sData.Length % 2) != 0)
                {
                    sData += " ";
                }
                bData = new byte[sData.Length / 2];
                try
                {
                    for (int i = 0; i < bData.Length; i++)
                    {
                        bData[i] = Convert.ToByte(sData.Substring(i * 2, 2), 16);
                    }
                }
                catch (Exception){}                

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
                Char[] cData = sData.ToCharArray();
                serialPort1.Write(sData.ToCharArray(), 0, cData.Length);
                SendCount += cData.Length;

                tsslSendCount.Text = String.Format("发送：{0}", SendCount);
            }            
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            String FileName;
            Byte[] fileData;
            int    ReadLen;
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = null;
                FileName = fd.FileName;
                txtFileNme.Text = FileName;
                try
                {
                    fs = File.Open(FileName, FileMode.Open);
                    ReadLen = (int)((fs.Length > 1024) ? 1024 : fs.Length);
                    fileData = new Byte[ReadLen];
                    fs.Read(fileData, 0, ReadLen);
                    txtReceiveData.Text = "文件路径：" + FileName + "\r\n";
                    txtReceiveData.AppendText("文件大小："+fs.Length.ToString() + "字节\r\n");
                    txtReceiveData.AppendText("下面是预览的1024字节内容：\r\n\r\n");
                    if(chkShowHEX.Checked)
                    {
                        String text = "";
                        foreach (Byte d in fileData)
                        {
                            text += String.Format("{0:X2} ", d);
                        }
                        txtReceiveData.AppendText(text);
                    }
                    else
                    {
                        txtReceiveData.AppendText(System.Text.Encoding.Default.GetString(fileData));
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("文件打开失败！");
                }
                finally
                {
                    fs.Close();
                }
            }
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            String FileName;
            String Info;
            long   fileLen;
            Byte[] fileData;
            
            double fLen,sLen;
            int nW,nY;
            String W = "==================================================";
            String Y = ">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>";

            FileName = txtFileNme.Text;
            try
            {
                FileStream fs = File.Open(FileName, FileMode.Open);
                fileLen = fs.Length;
                fileData = new Byte[fileLen];
                fs.Read(fileData, 0, (int)fileLen);
                Info = "文件路径：" + FileName + "\r\n";
                Info += "文件大小：" + fs.Length.ToString() + "字节\r\n";
                Info += "波特率：" + this.BaudRate.ToString() + "\r\n";
                Info += "预计发送时间：" + (fs.Length * 10000 / this.BaudRate) + "ms\r\n";
                txtReceiveData.Text = Info;
                if (serialPort1.IsOpen)
                {
                    fLen = fileData.Length;
                    sLen = 0;
                    int bufSize = serialPort1.WriteBufferSize;
                    if (fileData.Length > bufSize)
                    {
                        int len = fileData.Length;
                        int index = 0;
                        while (len > bufSize)
                        {
                            serialPort1.Write(fileData, index, bufSize);
                            SendCount += bufSize;
                            System.Threading.Thread.Sleep(10000 * bufSize / BaudRate);
                            index += bufSize;
                            len -= bufSize;

                            sLen += bufSize;
                            nY = (int)(50 * (sLen / fLen));
                            nW = 50 - nY;
                            txtReceiveData.Text = Info + "[" + Y.Substring(0, nY) + W.Substring(0, nW) + "]" + "\r\n";
                            tsslSendCount.Text = String.Format("发送：{0}", SendCount);
                            this.Refresh();
                        }
                        serialPort1.Write(fileData, index, len);
                        SendCount += len;

                        sLen += len;
                        nY = (int)(50 * (sLen / fLen));
                        nW = 50 - nY;
                        txtReceiveData.Text = Info + "[" + Y.Substring(0,nY) + W.Substring(0,nW) + "]" + "\r\n";
                        this.Refresh();
                    }
                    else
                    {
                        serialPort1.Write(fileData, 0, fileData.Length);
                        SendCount += fileData.Length;

                        sLen += fileData.Length;
                        nY = (int)(50 * (sLen / fLen));
                        nW = 50 - nY;
                        txtReceiveData.Text = Info + "[" + Y.Substring(0, nY) + W.Substring(0, nW) + "]" + "\r\n";
                    }
                    tsslSendCount.Text = String.Format("发送：{0}", SendCount);
                    this.Refresh();
                }
                fs.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("文件打开失败！");
            }

        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = null;
                String FileName;
                long   WriteLen;
                Byte[] WriteData;
                FileName = fd.FileName;
                try
                {
                    fs = File.Open(FileName, FileMode.Create);
                    WriteLen = DataByte.Available;
                    WriteData = new Byte[WriteLen];
                    WriteLen = DataByte.Read(WriteData);
                    fs.Write(WriteData, 0, (int)WriteLen);                    
                }
                catch (Exception)
                {
                    MessageBox.Show("文件保存失败！");
                }
                finally
                {
                    fs.Close();
                }
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

        private void LoadConfig()
        {
            try
            {
                if (File.Exists(this.ConfFileName))
                {
                    IniFile ConfFile = new IniFile(this.ConfFileName);
                    this.PortName = ConfFile.ReadConfig<String>("Serial", "PortName");
                    this.BaudRate = ConfFile.ReadConfig<Int32>("Serial", "BaudRate");
                    this.DataBit = ConfFile.ReadConfig<Int32>("Serial", "DataBits");
                    this.StopBit = ConfFile.ReadConfig<StopBits>("Serial", "StopBits");
                    this.ParityBit = ConfFile.ReadConfig<Parity>("Serial", "Parity");
                    this.FlowCtrl = ConfFile.ReadConfig<Int32>("Serial", "FlowControl");
                    this.DTR = ConfFile.ReadConfig<Boolean>("Serial", "DTR");
                    this.RTS = ConfFile.ReadConfig<Boolean>("Serial", "RTS");

                    this.SendDataAsc = ConfFile.ReadConfig<String>("App", "SendDataAsc");
                    this.SendDataHex = ConfFile.ReadConfig<String>("App", "SendDataHex");
                    this.SendHex = ConfFile.ReadConfig<Boolean>("App", "SendHex");
                    this.SendNewLine = ConfFile.ReadConfig<Boolean>("App", "SendNewLine");
                    this.ShowHex = ConfFile.ReadConfig<Boolean>("App", "ShowHex");
                    this.TimeInterval = ConfFile.ReadConfig<Int32>("App", "TimeInterval");
                }
            }catch (Exception) { }            
        }

        private void SaveConfig()
        {
            try
            {
                if (!File.Exists(this.ConfFileName))
                {
                     StreamWriter Fs = new StreamWriter(this.ConfFileName);
                     Fs.Write(this.ConfFileContent);
                     Fs.Close();
                }
                    IniFile ConfFile = new IniFile(this.ConfFileName);
                    ConfFile.WriteConfig<String>("Serial", "PortName",this.PortName);
                    ConfFile.WriteConfig<Int32>("Serial", "BaudRate",this.BaudRate);
                    ConfFile.WriteConfig<Int32>("Serial", "DataBits",this.DataBit);
                    ConfFile.WriteConfig<StopBits>("Serial", "StopBits",this.StopBit);
                    ConfFile.WriteConfig<Parity>("Serial", "Parity",this.ParityBit);
                    ConfFile.WriteConfig<Int32>("Serial", "FlowControl",this.FlowCtrl);
                    ConfFile.WriteConfig<Boolean>("Serial", "DTR",this.DTR);
                    ConfFile.WriteConfig<Boolean>("Serial", "RTS",this.RTS);

                    ConfFile.WriteConfig<String>("App", "SendDataAsc",this.SendDataAsc);
                    ConfFile.WriteConfig<String>("App", "SendDataHex",this.SendDataHex);
                    ConfFile.WriteConfig<Boolean>("App", "SendHex",this.SendHex);
                    ConfFile.WriteConfig<Boolean>("App", "SendNewLine",this.SendNewLine);
                    ConfFile.WriteConfig<Boolean>("App", "ShowHex",this.ShowHex);
                    ConfFile.WriteConfig<Int32>("App", "TimeInterval",this.TimeInterval);
            }
            catch (Exception) { }
        }
                
    }
}
