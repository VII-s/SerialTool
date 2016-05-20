namespace SerialTool
{
    partial class frmSerialTool
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSerialTool));
            this.txtReceiveData = new System.Windows.Forms.TextBox();
            this.lblSerialNum = new System.Windows.Forms.Label();
            this.cmbSerialNum = new System.Windows.Forms.ComboBox();
            this.grpSerial = new System.Windows.Forms.GroupBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.btnClearData = new System.Windows.Forms.Button();
            this.txtSendData = new System.Windows.Forms.TextBox();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.btnSaveData = new System.Windows.Forms.Button();
            this.btnSendData = new System.Windows.Forms.Button();
            this.btnOpenSerial = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.chkShowHEX = new System.Windows.Forms.CheckBox();
            this.txtTimeInterval = new System.Windows.Forms.TextBox();
            this.txtFileNme = new System.Windows.Forms.TextBox();
            this.chkSendNewLine = new System.Windows.Forms.CheckBox();
            this.chkSendHEX = new System.Windows.Forms.CheckBox();
            this.chkTimingSend = new System.Windows.Forms.CheckBox();
            this.chkRTS = new System.Windows.Forms.CheckBox();
            this.chkDTR = new System.Windows.Forms.CheckBox();
            this.cmbFlowControl = new System.Windows.Forms.ComboBox();
            this.lblFlowControl = new System.Windows.Forms.Label();
            this.cmbStopBit = new System.Windows.Forms.ComboBox();
            this.lblStopBit = new System.Windows.Forms.Label();
            this.cmbParityBit = new System.Windows.Forms.ComboBox();
            this.lblParityBit = new System.Windows.Forms.Label();
            this.cmbDataBit = new System.Windows.Forms.ComboBox();
            this.lblDataBit = new System.Windows.Forms.Label();
            this.cmbBaudRate = new System.Windows.Forms.ComboBox();
            this.lblBaudRate = new System.Windows.Forms.Label();
            this.ssrSerialInfo = new System.Windows.Forms.StatusStrip();
            this.tsslSendCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslReceiveCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSerialInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslCTSDSR = new System.Windows.Forms.ToolStripStatusLabel();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timerSend = new System.Windows.Forms.Timer(this.components);
            this.grpSerial.SuspendLayout();
            this.ssrSerialInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtReceiveData
            // 
            this.txtReceiveData.BackColor = System.Drawing.SystemColors.Window;
            this.txtReceiveData.Location = new System.Drawing.Point(0, 0);
            this.txtReceiveData.Multiline = true;
            this.txtReceiveData.Name = "txtReceiveData";
            this.txtReceiveData.ReadOnly = true;
            this.txtReceiveData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReceiveData.Size = new System.Drawing.Size(623, 266);
            this.txtReceiveData.TabIndex = 0;
            this.txtReceiveData.TextChanged += new System.EventHandler(this.txtReceiveData_TextChanged);
            // 
            // lblSerialNum
            // 
            this.lblSerialNum.AutoSize = true;
            this.lblSerialNum.Location = new System.Drawing.Point(5, 22);
            this.lblSerialNum.Name = "lblSerialNum";
            this.lblSerialNum.Size = new System.Drawing.Size(41, 12);
            this.lblSerialNum.TabIndex = 1;
            this.lblSerialNum.Text = "串口号";
            // 
            // cmbSerialNum
            // 
            this.cmbSerialNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerialNum.FormattingEnabled = true;
            this.cmbSerialNum.Location = new System.Drawing.Point(53, 18);
            this.cmbSerialNum.Name = "cmbSerialNum";
            this.cmbSerialNum.Size = new System.Drawing.Size(75, 20);
            this.cmbSerialNum.TabIndex = 2;
            this.cmbSerialNum.SelectedIndexChanged += new System.EventHandler(this.cmbSerialNum_SelectedIndexChanged);
            // 
            // grpSerial
            // 
            this.grpSerial.Controls.Add(this.lblUnit);
            this.grpSerial.Controls.Add(this.btnClearData);
            this.grpSerial.Controls.Add(this.txtSendData);
            this.grpSerial.Controls.Add(this.btnSendFile);
            this.grpSerial.Controls.Add(this.btnSaveData);
            this.grpSerial.Controls.Add(this.btnSendData);
            this.grpSerial.Controls.Add(this.btnOpenSerial);
            this.grpSerial.Controls.Add(this.btnOpenFile);
            this.grpSerial.Controls.Add(this.chkShowHEX);
            this.grpSerial.Controls.Add(this.txtTimeInterval);
            this.grpSerial.Controls.Add(this.txtFileNme);
            this.grpSerial.Controls.Add(this.cmbSerialNum);
            this.grpSerial.Controls.Add(this.chkSendNewLine);
            this.grpSerial.Controls.Add(this.lblSerialNum);
            this.grpSerial.Controls.Add(this.chkSendHEX);
            this.grpSerial.Controls.Add(this.chkTimingSend);
            this.grpSerial.Controls.Add(this.chkRTS);
            this.grpSerial.Controls.Add(this.chkDTR);
            this.grpSerial.Controls.Add(this.cmbFlowControl);
            this.grpSerial.Controls.Add(this.lblFlowControl);
            this.grpSerial.Controls.Add(this.cmbStopBit);
            this.grpSerial.Controls.Add(this.lblStopBit);
            this.grpSerial.Controls.Add(this.cmbParityBit);
            this.grpSerial.Controls.Add(this.lblParityBit);
            this.grpSerial.Controls.Add(this.cmbDataBit);
            this.grpSerial.Controls.Add(this.lblDataBit);
            this.grpSerial.Controls.Add(this.cmbBaudRate);
            this.grpSerial.Controls.Add(this.lblBaudRate);
            this.grpSerial.Location = new System.Drawing.Point(4, 268);
            this.grpSerial.Margin = new System.Windows.Forms.Padding(0);
            this.grpSerial.Name = "grpSerial";
            this.grpSerial.Padding = new System.Windows.Forms.Padding(0);
            this.grpSerial.Size = new System.Drawing.Size(615, 179);
            this.grpSerial.TabIndex = 3;
            this.grpSerial.TabStop = false;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(284, 84);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(35, 12);
            this.lblUnit.TabIndex = 5;
            this.lblUnit.Text = "ms/次";
            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(293, 17);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(75, 23);
            this.btnClearData.TabIndex = 4;
            this.btnClearData.Text = "清除数据";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            // 
            // txtSendData
            // 
            this.txtSendData.Location = new System.Drawing.Point(139, 138);
            this.txtSendData.Multiline = true;
            this.txtSendData.Name = "txtSendData";
            this.txtSendData.Size = new System.Drawing.Size(470, 33);
            this.txtSendData.TabIndex = 4;
            // 
            // btnSendFile
            // 
            this.btnSendFile.Location = new System.Drawing.Point(487, 80);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(121, 23);
            this.btnSendFile.TabIndex = 4;
            this.btnSendFile.Text = "发送文件";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnSaveData
            // 
            this.btnSaveData.Location = new System.Drawing.Point(213, 17);
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.Size = new System.Drawing.Size(75, 23);
            this.btnSaveData.TabIndex = 4;
            this.btnSaveData.Text = "保存数据";
            this.btnSaveData.UseVisualStyleBackColor = true;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // btnSendData
            // 
            this.btnSendData.Location = new System.Drawing.Point(334, 109);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(274, 23);
            this.btnSendData.TabIndex = 4;
            this.btnSendData.Text = "发送数据";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // btnOpenSerial
            // 
            this.btnOpenSerial.Location = new System.Drawing.Point(133, 17);
            this.btnOpenSerial.Name = "btnOpenSerial";
            this.btnOpenSerial.Size = new System.Drawing.Size(75, 23);
            this.btnOpenSerial.TabIndex = 4;
            this.btnOpenSerial.Text = "打开串口";
            this.btnOpenSerial.UseVisualStyleBackColor = true;
            this.btnOpenSerial.Click += new System.EventHandler(this.btnOpenSerial_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(334, 80);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(121, 23);
            this.btnOpenFile.TabIndex = 4;
            this.btnOpenFile.Text = "打开文件";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // chkShowHEX
            // 
            this.chkShowHEX.AutoSize = true;
            this.chkShowHEX.Location = new System.Drawing.Point(457, 20);
            this.chkShowHEX.Name = "chkShowHEX";
            this.chkShowHEX.Size = new System.Drawing.Size(66, 16);
            this.chkShowHEX.TabIndex = 3;
            this.chkShowHEX.Text = "HEX显示";
            this.chkShowHEX.UseVisualStyleBackColor = true;
            this.chkShowHEX.CheckedChanged += new System.EventHandler(this.chkShowHEX_CheckedChanged);
            // 
            // txtTimeInterval
            // 
            this.txtTimeInterval.Location = new System.Drawing.Point(219, 84);
            this.txtTimeInterval.Name = "txtTimeInterval";
            this.txtTimeInterval.Size = new System.Drawing.Size(62, 21);
            this.txtTimeInterval.TabIndex = 4;
            // 
            // txtFileNme
            // 
            this.txtFileNme.Location = new System.Drawing.Point(334, 54);
            this.txtFileNme.Name = "txtFileNme";
            this.txtFileNme.Size = new System.Drawing.Size(274, 21);
            this.txtFileNme.TabIndex = 4;
            // 
            // chkSendNewLine
            // 
            this.chkSendNewLine.AutoSize = true;
            this.chkSendNewLine.Location = new System.Drawing.Point(216, 107);
            this.chkSendNewLine.Name = "chkSendNewLine";
            this.chkSendNewLine.Size = new System.Drawing.Size(72, 16);
            this.chkSendNewLine.TabIndex = 3;
            this.chkSendNewLine.Text = "发送新行";
            this.chkSendNewLine.UseVisualStyleBackColor = true;
            // 
            // chkSendHEX
            // 
            this.chkSendHEX.AutoSize = true;
            this.chkSendHEX.Location = new System.Drawing.Point(136, 106);
            this.chkSendHEX.Name = "chkSendHEX";
            this.chkSendHEX.Size = new System.Drawing.Size(66, 16);
            this.chkSendHEX.TabIndex = 3;
            this.chkSendHEX.Text = "HEX发送";
            this.chkSendHEX.UseVisualStyleBackColor = true;
            // 
            // chkTimingSend
            // 
            this.chkTimingSend.AutoSize = true;
            this.chkTimingSend.Location = new System.Drawing.Point(136, 83);
            this.chkTimingSend.Name = "chkTimingSend";
            this.chkTimingSend.Size = new System.Drawing.Size(72, 16);
            this.chkTimingSend.TabIndex = 3;
            this.chkTimingSend.Text = "定时发送";
            this.chkTimingSend.UseVisualStyleBackColor = true;
            this.chkTimingSend.CheckedChanged += new System.EventHandler(this.chkTimingSend_CheckedChanged);
            // 
            // chkRTS
            // 
            this.chkRTS.AutoSize = true;
            this.chkRTS.Location = new System.Drawing.Point(216, 59);
            this.chkRTS.Name = "chkRTS";
            this.chkRTS.Size = new System.Drawing.Size(42, 16);
            this.chkRTS.TabIndex = 3;
            this.chkRTS.Text = "RTS";
            this.chkRTS.UseVisualStyleBackColor = true;
            this.chkRTS.CheckedChanged += new System.EventHandler(this.chkRTS_CheckedChanged);
            // 
            // chkDTR
            // 
            this.chkDTR.AutoSize = true;
            this.chkDTR.Location = new System.Drawing.Point(136, 60);
            this.chkDTR.Name = "chkDTR";
            this.chkDTR.Size = new System.Drawing.Size(42, 16);
            this.chkDTR.TabIndex = 3;
            this.chkDTR.Text = "DTR";
            this.chkDTR.UseVisualStyleBackColor = true;
            this.chkDTR.CheckedChanged += new System.EventHandler(this.chkDTR_CheckedChanged);
            // 
            // cmbFlowControl
            // 
            this.cmbFlowControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFlowControl.FormattingEnabled = true;
            this.cmbFlowControl.Location = new System.Drawing.Point(57, 151);
            this.cmbFlowControl.Name = "cmbFlowControl";
            this.cmbFlowControl.Size = new System.Drawing.Size(75, 20);
            this.cmbFlowControl.TabIndex = 2;
            this.cmbFlowControl.SelectedIndexChanged += new System.EventHandler(this.cmbFlowControl_SelectedIndexChanged);
            // 
            // lblFlowControl
            // 
            this.lblFlowControl.AutoSize = true;
            this.lblFlowControl.Location = new System.Drawing.Point(6, 152);
            this.lblFlowControl.Name = "lblFlowControl";
            this.lblFlowControl.Size = new System.Drawing.Size(41, 12);
            this.lblFlowControl.TabIndex = 1;
            this.lblFlowControl.Text = "流控制";
            // 
            // cmbStopBit
            // 
            this.cmbStopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStopBit.FormattingEnabled = true;
            this.cmbStopBit.Location = new System.Drawing.Point(57, 128);
            this.cmbStopBit.Name = "cmbStopBit";
            this.cmbStopBit.Size = new System.Drawing.Size(75, 20);
            this.cmbStopBit.TabIndex = 2;
            this.cmbStopBit.SelectedIndexChanged += new System.EventHandler(this.cmbStopBit_SelectedIndexChanged);
            // 
            // lblStopBit
            // 
            this.lblStopBit.AutoSize = true;
            this.lblStopBit.Location = new System.Drawing.Point(6, 129);
            this.lblStopBit.Name = "lblStopBit";
            this.lblStopBit.Size = new System.Drawing.Size(41, 12);
            this.lblStopBit.TabIndex = 1;
            this.lblStopBit.Text = "停止位";
            // 
            // cmbParityBit
            // 
            this.cmbParityBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParityBit.FormattingEnabled = true;
            this.cmbParityBit.Location = new System.Drawing.Point(57, 105);
            this.cmbParityBit.Name = "cmbParityBit";
            this.cmbParityBit.Size = new System.Drawing.Size(75, 20);
            this.cmbParityBit.TabIndex = 2;
            this.cmbParityBit.SelectedIndexChanged += new System.EventHandler(this.cmbParityBit_SelectedIndexChanged);
            // 
            // lblParityBit
            // 
            this.lblParityBit.AutoSize = true;
            this.lblParityBit.Location = new System.Drawing.Point(6, 106);
            this.lblParityBit.Name = "lblParityBit";
            this.lblParityBit.Size = new System.Drawing.Size(41, 12);
            this.lblParityBit.TabIndex = 1;
            this.lblParityBit.Text = "校验位";
            // 
            // cmbDataBit
            // 
            this.cmbDataBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataBit.FormattingEnabled = true;
            this.cmbDataBit.Location = new System.Drawing.Point(57, 82);
            this.cmbDataBit.Name = "cmbDataBit";
            this.cmbDataBit.Size = new System.Drawing.Size(75, 20);
            this.cmbDataBit.TabIndex = 2;
            this.cmbDataBit.SelectedIndexChanged += new System.EventHandler(this.cmbDataBit_SelectedIndexChanged);
            // 
            // lblDataBit
            // 
            this.lblDataBit.AutoSize = true;
            this.lblDataBit.Location = new System.Drawing.Point(6, 83);
            this.lblDataBit.Name = "lblDataBit";
            this.lblDataBit.Size = new System.Drawing.Size(41, 12);
            this.lblDataBit.TabIndex = 1;
            this.lblDataBit.Text = "数据位";
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.FormattingEnabled = true;
            this.cmbBaudRate.Location = new System.Drawing.Point(57, 59);
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.Size = new System.Drawing.Size(75, 20);
            this.cmbBaudRate.TabIndex = 2;
            this.cmbBaudRate.SelectedIndexChanged += new System.EventHandler(this.cmbBaudRate_SelectedIndexChanged);
            // 
            // lblBaudRate
            // 
            this.lblBaudRate.AutoSize = true;
            this.lblBaudRate.Location = new System.Drawing.Point(6, 60);
            this.lblBaudRate.Name = "lblBaudRate";
            this.lblBaudRate.Size = new System.Drawing.Size(41, 12);
            this.lblBaudRate.TabIndex = 1;
            this.lblBaudRate.Text = "波特率";
            // 
            // ssrSerialInfo
            // 
            this.ssrSerialInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslSendCount,
            this.tsslReceiveCount,
            this.tsslSerialInfo,
            this.tsslCTSDSR});
            this.ssrSerialInfo.Location = new System.Drawing.Point(0, 450);
            this.ssrSerialInfo.Name = "ssrSerialInfo";
            this.ssrSerialInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ssrSerialInfo.Size = new System.Drawing.Size(623, 26);
            this.ssrSerialInfo.TabIndex = 5;
            this.ssrSerialInfo.Text = "statusStrip1";
            // 
            // tsslSendCount
            // 
            this.tsslSendCount.AutoSize = false;
            this.tsslSendCount.Name = "tsslSendCount";
            this.tsslSendCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsslSendCount.Size = new System.Drawing.Size(98, 21);
            this.tsslSendCount.Text = "发送：0";
            this.tsslSendCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsslReceiveCount
            // 
            this.tsslReceiveCount.AutoSize = false;
            this.tsslReceiveCount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslReceiveCount.Name = "tsslReceiveCount";
            this.tsslReceiveCount.Size = new System.Drawing.Size(98, 21);
            this.tsslReceiveCount.Text = "接收：0";
            this.tsslReceiveCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tsslSerialInfo
            // 
            this.tsslSerialInfo.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslSerialInfo.Name = "tsslSerialInfo";
            this.tsslSerialInfo.Size = new System.Drawing.Size(262, 21);
            this.tsslSerialInfo.Text = "COM10已打开  256000bps,8,1,无校验,无流控";
            // 
            // tsslCTSDSR
            // 
            this.tsslCTSDSR.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslCTSDSR.Name = "tsslCTSDSR";
            this.tsslCTSDSR.Size = new System.Drawing.Size(98, 21);
            this.tsslCTSDSR.Text = "DTR=1  RTS=1";
            this.tsslCTSDSR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerSend
            // 
            this.timerSend.Tick += new System.EventHandler(this.timerSend_Tick);
            // 
            // frmSerialTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 476);
            this.Controls.Add(this.ssrSerialInfo);
            this.Controls.Add(this.grpSerial);
            this.Controls.Add(this.txtReceiveData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSerialTool";
            this.Text = "串口调试工具 V1.0  By：VIIs";
            this.Load += new System.EventHandler(this.frmSerialTool_Load);
            this.SizeChanged += new System.EventHandler(this.frmSerialTool_SizeChanged);
            this.grpSerial.ResumeLayout(false);
            this.grpSerial.PerformLayout();
            this.ssrSerialInfo.ResumeLayout(false);
            this.ssrSerialInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtReceiveData;
        private System.Windows.Forms.Label lblSerialNum;
        private System.Windows.Forms.ComboBox cmbSerialNum;
        private System.Windows.Forms.GroupBox grpSerial;
        private System.Windows.Forms.ComboBox cmbFlowControl;
        private System.Windows.Forms.Label lblFlowControl;
        private System.Windows.Forms.ComboBox cmbStopBit;
        private System.Windows.Forms.Label lblStopBit;
        private System.Windows.Forms.ComboBox cmbParityBit;
        private System.Windows.Forms.Label lblParityBit;
        private System.Windows.Forms.ComboBox cmbDataBit;
        private System.Windows.Forms.Label lblDataBit;
        private System.Windows.Forms.ComboBox cmbBaudRate;
        private System.Windows.Forms.Label lblBaudRate;
        private System.Windows.Forms.Button btnOpenSerial;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.TextBox txtSendData;
        private System.Windows.Forms.TextBox txtFileNme;
        private System.Windows.Forms.CheckBox chkSendNewLine;
        private System.Windows.Forms.CheckBox chkSendHEX;
        private System.Windows.Forms.CheckBox chkTimingSend;
        private System.Windows.Forms.CheckBox chkRTS;
        private System.Windows.Forms.CheckBox chkDTR;
        private System.Windows.Forms.StatusStrip ssrSerialInfo;
        private System.Windows.Forms.Button btnSaveData;
        private System.Windows.Forms.Button btnClearData;
        private System.Windows.Forms.CheckBox chkShowHEX;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox txtTimeInterval;
        private System.Windows.Forms.ToolStripStatusLabel tsslSendCount;
        private System.Windows.Forms.ToolStripStatusLabel tsslReceiveCount;
        private System.Windows.Forms.ToolStripStatusLabel tsslSerialInfo;
        private System.Windows.Forms.ToolStripStatusLabel tsslCTSDSR;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timerSend;
    }
}

