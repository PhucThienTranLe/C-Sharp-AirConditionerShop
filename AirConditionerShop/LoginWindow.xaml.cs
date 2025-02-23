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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private IStaffMemberService _staffMemberService = new StaffMemberService();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //Validate email and password not null
            if (EmailAddressTextBox.Text.IsNullOrEmpty() || PasswordTextBox.Password.IsNullOrEmpty()) 
            {
                MessageBox.Show("Emaill and password are required!", "Required fields", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            StaffMember? member = _staffMemberService.Authenticate(EmailAddressTextBox.Text, PasswordTextBox.Password);
            if (member == null) 
            {
                MessageBox.Show("Invalid emaill or password", "Wrong credentials", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if(member.Role == 3)
            {
                MessageBox.Show("You have no permission to access this function", "Access denied", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            } 

            MainWindow main = new MainWindow();
            main.CurrentAccount = member;
            main.ShowDialog();
            this.Hide();
        }
    }
}
