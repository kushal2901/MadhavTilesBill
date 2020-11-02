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
    public partial class SignUp : Form
    {
        Connectionclass obj = new Connectionclass();
        SqlCommand cmd;
        //DataTable dt;
        public SignUp()
        {
            InitializeComponent();
        }

        private void picclose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picminimize2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picclose2_MouseHover(object sender, EventArgs e)
        {
            picclose2.BackColor = System.Drawing.Color.White;
        }

        private void picminimize2_MouseHover(object sender, EventArgs e)
        {
            picminimize2.BackColor = System.Drawing.Color.White;
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
            if (txtfirstname.Text == "")
            {
                MessageBox.Show("FirstName Field is Empty");
            }
            else if (txtlastname.Text == "")
            {
                MessageBox.Show("LastName Field is Empty");
            }
            else if (txtcontactno.Text == "")
            {
                MessageBox.Show("Contact No Field is Empty");
            }
            else if (txtpassword.Text == "")
            {
                MessageBox.Show("Password Field is Empty");
            }
            else if (txtconfirmpass.Text == "")
            {
                MessageBox.Show("Confirm Password Field is Empty");
            }
            else
            {
                try
                {
                    obj.getconnection();
                    cmd = new SqlCommand("select contactno from tbl_login where contactno = '" + txtcontactno.Text + "'", obj.con);
                    cmd.ExecuteNonQuery();
                    SqlDataReader drduplicate = cmd.ExecuteReader();
                    if (drduplicate.Read())
                    {
                        MessageBox.Show("Enter Contact No. Is Already Exists", "Duplicate Contact", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        obj.getconnection();
                        cmd = new SqlCommand("insert into tbl_login values('" + txtfirstname.Text + "','" + txtlastname.Text + "','" + txtcontactno.Text + "','" + txtpassword.Text + "')", obj.con);
                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Create New User Successfully.", "Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LogIn lg = new LogIn();
                            lg.Show();
                        }
                        else
                        {
                            MessageBox.Show("Sign Up Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }               
                    obj.closeconnection();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            txtfirstname.Select();
        }

        private void txtfirstname_KeyPress(object sender, KeyPressEventArgs e)
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

        private void lastname_KeyPress(object sender, KeyPressEventArgs e)
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
            if(e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 32 || e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtpassword_Enter(object sender, EventArgs e)
        {
            if (txtpassword.Text == "")
            {
                txtpassword.Text = "";
                txtpassword.isPassword = true;
            }
        }

        private void txtpassword_Leave(object sender, EventArgs e)
        {
            /*if (txtpassword.Text == "")
            {
                txtpassword.Text = "";
                txtpassword.isPassword = false;
            }*/
        }

        private void txtconfirmpass_Leave(object sender, EventArgs e)
        {
            if(txtpassword.Text != "" && txtconfirmpass.Text != "")
            {
                string pass = Convert.ToString(txtpassword.Text);
                string confpass = Convert.ToString(txtconfirmpass.Text);
                
                if(pass != confpass)
                {
                    MessageBox.Show("Password Does Not Match");
                    txtconfirmpass.Select();
                }
            }
        }

        private void txtconfirmpass_Enter(object sender, EventArgs e)
        {
            if (txtconfirmpass.Text == "")
            {
                txtconfirmpass.Text = "";
                txtconfirmpass.isPassword = true;
            }
        }

        private void picshowpass_Click(object sender, EventArgs e)
        {
            if(txtconfirmpass.isPassword == false)
            {
                txtconfirmpass.isPassword = true;
            }
            else
            {
                txtconfirmpass.isPassword = false;
            }
        }

        private void picshowpass_Click_1(object sender, EventArgs e)
        {
            if(txtpassword.isPassword == false)
            {
                txtpassword.isPassword = true;
            }
            else
            {
                txtpassword.isPassword = false;
            }
        }

        private void panel364864_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
