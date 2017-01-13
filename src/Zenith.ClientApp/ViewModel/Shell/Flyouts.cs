using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahApps.Metro.Controls;

namespace Zenith.ClientApp.ViewModel.Shell
{
    public class SettingsFlyout : IFlyout
    {
        string _header = "Settings";
        bool _isModal = false;
        bool _isOpen = true;
        string _name = "Settings";
        Position _position = Position.Right;

        public string Header
        {
            get
            {
                return _header;
            }

            set
            {
                _header = value;
            }
        }

        public bool IsModal
        {
            get
            {
                return _isModal;
            }

            set
            {
                _isModal = value;
            }
        }

        public bool IsOpen
        {
            get
            {
                return _isOpen;
            }

            set
            {
                _isOpen = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public Position Position
        {
            get
            {
                return _position;
            }

            set
            {
                _position = value;
            }
        }
    }
}
