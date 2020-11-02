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

namespace MadhavTilesBill
{
    public partial class update : Form
    {
        Connectionclass obj = new Connectionclass();
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;
        SqlDataAdapter sda;

        public update()
        {
            InitializeComponent();
        }

        private void update_Load(object sender, EventArgs e)
        {
            customdate();
            fatchproductcompany();
        }

        public void customdate()
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void piccloseupdatebill_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picmaximizeupdatebill_Click(object sender, EventArgs e)
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

        private void picminimizeupdatebill_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public void fillgrid()
        {
            obj.getconnection();
            //cmd = new SqlCommand("select invoiceno as 'Invoice No',name as 'Name',address as 'Address',state as 'State',contact as 'Contact',pcompany as 'Company',pname as 'Pro Name ',basicprice as 'basicPrice',sgst as 'Sgst',cgst as 'Cgst',discount as 'Discount',total as 'Total',received as 'Received',billdate as 'Billdate' from tbl_newbill order by invoiceno asc", obj.con);
            cmd = new SqlCommand("select invoiceno as 'Invoice No',name as 'Name',address as 'Address',state as 'State',customergstin as 'GSTIN',contact as 'Contact',pcompany as 'Company',pname as 'Pro Name ',basicprice as 'basicPrice',sgst as 'Sgst',cgst as 'Cgst',discount as 'Discount',total as 'Total',received as 'Received',pending as 'Pending',billdate as 'Billdate',transname as 'Transport,vehno as 'VehNo.',placeofsupply as 'Place' from tbl_newbill where invoiceno = "+Convert.ToInt32(txtubinvoiceno.Text)+"", obj.con);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            if (dt.Rows.Count > 0)
            {
                bunifuCustomDataGrid1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("No Record Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            obj.closeconnection();
        }
        public void fatchproductcompany()
        {
            try
            {
                obj.getconnection();
                cmd = new SqlCommand("select pcompany from tbl_product order by pcompany asc", obj.con);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                foreach (DataRow row in dt.Rows)//item in collection
                {
                    cmbubpcompany.Items.Add(row["pcompany"].ToString());
                }
                obj.closeconnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void clearall()
        {
            txtubinvoiceno.Clear();
            txtubname.Clear();
            txtubaddress.Clear();
            txtubcontact.Clear();
            txtubstate.Clear();
            //cmbpcompany.Items.Clear();
            //cmbubpcompany.SelectedIndex = -1;
            cmbubpcompany.Text = "";
            txtubpname.Clear();
            txtubbasicprice.Clear();
            txtubsgst.Clear();
            txtubcgst.Clear();
            txtubdiscount.Clear();
            txtubtotal.Clear();
            txtubreceived.Clear();
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (txtubinvoiceno.Text == "")
            {
                MessageBox.Show("Inoice NO Field is Empty");
            }
            else if (txtubname.Text == "")
            {
                MessageBox.Show("Name Field is Empty");
            }
            else if (txtubaddress.Text == "")
            {
                MessageBox.Show("Address Field is Empty");
            }
            else if (txtubstate.Text == "")
            {
                MessageBox.Show("State Field is Empty");
            }
            else if (txtubcontact.Text == "")
            {
                MessageBox.Show("Contact Field is Empty");
            }

            else if (cmbubpcompany.Text == "")
            {
                MessageBox.Show("Product Name Field is Empty");
            }
            else if (txtubpname.Text == "")
            {
                MessageBox.Show("Product Name Field is Empty");
            }
            else if (txtubbasicprice.Text == "")
            {
                MessageBox.Show("Basic Price Field is Empty");
            }
            else if (txtubsgst.Text == "")
            {
                MessageBox.Show("SGST Field is Empty");
            }
            else if (txtubcgst.Text == "")
            {
                MessageBox.Show("CGST Field is Empty");
            }
            else if (txtubdiscount.Text == "")
            {
                MessageBox.Show("Discount Field is Empty");
            }
            else if (txtubtotal.Text == "")
            {
                MessageBox.Show("Total Field is Empty");
            }
            else if (txtubreceived.Text == "")
            {
                MessageBox.Show("Recevied Field is Empty");
            }
            else if (dateTimePicker1.Text == "")
            {
                MessageBox.Show("Date Field is Empty");
            }
            else
            {
                try
                {
                    obj.getconnection();
                    cmd = new SqlCommand("update tbl_newbill set name = '" + txtubname.Text + "',address = '" + txtubaddress.Text + "',state = '" + txtubstate.Text + "',customergstin = '"+txtubgstin.Text+"',contact = '" + txtubcontact.Text + "',pcompany = '" + cmbubpcompany.Text + "',pname = '" + txtubpname.Text + "',basicprice = " + Convert.ToInt32(txtubbasicprice.Text) + ",sgst = " + Convert.ToInt32(txtubsgst.Text) + ",cgst = " + Convert.ToInt32(txtubcgst.Text) + ",discount = " + Convert.ToInt32(txtubdiscount.Text) + ",total = " + Convert.ToInt32(txtubtotal.Text) + ",received = " + Convert.ToInt32(txtubreceived.Text) + ",pending = "+Convert.ToInt32(txtubpending.Text)+",billdate = '" + dateTimePicker1.Value.Date.ToString() + "',transname = '"+txtubtransname.Text+"',vehno = '"+txtubvehicalno.Text+"',placeofsupply = '"+txtubplaceofsupply.Text+"' where invoiceno = "+Convert.ToInt32(txtubinvoiceno.Text)+"", obj.con);
                    /*cmd.ExecuteNonQuery();
                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    sda.Fill(dt);*/
                    int result = cmd.ExecuteNonQuery();
                    if(result > 0)
                    {
                        MessageBox.Show("Bill Record Update Success...", "Update Bill", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fillgrid();
                        clearall();
                    }
                    else
                    {
                        MessageBox.Show("Bill Record Update Failed", "Update Bill Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    obj.closeconnection();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtubbasicprice_TextChanged(object sender, EventArgs e)
        {
            if (txtubtotal.Text != "" && txtubdiscount.Text != "")
            {
                if (txtubbasicprice.Text == "")
                {
                    txtubsgst.Clear();
                    txtubcgst.Clear();
                    txtubtotal.Clear();
                    txtubdiscount.Clear();
                    txtubreceived.Clear();
                }
                else
                {
                    try
                    {
                        txtubsgst.Text = (float.Parse(txtubbasicprice.Text) * 9 / 100).ToString();
                        txtubcgst.Text = (float.Parse(txtubbasicprice.Text) * 9 / 100).ToString();

                        if (txtubbasicprice.Text != "" && txtubsgst.Text != "" && txtubcgst.Text != "")
                        {
                            float nototal = 0;
                            nototal = float.Parse(txtubbasicprice.Text) + float.Parse(txtubsgst.Text) + float.Parse(txtubcgst.Text);
                            txtubtotal.Text = nototal.ToString();
                        }

                        txtubtotal.Text = (float.Parse(txtubtotal.Text) - float.Parse(txtubdiscount.Text)).ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (txtubbasicprice.Text != "")
            {
                try
                {

                    txtubsgst.Text = (float.Parse(txtubbasicprice.Text) * 9 / 100).ToString();
                    txtubcgst.Text = (float.Parse(txtubbasicprice.Text) * 9 / 100).ToString();

                    if (txtubbasicprice.Text != "" && txtubsgst.Text != "" && txtubcgst.Text != "")
                    {
                        float nototal = 0;
                        nototal = float.Parse(txtubbasicprice.Text) + float.Parse(txtubsgst.Text) + float.Parse(txtubcgst.Text);
                        txtubtotal.Text = nototal.ToString();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (txtubbasicprice.Text == "")
            {
                txtubsgst.Clear();
                txtubcgst.Clear();
                txtubtotal.Clear();
                txtubdiscount.Clear();
                txtubreceived.Clear();
            }
        }

        private void txtubdiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtubbasicprice.Text == "")
                {
                    txtubsgst.Clear();
                    txtubcgst.Clear();
                    txtubtotal.Clear();
                    txtubdiscount.Clear();
                    txtubreceived.Clear();
                }
                else
                {

                    float nototal = 0;
                    nototal = float.Parse(txtubbasicprice.Text) + float.Parse(txtubsgst.Text) + float.Parse(txtubcgst.Text);
                    if (txtubdiscount.Text == "")
                    {
                        txtubtotal.Text = nototal.ToString();
                    }
                    //txttotal.Text = (nototal + float.Parse(txtcgst.Text)).ToString();
                    else
                    {
                        txtubtotal.Text = (nototal - float.Parse(txtubdiscount.Text)).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtubname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 65 && e.KeyChar <= 90 || (e.KeyChar >= 97 && e.KeyChar <= 122) || e.KeyChar == 32 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtubcontact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 32 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        

        private void txtubstate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 65 && e.KeyChar <= 90 || (e.KeyChar >= 97 && e.KeyChar <= 122) || e.KeyChar == 32 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtubbasicprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 32 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtubdiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 32 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtubreceived_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 32 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtubaddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 65 && e.KeyChar <= 90 || (e.KeyChar >= 97 && e.KeyChar <= 122) || (e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 32 || e.KeyChar == 8 || e.KeyChar == 44 || e.KeyChar == 59 || e.KeyChar == 46 || (e.KeyChar == 40 || e.KeyChar == 41) || e.KeyChar == 13 || e.KeyChar == 127 || e.KeyChar == 61)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtubcontact_Leave(object sender, EventArgs e)
        {
            if (txtubcontact.Text != "")
            {
                if (txtubcontact.Text.Length != 10)
                {
                    MessageBox.Show("Contact Number Must Be 10 Digits!!");
                    txtubcontact.Focus();
                }
            }
        }

        

        public void productnameadd()
        {
            if (txtubpname.Text == "")
            {
                txtubpname.Text = txtubproductname1.Text + " - " + txtubqtyinbox.Text;
            }
            else if (txtubpname.Text != "")
            {
                string runtimename = txtubpname.Text;
                txtubpname.Text = runtimename + "," + txtubproductname1.Text + " - " + txtubqtyinbox.Text;
            }
        }

        public void basicpricecalculation()
        {
            if (txtubbasicprice.Text == "")
            {
                txtubbasicprice.Text = txtubtotalperbox.Text;
            }
            else if (txtubbasicprice.Text != "")
            {
                float nototal1 = 0;
                nototal1 = float.Parse(txtubbasicprice.Text) + float.Parse(txtubtotalperbox.Text);
                txtubbasicprice.Text = nototal1.ToString();
            }
        }

        private void btnubadd_Click(object sender, EventArgs e)
        {
            try
            {
                productnameadd();
                basicpricecalculation();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtubrateperbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtubqtyinbox.Text != "")
                {
                    if (txtubrateperbox.Text == "")
                    {
                        txtubrateperbox.Text = "";
                        txtubtotalperbox.Text = "";
                    }
                    else if (txtubrateperbox.Text != "" && txtubqtyinbox.Text != "")
                    {
                        txtubtotalperbox.Text = (float.Parse(txtubrateperbox.Text) * float.Parse(txtubqtyinbox.Text)).ToString();
                    }
                }
                else if (txtubqtyinbox.Text == "")
                {
                    MessageBox.Show("Please Enter Qty In Box Value");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtubqtyinbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtubqtyinbox.Text != "")
                {
                    if (txtubrateperbox.Text == "")
                    {
                        txtubrateperbox.Text = "";
                        txtubtotalperbox.Text = "";
                    }
                    else if (txtubrateperbox.Text != "" && txtubqtyinbox.Text != "")
                    {
                        txtubtotalperbox.Text = (float.Parse(txtubrateperbox.Text) * float.Parse(txtubqtyinbox.Text)).ToString();
                    }
                }
                else if (txtubqtyinbox.Text == "")
                {
                    MessageBox.Show("Please Enter Qty In Box Value");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtubqtyinbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 32 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtubrateperbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 32 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtubreceived_TextChanged(object sender, EventArgs e)
        {
            if (txtubtotal.Text != "" && txtubreceived.Text != "")
            {
                int totalvalue = Convert.ToInt32(txtubtotal.Text);
                int receivedvalue = Convert.ToInt32(txtubreceived.Text);
                //int i = totalvalue - receivedvalue;
                if (totalvalue < receivedvalue)
                {
                    MessageBox.Show("Received Value Grater Then Total Amount", "GraterThen Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtubreceived.Text = "";
                    txtubpending.Text = "";
                    txtubreceived.Focus();
                }
                else if (txtubtotal.Text != "" && txtubreceived.Text != "")
                {
                    float total = float.Parse(txtubtotal.Text) - float.Parse(txtubreceived.Text);
                    txtubpending.Text = total.ToString();
                }
            }
            else if (txtubreceived.Text == "")
            {
                txtubreceived.Text = "";
                txtubpending.Text = "";
            }
        }
    }
}
