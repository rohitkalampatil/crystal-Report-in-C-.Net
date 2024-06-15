using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace CrystelReport
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            dt.Columns.Add("item",typeof(string));
            dt.Columns.Add("qty", typeof(int));
            dt.Columns.Add("rate", typeof(decimal));
            dt.Columns.Add("amount", typeof(decimal),"qty*rate");

            foreach(DataGridViewRow dgv in dataGridView1.Rows)
            {
                dt.Rows.Add(dgv.Cells[0].Value,dgv.Cells[1].Value,dgv.Cells[2].Value,dgv.Cells[3].Value);
            }


            ds.Tables.Add(dt);
            ds.WriteXmlSchema("salesReport.xml");
            Form2 fm = new Form2();
            CrystalReport1 cr = new CrystalReport1();
            cr.SetDataSource(ds);

            fm.crystalReportViewer1.ReportSource = cr;
            fm.crystalReportViewer1.Refresh();


            fm.ShowDialog();
            

        }
    }
}
