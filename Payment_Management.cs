using Car_Rental_System;
using DAL;
using DAL.Entitys;
using Rental;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payments
{
    public partial class Payment_Management : Form
    {
       

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox tbxAmount;
        private ListBox lbxShow;
        private Button btnRecord;
        private Button btnDelet;
        private DateTimePicker tbxDate;
        private ComboBox cbxMethod;
        private Label label5;
        private Label feedbackLabel;
        private Button btnExit;
        private ComboBox cbRentalId;



        // Payment database instance
        private PaymentDB paymentDB = new PaymentDB();
        public Payment_Management()
        {
            InitializeComponent();
            // Set the minimum date for the date picker to today
            tbxDate.MinDate = DateTime.Today;
            // Set the value of the date picker to today
            tbxDate.Value = DateTime.Today;
            loadRentasComboBox();
        }

        private void Payment_Management_Load(object sender, EventArgs e)
        {
            // Initialize feedback label
            feedbackLabel.Text = "";
            // Set the minimum date for the date picker to today
            tbxDate.MinDate = DateTime.Today;
            // Set the selected index of the payment method combo box to the first item
            cbxMethod.SelectedIndex = 0;
            LoadPaymentsIntoListBox();
            loadRentasComboBox();
        }

        public void LoadPaymentsIntoListBox()
        {
            try
            {
                lbxShow.Items.Clear();
                var payments = paymentDB.GetPayments();

                foreach (var payment in payments)
                {
                    lbxShow.Items.Add($"{payment.RentalID}|{payment.Amount}|{payment.Date.ToShortDateString()}|{payment.Method}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                Debug.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void loadRentasComboBox()
        {
            cbRentalId.Items.Clear();

            try
            {
                var rentals = RentalDB.GetAllRentals();

                foreach (var rental in rentals)
                {
                    cbRentalId.Items.Add(rental.RentalID);
                }

                if (cbRentalId.Items.Count > 0)
                {
                    cbRentalId.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load rentals: " + ex.Message);
            }
        }

        private void btnRecord_Click_1(object sender, EventArgs e)
        {
            // Extract payment information from input fields
            string rentalID = cbRentalId.Text;
            string amountText = tbxAmount.Text;
            string method = cbxMethod.SelectedItem?.ToString();
            DateTime date = tbxDate.Value;
            feedbackLabel.Text = "";

            // Validate input fields
            if (string.IsNullOrWhiteSpace(cbRentalId.Text))
            {
                feedbackLabel.ForeColor = Color.Red;
                feedbackLabel.Text = "Error: Rental ID is required.";
                return;
            }

            if (paymentDB.CheckRentalIDExists(rentalID))
            {
                feedbackLabel.ForeColor = Color.Red;
                feedbackLabel.Text = "Error: Rental ID alreay exists.";
                return;
            }

            if (string.IsNullOrWhiteSpace(tbxAmount.Text) || !decimal.TryParse(tbxAmount.Text, out decimal parsedAmount) || parsedAmount <= 0)
            {
                feedbackLabel.ForeColor = Color.Red;
                feedbackLabel.Text = "Error: Amount must be a positive number.";
                return;
            }

            if (cbxMethod.SelectedIndex == -1)
            {
                feedbackLabel.ForeColor = Color.Red;
                feedbackLabel.Text = "Error: Payment Method is required.";
                return;
            }

            // Create a PaymentInfo object with the extracted information
            PaymentInfo payment = new PaymentInfo()
            {
                RentalID = rentalID,
                Amount = parsedAmount, 
                Date = date,
                Method = method
            };

            // Add the payment to the database
            using (var dbContext = new CarRentalDbContext())
            {
                dbContext.Payments.Add(payment);
                dbContext.SaveChanges();
            }
            LoadPaymentsIntoListBox();

            feedbackLabel.ForeColor = Color.Blue;
            feedbackLabel.Text = "Payment recorded successfully.";
        }

        // Method to handle the "Delete record" button click event
        private void btnDelet_Click(object sender, EventArgs e)
        {
            // Check if an item is selected in the list box
            if (lbxShow.SelectedIndex != -1)
            {
                // because first part of each item is the RentalID, directly before the first Delimiter
                var selectedItemText = lbxShow.SelectedItem.ToString();
                var parts = selectedItemText.Split(new[] { '|' }, 2); // Splitting with limit to get only the first part
                if (parts.Length > 0)
                {
                    var rentalID = parts[0].Trim();

                    // Delete payment by rental ID
                    paymentDB.DeletePaymentByRentalID(rentalID);

                    // Update the display with the latest payments
                    LoadPaymentsIntoListBox();

                    feedbackLabel.ForeColor = Color.Blue;
                    // Display success message
                    feedbackLabel.Text = "Payment deleted successfully.";
                }
                else
                {
                    // Display error message if unable to parse Rental ID
                    feedbackLabel.ForeColor = Color.Red;
                    feedbackLabel.Text = "Failed to parse Rental ID.";
                }
            }
            else
            {
                // Display error message if no item is selected in the list box
                feedbackLabel.ForeColor = Color.Red;
                feedbackLabel.Text = "Please select a record to delete.";
            }
        }




        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxAmount = new System.Windows.Forms.TextBox();
            this.lbxShow = new System.Windows.Forms.ListBox();
            this.btnRecord = new System.Windows.Forms.Button();
            this.btnDelet = new System.Windows.Forms.Button();
            this.tbxDate = new System.Windows.Forms.DateTimePicker();
            this.cbxMethod = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.feedbackLabel = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.cbRentalId = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rental &ID: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "&Amount: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(418, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Payment &Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(418, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Payment Method:";
            // 
            // tbxAmount
            // 
            this.tbxAmount.Location = new System.Drawing.Point(177, 119);
            this.tbxAmount.Name = "tbxAmount";
            this.tbxAmount.Size = new System.Drawing.Size(139, 21);
            this.tbxAmount.TabIndex = 5;
            // 
            // lbxShow
            // 
            this.lbxShow.FormattingEnabled = true;
            this.lbxShow.ItemHeight = 12;
            this.lbxShow.Location = new System.Drawing.Point(421, 220);
            this.lbxShow.Name = "lbxShow";
            this.lbxShow.Size = new System.Drawing.Size(495, 160);
            this.lbxShow.TabIndex = 6;
            this.lbxShow.SelectedIndexChanged += new System.EventHandler(this.lbxShow_SelectedIndexChanged);
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(107, 199);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(170, 43);
            this.btnRecord.TabIndex = 7;
            this.btnRecord.Text = "&Record Payment";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click_1);
            // 
            // btnDelet
            // 
            this.btnDelet.Location = new System.Drawing.Point(107, 269);
            this.btnDelet.Name = "btnDelet";
            this.btnDelet.Size = new System.Drawing.Size(170, 43);
            this.btnDelet.TabIndex = 8;
            this.btnDelet.Text = "&Delete Record";
            this.btnDelet.UseVisualStyleBackColor = true;
            this.btnDelet.Click += new System.EventHandler(this.btnDelet_Click);
            // 
            // tbxDate
            // 
            this.tbxDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbxDate.Location = new System.Drawing.Point(567, 65);
            this.tbxDate.Name = "tbxDate";
            this.tbxDate.Size = new System.Drawing.Size(193, 21);
            this.tbxDate.TabIndex = 9;
            // 
            // cbxMethod
            // 
            this.cbxMethod.AllowDrop = true;
            this.cbxMethod.FormattingEnabled = true;
            this.cbxMethod.Items.AddRange(new object[] {
            "Credit Card",
            "Master Card",
            "Cash"});
            this.cbxMethod.Location = new System.Drawing.Point(567, 119);
            this.cbxMethod.Name = "cbxMethod";
            this.cbxMethod.Size = new System.Drawing.Size(193, 20);
            this.cbxMethod.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(418, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "Record Infomation:";
            // 
            // feedbackLabel
            // 
            this.feedbackLabel.AutoSize = true;
            this.feedbackLabel.Location = new System.Drawing.Point(34, 341);
            this.feedbackLabel.Name = "feedbackLabel";
            this.feedbackLabel.Size = new System.Drawing.Size(59, 12);
            this.feedbackLabel.TabIndex = 12;
            this.feedbackLabel.Text = "Feed back";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(746, 408);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(170, 43);
            this.btnExit.TabIndex = 13;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cbRentalId
            // 
            this.cbRentalId.FormattingEnabled = true;
            this.cbRentalId.Location = new System.Drawing.Point(177, 63);
            this.cbRentalId.Margin = new System.Windows.Forms.Padding(2);
            this.cbRentalId.Name = "cbRentalId";
            this.cbRentalId.Size = new System.Drawing.Size(139, 20);
            this.cbRentalId.TabIndex = 23;
            // 
            // Payment_Management
            // 
            this.ClientSize = new System.Drawing.Size(983, 537);
            this.Controls.Add(this.cbRentalId);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.feedbackLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxMethod);
            this.Controls.Add(this.tbxDate);
            this.Controls.Add(this.btnDelet);
            this.Controls.Add(this.btnRecord);
            this.Controls.Add(this.lbxShow);
            this.Controls.Add(this.tbxAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Payment_Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Payment_Management_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void lbxShow_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}