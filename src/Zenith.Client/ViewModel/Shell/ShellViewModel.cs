using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenith.Client.ViewModel
{
    public class ShellViewModel
    {
        FlyoutViewModel _flyouts = null;

        public ShellViewModel()
        {
            _flyouts = new FlyoutViewModel();
        }

        #region Flyouts

        public void ToggleFlyout(string name)
        {
            this.ApplyToggleFlyout(name);
        }

        public void ToggleFlyout(string name, Position position)
        {
            this.ApplyToggleFlyout(name, position);
        }

        public void ToggleFlyout(string name, bool isModal)
        {
            this.ApplyToggleFlyout(name, null, isModal);
        }

        public void ToggleFlyout(string name, Position position, bool isModal)
        {
            this.ApplyToggleFlyout(name, position, isModal);
        }

        protected void ApplyToggleFlyout(string name, Position? position = null, bool? isModal = null, bool? show = null)
        {
            foreach (var f in this._flyouts.FlyoutsCollection.Where(x => name.Equals(x.Name)))
            {
                if (position.HasValue)
                {
                    f.Position = position.Value;
                }

                if (isModal.HasValue)
                {
                    f.IsModal = isModal.Value;
                }

                if (show.HasValue)
                {
                    f.IsOpen = show.Value;
                }
                else
                {
                    f.IsOpen = !f.IsOpen;
                }
            }
        }

        public FlyoutViewModel Flyouts
        {
            get { return _flyouts; }
        }

        #endregion
    }
}
