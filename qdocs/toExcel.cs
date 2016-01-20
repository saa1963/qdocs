using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CarlosAg.ExcelXmlWriter;
using System.Windows.Forms;
using System.IO;
using Oracle.ManagedDataAccess.Client;
using qdocs.Properties;
using Microsoft.Office.Interop.Excel;

namespace qdocs
{
    class toExcel
    {
        private string opis_vklad = 
            File.ReadAllText(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "вклады.sql"), Encoding.GetEncoding(1251));
        private string opis_vnutr_rub =
            File.ReadAllText(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "внутр-руб.sql"), Encoding.GetEncoding(1251));
        private string opis_vnutr_val = 
            File.ReadAllText(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "внутр-вал.sql"), Encoding.GetEncoding(1251));
        private string opis_nach_rub =
            File.ReadAllText(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "начальные.sql"), Encoding.GetEncoding(1251));
        private string opis_vneb =
            File.ReadAllText(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "внебал.sql"), Encoding.GetEncoding(1251));
        public string DoIt(DataGridView dgv)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = 
                new System.Globalization.CultureInfo("en-US");
            WorksheetStyleBorder b;
            WorksheetRow r;

            string fname1 = Path.Combine(Path.GetTempFileName());
            FileInfo fi = new FileInfo(fname1);
            string fname0 = Path.Combine(fi.DirectoryName, fi.Name.Substring(0, fi.Name.Length - 4) + ".xml");
            CarlosAg.ExcelXmlWriter.Workbook wb = new CarlosAg.ExcelXmlWriter.Workbook();
            CarlosAg.ExcelXmlWriter.Worksheet sh = wb.Worksheets.Add("Лист1");
            WorksheetCell c;
            WorksheetColumn cl;
            WorksheetStyle st;

            sh.Options.PageSetup.PageMargins.Left = 0.5F;
            sh.Options.PageSetup.PageMargins.Right = 0.5F;
            sh.Options.PageSetup.PageMargins.Top = 0.5F;
            sh.Options.PageSetup.PageMargins.Bottom = 0.5F;

            st = new WorksheetStyle("Header");
            st.Font.Bold = true;
            st.Font.Size = 11;
            wb.Styles.Add(st);

            st = new WorksheetStyle("TableHeader");
            st.Font.Bold = true;
            st.Font.Size = 8;
            st.Alignment.WrapText = true;
            st.Alignment.Horizontal = StyleHorizontalAlignment.Center | StyleHorizontalAlignment.Distributed;
            st.Alignment.Vertical = StyleVerticalAlignment.Center;
            b = st.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous);
            b.Weight = 1;
            b = st.Borders.Add(StylePosition.Top, LineStyleOption.Continuous);
            b.Weight = 1;
            b = st.Borders.Add(StylePosition.Left, LineStyleOption.Continuous);
            b.Weight = 1;
            b = st.Borders.Add(StylePosition.Right, LineStyleOption.Continuous);
            b.Weight = 1;
            wb.Styles.Add(st);

            st = new WorksheetStyle("Def");
            st.Alignment.WrapText = true;
            st.Font.Size = 8;
            //b = st.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous);
            //b.Weight = 1;
            //b = st.Borders.Add(StylePosition.Top, LineStyleOption.Continuous);
            //b.Weight = 1;
            //b = st.Borders.Add(StylePosition.Left, LineStyleOption.Continuous);
            //b.Weight = 1;
            //b = st.Borders.Add(StylePosition.Right, LineStyleOption.Continuous);
            //b.Weight = 1;
            wb.Styles.Add(st);

            st = new WorksheetStyle("Date");
            st.Alignment.WrapText = true;
            st.Font.Size = 8;
            //b = st.Borders.Add(StylePosition.Bottom, LineStyleOption.Continuous);
            //b.Weight = 1;
            //b = st.Borders.Add(StylePosition.Top, LineStyleOption.Continuous);
            //b.Weight = 1;
            //b = st.Borders.Add(StylePosition.Left, LineStyleOption.Continuous);
            //b.Weight = 1;
            //b = st.Borders.Add(StylePosition.Right, LineStyleOption.Continuous);
            //b.Weight = 1;
            st.NumberFormat = "Short Date";
            wb.Styles.Add(st);


            cl = sh.Table.Columns.Add(40);
            cl = sh.Table.Columns.Add(40);
            cl = sh.Table.Columns.Add(40);
            cl = sh.Table.Columns.Add(40);
            cl = sh.Table.Columns.Add(50);
            cl = sh.Table.Columns.Add(60);
            cl = sh.Table.Columns.Add(100);
            cl = sh.Table.Columns.Add(50);
            cl = sh.Table.Columns.Add(60);
            cl = sh.Table.Columns.Add(100);
            cl = sh.Table.Columns.Add(200);
            cl = sh.Table.Columns.Add(200);
            cl = sh.Table.Columns.Add(200);

            //r = sh.Table.Rows.Add();
            //for (int j = 0; j < dgv.Columns.Count; j++)
            //{
            //    c = r.Cells.Add(dgv.Columns[j].HeaderText, DataType.String, "TableHeader");
            //}
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                r = sh.Table.Rows.Add();
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    if (dgv[j,i].Value is System.String)
                        c = r.Cells.Add(dgv[j,i].Value.ToString(), DataType.String, "Def");
                    else if (dgv[j, i].Value is System.DateTime)
                        c = r.Cells.Add(((DateTime)dgv[j, i].Value).ToString("s"),
                            DataType.DateTime, "Date");
                    else if (dgv[j, i].Value is System.Decimal)
                        c = r.Cells.Add(((decimal)dgv[j, i].Value).ToString(), DataType.Number, "Def");
                    else if (dgv[j, i].Value is System.Int64)
                        c = r.Cells.Add(((System.Int64)dgv[j, i].Value).ToString(), DataType.Number, "Def");
                    else
                        c = r.Cells.Add("", DataType.String, "Def");
                }
            }
            wb.Save(fname0);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ru-RU");
            return fname0;
        }

        internal string DoOpis(DateTime dt)
        {
            int row = 1;
            int i0 = 0;
            decimal sm0 = 0;
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook wb = app.Workbooks.Add();
            Microsoft.Office.Interop.Excel._Worksheet wsh = wb.Worksheets["Лист1"];
            wsh.PageSetup.Zoom = false;
            wsh.PageSetup.FitToPagesWide = 1;
            wsh.PageSetup.FitToPagesTall = 500;
            Range r = wsh.get_Range("a1").EntireRow.EntireColumn;
            r.Font.Size = 8;
            wsh.Range["A:F"].NumberFormat = "@";
            wsh.Columns["A"].ColumnWidth = 6;
            wsh.Columns["B"].ColumnWidth = 4;
            wsh.Columns["C"].ColumnWidth = 11;
            wsh.Columns["D"].ColumnWidth = 28;
            wsh.Columns["E"].ColumnWidth = 11;
            wsh.Columns["F"].ColumnWidth = 28;
            wsh.Columns["G"].ColumnWidth = 13;
            wsh.Columns["H"].ColumnWidth = 49;
            wsh.Columns["I"].ColumnWidth = 52;
            wsh.Columns["J"].ColumnWidth = 101;
            var doname = GetDoName();
            DoSubOpis(wsh, dt, "Документы по вкладным операциям", opis_vklad, doname, ref row, ref i0, ref sm0);
            DoSubOpis(wsh, dt, "Внутрибанковские документы рублевые", opis_vnutr_rub, doname, ref row, ref i0, ref sm0);
            DoSubOpis(wsh, dt, "Внутрибанковские документы валютные", opis_vnutr_val, doname, ref row, ref i0, ref sm0);
            DoSubOpis(wsh, dt, "Начальные документы рублевые", opis_nach_rub, doname, ref row, ref i0, ref sm0);
            DoSubOpis(wsh, dt, "Внебалансовые документы", opis_vneb, doname, ref row, ref i0, ref sm0);

            wsh.Cells[row, 1] = "Всего документов";
            wsh.Cells[row, 4] = i0;
            wsh.Cells[row, 7] = sm0;

            wsh.Range[wsh.Cells[1, "H"], wsh.Cells[1, "J"]].EntireColumn.Hidden = true;
            
            app.Visible = true;
            
            return "";
        }

        private void DoSubOpis(Microsoft.Office.Interop.Excel._Worksheet sh, DateTime dt, string title, 
            string cmdText, string doname, ref int row, ref int i0, ref decimal sm0)
        {
            sh.Cells[row, 1] = "АКБ \"ТКПБ\" (ОАО) г.Тамбов";
            row++;
            sh.Cells[row, 1] = "БИК: 046850755";
            row += 2;
            sh.Cells[row, 1] = "ОПИСЬ ДОКУМЕНТОВ ПО ДОПОФИСУ ЗА " + dt.ToString("dd.MM.yyyy") + " г.";
            row += 2;
            sh.Cells[row, 1] = "ДОПОФИС: " + doname;
            row++;
            sh.Cells[row, 1] = title;
            row++;
            int row0 = row;
            int i = 0;
            decimal sm = 0;
            sh.Cells[row, 1] = "Номер док-та";
            sh.Cells[row, 2] = "ВО";
            sh.Cells[row, 3] = "БИК дебет";
            sh.Cells[row, 4] = "Счет дебет";
            sh.Cells[row, 5] = "БИК кредит";
            sh.Cells[row, 6] = "Счет кредит";
            sh.Cells[row, 7] = "Сумма";
            row++;

            using (OracleConnection cn = new OracleConnection(String.Format(
                Settings.Default.ConnectionString, Settings.Default.User, Settings.Default.Password)))
            {
                cn.Open();
                var cmd = new OracleCommand(cmdText, cn);
                cmd.Parameters.Add(":beg", OracleDbType.Date).Value = dt;
                using(var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        sh.Cells[row, 1] = rd["num"];
                        sh.Cells[row, 2] = rd["operationcode"];
                        sh.Cells[row, 3] = rd["ticdebet"];
                        sh.Cells[row, 4] = rd["debetaccount"];
                        sh.Cells[row, 5] = rd["ticcredit"];
                        sh.Cells[row, 6] = rd["creditaccount"];
                        sh.Cells[row, 7] = rd["sm"];
                        row++;
                        sh.Range[sh.Cells[row, 1], sh.Cells[row, 4]].Merge();
                        sh.Cells[row, 1] = rd["debetname"];
                        sh.Range[sh.Cells[row, 5], sh.Cells[row, 7]].Merge();
                        sh.Cells[row, 5] = rd["creditname"];
                        sh.Cells[row, 8] = "=RC[-7]";
                        sh.Cells[row, 9] = "=RC[-4]";
                        sh.Cells[row, 1].EntireRow.WrapText = true;
                        row++;
                        if (rd["cbudcode"].ToString() != "" || 
                            rd["cokatocode"].ToString() != "" ||
                            rd["cnalpurp"].ToString() != "" || 
                            rd["cnalperiod"].ToString() != "" ||
                            rd["cnaldocnum"].ToString() != "" || 
                            rd["cnaldocdate"].ToString() != "" ||
                            rd["cnaltype"].ToString() != "")
                        {
                            sh.Range[sh.Cells[row, 1], sh.Cells[row, 7]].Merge();
                            sh.Cells[row, 1] = rd["cbudcode"].ToString().PadRight(20) + " | " +
                                rd["cokatocode"].ToString().PadRight(11) + " | " +
                                rd["cnalpurp"].ToString().PadRight(2) + " | " +
                                rd["cnalperiod"].ToString().PadRight(10) + " | " +
                                rd["cnaldocnum"].ToString().PadRight(15) + " | " +
                                rd["cnaldocdate"].ToString().PadRight(10) + " | " +
                                rd["cnaltype"].ToString().PadRight(2);
                            row++;
                        }
                        sh.Range[sh.Cells[row, 1], sh.Cells[row, 7]].Merge();
                        sh.Cells[row, 1] = rd.GetValue(9) is DBNull ? "": rd.GetString(9);
                        sh.Cells[row, 10] = "=RC[-9]";
                        sh.Cells[row, 1].EntireRow.WrapText = true;
                        row++;
                        i++;
                        sm += (decimal)rd["sm"];
                        i0++;
                        sm0 += (decimal)rd["sm"];
                    }
                }
            }
            sh.Cells[row, 1] = "Итого документов";
            sh.Cells[row, 4] = i;
            sh.Cells[row, 7] = sm;
            var b = sh.Range[sh.Cells[row0, 1], sh.Cells[row - 1, 7]].Borders;
            b[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            b[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            b[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            b[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            b[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
            b[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
            row++;
            row++;
        }

        private string GetDoName()
        {
            using (OracleConnection cn = new OracleConnection(String.Format(
                Settings.Default.ConnectionString, Settings.Default.User, Settings.Default.Password)))
            {
                cn.Open();
                var cmd = new OracleCommand(@"
with otdel as (select iusrbranch from XXI.usr where cusrlogname = sys_context ('USERENV','CURRENT_USER'))
select o.cotdname from otd o, otdel o1 where O.IOTDNUM = o1.iusrbranch
                ", cn);
                var o = cmd.ExecuteScalar();
                return o.ToString();
            }
        }

        internal string DoLenta(DateTime dt)
        {
            int row = 1;
            int i0 = 0;
            decimal sm0 = 0;
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook wb = app.Workbooks.Add();
            Microsoft.Office.Interop.Excel._Worksheet wsh = wb.Worksheets["Лист1"];
            wsh.PageSetup.Zoom = false;
            wsh.PageSetup.FitToPagesWide = 1;
            wsh.PageSetup.FitToPagesTall = 500;
            Range r = wsh.get_Range("a1").EntireRow.EntireColumn;
            r.Font.Size = 8;

            DoSubLenta(wsh, dt, opis_vklad, ref row, ref i0, ref sm0);
            DoSubLenta(wsh, dt, opis_vnutr_rub, ref row, ref i0, ref sm0);
            DoSubLenta(wsh, dt, opis_vnutr_val, ref row, ref i0, ref sm0);
            DoSubLenta(wsh, dt, opis_nach_rub, ref row, ref i0, ref sm0);
            DoSubLenta(wsh, dt, opis_vneb, ref row, ref i0, ref sm0);

            wsh.Cells[row, 1] = sm0;

            app.Visible = true;

            return "";
        }

        private void DoSubLenta(Microsoft.Office.Interop.Excel._Worksheet sh, DateTime dt,
            string cmdText, ref int row, ref int i0, ref decimal sm0)
        {
            row++;
            int row0 = row;
            int i = 0;
            decimal sm = 0;

            using (OracleConnection cn = new OracleConnection(String.Format(
                Settings.Default.ConnectionString, Settings.Default.User, Settings.Default.Password)))
            {
                cn.Open();
                var cmd = new OracleCommand(cmdText, cn);
                cmd.Parameters.Add(":beg", OracleDbType.Date).Value = dt;
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        sh.Cells[row, 1] = rd["sm"];
                        row++;
                        i++;
                        sm += (decimal)rd["sm"];
                        i0++;
                        sm0 += (decimal)rd["sm"];
                    }
                }
            }
            sh.Cells[row, 1] = sm;
            row++;
            row++;
        }

        public void DoContrAgents(List<clsContr> lst)
        {
            int row = 1;
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook wb = app.Workbooks.Add();
            Microsoft.Office.Interop.Excel._Worksheet wsh = wb.Worksheets["Лист1"];
            wsh.PageSetup.Zoom = false;
            wsh.PageSetup.FitToPagesWide = 1;
            wsh.PageSetup.FitToPagesTall = 500;
            Range r = wsh.get_Range("a1").EntireRow.EntireColumn;
            r.Font.Size = 8;
            wsh.Range["A:D"].NumberFormat = "@";
            wsh.Range["E:E"].NumberFormat = "## ### ### ### ##0.00";
            wsh.Columns["A"].ColumnWidth = 13;
            wsh.Columns["B"].ColumnWidth = 10;
            wsh.Columns["C"].ColumnWidth = 23;
            wsh.Columns["D"].ColumnWidth = 60;
            wsh.Columns["E"].ColumnWidth = 13;
            foreach(var o in lst)
            {
                wsh.Cells[row, 1] = o.Inn;
                wsh.Cells[row, 2] = o.Bik;
                wsh.Cells[row, 3] = o.Acc;
                wsh.Cells[row, 4] = o.Name;
                wsh.Cells[row, 5] = o.Sm;
                row++;
            }
            app.Visible = true;
        }
    }
}
