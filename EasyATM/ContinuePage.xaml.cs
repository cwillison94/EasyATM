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
    /// Interaction logic for ContinuePage.xaml
    /// </summary>
    public partial class ContinuePage : Page
    {
        private OptionsPage session;

        public ContinuePage(OptionsPage session, bool success)
        {
            InitializeComponent();
            this.session = session;
            if (success)
            {
                this.label.Content = "Transaction Successful!";
                this.label.Background = Brushes.DeepSkyBlue;
            }
            else
            {
                this.label.Content = "Insufficient Funds, Sorry.";
                this.label.Background = Brushes.Red;
            }
        }

        private void ButtonComplete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAnotherTransaction_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(session);
        }
    }
}
