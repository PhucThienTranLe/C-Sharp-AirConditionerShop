using AirConditionerShop.BLL.IServices;
using AirConditionerShop.BLL.Services;
using AirConditionerShop.DAL.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AirConditionerShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IAirConService _airConService = new AirConService();
        public StaffMember CurrentAccount { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
            HelloMsgLabel.Content = "Hello " + CurrentAccount.FullName; 
            // Check role to authorize
            if(CurrentAccount.Role == 2) // role Staff
            {
                CreateButton.IsEnabled = false;
                UpdateButton.IsEnabled = false;
                DeleteButton.IsEnabled = false;
            }
        }
        private void FillDataGrid()
        {
            AirConsDataGrid.ItemsSource = null; // delete all gird item
            AirConsDataGrid.ItemsSource = _airConService.GetAllAirCons();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            DetailWindow detailWindow = new();
            detailWindow.ShowDialog();
            // Check If any data was changed, reload gird
            FillDataGrid();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            AirConditioner? selectedAirCon = AirConsDataGrid.SelectedItem as AirConditioner;
            if (selectedAirCon == null)
            {
                MessageBox.Show("Please select a row before editing", "Select a row", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }
            
            DetailWindow detailWindow = new();
            detailWindow.EditedAirCon = selectedAirCon;
            detailWindow.ShowDialog();
            FillDataGrid();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            AirConditioner? selectedAirCon = AirConsDataGrid.SelectedItem as AirConditioner;
            if (selectedAirCon == null)
            {
                MessageBox.Show("Please select a row before delecting", "Select a row", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return;
            }

            MessageBoxResult answer = MessageBox.Show("Are you sure about deleting this row", "Confirm?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.No)
               return;

            _airConService.DeleteAirCon(selectedAirCon);
            FillDataGrid();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string feature = FeatureFunctionTextBox.Text;
            //Validate Quantity
            int? quantity = null;
            int tmpQuantity;
            bool quantityStatus = int.TryParse(QuantityTextBox.Text, out tmpQuantity); // try to parse from string to int
                                                                                       // -> return int value for tmpQuantity and boolean value for quantityStatus
                                                                                       // true if QuantityTextBox.Text is able to parse, false if not
            if (!quantityStatus && !QuantityTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Incorrect quantity. Please type an integer!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if(quantityStatus == true) quantity = tmpQuantity;
            var result = _airConService.SearchAirConByFeatureAndQuantity(feature, quantity);
            AirConsDataGrid.ItemsSource = null; // delete all gird item
            AirConsDataGrid.ItemsSource = result;
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}