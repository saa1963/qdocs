using System;
using System.Collections.Generic;
using System.Text;

namespace qdocs
{
    public enum eOperator
    {
        Равно,
        НеРавно,
        Больше,
        БольшеИлиРавно,
        Меньше,
        МеньшеИлиРавно
    }
    public class CellCondition
    {
        private RowCondition m_rowcondition = null;
        private string m_operand;
        private eOperator m_operator;
        public CellCondition() { }
        public void Init(RowCondition rowcondition, string val)
        {
            int i;
            string val0 = val.Trim();
            string sym0 = val0.Substring(0, 1);
            string sym1 = " ";
            if (val0.Length > 1)
                sym1 = val0.Substring(1, 1);
            switch (sym0)
            {
                case "=":
                    m_operator = eOperator.Равно;
                    i = 1;
                    break;
                case "<":
                    switch (sym1)
                    {
                        case ">":
                            m_operator = eOperator.НеРавно;
                            i = 2;
                            break;
                        case "=":
                            m_operator = eOperator.МеньшеИлиРавно;
                            i = 2;
                            break;
                        default:
                            m_operator = eOperator.Меньше;
                            i = 1;
                            break;
                    }
                    break;
                case ">":
                    switch (sym1)
                    {
                        case "=":
                            m_operator = eOperator.БольшеИлиРавно;
                            i = 2;
                            break;
                        default:
                            m_operator = eOperator.Больше;
                            i = 1;
                            break;
                    }
                    break;
                default:
                    m_operator = eOperator.Равно;
                    i = 0;
                    break;
            }
            m_rowcondition = rowcondition;
            if (i < val0.Length)
            {
                m_operand = val0.Substring(i).Trim();
                if (m_operand == "")
                    throw new Exception("Неверное условие: " + val);
            }
            else
                throw new Exception("Неверное условие: " + val);
        }
        public string Field
        {
            get { return m_rowcondition.Field; }
        }
        public string Type
        {
            get { return m_rowcondition.Type; }
        }
        public string Operand
        {
            get { return m_operand; }
            set { m_operand = value; }
        }
        public eOperator Operator
        {
            get { return m_operator; }
            set { m_operator = value; }
        }
    }
}
