using System;
using System.Collections.Generic;
using System.Text;

namespace qdocs
{
    public class RowCondition
    {
        private string m_Field;
        private string m_Type;
        public RowCondition(string field, string type)
        {
            m_Field = field;
            m_Type = type;
        }
        public string Field
        {
            get { return m_Field; }
            set { m_Field = value; }
        }
        public string Type
        {
            get { return m_Type; }
            set { m_Type = value; }
        }
    }
}
