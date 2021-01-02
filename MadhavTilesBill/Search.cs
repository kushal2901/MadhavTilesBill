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
using OfficeOpenXml;
using System.IO;

namespace MadhavTilesBill
{
    public partial class Search : Form
    {
        SqlCommand cmd;
        Connectionclass obj = new Connectionclass();
        SqlDataAdapter sda;
        DataTable dt;
       
        public Search()
        {
            InitializeComponent();
        }

        private void picclosesearch_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picmaximizesearch_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void picminimizesearch_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public void dateformatechanged()
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
        }

        private void Search_Load(object sender, EventArgs e)
        {
            dateformatechanged();
            //btndelete.Enabled = false;
            
        }
        public void totalbillandsales()
        {
            //no of bills
            txttotalbills.Text = bunifuCustomDataGrid1.Rows.Count.ToString();

            //total sales amount
            double sum = 0;
            for(int i = 0;i<bunifuCustomDataGrid1.Rows.Count;i++)
            {
                sum += Convert.ToDouble(bunifuCustomDataGrid1.Rows[i].Cells[12].Value.ToString());
            }
            txttotalsales.Text = sum.ToString();
        }

        private void btnsearchno_Click(object sender, EventArgs e)
        {
            if (txtinvoicenosearch.Text == "")
            {
                MessageBox.Show("Please Enter Invoice No ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    obj.getconnection();
                    cmd = new SqlCommand("select invoiceno as 'Invoice No',name as 'Name',address as 'Address',state as 'State',customergstin as 'GSTIN',contact as 'Contact',pcompany as 'Company',pname as 'Pro Name ',basicprice as 'basicPrice',sgst as 'Sgst',cgst as 'Cgst',discount as 'Discount',total as 'Total',received as 'Received',pending as 'Pending',billdate as 'Billdate',transname as 'Transport',vehno as 'Veh No',placeofsupply as 'Place' from tbl_newbill where invoiceno = " + Convert.ToInt32(txtinvoicenosearch.Text) + "", obj.con);
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    if(dt.Rows.Count > 0)
                    {
                        bunifuCustomDataGrid1.DataSource = dt;
                        //btndelete.Enabled = true;
                        totalbillandsales();
                    }
                    else
                    {
                        MessageBox.Show("Record Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    obj.closeconnection();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnsearchdate_Click(object sender, EventArgs e)
        {
            if(dateTimePicker1.Text == "" && dateTimePicker2.Text == "")
            {
                MessageBox.Show("Please Select The Date", "Select date", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    obj.getconnection();
                    cmd = new SqlCommand("select invoiceno as 'Invoice No',name as 'Name',address as 'Address',state as 'State',customergstin as 'GSTIN',contact as 'Contact',pcompany as 'Company',pname as 'Pro Name ',basicprice as 'basicPrice',sgst as 'Sgst',cgst as 'Cgst',discount as 'Discount',total as 'Total',received as 'Received',pending as 'Pending',billdate as 'Billdate',transname as 'Transport',vehno as 'Veh No',placeofsupply as 'Place' from tbl_newbill where billdate between '" + dateTimePicker1.Value.Date.ToString("dd/MM/yyyy")+"' and '"+dateTimePicker2.Value.Date.ToString("dd/MM/yyyy")+"' ", obj.con);
                    cmd.ExecuteNonQuery();
                    dt = new DataTable();
                    sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        bunifuCustomDataGrid1.DataSource = dt;
                        //btndelete.Enabled = true;
                        totalbillandsales();
                    }
                    else
                    {
                        MessageBox.Show("Record Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    obj.closeconnection();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnviewall_Click(object sender, EventArgs e)
        {
            obj.getconnection();
            cmd = new SqlCommand("select invoiceno as 'Invoice No',name as 'Name',address as 'Address',state as 'State',customergstin as 'GSTIN',contact as 'Contact',pcompany as 'Company',pname as 'Pro Name ',basicprice as 'basicPrice',sgst as 'Sgst',cgst as 'Cgst',discount as 'Discount',total as 'Total',received as 'Received',pending as 'Pending',billdate as 'Billdate',transname as 'Transport',vehno as 'Veh No',placeofsupply as 'Place' from tbl_newbill order by invoiceno asc", obj.con);
            /*//cmd = new SqlCommand("select invoiceno as 'Invoice No',name as 'Name',address as 'Address',state as 'State',contact as 'Contact',pcompany as 'Company',pname as 'Pro Name ',basicprice as 'basicPrice',sgst as 'Sgst',cgst as 'Cgst',discount as 'Discount',total as 'Total',received as 'Received',billdate as 'Billdate' from tbl_newbill order by invoiceno asc", obj.con);
            //select invoiceno as 'Invoice No',name as 'Name',address as 'Address',state as 'State',customergstin as 'GSTIN',contact as 'Contact',pcompany as 'Company',pname as 'Pro Name ',basicprice as 'basicPrice',sgst as 'Sgst',cgst as 'Cgst',discount as 'Discount',total as 'Total',received as 'Received',pending as 'Pending',billdate as 'Billdate',transname as 'Transport,vehno as 'VehNo.',placeofsupply as 'Place'*/
            cmd.ExecuteNonQuery();
            dt = new DataTable();
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                bunifuCustomDataGrid1.DataSource = dt;
                //btndelete.Enabled = true;
                totalbillandsales();
            }
            else
            {
                MessageBox.Show("No Record Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            obj.closeconnection();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateformatechanged();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateformatechanged();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                obj.getconnection();
                if (bunifuCustomDataGrid1.SelectedRows.Count > 0)
                {
                    DialogResult dialogbox = MessageBox.Show("You Went To Delete Selected Bill Record", "Deleting Bill", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogbox == DialogResult.Yes)
                    {
                        string selected_invoiceno = bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString();

                        cmd = new SqlCommand("delete from tbl_newbill where invoiceno = " + Convert.ToInt32(selected_invoiceno) + "", obj.con);
                        int count = cmd.ExecuteNonQuery();

                        if (count > 0)
                        {
                            MessageBox.Show("Bill Record Delete Successfully", "Deleted Bill", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            bunifuCustomDataGrid1.Rows.RemoveAt(bunifuCustomDataGrid1.SelectedRows[0].Index);
                            totalbillandsales();
                        }
                        else
                        {
                            MessageBox.Show("Record does not Delete", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (dialogbox == DialogResult.No)
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Please Select a Row", "Select Row", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                obj.closeconnection();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                update ub = new update();

                if (bunifuCustomDataGrid1.SelectedRows.Count > 0)
                {
                    obj.getconnection();
                    ub.txtubinvoiceno.Text = bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString();
                    ub.txtubname.Text = bunifuCustomDataGrid1.CurrentRow.Cells[1].Value.ToString();
                    ub.txtubaddress.Text = bunifuCustomDataGrid1.CurrentRow.Cells[2].Value.ToString();
                    ub.txtubstate.Text = bunifuCustomDataGrid1.CurrentRow.Cells[3].Value.ToString();
                    ub.txtubgstin.Text = bunifuCustomDataGrid1.CurrentRow.Cells[4].Value.ToString();
                    ub.txtubcontact.Text = bunifuCustomDataGrid1.CurrentRow.Cells[5].Value.ToString();
                    ub.cmbubpcompany.Text = bunifuCustomDataGrid1.CurrentRow.Cells[6].Value.ToString();
                    ub.txtubpname.Text = bunifuCustomDataGrid1.CurrentRow.Cells[7].Value.ToString();
                    ub.txtubbasicprice.Text = bunifuCustomDataGrid1.CurrentRow.Cells[8].Value.ToString();
                    ub.txtubsgst.Text = bunifuCustomDataGrid1.CurrentRow.Cells[9].Value.ToString();
                    ub.txtubcgst.Text = bunifuCustomDataGrid1.CurrentRow.Cells[10].Value.ToString();
                    ub.txtubdiscount.Text = bunifuCustomDataGrid1.CurrentRow.Cells[11].Value.ToString();
                    ub.txtubtotal.Text = bunifuCustomDataGrid1.CurrentRow.Cells[12].Value.ToString();
                    ub.txtubreceived.Text = bunifuCustomDataGrid1.CurrentRow.Cells[13].Value.ToString();
                    ub.txtubpending.Text = bunifuCustomDataGrid1.CurrentRow.Cells[14].Value.ToString();
                    ub.dateTimePicker1.Text = bunifuCustomDataGrid1.CurrentRow.Cells[15].Value.ToString();
                    ub.txtubtransname.Text = bunifuCustomDataGrid1.CurrentRow.Cells[16].Value.ToString();
                    ub.txtubvehicalno.Text = bunifuCustomDataGrid1.CurrentRow.Cells[17].Value.ToString();
                    ub.txtubplaceofsupply.Text = bunifuCustomDataGrid1.CurrentRow.Cells[18].Value.ToString();
                    obj.closeconnection();
                    ub.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Please Select a Row", "Select Row", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btndownloadedata_Click(object sender, EventArgs e)
        {
            //OtpForDataDownload otpsend = new OtpForDataDownload();
            //otpsend.Show();
            try
            {
                downloaddatatoexcel();
                //obj.getconnection();
                /*cmd = new SqlCommand("select name,address,state,contact,pcompany,pname,basicprice,sgst,cgst,discount,total,received,billdate from tbl_newbill", obj.con);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                DataSet ds = new DataSet("new_dataset");
                ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
                sda.Fill(dt);
                ds.Tables.Add(dt);
                //DataSet1 ds = new DataSet1();
                //sda.Fill(ds, "tbl_newbill");
                ExcelLibrary.DataSetHelper.CreateWorkbook("MadhavTilesData.xls", ds);
                MessageBox.Show("Download All Data From Database", "Download success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                */
                //obj.closeconnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void downloaddatatoexcel()
        {
            try
            {
                obj.getconnection();
                cmd = new SqlCommand("select * from tbl_newbill", obj.con);
                dt = new DataTable();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Title = "Save Excel Sheet";
                    saveFileDialog1.Filter = "Excel Files|*.xlsx|All files|*.*";
                    saveFileDialog1.FileName = "ExcelSheet_" + DateTime.Now.ToString("dd-MM-yyyy") + ".xlsx";

                    ExcelPackage exlpkg = new ExcelPackage();

                    var Worksheet = exlpkg.Workbook.Worksheets.Add("Worksheet");

                    

                    for(int i = 0;i < dt.Columns.Count;i++)
                    {
                        Worksheet.Cells[1, i + 1].Value = dt.Columns[i].ColumnName.ToString();
                        
                    }
                    
                    for (int i = 0;i < dt.Rows.Count;i++)
                    {
                        for(int j = 0;j<dt.Columns.Count;j++)
                        {
                            Worksheet.Cells[i + 2, j + 1].Value = dt.Rows[i][j].ToString();
                        }    
                    }
                    byte[] bin = exlpkg.GetAsByteArray();

                    if(saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllBytes(saveFileDialog1.FileName, bin);
                        MessageBox.Show("Save Data Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if(saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    {

                    }
                }
                obj.closeconnection();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            try
            {
                
                obj.getconnection();
                cmd = new SqlCommand("select * from tbl_newbill where pending != '"+0+"'", obj.con);
                cmd.ExecuteNonQuery();
                dt = new DataTable();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    bunifuCustomDataGrid1.DataSource = dt;
                    //btndelete.Enabled = true;
                    totalbillandsales();
                }
                else
                {
                    MessageBox.Show("Record Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                obj.closeconnection();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
