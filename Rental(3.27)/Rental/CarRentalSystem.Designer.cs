namespace Rental
{
    partial class CarRentalSystem
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
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.lblCarID = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblPopularmodels = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lbxCarList = new System.Windows.Forms.ListBox();
            this.btnRentCar = new System.Windows.Forms.Button();
            this.btnReturnCar = new System.Windows.Forms.Button();
            this.lblVehicleInformation = new System.Windows.Forms.Label();
            this.lbxVehicleInformation = new System.Windows.Forms.ListBox();
            this.LSVStatus = new System.Windows.Forms.ListView();
            this.LVStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbxInfo = new System.Windows.Forms.ListBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.cbxCarID = new System.Windows.Forms.ComboBox();
            this.cbCustomerID = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lblCustomerID.Location = new System.Drawing.Point(8, 23);
            this.lblCustomerID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(65, 12);
            this.lblCustomerID.TabIndex = 0;
            this.lblCustomerID.Text = "CustomerID";
            this.lblCustomerID.Click += new System.EventHandler(this.lblCustomerID_Click);
            // 
            // lblCarID
            // 
            this.lblCarID.AutoSize = true;
            this.lblCarID.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lblCarID.Location = new System.Drawing.Point(26, 53);
            this.lblCarID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCarID.Name = "lblCarID";
            this.lblCarID.Size = new System.Drawing.Size(35, 12);
            this.lblCarID.TabIndex = 1;
            this.lblCarID.Text = "CarID";
            this.lblCarID.Click += new System.EventHandler(this.lblCarID_Click);
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lblStartDate.Location = new System.Drawing.Point(14, 88);
            this.lblStartDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(59, 12);
            this.lblStartDate.TabIndex = 2;
            this.lblStartDate.Text = "StartDate";
            this.lblStartDate.Click += new System.EventHandler(this.lblStartDate_Click);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.BackColor = System.Drawing.Color.PaleTurquoise;
            this.lblEndDate.Location = new System.Drawing.Point(20, 126);
            this.lblEndDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(47, 12);
            this.lblEndDate.TabIndex = 3;
            this.lblEndDate.Text = "EndDate";
            this.lblEndDate.Click += new System.EventHandler(this.lblEndDate_Click);
            // 
            // lblPopularmodels
            // 
            this.lblPopularmodels.AutoSize = true;
            this.lblPopularmodels.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.lblPopularmodels.Location = new System.Drawing.Point(8, 203);
            this.lblPopularmodels.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPopularmodels.Name = "lblPopularmodels";
            this.lblPopularmodels.Size = new System.Drawing.Size(83, 12);
            this.lblPopularmodels.TabIndex = 4;
            this.lblPopularmodels.Text = "Popularmodels";
            this.lblPopularmodels.Click += new System.EventHandler(this.lblPopularmodels_Click);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(90, 83);
            this.dtpStartDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(118, 21);
            this.dtpStartDate.TabIndex = 7;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(90, 121);
            this.dtpEndDate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(118, 21);
            this.dtpEndDate.TabIndex = 8;
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
            // 
            // lbxCarList
            // 
            this.lbxCarList.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbxCarList.FormattingEnabled = true;
            this.lbxCarList.ItemHeight = 12;
            this.lbxCarList.Location = new System.Drawing.Point(8, 226);
            this.lbxCarList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbxCarList.Name = "lbxCarList";
            this.lbxCarList.Size = new System.Drawing.Size(200, 160);
            this.lbxCarList.TabIndex = 9;
            this.lbxCarList.SelectedIndexChanged += new System.EventHandler(this.lbxCarList_SelectedIndexChanged);
            // 
            // btnRentCar
            // 
            this.btnRentCar.BackColor = System.Drawing.Color.Aquamarine;
            this.btnRentCar.Location = new System.Drawing.Point(8, 387);
            this.btnRentCar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRentCar.Name = "btnRentCar";
            this.btnRentCar.Size = new System.Drawing.Size(82, 23);
            this.btnRentCar.TabIndex = 10;
            this.btnRentCar.Text = "RentCar";
            this.btnRentCar.UseVisualStyleBackColor = false;
            this.btnRentCar.Click += new System.EventHandler(this.btnRentCar_Click);
            // 
            // btnReturnCar
            // 
            this.btnReturnCar.BackColor = System.Drawing.Color.Azure;
            this.btnReturnCar.Location = new System.Drawing.Point(125, 387);
            this.btnReturnCar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReturnCar.Name = "btnReturnCar";
            this.btnReturnCar.Size = new System.Drawing.Size(82, 23);
            this.btnReturnCar.TabIndex = 11;
            this.btnReturnCar.Text = "ReturnCar";
            this.btnReturnCar.UseVisualStyleBackColor = false;
            this.btnReturnCar.Click += new System.EventHandler(this.btnReturnCar_Click);
            // 
            // lblVehicleInformation
            // 
            this.lblVehicleInformation.AutoSize = true;
            this.lblVehicleInformation.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.lblVehicleInformation.Location = new System.Drawing.Point(8, 465);
            this.lblVehicleInformation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVehicleInformation.Name = "lblVehicleInformation";
            this.lblVehicleInformation.Size = new System.Drawing.Size(119, 12);
            this.lblVehicleInformation.TabIndex = 12;
            this.lblVehicleInformation.Text = "Vehicle Information";
            this.lblVehicleInformation.Click += new System.EventHandler(this.lblVehicleInformation_Click);
            // 
            // lbxVehicleInformation
            // 
            this.lbxVehicleInformation.FormattingEnabled = true;
            this.lbxVehicleInformation.ItemHeight = 12;
            this.lbxVehicleInformation.Location = new System.Drawing.Point(8, 479);
            this.lbxVehicleInformation.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbxVehicleInformation.Name = "lbxVehicleInformation";
            this.lbxVehicleInformation.Size = new System.Drawing.Size(756, 16);
            this.lbxVehicleInformation.TabIndex = 13;
            this.lbxVehicleInformation.SelectedIndexChanged += new System.EventHandler(this.lbxVehicleInformation_SelectedIndexChanged);
            // 
            // LSVStatus
            // 
            this.LSVStatus.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.LSVStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LVStatus});
            this.LSVStatus.HideSelection = false;
            this.LSVStatus.Location = new System.Drawing.Point(212, 20);
            this.LSVStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LSVStatus.Name = "LSVStatus";
            this.LSVStatus.Size = new System.Drawing.Size(552, 80);
            this.LSVStatus.TabIndex = 14;
            this.LSVStatus.UseCompatibleStateImageBehavior = false;
            this.LSVStatus.View = System.Windows.Forms.View.Details;
            this.LSVStatus.SelectedIndexChanged += new System.EventHandler(this.LSVStatus_SelectedIndexChanged);
            // 
            // LVStatus
            // 
            this.LVStatus.Text = "Number";
            // 
            // lbxInfo
            // 
            this.lbxInfo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lbxInfo.FormattingEnabled = true;
            this.lbxInfo.ItemHeight = 12;
            this.lbxInfo.Location = new System.Drawing.Point(243, 226);
            this.lbxInfo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbxInfo.Name = "lbxInfo";
            this.lbxInfo.Size = new System.Drawing.Size(521, 160);
            this.lbxInfo.TabIndex = 18;
            this.lbxInfo.SelectedIndexChanged += new System.EventHandler(this.lbxInfo_SelectedIndexChanged);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.lblInfo.Location = new System.Drawing.Point(241, 212);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(71, 12);
            this.lblInfo.TabIndex = 19;
            this.lblInfo.Text = "Information";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.IndianRed;
            this.btnExit.Location = new System.Drawing.Point(671, 436);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 27);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbxCarID
            // 
            this.cbxCarID.FormattingEnabled = true;
            this.cbxCarID.Location = new System.Drawing.Point(90, 50);
            this.cbxCarID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxCarID.Name = "cbxCarID";
            this.cbxCarID.Size = new System.Drawing.Size(118, 20);
            this.cbxCarID.TabIndex = 21;
            this.cbxCarID.SelectedIndexChanged += new System.EventHandler(this.cbxCarID_SelectedIndexChanged);
            // 
            // cbCustomerID
            // 
            this.cbCustomerID.FormattingEnabled = true;
            this.cbCustomerID.Location = new System.Drawing.Point(89, 20);
            this.cbCustomerID.Margin = new System.Windows.Forms.Padding(2);
            this.cbCustomerID.Name = "cbCustomerID";
            this.cbCustomerID.Size = new System.Drawing.Size(118, 20);
            this.cbCustomerID.TabIndex = 22;
            // 
            // CarRentalSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 502);
            this.Controls.Add(this.cbCustomerID);
            this.Controls.Add(this.cbxCarID);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lbxInfo);
            this.Controls.Add(this.LSVStatus);
            this.Controls.Add(this.lbxVehicleInformation);
            this.Controls.Add(this.lblVehicleInformation);
            this.Controls.Add(this.btnReturnCar);
            this.Controls.Add(this.btnRentCar);
            this.Controls.Add(this.lbxCarList);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblPopularmodels);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblCarID);
            this.Controls.Add(this.lblCustomerID);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CarRentalSystem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CarRentalSystem";
            this.Load += new System.EventHandler(this.CarRentalSystem_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.Label lblCarID;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblPopularmodels;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.ListBox lbxCarList;
        private System.Windows.Forms.Button btnRentCar;
        private System.Windows.Forms.Button btnReturnCar;
        private System.Windows.Forms.Label lblVehicleInformation;
        private System.Windows.Forms.ListBox lbxVehicleInformation;
        private System.Windows.Forms.ListView LSVStatus;
        private System.Windows.Forms.ColumnHeader LVStatus;
        private System.Windows.Forms.ListBox lbxInfo;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cbxCarID;
        private System.Windows.Forms.ComboBox cbCustomerID;
    }
}

