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
    /// Interaction logic for DemonimationControl.xaml
    /// </summary>
    public partial class DenominationControl : UserControl
    {
        public DenominationModifier DenominationModifier
        {
            get { return (DenominationModifier)GetValue(DenominationModifierProperty); }
            set { SetValue(DenominationModifierProperty, value); }
        }

        public static readonly DependencyProperty DenominationModifierProperty =
            DependencyProperty.Register("DenominationModifier", typeof(DenominationModifier),
              typeof(DenominationControl), new PropertyMetadata(OnDenominationModifierPropertyChanged));



        static void OnDenominationModifierPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            (obj as DenominationControl).OnDenominationModifierPropertyChanged(e);
        }

        private void OnDenominationModifierPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
 
        }


        public DenominationControl()
        {
            InitializeComponent();
            this.DenominationTotalLabel.Content = 0;
        }

        private void ButtonIncrement_Click(object sender, RoutedEventArgs e)
        {
            this.DenominationModifier.Increment();
            this.DenominationTotalLabel.Content = this.DenominationModifier.DenominationTotal;
        }

        private void ButtonDecrement_Click(object sender, RoutedEventArgs e)
        {
            this.DenominationModifier.Decrement();
            this.DenominationTotalLabel.Content = this.DenominationModifier.DenominationTotal;
        }


    }
}
