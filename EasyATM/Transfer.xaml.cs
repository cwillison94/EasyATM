using EasyATM.Models;
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
    /// Interaction logic for Transfer.xaml
    /// </summary>
    public partial class Transfer : Page
    {
        private const string SELECT_ACCOUNT_MESSAGE = "Select an Account";
        private OptionsPage session;

        private EasyBankAccount selectedToAccount;
        private EasyBankAccount selectedFromAccount;

        public Transfer(OptionsPage session, EasyBankAccount selectedFromAccount = null, EasyBankAccount selectedToAccount = null)
        {
            InitializeComponent();
            this.session = session;

            this.selectedFromAccount = selectedFromAccount;
            this.selectedToAccount = selectedToAccount;

            if (this.selectedFromAccount != null)
                this.SelectFromAccountLabel.Content = this.selectedFromAccount.ToString();

            if (this.selectedToAccount != null)
                this.SelectToAccountLabel.Content = this.selectedToAccount.ToString();

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


            if (this.selectedFromAccount == this.selectedToAccount)
            {
                ResetToAccount();
            }
            else if (this.selectedFromAccount == null)
            {
                this.AccountSelectFromItemControl.ItemsSource = accountsCopy;
                this.AccountSelectFromItemControl.Items.Refresh();

                this.AccountSelectToItemControl.ItemsSource = accountsCopy;
                this.AccountSelectToItemControl.Items.Refresh();
            }

            CheckTransferEnable();
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

            if (this.selectedFromAccount == this.selectedToAccount)
            {
                ResetFromAccount();
            }
            else if (this.selectedToAccount == null)
            {
                this.AccountSelectFromItemControl.ItemsSource = accountsCopy;
                this.AccountSelectFromItemControl.Items.Refresh();

                this.AccountSelectToItemControl.ItemsSource = accountsCopy;
                this.AccountSelectToItemControl.Items.Refresh();
            }

            CheckTransferEnable();
        }


        private void ResetFromAccount()
        {
            this.selectedFromAccount = null;
            this.SelectFromAccountLabel.Content = SELECT_ACCOUNT_MESSAGE;
            this.AccountSelectFromItemControl.ItemsSource = this.session.client.ListAccounts();
            this.AccountSelectFromItemControl.Items.Refresh();
        }

        private void ResetToAccount()
        {
            this.selectedToAccount = null;
            this.SelectToAccountLabel.Content = SELECT_ACCOUNT_MESSAGE;
            this.AccountSelectToItemControl.ItemsSource = this.session.client.ListAccounts();
            this.AccountSelectToItemControl.Items.Refresh();
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            InputBuilder("0");
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            InputBuilder("1");
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            InputBuilder("2");
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            InputBuilder("3");
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            InputBuilder("4");
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            InputBuilder("5");
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            InputBuilder("6");
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            InputBuilder("7");
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            InputBuilder("8");
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            InputBuilder("9");
        }

        private void btnDot_Click(object sender, RoutedEventArgs e)
        { 
           InputBuilder(".");
        }

        private void InputBuilder(string input)
        {
            var currentAmountText = this.TransferAmountTextBox.Text;

            if (currentAmountText.Contains("."))
            {
                var splitAmount = currentAmountText.Split('.');

                if (splitAmount[1].Length < 2)
                {
                    this.TransferAmountTextBox.Text += input;
                }
            }
            else
            {
                this.TransferAmountTextBox.Text += input;
            }
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

            //this.NavigationService.Navigate(this.session);
        }

        private void ButtonTransfer_Click(object sender, RoutedEventArgs e)
        {
            var transferAmount = GetTransferAmount();
            this.NavigationService.Navigate(new TransferConfirmation(this.session, this, this.selectedFromAccount, this.selectedToAccount, transferAmount));
        }

        private float GetTransferAmount()
        {
            // TODO: implement better form checking
            float amount;
            float.TryParse(this.TransferAmountTextBox.Text, out amount);

            return amount;
        }

        private void TransferAmountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckTransferEnable();

            var amountText = TransferAmountTextBox.Text;
            if (amountText.Contains(".")) this.ButtonDot.IsEnabled = false;
            else this.ButtonDot.IsEnabled = true;
        }

        private void CheckTransferEnable()
        {
            var amountText = TransferAmountTextBox.Text;
            if (amountText.Length != 0 && this.selectedToAccount != null && this.selectedFromAccount != null)
            {
                this.ButtonTransfer.IsEnabled = true;
            }
        }
    }
}
