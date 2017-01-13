using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Zenith.Client.Shared.Commands;
using Zenith.Core.Models;
using Zenith.Core.Models.VirtualObservatory;
using Zenith.Core.Models.VirtualObservatory.Objects;
using Zenith.SearchModule.Helpers;
using Zenith.VisualizationModule.ViewModel;
using Zenith.VisualizationModule.Windows;

namespace Zenith.SearchModule.ViewModel
{
    public class ObjectsDetailsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObjectSearchRequest _request = null;
        private ParameterizedRelayCommand<ObjectTypesCommandParameters> _objectTypesCommand;
        private bool _isEmpty = false;

        public ObjectsDetailsViewModel()
        {
        }

        public ObjectsDetailsViewModel(CelestialObject celestialObject, VirtualObservatorySearchRequest request)
        {
            _request = request as ObjectSearchRequest;

            this.CommonData = ModelHelpers.CommonDataFromResult(celestialObject);
            this.Details = ModelHelpers.DetailsFromResult(celestialObject);
        }

        public ICommand ObjectTypesCommand
        {
            get
            {
                if (_objectTypesCommand == null)
                    _objectTypesCommand = new ParameterizedRelayCommand<ObjectTypesCommandParameters>(OnObjectDetailsClick);

                return _objectTypesCommand;
            }
        }

        public void OnObjectDetailsClick(ObjectTypesCommandParameters parameters)
        {
            GraphViewModel graphModel = new GraphViewModel();
            graphModel.LoadObjectTypes();
            graphModel.CreateMainGraph();
            //ObjectTypesViewModel objectTypes = new ObjectTypesViewModel();
            //objectTypes.LoadObjectTypes();

            //UIHelpers.ShowPopupWindow(new ObjectTypesPopup(), new Size(200, 200), parameters.SourceElement, parameters.InputData, graphModel);
            ObjectsClassification objectsClassification = new ObjectsClassification(graphModel);
            objectsClassification.Show();
        }

        public ObjectCommonDataViewModel CommonData { get; set; }
        public List<ObjectDetailsItemViewModel> Details { get; set; }

        public bool IsEmpty
        {
            get
            {
                _isEmpty = (this.CommonData == null) && (this.Details == null || this.Details.Count == 0);
                return _isEmpty;
            }
            set { _isEmpty = value; }
        }

        public Visibility DetailsVisible
        {
            get
            {
                return (this.IsEmpty ? Visibility.Hidden : Visibility.Visible);
            }
        }

        public Visibility ResultsMessageVisible
        {
            get
            {
                return (this.IsEmpty ? Visibility.Visible : Visibility.Hidden);
            }
        }

        public string EmptyResultsMessage
        {
            get
            {
                if (_request == null)
                    return "Sorry, nothing found :(";
                else
                {
                    return string.Format("Sorry, nothing found for '{0}' :(", _request.SearchTerm);
                }
            }
        }
    }

    public class HelpCommandParameters : CommandParameters
    {

    }

    public class CopyCommandParameters : CommandParameters
    {

    }

    public class ObjectDetailsItemViewModel
    {
        private ParameterizedRelayCommand<HelpCommandParameters> _helpCommand;
        private ParameterizedRelayCommand<CopyCommandParameters> _copyCommand;
        List<DetailsValueViewModel> _itemValues = null;

        public ObjectDetailsItemViewModel()
        {
            _itemValues = new List<DetailsValueViewModel>();
        }

        public string Name { get; set; }
        public string Designation { get; set; }

        public IEnumerable<DetailsValueViewModel> Values
        {
            get { return _itemValues; }
        }

        public void AddValue(DetailsValueViewModel value)
        {
            _itemValues.Add(value);
        }

        //public void AddValue(string displayValue, ObservationValuePrimitive originalValue)
        //{
        //    DetailsValueViewModel detailsValue = new DetailsValueViewModel();
        //    detailsValue.FormattedDisplayValue = displayValue;
        //    detailsValue.OriginalValue = originalValue;

        //    AddValue(detailsValue);
        //}

        public void AddValue(string displayValue, OriginalValueContainer originalValue)
        {
            DetailsValueViewModel detailsValue = new DetailsValueViewModel();
            detailsValue.FormattedDisplayValue = displayValue;
            detailsValue.OriginalValue = originalValue;

            AddValue(detailsValue);
        }

        public bool HasHelp { get; set; }

        public ICommand HelpCommand
        {
            get
            {
                if (_helpCommand == null)
                    _helpCommand = new ParameterizedRelayCommand<HelpCommandParameters>(OnGetHelp);

                return _helpCommand;
            }
        }

        public ICommand CopyCommand
        {
            get
            {
                if (_copyCommand == null)
                    _copyCommand = new ParameterizedRelayCommand<CopyCommandParameters>(OnCopy);

                return _copyCommand;
            }
        }

        public void OnGetHelp(HelpCommandParameters parameters)
        {
            //UIHelpers.ShowPopupWindow(parameters.Source, parameters.Item);
        }

        public void OnCopy(CopyCommandParameters parameters)
        {
            //UIHelpers.ShowPopupWindow(parameters.Source, parameters.Item);
        }
    }

    public class OriginalValueContainer
    {
        public List<ValueBase> OriginalValues { get; set; }
    }

    public class ObjectCommonDataViewModel
    {
        public string ObjectIdentifier
        {
            get; set;
        }

        public string ObjectType
        {
            get; set;
        }

        public string Constellation
        {
            get; set;
        }

        public IEnumerable<string> OtherIdentifiers
        {
            get; set;
        }
    }

    public class DetailsValueViewModel
    {
        public string FormattedDisplayValue { get; set; }
        public OriginalValueContainer OriginalValue { get; set; }
    }

    public class ObjectTypesCommandParameters : CommandParameters
    {
        
    }
}
