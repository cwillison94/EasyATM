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
    /// Interaction logic for EnterPINPage.xaml
    /// </summary>
    public partial class EnterPINPage : Page
    {
        private int PIN;
        private int accountNumber;
        public EnterPINPage(int account)
        {
            accountNumber = account;
            InitializeComponent();
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password.Length < 4)
            {
                passwordBox.Password = passwordBox.Password + 0;
                if (passwordBox.Password.Length == 4) btnLogin.IsEnabled = true;
            }
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password.Length < 4)
            {
                passwordBox.Password = passwordBox.Password + 1;
                if (passwordBox.Password.Length == 4) btnLogin.IsEnabled = true;
            }
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password.Length < 4)
            {
                passwordBox.Password = passwordBox.Password + 2;
                if (passwordBox.Password.Length == 4) btnLogin.IsEnabled = true;
            }
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password.Length < 4)
            {
                passwordBox.Password = passwordBox.Password + 3;
                if (passwordBox.Password.Length == 4) btnLogin.IsEnabled = true;
            }
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password.Length < 4)
            {
                passwordBox.Password = passwordBox.Password + 4;
                if (passwordBox.Password.Length == 4) btnLogin.IsEnabled = true;
            }
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password.Length < 4)
            {
                passwordBox.Password = passwordBox.Password + 5;
                if (passwordBox.Password.Length == 4) btnLogin.IsEnabled = true;
            }
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password.Length < 4)
            {
                passwordBox.Password = passwordBox.Password + 6;
                if (passwordBox.Password.Length == 4) btnLogin.IsEnabled = true;
            }
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password.Length < 4)
            {
                passwordBox.Password = passwordBox.Password + 7;
                if (passwordBox.Password.Length == 4) btnLogin.IsEnabled = true;
            }
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password.Length < 4)
            {
                passwordBox.Password = passwordBox.Password + 8;
                if (passwordBox.Password.Length == 4) btnLogin.IsEnabled = true;
            }
        }

        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            if (passwordBox.Password.Length < 4)
            {
                passwordBox.Password = passwordBox.Password + 9;
                if (passwordBox.Password.Length == 4) btnLogin.IsEnabled = true;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            btnLogin.IsEnabled = false;
            label.Visibility = Visibility.Hidden;
            if (passwordBox.Password.Length > 0) passwordBox.Password = passwordBox.Password.Remove(passwordBox.Password.Length -1);
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if(passwordBox.Password.Length == 4)
            {
                var clientRequest = ClientAccessManager.Instance.Login(accountNumber);
                if (clientRequest.Success)
                {
                    this.NavigationService.Navigate(new OptionsPage(clientRequest.Client));
                }
                else
                {
                    label.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
