using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace MadhavTilesBill
{
    public partial class PrintBill : Form
    {
        Connectionclass obj = new Connectionclass();
        CrystalReport1 cryrpt1 = new CrystalReport1();
        SqlCommand cmd;
        SqlDataAdapter sda;
        public PrintBill()
        {
            InitializeComponent();
        }

        private void piccloseprintbill_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picmaximizeprintbill_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void picminimizeprintbill_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PrintBill_Load(object sender, EventArgs e)
        {
            txtinvoicenoprintbill.Text = getinvoicenoforcryrpt.strinvoiceno.ToString();
            if(txtinvoicenoprintbill.Text != "")
            {
                try
                {
                    obj.getconnection();
                    cmd = new SqlCommand("select * from tbl_newbill where invoiceno = '"+getinvoicenoforcryrpt.strinvoiceno+"'",obj.con);
                    DataSet ds = new DataSet();
                    sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds, "tbl_newbill");
                    cryrpt1.SetDataSource(ds);
                    crystalReportViewer1.ReportSource = cryrpt1;
                    obj.closeconnection();
                    getinvoicenoforcryrpt.strinvoiceno = "0";
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            if(txtinvoicenoprintbill.Text == "")
            {
                MessageBox.Show("Please Enter Invoiceno into The Field", "Blank Record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(txtinvoicenoprintbill.Text == "0")
            {
                MessageBox.Show("Invalid Invoiceno", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    obj.getconnection();
                    cmd = new SqlCommand("select * from tbl_newbill where invoiceno = '"+txtinvoicenoprintbill.Text+"'",obj.con);
                    DataSet ds = new DataSet();
                    sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds, "tbl_newbill");
                    cryrpt1.SetDataSource(ds);
                    crystalReportViewer1.ReportSource = cryrpt1;
                    obj.closeconnection();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
