using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Zenith.UI.Tests.Controls;
using Zenith.UI.Tests.ViewModel;
using Zenith.UI.Tests.Views;

namespace Zenith.UI.Tests
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NavbarViewModel _navbarModel = null;

        public MainWindow()
        {
            InitializeComponent();
            _navbarModel = new NavbarViewModel();
            this.Loaded += MainWindow_Loaded;
            DataContext = this;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _navbarModel.AddTab("Search", "", "appbar_magnify", "Pick one of the search modes", new TempView(_navbarModel));
            _navbarModel.AddTab("Data files", "", "appbar_page_text", "View and manipulate data files", new TempView(_navbarModel));
            //throw new InvalidOperationException("Invalid.");
        }

        public NavbarViewModel NavbarModel
        {
            get
            {
                return _navbarModel;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CustomDialog lg = new CustomDialog();
            lg.Show();
        }

        
    }

    
}
