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
    public partial class ShownAnswer : Form
    {
        public ShownAnswer()
        {
            InitializeComponent();
        }

        private void ShownAnswer_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void rtxtShownExportFile_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ShownAnswer_Load(object sender, EventArgs e)
        {
            rtxtShownExportFile.Clear();
            foreach (string ReadLine in FirstForm.PrintDFA)
                rtxtShownExportFile.AppendText((ReadLine + "\n"));
        }
    }
}
