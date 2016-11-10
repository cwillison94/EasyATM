using EasyATM.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Account : Page
    {
        private EasyBankAccount selectedAccount = null;
        private Client selectedClient = null;
        private OptionsPage session;

        public Account(OptionsPage session, Client client, int accountNumber)
        {
            InitializeComponent();
            this.session = session;
            this.selectedClient = client;
            this.selectedAccount = client.ListAccounts().First(x => x.AccountNumber == accountNumber);
            this.AccountMessage.Content = this.selectedAccount.Type + " - " + this.selectedAccount.AccountNumber;
            this.BalanceLabel.Content = this.selectedAccount.BalanceFormatted;
            this.HistoryListView.ItemsSource = this.selectedAccount.ListTransactionHistory();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new OptionsPage(this.selectedClient));
        }

        private void ButtonDeposit_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DepositPage(this.session, this.selectedAccount.AccountNumber));
        }

        private void ButtonWithdraw_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Withdrawal(this.session, this, this.selectedAccount.AccountNumber));
        }

        private void ButtonTransferTo_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Transfer(this.session,this, selectedToAccount: this.selectedAccount));
        }

        private void ButtonTransferFrom_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Transfer(this.session, this, selectedFromAccount: this.selectedAccount));
        }
    }
}
