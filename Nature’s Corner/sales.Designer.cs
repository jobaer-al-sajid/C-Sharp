namespace Nature_s_Corner
{
    partial class sales
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lbldate = new System.Windows.Forms.Label();
            this.lblquantity = new System.Windows.Forms.Label();
            this.lblcname = new System.Windows.Forms.Label();
            this.lblphone = new System.Windows.Forms.Label();
            this.lblpayment = new System.Windows.Forms.Label();
            this.txtquantity = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtcname = new System.Windows.Forms.TextBox();
            this.txtnumber = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.btndownload = new System.Windows.Forms.Button();
            this.lblprice = new System.Windows.Forms.Label();
            this.txtprice = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create New Sale";
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldate.Location = new System.Drawing.Point(149, 158);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(48, 16);
            this.lbldate.TabIndex = 1;
            this.lbldate.Text = "Date :";
            // 
            // lblquantity
            // 
            this.lblquantity.AutoSize = true;
            this.lblquantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblquantity.Location = new System.Drawing.Point(126, 213);
            this.lblquantity.Name = "lblquantity";
            this.lblquantity.Size = new System.Drawing.Size(75, 16);
            this.lblquantity.TabIndex = 2;
            this.lblquantity.Text = "Quantity : ";
            // 
            // lblcname
            // 
            this.lblcname.AutoSize = true;
            this.lblcname.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcname.Location = new System.Drawing.Point(76, 286);
            this.lblcname.Name = "lblcname";
            this.lblcname.Size = new System.Drawing.Size(125, 16);
            this.lblcname.TabIndex = 4;
            this.lblcname.Text = "Customer Name :";
            // 
            // lblphone
            // 
            this.lblphone.AutoSize = true;
            this.lblphone.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblphone.Location = new System.Drawing.Point(80, 356);
            this.lblphone.Name = "lblphone";
            this.lblphone.Size = new System.Drawing.Size(120, 16);
            this.lblphone.TabIndex = 6;
            this.lblphone.Text = "Mobile Number :";
            // 
            // lblpayment
            // 
            this.lblpayment.AutoSize = true;
            this.lblpayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpayment.Location = new System.Drawing.Point(86, 426);
            this.lblpayment.Name = "lblpayment";
            this.lblpayment.Size = new System.Drawing.Size(115, 16);
            this.lblpayment.TabIndex = 7;
            this.lblpayment.Text = "Payment Type :";
            // 
            // txtquantity
            // 
            this.txtquantity.Location = new System.Drawing.Point(246, 213);
            this.txtquantity.Name = "txtquantity";
            this.txtquantity.Size = new System.Drawing.Size(272, 22);
            this.txtquantity.TabIndex = 9;
            this.txtquantity.TextChanged += new System.EventHandler(this.txtquantity_TextChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(246, 153);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(272, 22);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // txtcname
            // 
            this.txtcname.Location = new System.Drawing.Point(246, 286);
            this.txtcname.Name = "txtcname";
            this.txtcname.Size = new System.Drawing.Size(272, 22);
            this.txtcname.TabIndex = 12;
            // 
            // txtnumber
            // 
            this.txtnumber.Location = new System.Drawing.Point(246, 356);
            this.txtnumber.Name = "txtnumber";
            this.txtnumber.Size = new System.Drawing.Size(272, 22);
            this.txtnumber.TabIndex = 13;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Cash",
            "Bkash",
            "Nagad",
            "Rocket"});
            this.comboBox1.Location = new System.Drawing.Point(246, 423);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(272, 24);
            this.comboBox1.TabIndex = 14;
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnsave.Location = new System.Drawing.Point(552, 619);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(88, 36);
            this.btnsave.TabIndex = 15;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btndownload
            // 
            this.btndownload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btndownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndownload.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btndownload.Location = new System.Drawing.Point(671, 619);
            this.btndownload.Name = "btndownload";
            this.btndownload.Size = new System.Drawing.Size(127, 36);
            this.btndownload.TabIndex = 16;
            this.btndownload.Text = "Download";
            this.btndownload.UseVisualStyleBackColor = false;
            this.btndownload.Click += new System.EventHandler(this.btndownload_Click);
            // 
            // lblprice
            // 
            this.lblprice.AutoSize = true;
            this.lblprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprice.Location = new System.Drawing.Point(150, 493);
            this.lblprice.Name = "lblprice";
            this.lblprice.Size = new System.Drawing.Size(51, 16);
            this.lblprice.TabIndex = 17;
            this.lblprice.Text = "Price :";
            this.lblprice.Click += new System.EventHandler(this.lblprice_Click);
            // 
            // txtprice
            // 
            this.txtprice.Location = new System.Drawing.Point(246, 493);
            this.txtprice.Name = "txtprice";
            this.txtprice.Size = new System.Drawing.Size(271, 22);
            this.txtprice.TabIndex = 18;
            this.txtprice.TextChanged += new System.EventHandler(this.txtprice_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Location = new System.Drawing.Point(40, 619);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 36);
            this.button1.TabIndex = 19;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // sales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 703);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtprice);
            this.Controls.Add(this.lblprice);
            this.Controls.Add(this.btndownload);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.txtnumber);
            this.Controls.Add(this.txtcname);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.txtquantity);
            this.Controls.Add(this.lblpayment);
            this.Controls.Add(this.lblphone);
            this.Controls.Add(this.lblcname);
            this.Controls.Add(this.lblquantity);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.label1);
            this.Name = "sales";
            this.Text = "sales page";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.Label lblquantity;
        private System.Windows.Forms.Label lblcname;
        private System.Windows.Forms.Label lblphone;
        private System.Windows.Forms.Label lblpayment;
        private System.Windows.Forms.TextBox txtquantity;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtcname;
        private System.Windows.Forms.TextBox txtnumber;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btndownload;
        private System.Windows.Forms.Label lblprice;
        private System.Windows.Forms.TextBox txtprice;
        private System.Windows.Forms.Button button1;
    }
}
