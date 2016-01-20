using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace qdocs
{
    public partial class frmGetAccPeriod : Form
    {
        public frmGetAccPeriod()
        {
            InitializeComponent();
        }

        public string Account
        {
            get { return tbAcc.Text; }
            set { tbAcc.Text = value; }
        }

        public DateTime Dt1
        {
            get { return tbDt1.Value; }
            set { tbDt1.Value = value; }
        }

        public DateTime Dt2
        {
            get { return tbDt2.Value; }
            set { tbDt2.Value = value; }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
