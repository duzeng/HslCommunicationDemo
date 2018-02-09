using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HslCommunication.Profinet;
using HslCommunication;

namespace HslCommunicationDemo
{
    public partial class FormSiemens : Form
    {
        public FormSiemens( )
        {
            InitializeComponent( );
        }

        private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
        {
            try
            {
                System.Diagnostics.Process.Start( "http://www.cnblogs.com/dathlin/p/7469679.html" );
            }
            catch(Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void FormSiemens_Load( object sender, EventArgs e )
        {
            siemensTcpNet = new SiemensTcpNet( SiemensPLCS.S1200 );
            panel2.Enabled = false;
        }

        private void button1_Click( object sender, EventArgs e )
        {
            // 连接
            if(!System.Net.IPAddress.TryParse(textBox1.Text,out System.Net.IPAddress address ))
            {
                MessageBox.Show( "Ip地址输入不正确！" );
                return;
            }

            siemensTcpNet.PLCIpAddress = address;

            try
            {
                OperateResult connect = siemensTcpNet.ConnectServer( );
                if(connect.IsSuccess)
                {
                    MessageBox.Show( "连接成功！" );
                    button2.Enabled = true;
                    button1.Enabled = false;
                    panel2.Enabled = true;
                }
                else
                {
                    MessageBox.Show( "连接失败！" );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message );
            }
        }

        private void button2_Click( object sender, EventArgs e )
        {
            // 断开连接
            siemensTcpNet.ConnectClose( );
            button2.Enabled = false;
            button1.Enabled = true;
            panel2.Enabled = false;
        }


        private SiemensTcpNet siemensTcpNet = null;






    }
}
