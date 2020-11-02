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
    public partial class Products : Form
    {
        Connectionclass obj = new Connectionclass();
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter sda;
        DataTable dt;
        
        public Products()
        {
            InitializeComponent();
        }

        public void autoproductid()
        {
            int a;

            obj.getconnection();
            cmd = new SqlCommand("select Max(pid) from tbl_product", obj.con);
            dr = cmd.ExecuteReader();

            if(dr.Read())
            {
                string val = dr[0].ToString();

                if (val == "")
                {
                    txtPid.Text = "1";
                }
                else
                {
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;
                    txtPid.Text = a.ToString();
                }
            }

            obj.closeconnection();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (txtPcompany.Text == "")
            {
                MessageBox.Show("please enter product comany", "Empty company", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    obj.getconnection();
                    cmd = new SqlCommand("insert into tbl_product values(" + Convert.ToInt32(txtPid.Text) + ",'" + txtPcompany.Text + "') ", obj.con);
                    int result = cmd.ExecuteNonQuery();

                    if(result > 0)
                    {
                        MessageBox.Show("product insert success....", "product info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearall();
                        autoproductid();
                    }
                    else
                    {
                        MessageBox.Show("product insert failed", "product failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    obj.closeconnection();

                    
                    
                    fillgrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Products_Load(object sender, EventArgs e)
        {
            //txtPid.Enabled = false;
            txtPcompany.Select();
            autoproductid();
            fillgrid();
        }

        public void fillgrid()
        {
                obj.getconnection();
                cmd = new SqlCommand("select pid as 'ID',pcompany as 'Company' from tbl_product order by pid asc", obj.con);
                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                bunifuCustomDataGrid1.DataSource = dt;
                obj.closeconnection(); 
        }

        private void piccloseproduct_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picmaximizeproduct_Click(object sender, EventArgs e)
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

        private void picminimizeproduct_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if(txtPcompany.Text == "")
            {
                MessageBox.Show("Product Comany Field Is Empty","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("You Want To Update Selected Company", "Updateing Company", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if(dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        obj.getconnection();
                        cmd = new SqlCommand("update tbl_product set pcompany = '" + txtPcompany.Text + "' where pid = " + Convert.ToInt32(txtPid.Text) + "", obj.con);
                        cmd.ExecuteNonQuery();
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        sda.Fill(dt);
                        MessageBox.Show("Record Update Success...", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearall();
                        autoproductid();
                        obj.closeconnection();
                        fillgrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else if(dialogResult == DialogResult.No)
                {

                }
                
            }
            
        }
        public void clearall()
        {
            txtPid.Text = "";
            txtPcompany.Text = "";
        }

        private void bunifuCustomDataGrid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("You Want To Update Selected Company", "Updateing Company", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    obj.getconnection();
                    int i;
                    i = e.RowIndex;
                    DataGridViewRow row = bunifuCustomDataGrid1.Rows[i];
                    txtPid.Text = row.Cells[0].Value.ToString();
                    txtPcompany.Text = row.Cells[1].Value.ToString();
                    obj.closeconnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if(dialogResult == DialogResult.No)
            {

            }
            
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if(txtPid.Text == "")
            {
                MessageBox.Show("select Id For Delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("You Want To Delete Selected Bill", "Deleting Bill", MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                    if(dialogResult == DialogResult.Yes)
                    {
                        obj.getconnection();
                        if (bunifuCustomDataGrid1.SelectedRows.Count > 0)
                        {
                            string selected_pid = bunifuCustomDataGrid1.CurrentRow.Cells[0].Value.ToString();

                            cmd = new SqlCommand("delete from tbl_product where pid = '" + Convert.ToInt32(selected_pid) + "'", obj.con);
                            int result = cmd.ExecuteNonQuery();
                            if (result > 0)
                            {
                                MessageBox.Show("Record Delete Successfully", "Deleted Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bunifuCustomDataGrid1.Rows.RemoveAt(bunifuCustomDataGrid1.SelectedRows[0].Index);
                                autoproductid();
                            }
                            else
                            {
                                MessageBox.Show("Record does not Delete", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Select a Row", "Select Row", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        obj.closeconnection();
                    }
                    else if(dialogResult == DialogResult.No)
                    {

                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            

        }

        private void txtPcompany_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar >= 65 && e.KeyChar <= 90 || (e.KeyChar >= 97 && e.KeyChar <= 122) || e.KeyChar == 32 || e.KeyChar == 8)
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
