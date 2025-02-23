using AirConditionerShop.BLL.IServices;
using AirConditionerShop.BLL.Services;
using AirConditionerShop.DAL.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AirConditionerShop
{
    /// <summary>
    /// Interaction logic for DetailWindow.xaml
    /// </summary>
    public partial class DetailWindow : Window
    {
        private IAirConService _airConService = new AirConService();
        private ISupplierService _supplierService = new SupplierService();
        public AirConditioner EditedAirCon { get; set; } // flag
        public DetailWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // REMEMBER VALIDATION
            if (!CheckValidation())
                return;

            AirConditioner airCon = new();
            airCon.AirConditionerName = AirConditionerNameTextBox.Text;
            airCon.Warranty = WarrantyTextBox.Text;
            airCon.SoundPressureLevel = SoundPressureLevelTextBox.Text;
            airCon.FeatureFunction = FeatureFunctionTextBox.Text;
            airCon.Quantity = int.Parse(QuantityTextBox.Text);
            airCon.DollarPrice = float.Parse(DollarPriceTextBox.Text);
            airCon.SupplierId = SupplierIdComboBox.SelectedValue.ToString();
            if(EditedAirCon == null)
                _airConService.AddAirCon(airCon);
            else
            {
                airCon.AirConditionerId = int.Parse(AirConditionerIdTextBox.Text); 
                _airConService.UpdateAirCon(airCon);
            } 
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillCombobox();
            FillElements(EditedAirCon);
        }

        private void FillCombobox()
        {
            SupplierIdComboBox.ItemsSource = _supplierService.GetAllSuppliers();
            SupplierIdComboBox.DisplayMemberPath = "SupplierName"; // Display name
            SupplierIdComboBox.SelectedValuePath = "SupplierId"; // Select value Id
        }

        private void FillElements(AirConditioner airCon)
        {   
            AirConditionerIdTextBox.IsEnabled = false;
            if (airCon == null)
            {
                DetailWindowModeLabel.Content = "Create Air Conditioner";
                return;
            }
            else
            {
                DetailWindowModeLabel.Content = "Update Air Conditioner";
                AirConditionerIdTextBox.Text = airCon.AirConditionerId.ToString();
                AirConditionerIdTextBox.IsEnabled = false;
                AirConditionerNameTextBox.Text = airCon.AirConditionerName;
                WarrantyTextBox.Text = airCon.Warranty;
                SoundPressureLevelTextBox.Text = airCon.SoundPressureLevel;
                FeatureFunctionTextBox.Text = airCon.FeatureFunction;
                QuantityTextBox.Text = airCon.Quantity.ToString();
                DollarPriceTextBox.Text = airCon.DollarPrice.ToString();
                SupplierIdComboBox.SelectedValue = airCon.SupplierId;
            }
        }

        private bool CheckValidation()
        {
            if (AirConditionerNameTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("The air conditioner name is required", "Field required", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (WarrantyTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("The warranty is required", "Field required", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (SoundPressureLevelTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("The sound pressure level is required", "Field required", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (FeatureFunctionTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("The feature is required", "Field required", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if(QuantityTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("The quantity is required", "Field required", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                int tmpQuantity;
                bool quantityStatus = int.TryParse(QuantityTextBox.Text, out tmpQuantity); // try to parse from string to int
                                                                                           // -> return int value for tmpQuantity and boolean value for quantityStatus
                                                                                           // true if QuantityTextBox.Text is able to parse, false if
                if (!quantityStatus)
                {
                    MessageBox.Show("Incorrect quantity. Please type an integer!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            if (DollarPriceTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("The price is required", "Field required", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            else
            {
                float tmpPrice;
                bool priceStatus = float.TryParse(DollarPriceTextBox.Text, out tmpPrice); // try to parse from string to int
                                                                                           // -> return int value for tmpQuantity and boolean value for quantityStatus
                                                                                           // true if QuantityTextBox.Text is able to parse, false if
                if (!priceStatus)
                {
                    MessageBox.Show("Incorrect price. Please type a float!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
            if (SupplierIdComboBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("The supplier is required", "Field required", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
