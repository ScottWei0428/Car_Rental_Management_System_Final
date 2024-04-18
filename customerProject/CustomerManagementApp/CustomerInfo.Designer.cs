namespace CustomerManagementApp
{
    partial class CustomerInformation
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
            this.AddCustomerBtn = new System.Windows.Forms.Button();
            this.UpdateCutomerBtn = new System.Windows.Forms.Button();
            this.ViewCustomerBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.customerName = new System.Windows.Forms.TextBox();
            this.customerAddress = new System.Windows.Forms.TextBox();
            this.customerPhnNum = new System.Windows.Forms.TextBox();
            this.customerEmail = new System.Windows.Forms.TextBox();
            this.customerListbox = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DeleteCustomerbtn = new System.Windows.Forms.Button();
            this.exitbutton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddCustomerBtn
            // 
            this.AddCustomerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddCustomerBtn.Location = new System.Drawing.Point(81, 293);
            this.AddCustomerBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddCustomerBtn.Name = "AddCustomerBtn";
            this.AddCustomerBtn.Size = new System.Drawing.Size(105, 49);
            this.AddCustomerBtn.TabIndex = 0;
            this.AddCustomerBtn.Text = "Add Customer";
            this.AddCustomerBtn.UseVisualStyleBackColor = true;
            this.AddCustomerBtn.Click += new System.EventHandler(this.AddCustomerBtn_Click);
            // 
            // UpdateCutomerBtn
            // 
            this.UpdateCutomerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateCutomerBtn.Location = new System.Drawing.Point(211, 293);
            this.UpdateCutomerBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.UpdateCutomerBtn.Name = "UpdateCutomerBtn";
            this.UpdateCutomerBtn.Size = new System.Drawing.Size(99, 49);
            this.UpdateCutomerBtn.TabIndex = 1;
            this.UpdateCutomerBtn.Text = "Update Customer";
            this.UpdateCutomerBtn.UseVisualStyleBackColor = true;
            this.UpdateCutomerBtn.Click += new System.EventHandler(this.UpdateCustomerBtn_Click);
            // 
            // ViewCustomerBtn
            // 
            this.ViewCustomerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewCustomerBtn.Location = new System.Drawing.Point(211, 369);
            this.ViewCustomerBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ViewCustomerBtn.Name = "ViewCustomerBtn";
            this.ViewCustomerBtn.Size = new System.Drawing.Size(99, 47);
            this.ViewCustomerBtn.TabIndex = 3;
            this.ViewCustomerBtn.Text = "View Customer";
            this.ViewCustomerBtn.UseVisualStyleBackColor = true;
            this.ViewCustomerBtn.Click += new System.EventHandler(this.ViewCustomerBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(56, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(57, 93);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Address";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 131);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Phone";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(57, 163);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Email";
            // 
            // customerName
            // 
            this.customerName.Location = new System.Drawing.Point(189, 55);
            this.customerName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customerName.Name = "customerName";
            this.customerName.Size = new System.Drawing.Size(147, 21);
            this.customerName.TabIndex = 8;
            // 
            // customerAddress
            // 
            this.customerAddress.Location = new System.Drawing.Point(189, 95);
            this.customerAddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customerAddress.Name = "customerAddress";
            this.customerAddress.Size = new System.Drawing.Size(147, 21);
            this.customerAddress.TabIndex = 9;
            // 
            // customerPhnNum
            // 
            this.customerPhnNum.Location = new System.Drawing.Point(189, 132);
            this.customerPhnNum.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customerPhnNum.Name = "customerPhnNum";
            this.customerPhnNum.Size = new System.Drawing.Size(147, 21);
            this.customerPhnNum.TabIndex = 10;
            // 
            // customerEmail
            // 
            this.customerEmail.Location = new System.Drawing.Point(189, 163);
            this.customerEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customerEmail.Name = "customerEmail";
            this.customerEmail.Size = new System.Drawing.Size(149, 21);
            this.customerEmail.TabIndex = 11;
            // 
            // customerListbox
            // 
            this.customerListbox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.customerListbox.FormattingEnabled = true;
            this.customerListbox.ItemHeight = 12;
            this.customerListbox.Location = new System.Drawing.Point(452, 14);
            this.customerListbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customerListbox.Name = "customerListbox";
            this.customerListbox.Size = new System.Drawing.Size(475, 280);
            this.customerListbox.TabIndex = 12;
            this.customerListbox.SelectedIndexChanged += new System.EventHandler(this.customerListbox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.customerName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.customerAddress);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.customerPhnNum);
            this.groupBox1.Controls.Add(this.customerEmail);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(22, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(378, 246);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CustomerInfo";
            // 
            // DeleteCustomerbtn
            // 
            this.DeleteCustomerbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteCustomerbtn.Location = new System.Drawing.Point(81, 369);
            this.DeleteCustomerbtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DeleteCustomerbtn.Name = "DeleteCustomerbtn";
            this.DeleteCustomerbtn.Size = new System.Drawing.Size(104, 47);
            this.DeleteCustomerbtn.TabIndex = 14;
            this.DeleteCustomerbtn.Text = "Delete Customer";
            this.DeleteCustomerbtn.UseVisualStyleBackColor = true;
            this.DeleteCustomerbtn.Click += new System.EventHandler(this.DeleteCustomerBtn_Click);
            // 
            // exitbutton
            // 
            this.exitbutton.Font = new System.Drawing.Font("微软雅黑", 10.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitbutton.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.exitbutton.Location = new System.Drawing.Point(794, 345);
            this.exitbutton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.exitbutton.Name = "exitbutton";
            this.exitbutton.Size = new System.Drawing.Size(117, 52);
            this.exitbutton.TabIndex = 16;
            this.exitbutton.Text = "&Exit";
            this.exitbutton.UseVisualStyleBackColor = true;
            this.exitbutton.Click += new System.EventHandler(this.exitbutton_Click);
            // 
            // CustomerInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.BackgroundImage = global::CustomerManagementApp.Properties.Resources.customer_relationship_management_strategies;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(958, 463);
            this.Controls.Add(this.exitbutton);
            this.Controls.Add(this.DeleteCustomerbtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.customerListbox);
            this.Controls.Add(this.UpdateCutomerBtn);
            this.Controls.Add(this.AddCustomerBtn);
            this.Controls.Add(this.ViewCustomerBtn);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CustomerInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Management";
            this.Load += new System.EventHandler(this.CustomerInformation_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddCustomerBtn;
        private System.Windows.Forms.Button UpdateCutomerBtn;
        private System.Windows.Forms.Button ViewCustomerBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox customerName;
        private System.Windows.Forms.TextBox customerAddress;
        private System.Windows.Forms.TextBox customerPhnNum;
        private System.Windows.Forms.TextBox customerEmail;
        private System.Windows.Forms.ListBox customerListbox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button DeleteCustomerbtn;
        private System.Windows.Forms.Button exitbutton;
    }
}

