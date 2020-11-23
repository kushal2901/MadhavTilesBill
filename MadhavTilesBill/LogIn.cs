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
    public partial class LogIn : Form
    {
        Connectionclass obj = new Connectionclass();
        SqlCommand cmd;
        SqlDataReader dr;
        public LogIn()
        {
            InitializeComponent();
        }

        private void picclose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();   
        }

        private void picminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            txtusername.Select();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtusername.Text == "")
            {
                MessageBox.Show("Username Field Is Empty");
            }
            else if (txtpassword.Text == "")
            {
                MessageBox.Show("Password Field Is Empty");
            }
            else
            {
                try
                {
                    obj.getconnection();
                    cmd = new SqlCommand("select * from tbl_login where contactno = '"+txtusername.Text+"' and password = '"+txtpassword.Text+"'",obj.con);
                    //cmd.ExecuteNonQuery();
                    dr = cmd.ExecuteReader();
                    if(dr.Read())
                    {
                        MessageBox.Show("Login Success", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        /*//getusernameforloginorlogout.strusername = Convert.ToString(txtusername.Text);
                        dr.Close();
                        cmd = new SqlCommand("select contactno from tbl_login where contactno = '"+getusernameforloginorlogout.strusername+"'",obj.con);
                        
                        dr = cmd.ExecuteReader();
                        if(dr.Read())
                        {
                            MessageBox.Show(getusernameforloginorlogout.strusername);
                            MainMenu mm = new MainMenu();
                            mm.Show();
                        }
                        else
                        {
                            LogIn lg = new LogIn();
                            lg.Show();
                        }*/
                        
                        this.Close();
                        
                       
                        /*MainMenu mm = new MainMenu();
                        mm.ShowDialog();*/
                        
                    }
                    else
                    {
                        MessageBox.Show("Invalid UserName & Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    obj.closeconnection();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
          
        }

        private void btnsignup_Click(object sender, EventArgs e)
        {
            //this.Hide();   
            SignUp sup = new SignUp();
            sup.ShowDialog();
            //this.Close();
        }

        private void picclose_MouseHover(object sender, EventArgs e)
        {
            picclose.BackColor = System.Drawing.Color.White;
        }

        private void picminimize_MouseHover(object sender, EventArgs e)
        {
            picminimize.BackColor = System.Drawing.Color.White;
        }

        private void txtpassword_Enter(object sender, EventArgs e)
        {
            if (txtpassword.Text == "")
            {
                txtpassword.Text = "";
                txtpassword.isPassword = true;
            }
        }

        private void picshowpasslg_Click(object sender, EventArgs e)
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

        private void txtusername_KeyPress(object sender, KeyPressEventArgs e)
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

        private void panel364864_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
