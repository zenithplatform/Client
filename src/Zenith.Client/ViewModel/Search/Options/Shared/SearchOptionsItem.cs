using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Zenith.Client.Shared.ViewModel;

namespace Zenith.Client.ViewModel
{
    //SearchOptionSegment
    public class SearchOptionsItem : INotifyPropertyChanged,
                                     ISegmentPresenter<SearchOptionSegment>
    //ISegmentPresenter<TextBoxSegment>
    {
        private bool _addEnabled = false;
        private bool _modifyEnabled = false;
        private bool _isEnabled = false;

        public string Caption { get; set; }
        public object Value { get; set; }
        public SearchOptionViewBase CurrentView { get; set; }
        public SearchOptionKind Kind { get; set; }

        //TextBoxSegment _currentSegment = null;
        SearchOptionSegment _currentSegment = null;

        public bool CanAdd
        {
            get
            {
                if (!_isEnabled)
                    return false;
                else
                    return _addEnabled && _isEnabled;
            }
            set
            {
                _addEnabled = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("CanAdd"));
            }
        }

        //public TextBoxSegment CurrentSegment
        //{
        //    get { return _currentSegment; }
        //}

        public SearchOptionSegment CurrentSegment
        {
            get { return _currentSegment; }
        }

        public bool CanModify
        {
            get
            {
                if (!_isEnabled)
                    return false;
                else
                    return _modifyEnabled && _isEnabled;
            }
            set
            {
                _modifyEnabled = value;
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("CanModify"));
            }
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;

                NotifyPropertyChanged(this, new PropertyChangedEventArgs("CanModify"));
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("CanAdd"));
                NotifyPropertyChanged(this, new PropertyChangedEventArgs("IsEnabled"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        //public TextBoxSegment CreateSegment()
        //{
        //    if (_currentSegment == null)
        //    {
        //        _currentSegment = new TextBoxSegment();
        //        _currentSegment.Origin = this;
        //    }

        //    return _currentSegment;
        //}

        public SearchOptionSegment CreateSegment()
        {
            if (_currentSegment == null)
            {
                _currentSegment = new SearchOptionSegment();
                _currentSegment.Origin = this;
            }

            return _currentSegment;
        }
    }

    public abstract class SearchOptionViewBase: ISegmentValuesPresenter<SegmentPart>
    {
        public abstract ObservableCollection<SegmentPart> CreateSegmentValues();
        public abstract void UpdateSegmentValues();
        public abstract void DestroySegmentValues();
    }

    //public interface ISearchOptionValue
    //{
    //    object SearchOptionValue { get; set; }
    //    FrameworkElement GetVisualRepresentation();
    //}

    //public class InputOption:ISearchOptionValue
    //{
    //    string _strValue = "";

    //    public object SearchOptionValue
    //    {
    //        get
    //        {
    //            return _strValue;
    //        }

    //        set
    //        {
    //            if (value != null)
    //                _strValue = value.ToString();
    //            else
    //                _strValue = null;
    //        }
    //    }

    //    public FrameworkElement GetVisualRepresentation()
    //    {
    //        return new TextBox();
    //    }
    //}

    //public class SelectionOption : ISearchOptionValue
    //{
    //    List<string> _options { get; set; }

    //    public object SearchOptionValue
    //    {
    //        get
    //        {
    //            return _options;
    //        }

    //        set
    //        {
    //            if (value != null)
    //                _options = (List<string>)value;
    //            else
    //                _options = null;
    //        }
    //    }

    //    public FrameworkElement GetVisualRepresentation()
    //    {
    //        return new ComboBox();
    //    }
    //}

    //public class ComplexOption<T> : ISearchOptionValue where T : FrameworkElement
    //{
    //    public object SearchOptionValue
    //    {
    //        get
    //        {
    //            throw new NotImplementedException();
    //        }

    //        set
    //        {
    //            throw new NotImplementedException();
    //        }
    //    }

    //    public FrameworkElement GetVisualRepresentation()
    //    {
    //        return default(T);
    //    }
    //}

    public enum SearchOptionKind
    {
        Coordinates,
        Radius,
        ObjectName,
        Epoch,
        Equinox,
        Unknown
    }
}
