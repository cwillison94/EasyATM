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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class WithdrawalConfirmation : Page
    {
        OptionsPage session;
        private EasyBankAccount account;
        private int amount;

        public WithdrawalConfirmation(OptionsPage session, EasyBankAccount account, int amount)
        {
            InitializeComponent();
            this.session = session;
            this.amount = amount;
            label_WithdrawConfirmAmount.Content = "$" + amount.ToString() + " CAD";
            this.account = account;
        }
       
        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ContinuePage(session, this.account.Withdraw(amount), yesHint: "Go back to Main Menu", noHint: "Remove Card and Dispense Cash"));
        }

        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(session);
        }
    }
}
