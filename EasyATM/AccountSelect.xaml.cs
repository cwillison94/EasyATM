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
    public enum AccountSelectType
    {
        Withdrawal,
        Deposit
    }
    /// <summary>
    /// Interaction logic for AccountSelect.xaml
    /// </summary>
    public partial class AccountSelect : Page
    {
        private const string WITHDRAWAL_LABEL = "Please Select an Account to Withdraw From:";
        private const string DEPOSIT_LABEL = "Please Select an Account to Deposit To:";

        OptionsPage session;
        private Client client = null;
        private AccountSelectType type;

        public AccountSelect(OptionsPage session, AccountSelectType type)
        {
            InitializeComponent();

            this.session = session;
            this.type = type;
            this.client = session.client;
            this.AccountSelectItemControl.ItemsSource = this.client.ListAccounts();
            SetAccountSelectMessage();
        }

        private void SetAccountSelectMessage()
        {
            switch (this.type)
            {
                case AccountSelectType.Withdrawal:
                    this.AccountSelectLabel.Content = WITHDRAWAL_LABEL;
                    break;
                case AccountSelectType.Deposit:
                    this.AccountSelectLabel.Content = DEPOSIT_LABEL;
                    break;
            }
        }

        private void ButtonSelectAccount_Click(object sender, RoutedEventArgs e)
        {
            var control = (Control)sender;
            var accountNumber = (int)control.Tag;

            switch (this.type)
            {
                case AccountSelectType.Withdrawal:
                    this.NavigationService.Navigate(new Withdrawal(session, accountNumber));
                    break;
                case AccountSelectType.Deposit:
                    //TODO: implement me
                    //this.NavigationService.Navigate(new Deposit(this.client, accountNumber));

                    break;
            }
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(this.session);
        }
    }


}
