using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EasyATM
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            AccountNumber.Text = "------";
        }

        private void updateAccountNumber(string i)
        {
            if (AccountNumber.Text[0] == '-')
            {
                AccountNumber.Text = AccountNumber.Text.Remove(0, 1);
                AccountNumber.Text = AccountNumber.Text + i;
            }
            if (AccountNumber.Text[0] != '-') btnLogin.IsEnabled = true;
            else btnLogin.IsEnabled = false;
        }

        private void AccountNumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            // Validate account number text box is valid
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            updateAccountNumber("0");
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            updateAccountNumber("1");
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            updateAccountNumber("2");
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            updateAccountNumber("3");
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            updateAccountNumber("4");
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            updateAccountNumber("5");
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            updateAccountNumber("6");
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            updateAccountNumber("7");
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            updateAccountNumber("8");
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            updateAccountNumber("9");
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var accountNumber = AccountNumber.Text;
            if (accountNumber.Length != 0)
            {
                AccountNumber.Text = accountNumber.Substring(0, accountNumber.Length - 1);
                AccountNumber.Text = AccountNumber.Text.Insert(0, "-");
            }
            btnLogin.IsEnabled = false;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            int accountNumber;

            if (int.TryParse(AccountNumber.Text, out accountNumber))
            {
                NavigationService.Navigate(new EnterPINPage(accountNumber));
            }
            else
            {
                // TODO: Handle parsing error - shouldn't happen
            }
        }

        private void AccountNumber_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnSwipeCard_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EnterPINPage(123456));
        }
    }
}
