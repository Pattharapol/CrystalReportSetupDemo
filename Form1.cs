using CrystalReportSetupDemo.DataSet;
using CrystalReportSetupDemo.Reports;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CrystalReportSetupDemo
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("server=192.168.0.2;userid=root;password=boom123;");
            MySqlDataAdapter da = new MySqlDataAdapter("select * from human_resource.userinfo", con);
            DataSet1 ds = new DataSet1();
            da.Fill(ds, "tbl_userinfo");

            rptTbl_Userinfo rpt = new rptTbl_Userinfo();
            rpt.SetDataSource(ds);

            ReportViewer frm = new ReportViewer();
            frm.crystalReportViewer1.ReportSource = rpt;
            frm.ShowDialog();
        }
    }
}