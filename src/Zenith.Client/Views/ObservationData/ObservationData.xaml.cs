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

namespace Zenith.Client.Views
{
    public partial class ObservationData : UserControl
    {
        public ObservationData()
        {
            InitializeComponent();
            this.Loaded += ObservationData_Loaded;
        }

        private void ObservationData_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        //private void ItemName_MouseEnter(object sender, MouseEventArgs e)
        //{
        //    TextBox textBlock = (TextBox)sender;
        //    textBlock.Background = Brushes.LightSteelBlue;
        //}

        //private void ItemName_MouseLeave(object sender, MouseEventArgs e)
        //{
        //    TextBox textBlock = (TextBox)sender;
        //    textBlock.Background = Brushes.Transparent;
        //}
    }
}
