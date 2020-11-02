namespace MadhavTilesBill
{
    partial class Products
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Products));
            this.lblpid = new System.Windows.Forms.Label();
            this.lblpcompany = new System.Windows.Forms.Label();
            this.bunifuCustomDataGrid1 = new Bunifu.Framework.UI.BunifuCustomDataGrid();
            this.txtPcompany = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.btndelete = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnupdate = new Bunifu.Framework.UI.BunifuThinButton2();
            this.picmaximizeproduct = new System.Windows.Forms.PictureBox();
            this.picminimizeproduct = new System.Windows.Forms.PictureBox();
            this.piccloseproduct = new System.Windows.Forms.PictureBox();
            this.btnsave = new Bunifu.Framework.UI.BunifuThinButton2();
            this.txtPid = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picmaximizeproduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picminimizeproduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.piccloseproduct)).BeginInit();
            this.SuspendLayout();
            // 
            // lblpid
            // 
            this.lblpid.AutoSize = true;
            this.lblpid.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpid.Location = new System.Drawing.Point(83, 51);
            this.lblpid.Name = "lblpid";
            this.lblpid.Size = new System.Drawing.Size(107, 28);
            this.lblpid.TabIndex = 0;
            this.lblpid.Text = "Product Id";
            // 
            // lblpcompany
            // 
            this.lblpcompany.AutoSize = true;
            this.lblpcompany.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpcompany.Location = new System.Drawing.Point(35, 98);
            this.lblpcompany.Name = "lblpcompany";
            this.lblpcompany.Size = new System.Drawing.Size(175, 28);
            this.lblpcompany.TabIndex = 1;
            this.lblpcompany.Text = "Product Company";
            // 
            // bunifuCustomDataGrid1
            // 
            this.bunifuCustomDataGrid1.AllowUserToAddRows = false;
            this.bunifuCustomDataGrid1.AllowUserToDeleteRows = false;
            this.bunifuCustomDataGrid1.AllowUserToResizeColumns = false;
            this.bunifuCustomDataGrid1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.bunifuCustomDataGrid1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.bunifuCustomDataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuCustomDataGrid1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bunifuCustomDataGrid1.BackgroundColor = System.Drawing.Color.White;
            this.bunifuCustomDataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bunifuCustomDataGrid1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.bunifuCustomDataGrid1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 15F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bunifuCustomDataGrid1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.bunifuCustomDataGrid1.ColumnHeadersHeight = 35;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bunifuCustomDataGrid1.DefaultCellStyle = dataGridViewCellStyle3;
            this.bunifuCustomDataGrid1.DoubleBuffered = true;
            this.bunifuCustomDataGrid1.EnableHeadersVisualStyles = false;
            this.bunifuCustomDataGrid1.GridColor = System.Drawing.Color.Blue;
            this.bunifuCustomDataGrid1.HeaderBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(122)))), ((int)(((byte)(224)))));
            this.bunifuCustomDataGrid1.HeaderForeColor = System.Drawing.Color.White;
            this.bunifuCustomDataGrid1.Location = new System.Drawing.Point(88, 174);
            this.bunifuCustomDataGrid1.MultiSelect = false;
            this.bunifuCustomDataGrid1.Name = "bunifuCustomDataGrid1";
            this.bunifuCustomDataGrid1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.bunifuCustomDataGrid1.RowHeadersWidth = 51;
            this.bunifuCustomDataGrid1.RowTemplate.Height = 24;
            this.bunifuCustomDataGrid1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bunifuCustomDataGrid1.Size = new System.Drawing.Size(1112, 512);
            this.bunifuCustomDataGrid1.TabIndex = 12;
            this.bunifuCustomDataGrid1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bunifuCustomDataGrid1_CellDoubleClick);
            // 
            // txtPcompany
            // 
            this.txtPcompany.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.txtPcompany.BackColor = System.Drawing.Color.White;
            this.txtPcompany.CausesValidation = false;
            this.txtPcompany.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPcompany.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtPcompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPcompany.HintForeColor = System.Drawing.Color.Empty;
            this.txtPcompany.HintText = "";
            this.txtPcompany.isPassword = false;
            this.txtPcompany.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtPcompany.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPcompany.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtPcompany.LineThickness = 1;
            this.txtPcompany.Location = new System.Drawing.Point(247, 98);
            this.txtPcompany.Margin = new System.Windows.Forms.Padding(4);
            this.txtPcompany.Name = "txtPcompany";
            this.txtPcompany.Size = new System.Drawing.Size(204, 30);
            this.txtPcompany.TabIndex = 13;
            this.txtPcompany.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            
            this.txtPcompany.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPcompany_KeyPress);
            // 
            // btndelete
            // 
            this.btndelete.ActiveBorderThickness = 1;
            this.btndelete.ActiveCornerRadius = 1;
            this.btndelete.ActiveFillColor = System.Drawing.Color.MediumSeaGreen;
            this.btndelete.ActiveForecolor = System.Drawing.Color.White;
            this.btndelete.ActiveLineColor = System.Drawing.Color.MediumSeaGreen;
            this.btndelete.BackColor = System.Drawing.SystemColors.Control;
            this.btndelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btndelete.BackgroundImage")));
            this.btndelete.ButtonText = "Delete";
            this.btndelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndelete.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.ForeColor = System.Drawing.Color.SeaGreen;
            this.btndelete.IdleBorderThickness = 1;
            this.btndelete.IdleCornerRadius = 1;
            this.btndelete.IdleFillColor = System.Drawing.Color.White;
            this.btndelete.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btndelete.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btndelete.Location = new System.Drawing.Point(970, 84);
            this.btndelete.Margin = new System.Windows.Forms.Padding(5);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(181, 41);
            this.btndelete.TabIndex = 19;
            this.btndelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.ActiveBorderThickness = 1;
            this.btnupdate.ActiveCornerRadius = 1;
            this.btnupdate.ActiveFillColor = System.Drawing.Color.MediumSeaGreen;
            this.btnupdate.ActiveForecolor = System.Drawing.Color.White;
            this.btnupdate.ActiveLineColor = System.Drawing.Color.MediumSeaGreen;
            this.btnupdate.BackColor = System.Drawing.SystemColors.Control;
            this.btnupdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnupdate.BackgroundImage")));
            this.btnupdate.ButtonText = "Update";
            this.btnupdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnupdate.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnupdate.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnupdate.IdleBorderThickness = 1;
            this.btnupdate.IdleCornerRadius = 1;
            this.btnupdate.IdleFillColor = System.Drawing.Color.White;
            this.btnupdate.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnupdate.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnupdate.Location = new System.Drawing.Point(779, 84);
            this.btnupdate.Margin = new System.Windows.Forms.Padding(5);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(181, 41);
            this.btnupdate.TabIndex = 18;
            this.btnupdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // picmaximizeproduct
            // 
            this.picmaximizeproduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picmaximizeproduct.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.picmaximizeproduct.Image = global::MadhavTilesBill.Properties.Resources._61728;
            this.picmaximizeproduct.Location = new System.Drawing.Point(1328, 0);
            this.picmaximizeproduct.Name = "picmaximizeproduct";
            this.picmaximizeproduct.Size = new System.Drawing.Size(32, 31);
            this.picmaximizeproduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picmaximizeproduct.TabIndex = 17;
            this.picmaximizeproduct.TabStop = false;
            this.picmaximizeproduct.Click += new System.EventHandler(this.picmaximizeproduct_Click);
            // 
            // picminimizeproduct
            // 
            this.picminimizeproduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picminimizeproduct.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.picminimizeproduct.Image = global::MadhavTilesBill.Properties.Resources.minimize_window__1_;
            this.picminimizeproduct.Location = new System.Drawing.Point(1294, 0);
            this.picminimizeproduct.Name = "picminimizeproduct";
            this.picminimizeproduct.Size = new System.Drawing.Size(32, 31);
            this.picminimizeproduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picminimizeproduct.TabIndex = 16;
            this.picminimizeproduct.TabStop = false;
            this.picminimizeproduct.Click += new System.EventHandler(this.picminimizeproduct_Click);
            // 
            // piccloseproduct
            // 
            this.piccloseproduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.piccloseproduct.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.piccloseproduct.Image = global::MadhavTilesBill.Properties.Resources.close_window;
            this.piccloseproduct.Location = new System.Drawing.Point(1362, 0);
            this.piccloseproduct.Name = "piccloseproduct";
            this.piccloseproduct.Size = new System.Drawing.Size(32, 31);
            this.piccloseproduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.piccloseproduct.TabIndex = 15;
            this.piccloseproduct.TabStop = false;
            this.piccloseproduct.Click += new System.EventHandler(this.piccloseproduct_Click);
            // 
            // btnsave
            // 
            this.btnsave.ActiveBorderThickness = 1;
            this.btnsave.ActiveCornerRadius = 1;
            this.btnsave.ActiveFillColor = System.Drawing.Color.MediumSeaGreen;
            this.btnsave.ActiveForecolor = System.Drawing.Color.White;
            this.btnsave.ActiveLineColor = System.Drawing.Color.MediumSeaGreen;
            this.btnsave.BackColor = System.Drawing.SystemColors.Control;
            this.btnsave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnsave.BackgroundImage")));
            this.btnsave.ButtonText = "Save";
            this.btnsave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsave.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.Color.SeaGreen;
            this.btnsave.IdleBorderThickness = 1;
            this.btnsave.IdleCornerRadius = 1;
            this.btnsave.IdleFillColor = System.Drawing.Color.White;
            this.btnsave.IdleForecolor = System.Drawing.Color.SeaGreen;
            this.btnsave.IdleLineColor = System.Drawing.Color.SeaGreen;
            this.btnsave.Location = new System.Drawing.Point(588, 84);
            this.btnsave.Margin = new System.Windows.Forms.Padding(5);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(181, 41);
            this.btnsave.TabIndex = 14;
            this.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // txtPid
            // 
            this.txtPid.BackColor = System.Drawing.Color.White;
            this.txtPid.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPid.Enabled = false;
            this.txtPid.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.txtPid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPid.HintForeColor = System.Drawing.Color.Empty;
            this.txtPid.HintText = "";
            this.txtPid.isPassword = false;
            this.txtPid.LineFocusedColor = System.Drawing.Color.Blue;
            this.txtPid.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPid.LineMouseHoverColor = System.Drawing.Color.Blue;
            this.txtPid.LineThickness = 1;
            this.txtPid.Location = new System.Drawing.Point(247, 51);
            this.txtPid.Margin = new System.Windows.Forms.Padding(4);
            this.txtPid.Name = "txtPid";
            this.txtPid.Size = new System.Drawing.Size(156, 39);
            this.txtPid.TabIndex = 4;
            this.txtPid.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1394, 721);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.picmaximizeproduct);
            this.Controls.Add(this.picminimizeproduct);
            this.Controls.Add(this.piccloseproduct);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.txtPcompany);
            this.Controls.Add(this.bunifuCustomDataGrid1);
            this.Controls.Add(this.txtPid);
            this.Controls.Add(this.lblpcompany);
            this.Controls.Add(this.lblpid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Products";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Products";
            this.Load += new System.EventHandler(this.Products_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuCustomDataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picmaximizeproduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picminimizeproduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.piccloseproduct)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblpid;
        private System.Windows.Forms.Label lblpcompany;
        private Bunifu.Framework.UI.BunifuCustomDataGrid bunifuCustomDataGrid1;
        private Bunifu.Framework.UI.BunifuThinButton2 btnsave;
        private System.Windows.Forms.PictureBox picmaximizeproduct;
        private System.Windows.Forms.PictureBox picminimizeproduct;
        private System.Windows.Forms.PictureBox piccloseproduct;
        private Bunifu.Framework.UI.BunifuThinButton2 btnupdate;
        private Bunifu.Framework.UI.BunifuThinButton2 btndelete;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtPcompany;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtPid;
    }
}