using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for DispensingCash.xaml
    /// </summary>
    public partial class DispensingCash : Page
    {

        public DispensingCash()
        {
            InitializeComponent();
            StateTracker.Instance.CurrentPage = this;
        }

        private void ButtonHumanAction_Click(object sender, RoutedEventArgs e)
        {
            // cash grabbed
            this.NavigationService.Navigate(new LoginPage());
        }
    }
}
