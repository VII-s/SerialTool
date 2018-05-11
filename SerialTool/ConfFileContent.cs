using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SerialTool
{
    public partial class frmSerialTool
    {
        private String ConfFileName = Application.StartupPath + "\\SerialTool.ini";
        private String ConfFileContent = 
              ";这是SerialTool的设置保存文件，您在程序中设置好的串口参数和字符串数据都会自动保存，请最好不要用外部编辑器改动本文件！" + "\r\n"
            + ";如果文件被修改后程序不能打开，请删除本文件，程序将会自动生成一个新的ini文件。"     + "\r\n"
            + ";靠行首的半角分号是注释符号"    + "\r\n"
            + ";每行都以回车结束"              + "\r\n"
            + "[Serial]"                      + "\r\n"
            + ";端口号Band rate"              + "\r\n"
            + "PortName=COM1"                 + "\r\n"
            + ";波特率Band rate"              + "\r\n"
            + "BaudRate=9600"                 + "\r\n"
            + ";数据位Data bits"              + "\r\n"
            + "DataBits=8"                    + "\r\n"
            + ";停止位Stop bits"              + "\r\n"
            + "StopBits=One"                  + "\r\n"
            + ";校验位Parity"                 + "\r\n"
            + "Parity=Odd"                    + "\r\n"
            + ";流控Flow control"             + "\r\n"
            + "FlowControl=0"                 + "\r\n"
            + ";DTR"                          + "\r\n"
            + "DTR=False"                     + "\r\n"
            + ";RTS"                          + "\r\n"
            + "RTS=False"                     + "\r\n"
            + " "                             + "\r\n"
            + "[App]"                         + "\r\n"
            + ";主面板ASC字符串"               + "\r\n"
            + "SendDataAsc="                  + "\r\n"
            + ";主面板HEX数据串"               + "\r\n"
            + "SendDataHex="                  + "\r\n"
            + ";主面板发送方式(ASC or HEX)"    + "\r\n"
            + "SendHex=True"                  + "\r\n"
            + ";主面板字符串发送间隔时间"      + "\r\n"
            + "TimeInterval=1000"             + "\r\n"
            + ";主面板字符串发送新行"          + "\r\n"
            + "SendNewLine=False"             + "\r\n"
            + ";接收窗口是否HEX显示方式"       + "\r\n"
            + "ShowHex=False"                 + "\r\n"
            + ";end";
    }
}
