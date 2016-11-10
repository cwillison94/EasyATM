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
    /// Interaction logic for PrintAccounts.xaml
    /// </summary>
    public partial class PrintAccounts : Page
    {
        OptionsPage session;

        public PrintAccounts(OptionsPage session)
        {
            InitializeComponent();
            this.session = session;
        }

        private void btnRemovePrint_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(session);
        }
    }
}
