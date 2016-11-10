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
        int decimalPostitions;
        bool decimalState;
        OptionsPage session;
        int accountNumber;

        public DepositPage(OptionsPage session, int accountNumber)
        {
            this.session = session;
            this.accountNumber = accountNumber;
            InitializeComponent();

        }
        private void updateDepositAmount(string i)
        {
          if(decimalState && decimalPostitions < 2)
          {
              decimalPostitions ++;
              DepositAmount.Text = DepositAmount.Text + i;
          }
          else if (!decimalState && DepositAmount.Text.Length < 7)
          {
              DepositAmount.Text = DepositAmount.Text + i;
          }
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            updateDepositAmount("0");
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            updateDepositAmount("1");
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            updateDepositAmount("2");
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            updateDepositAmount("3");
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            updateDepositAmount("4");
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            updateDepositAmount("5");
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            updateDepositAmount("6");
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            updateDepositAmount("7");
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            updateDepositAmount("8");
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            updateDepositAmount("9");
        }

        private void btnDecimal_Click(object sender, RoutedEventArgs e)
        {

            if (DepositAmount.Text.Length < 7)
            {
                DepositAmount.Text = DepositAmount.Text + ".";
                btnDecimal.IsEnabled = false;
                decimalState = true;
                decimalLocation = DepositAmount.Text.Length - 1;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            int pos = DepositAmount.Text.Length - 1;
            if (decimalPostitions > 0) decimalPostitions--;
            if (DepositAmount.Text.Length > 0) DepositAmount.Text = DepositAmount.Text.Remove(pos);
            if (pos == decimalLocation)
            {
                btnDecimal.IsEnabled = true;
                decimalLocation = -1;
                decimalState = false;
            }
        }

        private void buttonAccept_Click(object sender, RoutedEventArgs e)
        {
            float depositAmount;

            if (float.TryParse(DepositAmount.Text, out depositAmount))
            {
                NavigationService.Navigate(new DepositConfirmation(session, depositAmount, accountNumber));
            }          
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(session);
        }
    }
}
