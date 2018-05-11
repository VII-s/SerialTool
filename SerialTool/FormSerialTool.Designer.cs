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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.llbBlog = new System.Windows.Forms.LinkLabel();
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
            this.chkSaveToFile = new System.Windows.Forms.CheckBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ssrSerialInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtReceiveData
            // 
            this.txtReceiveData.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.txtReceiveData, "txtReceiveData");
            this.txtReceiveData.Name = "txtReceiveData";
            this.txtReceiveData.TabStop = false;
            this.txtReceiveData.TextChanged += new System.EventHandler(this.txtReceiveData_TextChanged);
            // 
            // lblSerialNum
            // 
            resources.ApplyResources(this.lblSerialNum, "lblSerialNum");
            this.lblSerialNum.Name = "lblSerialNum";
            // 
            // cmbSerialNum
            // 
            this.cmbSerialNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSerialNum.FormattingEnabled = true;
            resources.ApplyResources(this.cmbSerialNum, "cmbSerialNum");
            this.cmbSerialNum.Name = "cmbSerialNum";
            this.cmbSerialNum.SelectedIndexChanged += new System.EventHandler(this.cmbSerialNum_SelectedIndexChanged);
            // 
            // grpSerial
            // 
            this.grpSerial.Controls.Add(this.pictureBox1);
            this.grpSerial.Controls.Add(this.llbBlog);
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
            this.grpSerial.Controls.Add(this.chkSaveToFile);
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
            resources.ApplyResources(this.grpSerial, "grpSerial");
            this.grpSerial.Name = "grpSerial";
            this.grpSerial.TabStop = false;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // llbBlog
            // 
            resources.ApplyResources(this.llbBlog, "llbBlog");
            this.llbBlog.Name = "llbBlog";
            this.llbBlog.TabStop = true;
            this.llbBlog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbBlog_LinkClicked);
            // 
            // lblUnit
            // 
            resources.ApplyResources(this.lblUnit, "lblUnit");
            this.lblUnit.Name = "lblUnit";
            // 
            // btnClearData
            // 
            resources.ApplyResources(this.btnClearData, "btnClearData");
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            // 
            // txtSendData
            // 
            resources.ApplyResources(this.txtSendData, "txtSendData");
            this.txtSendData.Name = "txtSendData";
            this.txtSendData.Leave += new System.EventHandler(this.txtSendData_Leave);
            // 
            // btnSendFile
            // 
            resources.ApplyResources(this.btnSendFile, "btnSendFile");
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.UseVisualStyleBackColor = true;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnSaveData
            // 
            resources.ApplyResources(this.btnSaveData, "btnSaveData");
            this.btnSaveData.Name = "btnSaveData";
            this.btnSaveData.UseVisualStyleBackColor = true;
            this.btnSaveData.Click += new System.EventHandler(this.btnSaveData_Click);
            // 
            // btnSendData
            // 
            resources.ApplyResources(this.btnSendData, "btnSendData");
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // btnOpenSerial
            // 
            resources.ApplyResources(this.btnOpenSerial, "btnOpenSerial");
            this.btnOpenSerial.Name = "btnOpenSerial";
            this.btnOpenSerial.UseVisualStyleBackColor = true;
            this.btnOpenSerial.Click += new System.EventHandler(this.btnOpenSerial_Click);
            // 
            // btnOpenFile
            // 
            resources.ApplyResources(this.btnOpenFile, "btnOpenFile");
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // chkShowHEX
            // 
            resources.ApplyResources(this.chkShowHEX, "chkShowHEX");
            this.chkShowHEX.Name = "chkShowHEX";
            this.chkShowHEX.UseVisualStyleBackColor = true;
            this.chkShowHEX.CheckedChanged += new System.EventHandler(this.chkShowHEX_CheckedChanged);
            // 
            // txtTimeInterval
            // 
            resources.ApplyResources(this.txtTimeInterval, "txtTimeInterval");
            this.txtTimeInterval.Name = "txtTimeInterval";
            // 
            // txtFileNme
            // 
            resources.ApplyResources(this.txtFileNme, "txtFileNme");
            this.txtFileNme.Name = "txtFileNme";
            // 
            // chkSendNewLine
            // 
            resources.ApplyResources(this.chkSendNewLine, "chkSendNewLine");
            this.chkSendNewLine.Name = "chkSendNewLine";
            this.chkSendNewLine.UseVisualStyleBackColor = true;
            // 
            // chkSendHEX
            // 
            resources.ApplyResources(this.chkSendHEX, "chkSendHEX");
            this.chkSendHEX.Name = "chkSendHEX";
            this.chkSendHEX.UseVisualStyleBackColor = true;
            this.chkSendHEX.CheckedChanged += new System.EventHandler(this.chkSendHEX_CheckedChanged);
            // 
            // chkTimingSend
            // 
            resources.ApplyResources(this.chkTimingSend, "chkTimingSend");
            this.chkTimingSend.Name = "chkTimingSend";
            this.chkTimingSend.UseVisualStyleBackColor = true;
            this.chkTimingSend.CheckedChanged += new System.EventHandler(this.chkTimingSend_CheckedChanged);
            // 
            // chkSaveToFile
            // 
            resources.ApplyResources(this.chkSaveToFile, "chkSaveToFile");
            this.chkSaveToFile.Name = "chkSaveToFile";
            this.chkSaveToFile.UseVisualStyleBackColor = true;
            this.chkSaveToFile.CheckedChanged += new System.EventHandler(this.chkSaveToFile_CheckedChanged);
            // 
            // chkRTS
            // 
            resources.ApplyResources(this.chkRTS, "chkRTS");
            this.chkRTS.Name = "chkRTS";
            this.chkRTS.UseVisualStyleBackColor = true;
            this.chkRTS.CheckedChanged += new System.EventHandler(this.chkRTS_CheckedChanged);
            // 
            // chkDTR
            // 
            resources.ApplyResources(this.chkDTR, "chkDTR");
            this.chkDTR.Name = "chkDTR";
            this.chkDTR.UseVisualStyleBackColor = true;
            this.chkDTR.CheckedChanged += new System.EventHandler(this.chkDTR_CheckedChanged);
            // 
            // cmbFlowControl
            // 
            this.cmbFlowControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFlowControl.FormattingEnabled = true;
            resources.ApplyResources(this.cmbFlowControl, "cmbFlowControl");
            this.cmbFlowControl.Name = "cmbFlowControl";
            this.cmbFlowControl.SelectedIndexChanged += new System.EventHandler(this.cmbFlowControl_SelectedIndexChanged);
            // 
            // lblFlowControl
            // 
            resources.ApplyResources(this.lblFlowControl, "lblFlowControl");
            this.lblFlowControl.Name = "lblFlowControl";
            // 
            // cmbStopBit
            // 
            this.cmbStopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStopBit.FormattingEnabled = true;
            resources.ApplyResources(this.cmbStopBit, "cmbStopBit");
            this.cmbStopBit.Name = "cmbStopBit";
            this.cmbStopBit.SelectedIndexChanged += new System.EventHandler(this.cmbStopBit_SelectedIndexChanged);
            // 
            // lblStopBit
            // 
            resources.ApplyResources(this.lblStopBit, "lblStopBit");
            this.lblStopBit.Name = "lblStopBit";
            // 
            // cmbParityBit
            // 
            this.cmbParityBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParityBit.FormattingEnabled = true;
            resources.ApplyResources(this.cmbParityBit, "cmbParityBit");
            this.cmbParityBit.Name = "cmbParityBit";
            this.cmbParityBit.SelectedIndexChanged += new System.EventHandler(this.cmbParityBit_SelectedIndexChanged);
            // 
            // lblParityBit
            // 
            resources.ApplyResources(this.lblParityBit, "lblParityBit");
            this.lblParityBit.Name = "lblParityBit";
            // 
            // cmbDataBit
            // 
            this.cmbDataBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataBit.FormattingEnabled = true;
            resources.ApplyResources(this.cmbDataBit, "cmbDataBit");
            this.cmbDataBit.Name = "cmbDataBit";
            this.cmbDataBit.SelectedIndexChanged += new System.EventHandler(this.cmbDataBit_SelectedIndexChanged);
            // 
            // lblDataBit
            // 
            resources.ApplyResources(this.lblDataBit, "lblDataBit");
            this.lblDataBit.Name = "lblDataBit";
            // 
            // cmbBaudRate
            // 
            this.cmbBaudRate.FormattingEnabled = true;
            resources.ApplyResources(this.cmbBaudRate, "cmbBaudRate");
            this.cmbBaudRate.Name = "cmbBaudRate";
            this.cmbBaudRate.SelectedIndexChanged += new System.EventHandler(this.cmbBaudRate_SelectedIndexChanged);
            this.cmbBaudRate.Leave += new System.EventHandler(this.cmbBaudRate_Leave);
            // 
            // lblBaudRate
            // 
            resources.ApplyResources(this.lblBaudRate, "lblBaudRate");
            this.lblBaudRate.Name = "lblBaudRate";
            // 
            // ssrSerialInfo
            // 
            this.ssrSerialInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslSendCount,
            this.tsslReceiveCount,
            this.tsslSerialInfo,
            this.tsslCTSDSR});
            resources.ApplyResources(this.ssrSerialInfo, "ssrSerialInfo");
            this.ssrSerialInfo.Name = "ssrSerialInfo";
            // 
            // tsslSendCount
            // 
            resources.ApplyResources(this.tsslSendCount, "tsslSendCount");
            this.tsslSendCount.Name = "tsslSendCount";
            // 
            // tsslReceiveCount
            // 
            resources.ApplyResources(this.tsslReceiveCount, "tsslReceiveCount");
            this.tsslReceiveCount.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslReceiveCount.Name = "tsslReceiveCount";
            // 
            // tsslSerialInfo
            // 
            this.tsslSerialInfo.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslSerialInfo.Name = "tsslSerialInfo";
            resources.ApplyResources(this.tsslSerialInfo, "tsslSerialInfo");
            // 
            // tsslCTSDSR
            // 
            this.tsslCTSDSR.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tsslCTSDSR.Name = "tsslCTSDSR";
            resources.ApplyResources(this.tsslCTSDSR, "tsslCTSDSR");
            // 
            // timerSend
            // 
            this.timerSend.Tick += new System.EventHandler(this.timerSend_Tick);
            // 
            // frmSerialTool
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ssrSerialInfo);
            this.Controls.Add(this.grpSerial);
            this.Controls.Add(this.txtReceiveData);
            this.Name = "frmSerialTool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSerialTool_FormClosing);
            this.Load += new System.EventHandler(this.frmSerialTool_Load);
            this.SizeChanged += new System.EventHandler(this.frmSerialTool_SizeChanged);
            this.grpSerial.ResumeLayout(false);
            this.grpSerial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel llbBlog;
        private System.Windows.Forms.CheckBox chkSaveToFile;
    }
}

