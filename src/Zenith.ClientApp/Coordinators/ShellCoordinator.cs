using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Zenith.Client.Shared.Interfaces;
using System.Windows;

namespace Zenith.ClientApp.Coordinators
{
    public class ShellCoordinator : IShellCoordinator
    {
        public event ShellEventHandler OnShellEvent;
        private Dictionary<IShellElementTarget, List<string>> _targets = null;
        private ObservableCollection<IDialogTarget> _dialogs = null;
        private static volatile IShellCoordinator _shellCoordinator;
        private static readonly object _syncObject = new object();
        Window _mainWindow = null;

        private ShellCoordinator()
        {
            _targets = new Dictionary<IShellElementTarget, List<string>>();
            _dialogs = new ObservableCollection<IDialogTarget>();

            AppCoordinator.Instance.OnGlobalEvent += Instance_OnGlobalEvent;
        }

        private void Instance_OnGlobalEvent(Interfaces.GlobalEventType eventType, object payload)
        {
            if(eventType == Interfaces.GlobalEventType.UserLoggedIn)
            {
                MessageBox.Show(payload.ToString());
            }
            else if(eventType == Interfaces.GlobalEventType.UserLoggedOut)
            {

            }
        }

        public static IShellCoordinator Instance
        {
            get
            {
                if (null == _shellCoordinator)
                {
                    lock (_syncObject)
                    {
                        if (null == _shellCoordinator)
                        {
                            _shellCoordinator = new ShellCoordinator();
                        }
                    }
                }

                return _shellCoordinator;
            }
        }

        public Window MainWindow
        {
            get
            {
                return _mainWindow;
            }

            set
            {
                _mainWindow = value;
            }
        }

        public void Register<T>(T target, string actionKey) where T : IShellElementTarget
        {
            if(_targets.ContainsKey(target))
            {
                List<string> actionKeys = _targets[target];

                if (!actionKeys.Contains(actionKey))
                    actionKeys.Add(actionKey);
            }
            else
            {
                List<string> actionKeys = new List<string>();
                actionKeys.Add(actionKey);

                _targets.Add(target, actionKeys);
            }
        }

        public void Unregister<T>(T target, string actionKey) where T : IShellElementTarget
        {
            if (_targets.ContainsKey(target))
            {
                List<string> actionKeys = _targets[target];

                if (actionKeys.Contains(actionKey))
                    actionKeys.Remove(actionKey);
            }
        }

        public void Unregister<T>(T target) where T : IShellElementTarget
        {
            if (_targets.ContainsKey(target))
            {
                List<string> actionKeys = _targets[target];
                actionKeys.Clear();
                _targets.Remove(target);
            }
        }

        public void Invoke<T>(string actionKey, object payload) where T : IShellElementTarget
        {
            foreach(IShellElementTarget target in _targets.Keys)
            {
                List<string> actions = _targets[target];

                if(actions.Contains(actionKey))
                {
                    target.InvokeAction(actionKey, payload);
                    break;
                }
            }
        }

        public void ShowDialog<T>(Window parent, object dataContext) where T : IDialogTarget
        {
            T instance = (T)Activator.CreateInstance(typeof(T), new object[] { parent });

            _dialogs.Add(instance);

            typeof(T).GetProperty("DataContext").SetValue(instance, dataContext);
            typeof(T).GetMethod("ShowDialog").Invoke(instance, null);
        }

        public void CloseDialog<T>() where T : IDialogTarget
        {
            IDialogTarget target = _dialogs.OfType<T>().First();

            if (target != null)
            {
                target.RequestClose();
                _dialogs.Remove(target);
            }
        }
    }
}
