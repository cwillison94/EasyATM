using EasyATM.Models;
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

namespace EasyATM
{
    /// <summary>
    /// Interaction logic for Transfer.xaml
    /// </summary>
    public partial class Transfer : Page
    {
        private OptionsPage session;

        private EasyBankAccount selectedToAccount;
        private EasyBankAccount selectedFromAccount;

        public Transfer(OptionsPage session)
        {
            InitializeComponent();
            this.session = session;

            this.AccountSelectToItemControl.ItemsSource = this.session.client.ListAccounts();
            this.AccountSelectFromItemControl.ItemsSource = this.session.client.ListAccounts();
        }

        private void ButtonSelectAccountFrom_Click(object sender, RoutedEventArgs e)
        {
            var control = (Control)sender;
            var accountNumber = (int)control.Tag;
            
            // set selected from account
            var account = this.session.client.GetAccount(accountNumber);
            this.selectedFromAccount = account;
            this.SelectFromAccountLabel.Content = this.selectedFromAccount.ToString();

            // remove selected account to list
            var accounts = this.session.client.ListAccounts();
            var accountsCopy = new List<EasyBankAccount>(accounts);
            accountsCopy.RemoveAll(x => x.AccountNumber == accountNumber);

            if (this.selectedToAccount == null)
            {
                this.AccountSelectToItemControl.ItemsSource = accountsCopy;
                this.AccountSelectToItemControl.Items.Refresh();
            }
            
        }

        private void ButtonSelectAccountTo_Click(object sender, RoutedEventArgs e)
        {
            var control = (Control)sender;
            var accountNumber = (int)control.Tag;

            // set selected from account
            var account = this.session.client.GetAccount(accountNumber);
            this.selectedToAccount = account;
            this.SelectToAccountLabel.Content = this.selectedToAccount.ToString();

            // remove selected account to list
            var accounts = this.session.client.ListAccounts();
            var accountsCopy = new List<EasyBankAccount>(accounts);
            accountsCopy.RemoveAll(x => x.AccountNumber == accountNumber);

            if (this.selectedFromAccount == null)
            {
                this.AccountSelectFromItemControl.ItemsSource = accountsCopy;
                this.AccountSelectFromItemControl.Items.Refresh();
            }
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            this.TransferAmountTextBox.Text = this.TransferAmountTextBox.Text + "0";
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            this.TransferAmountTextBox.Text = this.TransferAmountTextBox.Text + "1";
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            this.TransferAmountTextBox.Text = this.TransferAmountTextBox.Text + "2";
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            this.TransferAmountTextBox.Text = this.TransferAmountTextBox.Text + "3";
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            this.TransferAmountTextBox.Text = this.TransferAmountTextBox.Text + "4";
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            this.TransferAmountTextBox.Text = this.TransferAmountTextBox.Text + "5";
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            this.TransferAmountTextBox.Text = this.TransferAmountTextBox.Text + "6";
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            this.TransferAmountTextBox.Text = this.TransferAmountTextBox.Text + "7";
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            this.TransferAmountTextBox.Text = this.TransferAmountTextBox.Text + "8";
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            this.TransferAmountTextBox.Text = this.TransferAmountTextBox.Text + "9";
        }

        private void btnDot_Click(object sender, RoutedEventArgs e)
        {
            this.TransferAmountTextBox.Text = this.TransferAmountTextBox.Text + ".";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            var transferAmountText = this.TransferAmountTextBox.Text;
            if (transferAmountText.Length != 0)
            {
                this.TransferAmountTextBox.Text = transferAmountText.Substring(0, transferAmountText.Length - 1);
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(this.session);
        }
    }
}
