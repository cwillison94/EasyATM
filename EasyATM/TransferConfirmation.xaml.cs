﻿using EasyATM.Models;
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
        private EasyBankAccount fromAccount;
        private EasyBankAccount toAccount;
        private Transfer transferSession;
        private float transferAmount;

        public TransferConfirmation(OptionsPage session, Transfer transferSession, EasyBankAccount fromAccount, EasyBankAccount toAccount, float transferAmount)
        {
            InitializeComponent();

            this.session = session;
            this.transferSession = transferSession;
            this.fromAccount = fromAccount;
            this.toAccount = toAccount;
            this.transferAmount = transferAmount;

            this.AcceptTransferLabel.Content = this.transferAmount.ToString("C") + " FROM " + this.fromAccount.ToString() + " TO " + this.toAccount.ToString();
        }

        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ContinuePage(this.session, this.fromAccount.TransferTo(this.toAccount, this.transferAmount), yesHint: "Go back to Main Menu", noHint: "Logout"));
        }

        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(this.transferSession);
        }
    }
}
