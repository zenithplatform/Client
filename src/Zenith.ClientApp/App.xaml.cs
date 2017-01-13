using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Zenith.Client.Shared.Interfaces;
using Zenith.ClientApp.Coordinators;
using Zenith.ClientApp.ViewModel;

namespace Zenith.ClientApp
{
    public partial class App : Application
    {
        ShellViewModel _shellModel = null;
        IShellCoordinator _shellCoordinator = null;
        Window _shellWindow = null;

        public App()
            : base()
        {
            this._shellCoordinator = ShellCoordinator.Instance;

            AppDomain.CurrentDomain.UnhandledException += (s, ev) =>
                PassToExceptionHandler((Exception)ev.ExceptionObject, "AppDomain.CurrentDomain.UnhandledException");

            DispatcherUnhandledException += (s, ev) =>
                PassToExceptionHandler(ev.Exception, "Application.Current.DispatcherUnhandledException");

            TaskScheduler.UnobservedTaskException += (s, ev) =>
                PassToExceptionHandler(ev.Exception, "TaskScheduler.UnobservedTaskException");
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _shellModel = new ShellViewModel(this._shellCoordinator);

            _shellWindow = new Shell();
            _shellWindow.DataContext = _shellModel;
            _shellWindow.Show();

            this._shellCoordinator.MainWindow = _shellWindow;
        }

        private void PassToExceptionHandler(Exception exception, string @event)
        {
            MessageBox.Show(exception.ToString());
        }
    }
}
