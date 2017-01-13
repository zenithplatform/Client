using System;
using System.Security;
using System.Windows.Controls;
using Zenith.Client.Shared.Interfaces;
using Zenith.ClientApp.ViewModel;

namespace Zenith.ClientApp.Views
{
    public partial class AuthenticationForm : UserControl, IPasswordSource
    {
        public AuthenticationForm()
        {
            InitializeComponent();
        }

        public SecureString GetConfirmationPassword()
        {
            return this.PasswordFieldConfirm.SecurePassword;
        }

        public SecureString GetPassword()
        {
            AuthFormViewModel context = this.DataContext as AuthFormViewModel;

            if (context.CurrentView == (int)FormView.Login)
                return this.PasswordFieldLogin.SecurePassword;
            else
                return this.PasswordFieldSignup.SecurePassword;
        }
    }
}
