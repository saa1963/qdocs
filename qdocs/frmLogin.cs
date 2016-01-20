using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using qdocs.Properties;

namespace qdocs
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            tbLogin.Text = Settings.Default.User ?? "";
            tbPassword.Text = Settings.Default.Password ?? "";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Settings.Default.User = tbLogin.Text;
            Settings.Default.Password = tbPassword.Text;
            Settings.Default.Save();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
    }
}
