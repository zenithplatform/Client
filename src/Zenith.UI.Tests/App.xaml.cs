using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TaskDialogInterop;

namespace Zenith.UI.Tests
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
            : base()
        {
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
        }

        private void PassToExceptionHandler(Exception exception, string @event)
        {
            TaskDialogOptions config = new TaskDialogOptions();

            config.Owner = this.MainWindow;
            config.Title = "Task Dialog Title";
            config.MainInstruction = "The main instruction text for the TaskDialog goes here";
            config.Content = "The content text for the task dialog is shown here and the text will automatically wrap as needed.";
            config.ExpandedInfo = "Any expanded content text for the task dialog is shown here and the text will automatically wrap as needed.";
            config.VerificationText = "Don't show me this message again";
            config.CustomButtons = new string[] { "&Save", "Do&n't save", "&Cancel" };
            config.MainIcon = VistaTaskDialogIcon.Shield;
            config.FooterText = "Optional footer text with an icon or <a href=\"testUri\">hyperlink</a> can be included.";
            config.FooterIcon = VistaTaskDialogIcon.Warning;
            config.AllowDialogCancellation = true;

            TaskDialogResult res = TaskDialog.Show(config);
        }
    }
}
