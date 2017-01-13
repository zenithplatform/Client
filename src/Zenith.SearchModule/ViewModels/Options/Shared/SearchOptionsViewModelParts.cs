using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenith.Client.Shared.ViewModel;

namespace Zenith.SearchModule.ViewModel
{
    public class CoordinatesViewModel : SearchOptionViewBase
    {
        string _declination = "";
        string _rightAscension = "";
        bool _enabled = false;

        SegmentPart _declinationPart = null;
        SegmentPart _rightAscensionPart = null;

        ObservableCollection<SegmentPart> _parts = null;

        public CoordinatesViewModel()
        {
            _parts = new ObservableCollection<SegmentPart>();
        }

        public string Declination
        {
            get { return _declination; }
            set
            {
                _declination = value;
            }
        }

        public string RightAscension
        {
            get { return _rightAscension; }
            set
            {
                _rightAscension = value;
            }
        }

        public override ObservableCollection<SegmentPart> CreateSegmentValues()
        {
            if(_declinationPart == null)
            {
                _declinationPart = new SegmentPart();
                _declinationPart.Caption = "Declination : ";
                _declinationPart.Value = this.Declination;
            }

            if(_rightAscensionPart == null)
            {
                _rightAscensionPart = new SegmentPart();
                _rightAscensionPart.Caption = "Right ascension : ";
                _rightAscensionPart.Value = this.RightAscension;
            }

            _parts.Add(_declinationPart);
            _parts.Add(_rightAscensionPart);

            return _parts;
        }

        public override void DestroySegmentValues()
        {
            _parts.Clear();
            _declinationPart = null;
            _rightAscensionPart = null;
        }

        public override void UpdateSegmentValues()
        {
            if (_rightAscensionPart != null)
                _rightAscensionPart.Value = this.RightAscension;

            if (_declinationPart != null)
                _declinationPart.Value = _declination;
        }
    }

    public class EpochViewModel : SearchOptionViewBase
    {
        private string _selectedItem = null;
        private List<string> _items = null;

        public List<String> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        bool _enabled = false;

        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
            }
        }

        SegmentPart _selectedItemPart = null;
        ObservableCollection<SegmentPart> _parts = null;

        public EpochViewModel()
        {
            _parts = new ObservableCollection<SegmentPart>();
            _items = new List<string>();

            _items.Add("J2000");
            _items.Add("J1950");
            _items.Add("B1950");
            _items.Add("B1900");
        }

        public override ObservableCollection<SegmentPart> CreateSegmentValues()
        {
            if(_selectedItemPart == null)
            {
                _selectedItemPart = new SegmentPart();
                _selectedItemPart.Caption = "Epoch : ";
                _selectedItemPart.Value = this.SelectedItem;
            }

            _parts.Add(_selectedItemPart);

            return _parts;
        }

        public override void DestroySegmentValues()
        {
            _parts.Clear();
            _selectedItemPart = null;
        }

        public override void UpdateSegmentValues()
        {
            if (_selectedItemPart != null)
                _selectedItemPart.Value = this.SelectedItem;
        }
    }

    public class EquinoxViewModel : SearchOptionViewBase
    {
        private List<string> _items = null;
        private string _selectedItem = null;

        public List<String> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        bool _enabled = false;

        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
            }
        }

        SegmentPart _selectedItemPart = null;
        ObservableCollection<SegmentPart> _parts = null;

        public EquinoxViewModel()
        {
            _parts = new ObservableCollection<SegmentPart>();
            _items = new List<string>();
            _items.Add("2000");
            _items.Add("1950");
            _items.Add("1900");
        }

        public override ObservableCollection<SegmentPart> CreateSegmentValues()
        {
            if (_selectedItemPart == null)
            {
                _selectedItemPart = new SegmentPart();
                _selectedItemPart.Caption = "Equinox : ";
                _selectedItemPart.Value = this.SelectedItem;
            }

            _parts.Add(_selectedItemPart);

            return _parts;
        }

        public override void DestroySegmentValues()
        {
            _parts.Clear();
            _selectedItemPart = null;
        }

        public override void UpdateSegmentValues()
        {
            if (_selectedItemPart != null)
                _selectedItemPart.Value = this.SelectedItem;
        }
    }

    public class RadiusViewModel : SearchOptionViewBase
    {
        private List<string> _units = null;
        private double _radius = 0.0;
        bool _enabled = false;

        public double Radius
        {
            get { return _radius; }
            set
            {
                _radius = value;
            }
        }

        public List<string> Units
        {
            get { return _units; }
            set { _units = value; }
        }

        SegmentPart _radiusPart = null;
        ObservableCollection<SegmentPart> _parts = null;

        public RadiusViewModel()
        {
            _parts = new ObservableCollection<SegmentPart>();
            _units = new List<string>();
            _units.Add("degree");
            _units.Add("arcmin");
            _units.Add("arcsec");
        }

        public override ObservableCollection<SegmentPart> CreateSegmentValues()
        {
            if (_radiusPart == null)
            {
                _radiusPart = new SegmentPart();
                _radiusPart.Caption = "Radius : ";
                _radiusPart.Value = this.Radius.ToString();
            }

            _parts.Add(_radiusPart);

            return _parts;
        }

        public override void DestroySegmentValues()
        {
            _parts.Clear();
            _radiusPart = null;
        }

        public override void UpdateSegmentValues()
        {
            if (_radiusPart != null)
                _radiusPart.Value = this.Radius.ToString();
        }
    }

    public class ObjectNameViewModel : SearchOptionViewBase
    {
        private string _objectName = "";
        bool _enabled = false;

        public ObjectNameViewModel()
        {
            _parts = new ObservableCollection<SegmentPart>();
        }

        public string ObjectName
        {
            get { return _objectName; }
            set
            {
                _objectName = value;
            }
        }

        SegmentPart _objectNamePart = null;

        ObservableCollection<SegmentPart> _parts = null;

        public override ObservableCollection<SegmentPart> CreateSegmentValues()
        {
            if(_objectNamePart == null)
            {
                _objectNamePart = new SegmentPart();
                _objectNamePart.Caption = "Object name : ";
                _objectNamePart.Value = this.ObjectName;
            }

            _parts.Add(_objectNamePart);

            return _parts;
        }

        public override void DestroySegmentValues()
        {
            _parts.Clear();
            _objectNamePart = null;
        }

        public override void UpdateSegmentValues()
        {
            if (_objectNamePart != null)
                _objectNamePart.Value = _objectName;
        }
    }
}
