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
    /// Interaction logic for PrintAccountSelect.xaml
    /// </summary>
    public partial class PrintAccountSelect : Page
    {
        OptionsPage session;
        List<int> selectedAccounts;
        public PrintAccountSelect(OptionsPage session)
        {
            InitializeComponent();
            this.session = session;
            this.AccountSelectItemControl.ItemsSource = session.client.ListAccounts();
        }

        private void CheckBoxSelectAccount_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PrintAccounts(this.session, selectedAccounts));
        }
    }
}
