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

        }

        private void ButtonViewAccount_Click(object sender, RoutedEventArgs e)
        {
            var control = (Control)sender;
            var accountNumber = (int) control.Tag;
            this.NavigationService.Navigate(new Account(this, this.client, accountNumber));
        }

        private void ButtonFinish_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LoginPage());
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AccountSelect(this, AccountSelectType.Deposit));
        }
    }
}
