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
    public partial class frmGetDate : Form
    {
        public frmGetDate()
        {
            InitializeComponent();
            tbDate.Value = DateTime.Today.AddDays(-1);
        }

        public DateTime Dt 
        {
            get { return tbDate.Value; }
            set { tbDate.Value = value; }
        }
    }
}
