using MahApps.Metro.Controls;
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
using System.Windows.Shapes;
using Zenith.Client.Shared.Interfaces;

namespace Zenith.ClientApp.Windows
{
    public partial class LoginDialog : MetroWindow, IDialogTarget
    {
        Window _parent = null;

        public LoginDialog()
        {
            InitializeComponent();
            this.Loaded += LoginDialog_Loaded;
        }

        private void LoginDialog_Loaded(object sender, RoutedEventArgs e)
        {
            this.Left = _parent.Left + (_parent.ActualWidth - this.ActualWidth) / 2;
            this.Top = _parent.Top + (_parent.ActualHeight - this.ActualHeight) / 2;
        }

        public void RequestClose()
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                this.Close();
            }));
        }

        public LoginDialog(Window parent)
            :this()
        {
            this._parent = parent;
        }
    }
}
