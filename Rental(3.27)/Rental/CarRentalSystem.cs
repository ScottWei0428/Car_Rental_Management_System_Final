using DAL;
using DAL.Entitys;
using management_system;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Rental
{
    public partial class CarRentalSystem : Form
    {
        private Dictionary<Control, ErrorProvider> errorProviders;

        public CarRentalSystem()
        {
            InitializeComponent();

            this.BackgroundImage = Properties.Resources.CarRentalSystemimage;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.MouseClick += Form1_MouseClick;
            this.Load += CarRentalSystem_Load;

            errorProviders = new Dictionary<Control, ErrorProvider> {
            { cbCustomerID, new ErrorProvider() },
            { cbxCarID, new ErrorProvider() },
            { dtpEndDate, new ErrorProvider() },
            { dtpStartDate, new ErrorProvider() }
        };

            LSVStatus.Columns.Add("Cars", -2, HorizontalAlignment.Left);
            LSVStatus.Columns.Add("Status", -2, HorizontalAlignment.Left);
            LSVStatus.Columns.Add("Details", -2, HorizontalAlignment.Left);

            PopulateCarList();
            UpdateCarStatusListView();
        }

        private void UpdateCarStatusListView()
        {
            LSVStatus.Items.Clear();
            foreach (var car in RentalDB.GetCars())
            {
                var item = new ListViewItem(car.CarID);
                item.SubItems.Add(car.Model);
                string status = car.Status.Equals("available", StringComparison.OrdinalIgnoreCase) ? "Available" : "Unavailable";
                item.SubItems.Add(status);

                LSVStatus.Items.Add(item);
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!cbCustomerID.Bounds.Contains(e.Location) && !cbxCarID.Bounds.Contains(e.Location))
            {
                lbxCarList.ClearSelected();
            }
            this.Focus();
        }

        private void btnRentCar_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Invalid Information. Please review your input.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string customerID = cbCustomerID.Text;
            string carID = cbxCarID.Text;
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;

            int successId = RentalDB.RentCar(customerID, carID, startDate, endDate);
            if (successId > 0)
            {
                MessageBox.Show("Car rental successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string rentalInfo = $"Rented | Rental ID: {successId}, Car ID: {carID}, Customer ID: {customerID}, Start: {startDate.ToShortDateString()}, End: {endDate.ToShortDateString()}";
                lbxInfo.Items.Add(rentalInfo);
                PopulateCarList();
                UpdateCarStatusListView();
            }
            else
            {
                MessageBox.Show($"The selected car ({carID}) has already been rented out.", "Car Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            UpdateCarStatusListView();
        }

        private bool ValidateInput()
        {
            bool isValid = true;


            if (string.IsNullOrWhiteSpace(cbCustomerID.Text))
            {
                errorProviders[cbCustomerID].SetError(cbCustomerID, "Please enter Customer ID.");
                isValid = false;
            }
            else
            {
                errorProviders[cbCustomerID].SetError(cbCustomerID, "");
            }

            if (string.IsNullOrWhiteSpace(cbxCarID.Text))
            {
                errorProviders[cbxCarID].SetError(cbxCarID, "Please enter Vehicle ID.");
                isValid = false;
            }
            else
            {
                errorProviders[cbxCarID].SetError(cbxCarID, "");
            }

            if (dtpEndDate.Value <= dtpStartDate.Value)
            {
                errorProviders[dtpEndDate].SetError(dtpEndDate, "End Date must be later than Start Date.");
                isValid = false;
            }
            else
            {
                errorProviders[dtpEndDate].SetError(dtpEndDate, "");
            }

            if (dtpStartDate.Value == DateTime.MinValue)
            {
                errorProviders[dtpStartDate].SetError(dtpStartDate, "Please select Start Date.");
                isValid = false;
            }
            else
            {
                errorProviders[dtpStartDate].SetError(dtpStartDate, "");
            }
            return isValid;
        }


   
        private void tbxCustomerID_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxCarID_TextChanged(object sender, EventArgs e)
        {
            string searchText = cbxCarID.Text.Trim().ToLower();

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                using (var dbContext = new CarRentalDbContext())
                {
                    lbxCarList.Items.Clear();
                    List<Car> cars = dbContext.Cars.ToList();
                    foreach (Car car in cars) {
                        lbxCarList.Items.Add($"{car.Model}");
                    }
                    
                }
            }
            else
            {
                PopulateCarList(); 
            }
        }
        private void PopulateCarList()
        {
            lbxCarList.Items.Clear();
            foreach (var car in RentalDB.GetCars())
            {

                lbxCarList.Items.Add($"{car.Model}-{car.Brand}-{car.Year}-{car.Price}-{car.Status}-{car.CarID}");
            }
        }
        private void lblCustomerID_Click(object sender, EventArgs e)
        {

        }

        private void lblCarID_Click(object sender, EventArgs e)
        {

        }

        private void lblStartDate_Click(object sender, EventArgs e)
        {

        }

        private void lblEndDate_Click(object sender, EventArgs e)
        {

        }
        private void lbxCarList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxCarList.SelectedItem != null)
            {
                string selectedCar = lbxCarList.SelectedItem.ToString();

                string carInfo = GetCarInfo(selectedCar);
                lbxVehicleInformation.Items.Clear();
                lbxVehicleInformation.Items.Add(carInfo);
            }
        }

        private string GetCarInfo(string car)
        {
            string[] carParts = car.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

            string carName = carParts[0].Trim();
            string brand = carParts[1].Trim();
            string year = carParts[2].Trim();
            string price = carParts[3].Trim();
            string status = carParts[4].Trim();
            string carId = GetCarId(carName);
            cbxCarID.SelectedValue = carName;

            return $"Model: {carName}, Brand: {brand}, Year: {year}, Price: {price}, Status: {status}, CarID: {carId}";
        }

        private string GetCarId(string carInfo)
        {
            string[] carParts = carInfo.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            string carName = carParts[0].Trim();

            switch (carName)
            {
                case "Accord":
                    return "01";
                case "Mustang":
                    return "02";
                case "Camry":
                    return "03";
                case "Sonata":
                    return "04";
                case "Wrangler":
                    return "05";
                default:
                    return "Unknown";
            }
        }

        private void btnReturnCar_Click(object sender, EventArgs e)
        {
            string carID = cbxCarID.Text;
            string customerID = cbCustomerID.Text;
            int rentalID = FindRentalIDByCarID(carID);

            bool success = RentalDB.ReturnCar(carID, customerID);
            if (success)
            {
                MessageBox.Show("Car returned successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                string returnInfo = $"Returned | Rental ID: {rentalID}, Car ID: {carID}, Customer ID: {customerID}";
                lbxInfo.Items.Add(returnInfo);
                UpdateCarStatusListView();
                PopulateCarList();
            }
            else
            {
                MessageBox.Show("Unable to return the car. It may not be rented out.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private int FindRentalIDByCarID(string carID)
        {
            return 0;
        }


        private void dtpStartDate_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void dtpEndDate_ValueChanged_1(object sender, EventArgs e)
        {
        }

        private void lblPopularmodels_Click(object sender, EventArgs e)
        {

        }
        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblVehicleInformation_Click(object sender, EventArgs e)
        {

        }

        private void lbxVehicleInformation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LSVStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblRentalID_Click(object sender, EventArgs e)
        {

        }

        private void tbxRentalID_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbxInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxCarID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCarID = cbxCarID.SelectedItem?.ToString();
            if (!string.IsNullOrWhiteSpace(selectedCarID))
            {
                
                var car = RentalDB.GetCar(selectedCarID);
                if (car != null)
                {
                    
                    lbxVehicleInformation.Items.Clear();
                    lbxVehicleInformation.Items.Add(car.Model);
                }
            }
        }
        private void PopulateCarIdComboBox()
        {
            cbxCarID.Items.Clear(); 

         
            foreach (var car in RentalDB.GetCars())
            {
                cbxCarID.Items.Add(car.CarID);
            }

            // 可选：默认选中第一个选项
            if (cbxCarID.Items.Count > 0)
            {
                cbxCarID.SelectedIndex = 0;
            }
        }

        private void loadCustomerIDComboBox()
        {
            cbCustomerID.Items.Clear();

            foreach (var customer in RentalDB.GetCustomers())
            {
                cbCustomerID.Items.Add(customer.Id);
            }

            if (cbCustomerID.Items.Count > 0)
            {
                cbCustomerID.SelectedIndex = 0;
            }
        }

        

        private void CarRentalSystem_Load(object sender, EventArgs e)
        {
            PopulateCarIdComboBox(); 
            loadCustomerIDComboBox();
        }
    }
}

