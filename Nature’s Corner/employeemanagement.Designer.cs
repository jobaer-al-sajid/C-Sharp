namespace Nature_s_Corner
{
    partial class employeemanagement
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
            this.greenpanel = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.naturelabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.employeesearchbox = new Guna.UI2.WinForms.Guna2TextBox();
            this.seachnamelabel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.searchbutton = new Guna.UI2.WinForms.Guna2Button();
            this.employeeview = new System.Windows.Forms.DataGridView();
            this.Addbutton = new Guna.UI2.WinForms.Guna2Button();
            this.txtfullname = new System.Windows.Forms.TextBox();
            this.txtposition = new System.Windows.Forms.TextBox();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.lblemail = new System.Windows.Forms.Label();
            this.lblposition = new System.Windows.Forms.Label();
            this.lblphone = new System.Windows.Forms.Label();
            this.lblfullname = new System.Windows.Forms.Label();
            this.txtphone = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dltbutton = new System.Windows.Forms.Button();
            this.greenpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeview)).BeginInit();
            this.SuspendLayout();
            // 
            // greenpanel
            // 
            this.greenpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.greenpanel.Controls.Add(this.naturelabel);
            this.greenpanel.Location = new System.Drawing.Point(0, -1);
            this.greenpanel.Margin = new System.Windows.Forms.Padding(4);
            this.greenpanel.Name = "greenpanel";
            this.greenpanel.Size = new System.Drawing.Size(1309, 55);
            this.greenpanel.TabIndex = 1;
            // 
            // naturelabel
            // 
            this.naturelabel.BackColor = System.Drawing.Color.Transparent;
            this.naturelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.naturelabel.ForeColor = System.Drawing.Color.White;
            this.naturelabel.Location = new System.Drawing.Point(16, 17);
            this.naturelabel.Margin = new System.Windows.Forms.Padding(4);
            this.naturelabel.Name = "naturelabel";
            this.naturelabel.Size = new System.Drawing.Size(155, 27);
            this.naturelabel.TabIndex = 0;
            this.naturelabel.Text = "Nature’s Corner";
            // 
            // employeesearchbox
            // 
            this.employeesearchbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.employeesearchbox.DefaultText = "";
            this.employeesearchbox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.employeesearchbox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.employeesearchbox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.employeesearchbox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.employeesearchbox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.employeesearchbox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.employeesearchbox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.employeesearchbox.Location = new System.Drawing.Point(71, 127);
            this.employeesearchbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.employeesearchbox.Name = "employeesearchbox";
            this.employeesearchbox.PlaceholderText = "";
            this.employeesearchbox.SelectedText = "";
            this.employeesearchbox.Size = new System.Drawing.Size(316, 33);
            this.employeesearchbox.TabIndex = 4;
            this.employeesearchbox.TextChanged += new System.EventHandler(this.fullnametextbox_TextChanged);
            // 
            // seachnamelabel
            // 
            this.seachnamelabel.AutoSize = false;
            this.seachnamelabel.BackColor = System.Drawing.Color.Transparent;
            this.seachnamelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seachnamelabel.ForeColor = System.Drawing.Color.Black;
            this.seachnamelabel.Location = new System.Drawing.Point(71, 81);
            this.seachnamelabel.Margin = new System.Windows.Forms.Padding(4);
            this.seachnamelabel.Name = "seachnamelabel";
            this.seachnamelabel.Size = new System.Drawing.Size(200, 37);
            this.seachnamelabel.TabIndex = 7;
            this.seachnamelabel.Text = "Search by name";
            this.seachnamelabel.Click += new System.EventHandler(this.fullnamelabel_Click);
            // 
            // searchbutton
            // 
            this.searchbutton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.searchbutton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.searchbutton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.searchbutton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.searchbutton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.searchbutton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.searchbutton.ForeColor = System.Drawing.Color.White;
            this.searchbutton.Location = new System.Drawing.Point(71, 179);
            this.searchbutton.Margin = new System.Windows.Forms.Padding(4);
            this.searchbutton.Name = "searchbutton";
            this.searchbutton.Size = new System.Drawing.Size(176, 54);
            this.searchbutton.TabIndex = 17;
            this.searchbutton.Text = "Search";
            this.searchbutton.Click += new System.EventHandler(this.searchbutton_Click);
            // 
            // employeeview
            // 
            this.employeeview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.employeeview.Location = new System.Drawing.Point(13, 407);
            this.employeeview.Margin = new System.Windows.Forms.Padding(4);
            this.employeeview.Name = "employeeview";
            this.employeeview.RowHeadersWidth = 51;
            this.employeeview.Size = new System.Drawing.Size(1281, 252);
            this.employeeview.TabIndex = 19;
            this.employeeview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.employeeview_CellContentClick);
            // 
            // Addbutton
            // 
            this.Addbutton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.Addbutton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.Addbutton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.Addbutton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.Addbutton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Addbutton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Addbutton.ForeColor = System.Drawing.Color.White;
            this.Addbutton.Location = new System.Drawing.Point(847, 326);
            this.Addbutton.Margin = new System.Windows.Forms.Padding(4);
            this.Addbutton.Name = "Addbutton";
            this.Addbutton.Size = new System.Drawing.Size(176, 54);
            this.Addbutton.TabIndex = 20;
            this.Addbutton.Text = "Add Employee";
            this.Addbutton.Click += new System.EventHandler(this.Addbutton_Click);
            // 
            // txtfullname
            // 
            this.txtfullname.Location = new System.Drawing.Point(915, 83);
            this.txtfullname.Name = "txtfullname";
            this.txtfullname.Size = new System.Drawing.Size(249, 22);
            this.txtfullname.TabIndex = 21;
            this.txtfullname.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtposition
            // 
            this.txtposition.Location = new System.Drawing.Point(915, 267);
            this.txtposition.Name = "txtposition";
            this.txtposition.Size = new System.Drawing.Size(249, 22);
            this.txtposition.TabIndex = 22;
            this.txtposition.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtemail
            // 
            this.txtemail.Location = new System.Drawing.Point(915, 199);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(249, 22);
            this.txtemail.TabIndex = 23;
            this.txtemail.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // lblemail
            // 
            this.lblemail.AutoSize = true;
            this.lblemail.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblemail.Location = new System.Drawing.Point(810, 202);
            this.lblemail.Name = "lblemail";
            this.lblemail.Size = new System.Drawing.Size(45, 19);
            this.lblemail.TabIndex = 24;
            this.lblemail.Text = "Email";
            // 
            // lblposition
            // 
            this.lblposition.AutoSize = true;
            this.lblposition.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblposition.Location = new System.Drawing.Point(810, 267);
            this.lblposition.Name = "lblposition";
            this.lblposition.Size = new System.Drawing.Size(63, 19);
            this.lblposition.TabIndex = 25;
            this.lblposition.Text = "Position";
            // 
            // lblphone
            // 
            this.lblphone.AutoSize = true;
            this.lblphone.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblphone.Location = new System.Drawing.Point(810, 141);
            this.lblphone.Name = "lblphone";
            this.lblphone.Size = new System.Drawing.Size(51, 19);
            this.lblphone.TabIndex = 26;
            this.lblphone.Text = "Phone";
            // 
            // lblfullname
            // 
            this.lblfullname.AutoSize = true;
            this.lblfullname.Font = new System.Drawing.Font("Microsoft YaHei UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfullname.Location = new System.Drawing.Point(806, 88);
            this.lblfullname.Name = "lblfullname";
            this.lblfullname.Size = new System.Drawing.Size(69, 19);
            this.lblfullname.TabIndex = 27;
            this.lblfullname.Text = "Fullname";
            // 
            // txtphone
            // 
            this.txtphone.Location = new System.Drawing.Point(915, 138);
            this.txtphone.Name = "txtphone";
            this.txtphone.Size = new System.Drawing.Size(249, 22);
            this.txtphone.TabIndex = 28;
            this.txtphone.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(71, 326);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 38);
            this.button1.TabIndex = 29;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dltbutton
            // 
            this.dltbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.dltbutton.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dltbutton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.dltbutton.Location = new System.Drawing.Point(1085, 326);
            this.dltbutton.Name = "dltbutton";
            this.dltbutton.Size = new System.Drawing.Size(162, 54);
            this.dltbutton.TabIndex = 30;
            this.dltbutton.Text = "Delete";
            this.dltbutton.UseVisualStyleBackColor = false;
            this.dltbutton.Click += new System.EventHandler(this.button2_Click);
            // 
            // employeemanagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1307, 672);
            this.Controls.Add(this.dltbutton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtphone);
            this.Controls.Add(this.lblfullname);
            this.Controls.Add(this.lblphone);
            this.Controls.Add(this.lblposition);
            this.Controls.Add(this.lblemail);
            this.Controls.Add(this.txtemail);
            this.Controls.Add(this.txtposition);
            this.Controls.Add(this.txtfullname);
            this.Controls.Add(this.Addbutton);
            this.Controls.Add(this.employeeview);
            this.Controls.Add(this.searchbutton);
            this.Controls.Add(this.seachnamelabel);
            this.Controls.Add(this.employeesearchbox);
            this.Controls.Add(this.greenpanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "employeemanagement";
            this.Text = "employeemanagement";
            this.Load += new System.EventHandler(this.employeemanagement_Load);
            this.greenpanel.ResumeLayout(false);
            this.greenpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeeview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel greenpanel;
        private Guna.UI2.WinForms.Guna2HtmlLabel naturelabel;
        private Guna.UI2.WinForms.Guna2TextBox employeesearchbox;
        private Guna.UI2.WinForms.Guna2HtmlLabel seachnamelabel;
        private Guna.UI2.WinForms.Guna2Button searchbutton;
        private System.Windows.Forms.DataGridView employeeview;
        private Guna.UI2.WinForms.Guna2Button Addbutton;
        private System.Windows.Forms.TextBox txtfullname;
        private System.Windows.Forms.TextBox txtposition;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.Label lblemail;
        private System.Windows.Forms.Label lblposition;
        private System.Windows.Forms.Label lblphone;
        private System.Windows.Forms.Label lblfullname;
        private System.Windows.Forms.TextBox txtphone;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button dltbutton;
    }
}