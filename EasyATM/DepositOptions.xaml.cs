﻿using System;
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
    /// Interaction logic for DepositOptions.xaml
    /// </summary>
    public partial class DepositOptions : Page
    {
        OptionsPage session;
        int accountNumber;

        public DepositOptions(OptionsPage session, int accountNumber)
        {
            this.session = session;
            this.accountNumber = accountNumber;
            InitializeComponent();

            StateTracker.Instance.CurrentPage = this;
        }

        private void btnCash_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DepositPage(session, accountNumber));
        }

        private void btnCheque_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DepositPage(session, accountNumber));
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(StateTracker.Instance.PreviousPage);
        }
    }
}
