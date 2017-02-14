using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using qdocs.Properties;
using Oracle.ManagedDataAccess.Client;
using System.Diagnostics;

namespace qdocs
{
    public partial class frmMain : Form
    {
        private DataTable dt = null;
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            tbDt1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            tbDt2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            InitParams();
            //splitContainer2.FixedPanel = FixedPanel.Panel1;
            //splitContainer1.FixedPanel = FixedPanel.Panel2;
        }

        private void InitParams()
        {
            dgvConditions.Rows.Add(8);
            dgvConditions[0, 0].Value = "Дебет документа";
            dgvConditions.Rows[0].Tag =
                new RowCondition("t.cpay_acc", "C");
            dgvConditions[0, 1].Value = "Кредит документа";
            dgvConditions.Rows[1].Tag =
                new RowCondition("t.crec_acc", "C");
            dgvConditions[0, 2].Value = "Плательщик";
            dgvConditions.Rows[2].Tag =
                new RowCondition("t.cpay_name", "C");
            dgvConditions[0, 3].Value = "Получатель";
            dgvConditions.Rows[3].Tag =
                new RowCondition("t.crec_name", "C");
            dgvConditions[0, 4].Value = "Вид операции";
            dgvConditions.Rows[4].Tag =
                new RowCondition("T.CTRNVO", "C");
            dgvConditions[0, 5].Value = "Назначение плат.";
            dgvConditions.Rows[5].Tag =
                new RowCondition("T.CTRNPURP", "C");
            dgvConditions[0, 6].Value = "Сумма";
            dgvConditions.Rows[6].Tag =
                new RowCondition("T.MTRNRSUM", "N");
            dgvConditions[0, 7].Value = "Исп.";
            dgvConditions.Rows[7].Tag =
                new RowCondition("operator", "C");
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            TimeSpan ts = tbDt2.Value - tbDt1.Value;
            
            try
            {
                Query q = new Query(dgvConditions, tbDt1.Value, tbDt2.Value, tbMinusPrixod.Checked);
                bs.DataSource = null;
                using (OracleConnection cn = new OracleConnection(String.Format(
                    Settings.Default.ConnectionString1, Settings.Default.User, Settings.Default.Password)))
                {
                    cn.Open();
                    OracleDataAdapter da = new OracleDataAdapter(q.QueryString, cn);
                    dt = new DataTable();
                    da.Fill(dt);
                }
                bs.DataSource = dt;
            }
            catch (OracleException e1)
            {
                MessageBox.Show(e1.Message);
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SavePositions();
        }

        private void SavePositions()
        {
            //splitContainer1.FixedPanel = FixedPanel.Panel2;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            var ex = new toExcel();
            string fname = ex.DoIt(this.dgv);

            Process prc = new Process();
            prc.StartInfo.Arguments = "\"" + fname + "\"";
            prc.StartInfo.FileName = "excel.exe";
            prc.Start();
        }

        private void mnuOpis_Click(object sender, EventArgs e)
        {
            var fDate = new frmGetDate();
            if (fDate.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var fname = new toExcel().DoOpis(fDate.Dt);
            }
        }

        private void mnuLenta_Click(object sender, EventArgs e)
        {
            var fDate = new frmGetDate();
            if (fDate.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var fname = new toExcel().DoLenta(fDate.Dt);
            }
        }

        private void mnuContrAgents_Click(object sender, EventArgs e)
        {
            string inn, bik, acc, name;
            decimal sm;
            List<clsContr> lst = new List<clsContr>();
            var f = new frmGetAccPeriod();
            f.Dt1 = DateTime.Today;
            f.Dt2 = DateTime.Today;
            if (f.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            using (OracleConnection cn = new OracleConnection(String.Format(
                Settings.Default.ConnectionString1, Settings.Default.User, Settings.Default.Password)))
            {
                cn.Open();
                var cmd = new OracleCommand(@"select
max(T.CREC_INN) Inn,
max(decode(t.cpay_acc, :acc, t.crec_bic, t.cpay_bic)) Bik,
decode(t.cpay_acc, :acc, t.crec_acc, t.cpay_acc) Account, 
max(decode(t.cpay_acc, :acc, t.crec_name, t.cpay_name)) Name,
sum(t.mtrnrsum) Summa 
from v_pdoc_mf t
where T.DTRNTRAN between :dt1 and :dt2 and
(T.CTRNACCD = :acc or T.CTRNACCC = :acc) and
decode(t.cpay_acc, :acc, t.crec_acc, t.cpay_acc) like '40%'
group by decode(t.cpay_acc, :acc, t.crec_acc, t.cpay_acc)
order by 5 desc", cn);
                cmd.BindByName = true;
                cmd.Parameters.Add(":dt1", OracleDbType.Date).Value = f.Dt1;
                cmd.Parameters.Add(":dt2", OracleDbType.Date).Value = f.Dt2;
                cmd.Parameters.Add(":acc", OracleDbType.Varchar2).Value = f.Account;
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        if (r["Inn"] is DBNull) inn = "";
                        else inn = r["Inn"].ToString();
                        if (r["Bik"] is DBNull) bik = "";
                        else bik = r["Bik"].ToString();
                        if (r["Account"] is DBNull) acc = "";
                        else acc = r["Account"].ToString();
                        if (r["Name"] is DBNull) name = "";
                        else name = r["Name"].ToString();
                        sm = (decimal)r["Summa"];
                        lst.Add(new clsContr {Inn = inn, Bik = bik, Acc = acc, Name = name, Sm = sm});
                    }
                }
            }
            new toExcel().DoContrAgents(lst);
        }
    }
}

