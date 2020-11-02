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
using System.Net;
using System.Collections.Specialized;
using System.IO;
using ExcelLibrary.CompoundDocumentFormat;
using ExcelLibrary.SpreadSheet;
using ExcelLibrary.BinaryDrawingFormat;
using ExcelLibrary.BinaryFileFormat;

namespace MadhavTilesBill
{
    public partial class OtpForDataDownload : Form
    {
        SqlCommand cmd;
        SqlDataReader dr;
        Connectionclass obj = new Connectionclass();
        SqlDataAdapter sda;
        DataTable dt;
        string randomnumber;
        public OtpForDataDownload()
        {
            InitializeComponent();
        }

        
            
        
        public string sendSMS()
        {
            String result;
            string apiKey = "buzKxKR2BeE-dMIPiVzolCskOK4pPxe5ARrHu3yCnW";
            string numbers = txtcontactno.Text; // in a comma seperated list
            string sender = "TXTLCL";
            string name = txtname.Text;
            Random rnd = new Random();
            randomnumber = (rnd.Next(100000, 999999)).ToString();
            //string message = "MadhavTiles Data Download is your one time password is : " + randomnumber;
            string message = "Hi " + name + " Your One Time Password is : "+randomnumber+" For MadhavTiles Download Data";

            String url = "https://api.textlocal.in/send/?apikey=" + apiKey + "&numbers=" + numbers + "&message=" + message + "&sender=" + sender;
            //refer to parameters to complete correct url string

            StreamWriter myWriter = null;
            HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

            objRequest.Method = "POST";
            objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
            objRequest.ContentType = "application/x-www-form-urlencoded";
            try
            {
                myWriter = new StreamWriter(objRequest.GetRequestStream());
                myWriter.Write(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                myWriter.Close();
            }

            HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                // Close and clean up the StreamReader
                sr.Close();
            }
            return result;
        }

        private void btnverifyotp_Click(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                MessageBox.Show("Name Field Is Empty");
            }
            else if (txtcontactno.Text == "")
            {
                MessageBox.Show("Contact No Field Is Empty");
            }
            else
            {
                try
                {
                    obj.getconnection();
                    cmd = new SqlCommand("select contactno from tbl_login where contactno = '"+txtcontactno.Text+"'",obj.con);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        sendSMS();
                        MessageBox.Show("OTP Send Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Enter ContactNo Is Not Valid","Not Valid",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    dr.Close();
                    obj.closeconnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btndownload_Click(object sender, EventArgs e)
        {
            if(txtverifyotp.Text == "")
            {
                MessageBox.Show("Verify OTP Field Is Empty");
            }
            else
            {
                if(txtverifyotp.Text == randomnumber)
                {
                    try
                    {
                        obj.getconnection();
                        cmd = new SqlCommand("select name,address,state,contact,pcompany,pname,basicprice,sgst,cgst,discount,total,received,billdate from tbl_newbill",obj.con);
                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        DataSet ds = new DataSet("new_dataset");
                        ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
                        sda.Fill(dt);
                        ds.Tables.Add(dt);
                        //DataSet1 ds = new DataSet1();
                        //sda.Fill(ds, "tbl_newbill");
                        ExcelLibrary.DataSetHelper.CreateWorkbook("MadhavTilesData.xls", ds);
                        MessageBox.Show("Download All Data From Database","Download success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        obj.closeconnection();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    //MessageBox.Show("Download Data Is Successfully");
                }
                else
                {
                    MessageBox.Show("OTP Is Incorrect");
                }
            }
        }

        private void piccloseotpdd_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picmaximizeotpdd_Click(object sender, EventArgs e)
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

        private void picminimizeotpdd_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
