using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HslCommunicationDemo
{
    public partial class FormLoad : Form
    {
        public FormLoad( )
        {
            InitializeComponent( );
        }

        private void button1_Click( object sender, EventArgs e )
        {
            Hide( );
            using (FormSiemens form = new FormSiemens( HslCommunication.Profinet.SiemensPLCS.S1200 ))
            {
                form.ShowDialog( );
            }
            Close( );
        }
    }
}
