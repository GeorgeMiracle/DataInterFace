using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataInterFace
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataClasses1DataContext dataClasses1DataContext = new DataClasses1DataContext();
            var ret = dataClasses1DataContext.LD_field.Select(x => x).OrderBy(x => x.index);
            foreach (var item in ret)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("//" + item.name + "\r\n");
                sb.Append("if (!string.IsNullOrEmpty(sheet.GetRow(2 + i).GetCell(" + item.index + ", MissingCellPolicy.CREATE_NULL_AS_BLANK).ToString()))" + "\r\n");
                sb.Append("  {" + "\r\n");
                sb.Append("  bemptyRow = false;" + "\r\n");
                sb.Append("  pIExcelData." + item.field + " =GetCellValue( sheet.GetRow(2 + i).GetCell(" + item.index + ", MissingCellPolicy.CREATE_NULL_AS_BLANK)).ToString();" + "\r\n");
                sb.Append("  }" + "\r\n");

                richTextBox1.Text += sb.ToString();
            }
        }
    }
}
