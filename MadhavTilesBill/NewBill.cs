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
    public partial class NewBill : Form
    {
        SqlCommand cmd;
        Connectionclass obj =new Connectionclass();
        SqlDataAdapter sda;
        DataTable dt;
        SqlDataReader dr;

        public NewBill()
        {
            InitializeComponent();
        }

        private void piccloseproduct_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picmaximizeproduct_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                //this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.picclosenewbill.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top));
                this.picclosenewbill.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

                this.picmaximizenewbill.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top));
                this.picmaximizenewbill.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

                this.picminimizenewbill.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top));
                this.picminimizenewbill.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

                this.WindowState = FormWindowState.Normal;
            }
           
        }

        private void picminimizeproduct_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void NewBill_Load(object sender, EventArgs e)
        {
            autobillno();

            dateTimePicker1.CustomFormat = "dd/MM/yyyy";

            fatchproductcompany();

            //fillgrid();
        }
        public void autobillno()
        {
            obj.getconnection();
            cmd = new SqlCommand("select invoiceno from tbl_newbill", obj.con);
            sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);

            if(ds.Tables[0].Rows.Count < 1)
            {
                txtinvoiceno.Text = "INV00000001";
            }
            else
            {
                cmd = new SqlCommand("select invoiceno from tbl_newbill", obj.con);
                sda = new SqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                sda.Fill(ds1);
                int maxno = 0;
                var part1 = "0";
                var part2 = "0";

                foreach (DataRow dr in ds1.Tables[0].Rows)
                {
                    var ino = dr["invoiceno"].ToString();
                    part1 = ino.Substring(0, 3);
                    part2 = ino.Substring(3, (ino.Length) - 3);

                    if (maxno < Convert.ToInt32(part2))
                    {
                        maxno = Convert.ToInt32(part2);
                    }
                }
                maxno = maxno + 1;

                var newserial = part1 + maxno.ToString("00000000");
                txtinvoiceno.Text = newserial.ToString();
            }

            
            obj.closeconnection();
            /*int a;

            obj.getconnection();
            cmd = new SqlCommand("select Max(invoiceno) from tbl_newbill", obj.con);
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();

            if(dr.Read())
            {
                string val = dr[0].ToString();
                if(val == "")
                {
                    txtinvoiceno.Text = "1";
                }
                else
                {
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;
                    txtinvoiceno.Text = a.ToString();
                }
            }
            obj.closeconnection();*/
        }
        /*public void fillgrid()
        {
            obj.getconnection();
            cmd = new SqlCommand("select invoiceno as 'Invoice No',name as 'Name',address as 'Address',state as 'State',contact as 'Contact',pcompany as 'Company',pname as 'Pro Name ',basicprice as 'basicPrice',sgst as 'Sgst',cgst as 'Cgst',discount as 'Discount',total as 'Total',received as 'Received',billdate as 'Billdate' from tbl_newbill order by invoiceno asc", obj.con);
            dr = cmd.ExecuteReader();
            dt = new DataTable();
            dt.Load(dr);
            if(dt.Rows.Count > 0)
            {
                bunifuCustomDataGrid1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("No Record Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            obj.closeconnection();
        }*/

        public void fatchproductcompany()
        {
            try
            {
                obj.getconnection();
                cmd = new SqlCommand("select pcompany from tbl_product order by pcompany asc",obj.con);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                foreach(DataRow row in dt.Rows)//item in collection
                {
                    cmbpcompany.Items.Add(row["pcompany"].ToString());
                }
                obj.closeconnection();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void clearall()
        {
            txtinvoiceno.Clear();
            txtname.Clear();
            txtaddress.Clear();
            txtcontact.Clear();
            txtstate.Clear();
            //cmbpcompany.Items.Clear();
            cmbpcompany.SelectedIndex = -1;
            txtpname.Clear();
            txtbasicprice.Clear();
            txtsgst.Clear();
            txtcgst.Clear();
            txtdiscount.Clear();
            txttotal.Clear();
            txtreceived.Clear();
            txttransname.Clear();
            txtvehicalno.Clear();
            txtplaceofsupply.Clear();
            txtgstin.Clear();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if(txtinvoiceno.Text == "")
            {
                MessageBox.Show("Inoice NO Field is Empty");
            }
            else if (txtname.Text == "")
            {
                MessageBox.Show("Name Field is Empty");
            }
            else if (txtaddress.Text == "")
            {
                MessageBox.Show("Address Field is Empty");
            }
            else if (txtstate.Text == "")
            {
                MessageBox.Show("State Field is Empty");
            }
            else if (txtcontact.Text == "")
            {
                MessageBox.Show("Contact Field is Empty");
            }
           
            /*else if (cmbpcompany.Text == "")
            {
                MessageBox.Show("Product Name Field is Empty");
            }*/
            else if (txtpname.Text == "")
            {
                MessageBox.Show("Product Name Field is Empty");
            }
            else if (txtbasicprice.Text == "")
            {
                MessageBox.Show("Basic Price Field is Empty");
            }
            else if (txtsgst.Text == "")
            {
                MessageBox.Show("SGST Field is Empty");
            }
            else if (txtcgst.Text == "")
            {
                MessageBox.Show("CGST Field is Empty");
            }
            else if (txtdiscount.Text == "")
            {
                MessageBox.Show("Discount Field is Empty");
            }
            else if (txttotal.Text == "")
            {
                MessageBox.Show("Total Field is Empty");
            }
            else if (txtreceived.Text == "")
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
                    //duplicate contact query
                    /*cmd = new SqlCommand("select contact from tbl_newbill where contact = '" + txtcontact.Text + "'", obj.con);
                    SqlDataReader drduplicate = cmd.ExecuteReader();
                    if(drduplicate.Read())
                    {
                        MessageBox.Show("Enter Contact Is Already Exists", "Duplicate Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        //insert record query
                        obj.getconnection();*/

                        cmd = new SqlCommand("insert into tbl_newbill values('" + txtinvoiceno.Text + "','" + txtname.Text + "','" + txtaddress.Text + "','" + txtstate.Text + "','" + txtgstin.Text + "','" + txtcontact.Text + "','" + cmbpcompany.Text + "','" + txtpname.Text + "'," + Convert.ToInt32(txtbasicprice.Text) + "," + Convert.ToDouble(txtsgst.Text) + "," + Convert.ToDouble(txtcgst.Text) + "," + Convert.ToInt32(txtdiscount.Text) + "," + Convert.ToInt32(txttotal.Text) + "," + Convert.ToInt32(txtreceived.Text) + "," + Convert.ToInt32(txtpending.Text) + ",'" + dateTimePicker1.Value.Date.ToString("dd/MM/yyyy") + "','" + txttransname.Text + "','" + txtvehicalno.Text + "','" + txtplaceofsupply.Text + "')", obj.con);
                        int result =  cmd.ExecuteNonQuery();
                        if(result > 0)
                        {
                            MessageBox.Show("Bill Record Insert successfully", "Bill Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                            //fillgrid();

                            getinvoicenoforcryrpt.strinvoiceno = txtinvoiceno.Text;

                            clearall();

                            PrintBill pb = new PrintBill();
                            pb.ShowDialog();
                            //txtname.Focus();
                            //autobillno();
                            //fatchproductcompany();
                        }
                        else
                        {
                            MessageBox.Show("Bill Saved Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    
                    obj.closeconnection();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtbasicprice_TextChanged(object sender, EventArgs e)
        {
            if (txttotal.Text != "" && txtdiscount.Text != "")
            {
                if (txtbasicprice.Text == "")
                {
                    txtsgst.Clear();
                    txtcgst.Clear();
                    txttotal.Clear();
                    txtdiscount.Clear();
                    txtreceived.Clear();
                }
                else
                {
                    try
                    {
                        txtsgst.Text = (float.Parse(txtbasicprice.Text) * 9 / 100).ToString();
                        txtcgst.Text = (float.Parse(txtbasicprice.Text) * 9 / 100).ToString();

                        if (txtbasicprice.Text != "" && txtsgst.Text != "" && txtcgst.Text != "")
                        {
                            float nototal = 0;
                            nototal = float.Parse(txtbasicprice.Text) + float.Parse(txtsgst.Text) + float.Parse(txtcgst.Text);
                            txttotal.Text = nototal.ToString();
                        }

                        txttotal.Text = (float.Parse(txttotal.Text) - float.Parse(txtdiscount.Text)).ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (txtbasicprice.Text != "")
            {
                try
                {

                    txtsgst.Text = (float.Parse(txtbasicprice.Text) * 9 / 100).ToString();
                    txtcgst.Text = (float.Parse(txtbasicprice.Text) * 9 / 100).ToString();

                    if (txtbasicprice.Text != "" && txtsgst.Text != "" && txtcgst.Text != "")
                    {
                        float nototal = 0;
                        nototal = float.Parse(txtbasicprice.Text) + float.Parse(txtsgst.Text) + float.Parse(txtcgst.Text);
                        txttotal.Text = nototal.ToString();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (txtbasicprice.Text == "")
            {
                txtsgst.Clear();
                txtcgst.Clear();
                txttotal.Clear();
                txtdiscount.Clear();
                txtreceived.Clear();
            }
        }

        private void txtdiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtbasicprice.Text == "")
                {
                    txtsgst.Clear();
                    txtcgst.Clear();
                    txttotal.Clear();
                    txtdiscount.Clear();
                    txtreceived.Clear();
                }
                else
                {

                    float nototal = 0;
                    nototal = float.Parse(txtbasicprice.Text) + float.Parse(txtsgst.Text) + float.Parse(txtcgst.Text);
                    if (txtdiscount.Text == "")
                    {
                        txttotal.Text = nototal.ToString();
                    }
                    //txttotal.Text = (nototal + float.Parse(txtcgst.Text)).ToString();
                    else
                    {
                        txttotal.Text = (nototal - float.Parse(txtdiscount.Text)).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtcontact_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtaddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar >= 65 && e.KeyChar <= 90 || (e.KeyChar >= 97 && e.KeyChar <= 122) || (e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 32 || e.KeyChar == 8 || e.KeyChar == 44 || e.KeyChar == 59 || e.KeyChar == 46 || (e.KeyChar == 40 || e.KeyChar == 41) || e.KeyChar == 13 || e.KeyChar == 127 || e.KeyChar == 61)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtcontact_Leave(object sender, EventArgs e)
        {
            if (txtcontact.Text != "")
            {         
                if (txtcontact.Text.Length != 10)
                {
                    MessageBox.Show("Contact Number Must Be 10 Digits!!");
                    txtcontact.Focus();
                }
            }
        }

        private void txtstate_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtbasicprice_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtdiscount_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txttotal_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtreceived_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtreceived_TextChanged(object sender, EventArgs e)
        {
            if (txttotal.Text != "" && txtreceived.Text != "")
            {
                int totalvalue = Convert.ToInt32(txttotal.Text);
                int receivedvalue = Convert.ToInt32(txtreceived.Text);
                //int i = totalvalue - receivedvalue;
                if (totalvalue < receivedvalue)
                {
                    MessageBox.Show("Received Value Grater Then Total Amount", "GraterThen Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtreceived.Text = "";
                    txtpending.Text = "";
                    txtreceived.Focus();
                }
                else if (txttotal.Text != "" && txtreceived.Text != "")
                {
                    float total = float.Parse(txttotal.Text) - float.Parse(txtreceived.Text);
                    txtpending.Text = total.ToString();
                }
            }
            else if (txtreceived.Text == "")
            {
                txtreceived.Text = "";
                txtpending.Text = "";
            }


            
        }

        

        public void productnameadd()
        {
            if(txtpname.Text == "")
            {
                txtpname.Text = txtproductname1.Text + " - " + txtqtyinbox.Text;
            }
            else if(txtpname.Text != "")
            {
                string runtimename = txtpname.Text;
                txtpname.Text = runtimename + "," + txtproductname1.Text + " - " + txtqtyinbox.Text;
            }
        }

        public void basicpricecalculation()
        {
            if(txtbasicprice.Text == "")
            {
                txtbasicprice.Text = txttotalperbox.Text;
            }
            else if(txtbasicprice.Text != "")
            {
                float nototal1 = 0;
                nototal1 = float.Parse(txtbasicprice.Text) + float.Parse(txttotalperbox.Text);
                txtbasicprice.Text = nototal1.ToString();
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtproductname1.Text == "")
                {
                    MessageBox.Show("Please enter product name");
                }
                else if(txtqtyinbox.Text == "")
                {
                    MessageBox.Show("please enter Qty in box");
                }
                else if(txtrateperbox.Text == "")
                {
                    MessageBox.Show("Please enter rate per box");
                }
                else if(txttotalperbox.Text == "")
                {
                    MessageBox.Show("please enter total per box");
                }
                else
                {
                    productnameadd();
                    basicpricecalculation();
                    txtproductname1.Text = "";
                    txtqtyinbox.Text = "";
                    txtrateperbox.Text = "";
                    txttotalperbox.Text = "";
                }
                
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtrateperbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(txtqtyinbox.Text != "")
                {
                    if (txtrateperbox.Text == "")
                    {
                        txtrateperbox.Text = "";
                        txttotalperbox.Text = "";
                    }
                    else if (txtrateperbox.Text != "" && txtqtyinbox.Text != "")
                    {
                        txttotalperbox.Text = (float.Parse(txtrateperbox.Text) * float.Parse(txtqtyinbox.Text)).ToString();
                    }
                    
                }
                else if(txtqtyinbox.Text == "")
                {
                    //MessageBox.Show("Please Enter Qty In Box Value");
                    txtrateperbox.Text = "";
                    txttotalperbox.Text = "";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtqtyinbox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtqtyinbox.Text != "")
                {
                    if (txtrateperbox.Text == "")
                    {
                        txtrateperbox.Text = "";
                        txttotalperbox.Text = "";
                    }
                    else if (txtrateperbox.Text != "" && txtqtyinbox.Text != "")
                    {
                        txttotalperbox.Text = (float.Parse(txtrateperbox.Text) * float.Parse(txtqtyinbox.Text)).ToString();
                    }
                    
                }
                else if (txtqtyinbox.Text == "")
                {
                    txtrateperbox.Text = "";
                    txttotalperbox.Text = "";
                    //MessageBox.Show("Please Enter Qty In Box Value");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        

        }

        private void txtqtyinbox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtrateperbox_KeyPress(object sender, KeyPressEventArgs e)
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

        
    }
}
