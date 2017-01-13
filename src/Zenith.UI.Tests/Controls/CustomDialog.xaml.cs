using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Zenith.UI.Tests.Controls
{
    public partial class CustomDialog : MetroWindow
    {
        [DllImport("kernel32.dll")]
        internal static extern uint GetTickCount();

        public CustomDialog()
        {
            InitializeComponent();
            base.ShowMaxRestoreButton = false;
            base.ShowMinButton = false;
            base.Topmost = true;

            DataContext = this;
        }

        public CrashReportModel CrashReportDataContext
        {
            get
            {
                CrashReportModel model = new CrashReportModel();

                string strBuildTime = new DateTime(2000, 1, 1).AddDays(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Build).ToShortDateString();

                // Gets program uptime
                TimeSpan timeSpanProcTime = Process.GetCurrentProcess().TotalProcessorTime;

                // Used to get disk space
                DriveInfo driveInfo = new DriveInfo(Directory.GetDirectoryRoot(System.Reflection.Assembly.GetExecutingAssembly().Location));

                model.AddItem("Current Date/Time", DateTime.Now.ToString());
                model.AddItem("Exec. Date/Time", Process.GetCurrentProcess().StartTime.ToString());
                model.AddItem("Build Date", strBuildTime);
                model.AddItem("OS", Environment.OSVersion.VersionString);
                model.AddItem("Language", "EN-US");
                model.AddItem("System Uptime", string.Format("{0} Days {1} Hours {2} Mins {3} Secs", Math.Round((decimal)GetTickCount() / 86400000), Math.Round((decimal)GetTickCount() / 3600000 % 24), Math.Round((decimal)GetTickCount() / 120000 % 60), Math.Round((decimal)GetTickCount() / 1000 % 60)));
                model.AddItem("Program Uptime", string.Format("{0} hours {1} mins {2} secs", timeSpanProcTime.TotalHours.ToString("0"), timeSpanProcTime.TotalMinutes.ToString("0"), timeSpanProcTime.TotalSeconds.ToString("0")));
                model.AddItem("PID", Process.GetCurrentProcess().Id.ToString());
                 model.AddItem("Thread Count", Process.GetCurrentProcess().Threads.Count.ToString());
                 model.AddItem("Thread Id", System.Threading.Thread.CurrentThread.ManagedThreadId.ToString());
                 model.AddItem("Executable", Assembly.GetExecutingAssembly().Location);
                 model.AddItem("Process Name", Process.GetCurrentProcess().ProcessName);
                 model.AddItem("Version", "0.10.0.0");
                 model.AddItem("CLR Version", Environment.Version.ToString());

                //model.AddItem("Crash time", DateTime.Now.ToString());
                //model.AddItem("Operating system", Environment.OSVersion.VersionString);
                //model.AddItem("Crash time", DateTime.Now.ToString());
                //model.AddItem("Operating system", Environment.OSVersion.VersionString);
                //model.AddItem("Crash time", DateTime.Now.ToString());
                //model.AddItem("Operating system", Environment.OSVersion.VersionString);
                //model.AddItem("Crash time", DateTime.Now.ToString());
                //model.AddItem("Operating system", Environment.OSVersion.VersionString);
                //model.AddItem("Crash time", DateTime.Now.ToString());
                //model.AddItem("Operating system", Environment.OSVersion.VersionString);
                //model.AddItem("Crash time", DateTime.Now.ToString());
                //model.AddItem("Operating system", Environment.OSVersion.VersionString);
                //model.AddItem("Crash time", DateTime.Now.ToString());
                //model.AddItem("Operating system", Environment.OSVersion.VersionString);
                //model.AddItem("Crash time", DateTime.Now.ToString());
                //model.AddItem("Operating system", Environment.OSVersion.VersionString);
                //model.AddItem("Crash time", DateTime.Now.ToString());
                //model.AddItem("Operating system", Environment.OSVersion.VersionString);
                //model.AddItem("Crash time", DateTime.Now.ToString());
                //model.AddItem("Operating system", Environment.OSVersion.VersionString);
                //model.AddItem("Crash time", DateTime.Now.ToString());
                //model.AddItem("Operating system", Environment.OSVersion.VersionString);
                //model.AddItem("Crash time", DateTime.Now.ToString());
                //model.AddItem("Operating system", Environment.OSVersion.VersionString);
                //model.AddItem("Crash time", DateTime.Now.ToString());
                //model.AddItem("Operating system", Environment.OSVersion.VersionString);
                //model.AddItem("Crash time", DateTime.Now.ToString());
                //model.AddItem("Operating system", Environment.OSVersion.VersionString);
                //model.AddItem("Crash time", DateTime.Now.ToString());
                //model.AddItem("Operating system", Environment.OSVersion.VersionString);
                //model.AddItem("Crash time", DateTime.Now.ToString());
                //model.AddItem("Operating system", Environment.OSVersion.VersionString);
                //model.AddItem("Crash time", DateTime.Now.ToString());
                //model.AddItem("Operating system", Environment.OSVersion.VersionString);
                //model.AddItem("Crash time", DateTime.Now.ToString());
                //model.AddItem("Operating system", Environment.OSVersion.VersionString);
                //model.AddItem("Crash time", DateTime.Now.ToString());
                //model.AddItem("Operating system", Environment.OSVersion.VersionString);
                //model.AddItem("Crash time", DateTime.Now.ToString());
                //model.AddItem("Operating system", Environment.OSVersion.VersionString);
                return model;
            }
        }
    }

    public class NameValuePair
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class CrashReportModel
    {
        private ObservableCollection<NameValuePair> _collection = null;

        public CrashReportModel()
        {
            _collection = new ObservableCollection<NameValuePair>();
        }

        public ObservableCollection<NameValuePair> Items
        {
            get { return _collection; }
        }

        public void AddItem(string name, string value)
        {
            _collection.Add(new NameValuePair() { Name = name, Value = value });
        }

        public string Exception
        {
            get { return "at StackTrace.Program.GetValue() in C:\\DebuggingPresentation\\StackTrace\\StackTrace\\Program.cs:line 29\n"+
                        "at StackTrace.Program.Main(String[] args) in C:\\DebuggingPresentation\\StackTrace\\StackTrace\\Program.cs:line 15\n"+
                        "at System.AppDomain.nExecuteAssembly(Assembly assembly, String[] args)\n"+
                        "at System.AppDomain.ExecuteAssembly(String assemblyFile,\n"+
                        "Evidence assemblySecurity, String[] args)\n"+
                        "at Microsoft.VisualStudio.HostingProcess.HostProc.RunUsersAssembly()\n"+
                        "at System.Threading.ThreadHelper.ThreadStart_Context(Object state)\n"+
                        "at System.Threading.ExecutionContext.Run(ExecutionContext executionContext, ContextCallback callback, Object state)\n"+
                        "at System.Threading.ThreadHelper.ThreadStart()";
            }
        }
    }
}
