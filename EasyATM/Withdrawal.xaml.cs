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
    /// Interaction logic for Withdrawal.xaml
    /// </summary>
    public partial class Withdrawal : Page
    {
        private int TotalValue
        {
            get
            {
                return count_5 * 5 + count_10 * 10 + count_20 * 20 + count_50 * 50 + count_100 * 100;
            }
        }

        private Client client = null;
        private EasyBankAccount account = null;
        private int count_5;
        private int count_10;
        private int count_20;
        private int count_50;
        private int count_100;

        public Withdrawal(Client client, int accountNumber)
        {
            InitializeComponent();

            this.client = client;
            this.account = client.GetAccount(accountNumber);
            this.AccountMessageLabel.Content = this.client.FullName + " : " + this.account.ToString();

            count_5 = 0;
            count_10 = 0;
            count_20 = 0;
            count_50 = 0;
            count_100 = 0;
        }

        private void refreshTotalCount()
        {
            countTotal.Content = this.TotalValue.ToString("C");
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new OptionsPage(this.client));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void increment5_Click(object sender, RoutedEventArgs e)
        {
            if (count_5 < 20) count_5++;
            countNotes5.Content = count_5;
            refreshTotalCount();
        }

        private void decrement5_Click(object sender, RoutedEventArgs e)
        {
            if (count_5 > 0) count_5--;
            countNotes5.Content = count_5;
            refreshTotalCount();
        }

        private void increment10_Click(object sender, RoutedEventArgs e)
        {
            if (count_10 < 20) count_10++;
            countNotes10.Content = count_10;
            refreshTotalCount();
        }

        private void decrement10_Click(object sender, RoutedEventArgs e)
        {
            if (count_10 > 0) count_10--;
            countNotes10.Content = count_10;
            refreshTotalCount();
        }

        private void increment20_Click(object sender, RoutedEventArgs e)
        {
            if (count_20 < 20) count_20++;
            countNotes20.Content = count_20;
            refreshTotalCount();
        }

        private void decrement20_Click(object sender, RoutedEventArgs e)
        {
            if (count_20 > 0) count_20--;
            countNotes20.Content = count_20;
            refreshTotalCount();
        }

        private void increment50_Click(object sender, RoutedEventArgs e)
        {
            if (count_50 < 20) count_50++;
            countNotes50.Content = count_50;
            refreshTotalCount();
        }

        private void decrement50_Click(object sender, RoutedEventArgs e)
        {
            if (count_50 > 0) count_50--;
            countNotes50.Content = count_50;
            refreshTotalCount();
        }

        private void buttonAccept_Click(object sender, RoutedEventArgs e)
        {
            this.account.Withdraw(this.TotalValue);
            resetCounts();
            this.NavigationService.Navigate(new OptionsPage(this.client));
            // TODO: Implenent continue page
            //this.NavigationService.Navigate(new ContinuePage(this.client));
        }

        private void resetCounts()
        {
            count_5 = 0;
            count_10 = 0;
            count_20 = 0;
            count_50 = 0;
            count_100 = 0;

            countNotes5.Content = count_5;
            countNotes10.Content = count_10;
            countNotes20.Content = count_20;
            countNotes50.Content = count_50;

            refreshTotalCount();
        }

        private void buttonReset_Click(object sender, RoutedEventArgs e)
        {
            resetCounts();
        }
    }
}