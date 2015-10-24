using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NFA_DFA
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void FormAbout_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void picSite_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.Azerbaycan.ir");
        }

        private void picCopyright_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
