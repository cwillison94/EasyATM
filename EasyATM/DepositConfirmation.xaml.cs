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
using EasyATM.Service;

namespace EasyATM
{
    /// <summary>
    /// Interaction logic for DepositConfirmation.xaml
    /// </summary>
    public partial class DepositConfirmation : Page
    {
        float amount;
        OptionsPage session;
        int accountNumber;

        public DepositConfirmation(OptionsPage session, float amount, int accountNumber)
        {
            InitializeComponent();
            this.session = session;
            this.amount = amount;
            this.accountNumber = accountNumber;
            this.labelAmount.Content = "$" + amount.ToString() + " CAD";
        }

        private void btnInsertEnv_Click(object sender, RoutedEventArgs e)
        {
            EasyBankAccount account = session.client.GetAccount(accountNumber);
            account.Deposit(amount);
            NavigationService.Navigate(new ContinuePage(session, true, false, "Return to Main Page", "Logout"));
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(session);
        }
    }
}
