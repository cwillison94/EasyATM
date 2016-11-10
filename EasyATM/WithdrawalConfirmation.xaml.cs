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
        private Page previousPage;

        public WithdrawalConfirmation(OptionsPage session, Page previousPage, EasyBankAccount account, int amount)
        {
            InitializeComponent();
            this.session = session;
            this.previousPage = previousPage;
            this.amount = amount;
            this.account = account;

            label_WithdrawConfirmAmount.Content = this.amount.ToString("C") + " FROM " + this.account.ToString();

        }
       
        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ContinuePage(session, this.account.Withdraw(amount), withdrawRequired: true, yesHint: "Go back to Main Menu", noHint: "Logout and Dispense Cash"));
        }

        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(this.previousPage);
        }
    }
}
