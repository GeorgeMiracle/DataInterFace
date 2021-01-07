using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataInterFace
{
    public partial class FrmLog : Form
    {
        private string msg;
        public FrmLog(string msg)
        {
            InitializeComponent();
            this.msg = msg;
        }

        private void FrmLog_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = msg;
        }
    }
}
