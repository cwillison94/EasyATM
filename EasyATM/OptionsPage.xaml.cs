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
    /// Interaction logic for OptionsPage.xaml
    /// </summary>
    public partial class OptionsPage : Page
    {
        public Client client; 

        public OptionsPage(Client client)
        {
            this.client = client;
            InitializeComponent();       
            this.WelcomeMessage.Content = client.WelcomeMessage;

            this.AccountItemControl.ItemsSource = this.client.ListAccounts();
            this.PendingListView.ItemsSource = this.client.ListPendingWithdrawals();

            CheckPendingWithdrawalVisiblity();
        }

        public void NavigateToMe(NavigationService navService)
        {
            this.PendingListView.ItemsSource = this.client.ListPendingWithdrawals();
            this.PendingListView.Items.Refresh();
            CheckPendingWithdrawalVisiblity();
            navService.Navigate(this);
        }

        private void CheckPendingWithdrawalVisiblity()
        {
            if (this.client.HasPendingWidthdrawls)
            {
                this.PendingListView.Visibility = Visibility.Visible;
                this.PendingWithdrawalLabel.Visibility = Visibility.Visible;
            }
            else
            {
                this.PendingListView.Visibility = Visibility.Collapsed;
                this.PendingWithdrawalLabel.Visibility = Visibility.Collapsed;
            }
        }

        private void ButtonViewAccount_Click(object sender, RoutedEventArgs e)
        {
            var control = (Control)sender;
            var accountNumber = (int) control.Tag;
            this.NavigationService.Navigate(new Account(this, this.client, accountNumber));
        }

        private void ButtonFinish_Click(object sender, RoutedEventArgs e)
        {
            if (this.client.HasPendingWidthdrawls)
            {
                this.NavigationService.Navigate(new DispensingCash());
            }
            else
            {
                this.NavigationService.Navigate(new LoginPage());
            }
        }

        private void ButtonWithdrawal_Click(object sender, RoutedEventArgs e)
        {
            // TODO: select account page for withdrawal
            this.NavigationService.Navigate(new AccountSelect(this, AccountSelectType.Withdrawal));
        }

        private void ButtonTransfer_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Transfer(this, this));
        }

        private void ButtonDeposit_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AccountSelect(this, AccountSelectType.Deposit));
        }

        private void ButtonPrint_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PrintAccountSelect(this));
        }

        private void Page_GotFocus(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Got Focus");
        }

        private void Page_Initialized(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Initialized");

        }

        private void Page_LostFocus(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Lost Focus");
        }
    }
}
