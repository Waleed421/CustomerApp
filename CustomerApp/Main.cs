using DevExpress.XtraReports.UI;
using System;
using System.Windows.Forms;
using System.Data.Linq;
using System.Linq;


namespace CustomerApp
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            XtraReport1 xr = new XtraReport1();
            CustomerDBDataSet ct = new CustomerDBDataSet();
            new CustomerDBDataSetTableAdapters.CustomerTableAdapter().Fill(ct.Customer);
            xr.DataSource = ct;
            ReportPrintTool tool = new ReportPrintTool(xr);
            tool.ShowPreview();
        }
    }
}
