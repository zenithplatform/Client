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
using Zenith.UI.Tests.ViewModel;

namespace Zenith.UI.Tests.Views
{
    /// <summary>
    /// Interaction logic for TempView.xaml
    /// </summary>
    public partial class TempView : UserControl
    {
        NavbarViewModel _strip = null;

        public TempView()
        {
            InitializeComponent();
        }

        public TempView(NavbarViewModel strip)
            :this()
        {
            this._strip = strip;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_strip != null)
                _strip.IsVisible = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (_strip != null)
                _strip.IsVisible = false;
        }
    }
}
