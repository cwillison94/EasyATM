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
    /// Interaction logic for TransferConfirmation.xaml
    /// </summary>
    public partial class TransferConfirmation : Page
    {
        private OptionsPage session;
        private EasyBankTransfer transfer;

        public TransferConfirmation(OptionsPage session, EasyBankTransfer transfer)
        {
            InitializeComponent();
            this.transfer = transfer;
            this.session = session;

            this.AcceptTransferLabel.Content = this.transfer.TransferMessage;
        }

        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ContinuePage(this.session, this.transfer.Transfer()));
        }

        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
