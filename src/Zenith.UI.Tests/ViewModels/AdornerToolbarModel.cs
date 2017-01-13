using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zenith.Client.Shared.Commands;

namespace Zenith.UI.Tests.ViewModels
{
    public class AdornerToolbarModel
    {
        private RelayCommand<object> _moveCommand;

        public ICommand MoveCommand
        {
            get
            {
                if (_moveCommand == null)
                    _moveCommand = new RelayCommand<object>(OnMoveClick);

                return _moveCommand;
            }
        }

        public void OnMoveClick(object parameters)
        {

        }
    }
}
