using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace qdocs
{
    public class Query
    {
        private string m_QueryString;
        
        public Query(DataGridView dgv, DateTime dt1, DateTime dt2, bool minusprixod)
        {
            m_QueryString = @"
            with otdel as (select iusrbranch from XXI.usr where cusrlogname = sys_context ('USERENV','CURRENT_USER'))
            select
                t.dtrntran accountingdate,
                T.ITRNDOCNUM num,
                T.CTRNVO operationcode,
                T.MTRNRSUM sm,
                nvl(t.cpay_bic, '046850755') ticdebet,
                nvl(t.crec_bic, '046850755') ticcredit,
                t.cpay_acc debetaccount,
                t.crec_acc creditaccount,
                t.cpay_name namedebet,
                t.crec_name namecredit,
                T.CTRNPURP note,
                a1.CACCIDEDIT operator1,
                a2.CACCIDEDIT operator2,
                t.cpay_inn inndebet, 
                t.crec_inn inncredit,
                t.ctrnbnamea bank
            from 
                XXI.v_pdoc_mf t left join XXI.acc a1 on t.cpay_acc = a1.caccacc left join XXI.acc a2 on t.crec_acc = a2.caccacc, otdel o  
            where
                (a1.iaccotd = o.iusrbranch or a2.iaccotd = o.iusrbranch) and
                T.DTRNTRAN between " + 
                "To_Date('" + dt1.ToString("ddMMyyyy") + "', 'DDMMYYYY') AND " +
                "To_Date('" + dt2.ToString("ddMMyyyy") + "', 'DDMMYYYY') AND ";
            if (minusprixod)
            {
                m_QueryString += "t.itrntype not in (5,41,42,43,44,50,53) AND ";
            }
            string cond = GetConditions(dgv);
            if (cond != "")
                m_QueryString += cond;
            else
                m_QueryString = m_QueryString.Substring(0, m_QueryString.Length - 5);
            //m_QueryString += " ORDER BY t.dtrntran, t.itrnnum";
            m_QueryString += " ORDER BY to_char(t.dtrntran, 'YYYYMMDD') || substr(t.cpay_acc, 1, 5) || substr(t.cpay_acc, 14, 7), t.itrndocnum";
        }

        private string GetConditions(DataGridView dgv)
        {
            string cond;
            List<List<CellCondition>> m_list = new List<List<CellCondition>>();
            DataGridViewRow r;
            object o;
            CellCondition cc;
            List<CellCondition> lst;
            for (int row = 0; row < dgv.Rows.Count; row++)
            {
                r = dgv.Rows[row];
                lst = new List<CellCondition>();
                for (int col = 1; col < dgv.Columns.Count; col++)
                {
                    o = dgv[col, row].Value;
                    if (o != null)
                    {
                        cc = new CellCondition();
                        cc.Init((RowCondition)r.Tag, (string)o);
                        lst.Add(cc);
                    }
                }
                if (lst.Count > 0)
                    m_list.Add(lst);
            }
            cond = "";
            foreach (List<CellCondition> lst0 in m_list)
            {
                cond += "(";
                foreach (CellCondition cc1 in lst0)
                {
                    cond += "(";
                    if (cc1.Type == "C")
                    {
                        if (cc1.Field != "operator")
                        {
                            switch (cc1.Operator)
                            {
                                case eOperator.Равно:
                                    cond += cc1.Field + " LIKE '" + cc1.Operand + "'";
                                    break;
                                case eOperator.НеРавно:
                                    cond += cc1.Field + " NOT LIKE '" + cc1.Operand + "'";
                                    break;
                                default:
                                    throw new Exception("Неверное условие");
                            }
                        }
                        else
                        {
                            switch (cc1.Operator)
                            {
                                case eOperator.Равно:
                                    cond += "(a1.CACCIDEDIT = '" + cc1.Operand +
                                        "') OR (a2.CACCIDEDIT = '" + cc1.Operand + "')";
                                    break;
                                default:
                                    throw new Exception("Неверное условие");
                            }
                        }
                    }
                    else if (cc1.Type == "N")
                    {
                        switch (cc1.Operator)
                        {
                            case eOperator.Равно:
                                cond += cc1.Field + " = " + cc1.Operand;
                                break;
                            case eOperator.НеРавно:
                                cond += cc1.Field + " <> " + cc1.Operand;
                                break;
                            case eOperator.Больше:
                                cond += cc1.Field + " > " + cc1.Operand;
                                break;
                            case eOperator.Меньше:
                                cond += cc1.Field + " < " + cc1.Operand;
                                break;
                            case eOperator.БольшеИлиРавно:
                                cond += cc1.Field + " >= " + cc1.Operand;
                                break;
                            case eOperator.МеньшеИлиРавно:
                                cond += cc1.Field + " <= " + cc1.Operand;
                                break;
                            default:
                                throw new Exception("Неверное условие");
                        }
                    }
                    cond += ") OR ";
                }
                cond = cond.Substring(0, cond.Length - 4);
                cond += ") AND ";
            }
            if (cond != "")
                cond = cond.Substring(0, cond.Length - 5);
            return cond;
        }
        public string QueryString
        {
            get 
            {
                return m_QueryString;
            }
        }
    }
}
