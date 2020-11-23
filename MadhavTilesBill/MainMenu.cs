using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MadhavTilesBill
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void picclosemenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picminimizemenu_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picmaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
                this.lblcompanyname.Font = new System.Drawing.Font("Segoe UI Semibold", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lblcompanyname.Location = new System.Drawing.Point(512, 129);
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void btnproduct_Click(object sender, EventArgs e)
        {
            Products prd = new Products();
            prd.Show();

        }

        private void btnnewbill_Click(object sender, EventArgs e)
        {
            NewBill nb = new NewBill();
            nb.Show();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            Search sr = new Search();
            sr.Show();
        }

        private void btnprintbill_Click(object sender, EventArgs e)
        {
            PrintBill pb = new PrintBill();
            pb.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            LogIn lg = new LogIn();
            lg.ShowDialog();
            
        }
    }
}
