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
        private Client client; 
        public OptionsPage(Client client)
        {
            this.client = client;
            InitializeComponent();
       
            this.WelcomeMessage.Content = client.WelcomeMessage;

            this.AccountItemControl.ItemsSource = this.client.ListAccounts();

        }
    }
}
