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
using System.Windows.Navigation;
using System.Windows.Shapes;
using EasyATM.Models;

namespace EasyATM
{
    /// <summary>
    /// Interaction logic for DepositPage.xaml
    /// </summary>
    public partial class DepositPage : Page
    {
        int decimalLocation;
        OptionsPage session;
        int accountNumber;

        public DepositPage(OptionsPage session, int accountNumber)
        {
            this.session = session;
            this.accountNumber = accountNumber;
            InitializeComponent();
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            if (DepositAmount.Text.Length < 7) DepositAmount.Text = DepositAmount.Text + "0";
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if (DepositAmount.Text.Length < 7) DepositAmount.Text = DepositAmount.Text + "1";
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            if (DepositAmount.Text.Length < 7) DepositAmount.Text = DepositAmount.Text + "2";
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            if (DepositAmount.Text.Length < 7) DepositAmount.Text = DepositAmount.Text + "3";
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            if (DepositAmount.Text.Length < 7) DepositAmount.Text = DepositAmount.Text + "4";
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            if (DepositAmount.Text.Length < 7) DepositAmount.Text = DepositAmount.Text + "5";
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            if (DepositAmount.Text.Length < 7) DepositAmount.Text = DepositAmount.Text + "6";
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            if (DepositAmount.Text.Length < 7) DepositAmount.Text = DepositAmount.Text + "7";
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            if (DepositAmount.Text.Length < 7) DepositAmount.Text = DepositAmount.Text + "8";
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            if (DepositAmount.Text.Length < 7) DepositAmount.Text = DepositAmount.Text + "9";
        }

        private void btnDecimal_Click(object sender, RoutedEventArgs e)
        {
            if (DepositAmount.Text.Length < 7) DepositAmount.Text = DepositAmount.Text + ".";
            btnDecimal.IsEnabled = false;
            decimalLocation = DepositAmount.Text.Length - 1;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            int pos = DepositAmount.Text.Length - 1;
            if (DepositAmount.Text.Length > 0) DepositAmount.Text = DepositAmount.Text.Remove(pos);
            if (pos == decimalLocation)
            {
                btnDecimal.IsEnabled = true;
                decimalLocation = -1;
            }
        }

        private void buttonAccept_Click(object sender, RoutedEventArgs e)
        {
            float depositAmount;

            if (float.TryParse(DepositAmount.Text, out depositAmount))
            {
                EasyBankAccount account = session.client.GetAccount(accountNumber);
                account.Deposit(depositAmount);
            }
            NavigationService.Navigate(new ContinuePage(session, true));
        }
    }
}
