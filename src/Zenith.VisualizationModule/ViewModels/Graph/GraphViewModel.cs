using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Zenith.Client.ApplicationServices.Storage;
using Zenith.Client.Shared.Commands;
using Zenith.Core.Models;

namespace Zenith.VisualizationModule.ViewModel
{
    public class GraphViewModel:INotifyPropertyChanged
    {
        ObjectTypesContainer _container = null;
        ObservableCollection<CelestialObjectType> _mainNodes = null;
        ObservableCollection<CelestialObjectType> _subNodes = null;
        //private ObjectTypesGraph _mainGraph = null;
        //private ObjectTypesGraph _subGraph = null;
        private ObjectTypesGraph _currentGraph = null;
        private ParameterizedRelayCommand<VertexClickCommandParameters> _vertexClickCommand;
        private SimpleRelayCommand _backCommand;
        ObjectTypeVertex _previousRoot = null;

        public event PropertyChangedEventHandler PropertyChanged;

        public GraphViewModel()
        {

        }

        public ICommand VertexClickCommand
        {
            get
            {
                if (_vertexClickCommand == null)
                    _vertexClickCommand = new ParameterizedRelayCommand<VertexClickCommandParameters>(OnVertexClick);

                return _vertexClickCommand;
            }
        }

        public ICommand BackCommand
        {
            get
            {
                if (_backCommand == null)
                    _backCommand = new SimpleRelayCommand(OnBackClick);

                return _backCommand;
            }
        }

        public void OnVertexClick(VertexClickCommandParameters parameters)
        {
            CelestialObjectType oType = parameters.Target.Tag as CelestialObjectType;

            if (oType == null)
                return;

            if (oType.Subtypes == null || oType.Subtypes.Count == 0)
                return;

            _previousRoot = parameters.Target.Parent;
            //CreateOneLevelGraph(parameters.Target, _previousRoot);
            CreateOneLevelGraph(parameters.Target);
        }

        public void OnBackClick(object parameter)
        {
            if (_previousRoot == null)
                return;

            CreateOneLevelGraph(_previousRoot);
            _previousRoot = _previousRoot.Parent;
        }

        //public ObjectTypesGraph MainGraph
        //{
        //    get { return _mainGraph; }
        //}

            //public ObjectTypesGraph SubGraph
            //{
            //    get { return _subGraph; }
            //}

        public ObjectTypesGraph CurrentGraph
        {
            get { return _currentGraph; }
        }

        public ObjectTypeVertex PreviousRoot
        {
            get { return _previousRoot; }
            set
            {
                _previousRoot = value;
            }
        }

        public void LoadObjectTypes()
        {
            StorageService storageSvc = new StorageService();
            _container = storageSvc.LoadObjectTypes();
            _mainNodes = ObjectTypes[0].Subtypes;
        }

        public void CreateMainGraph()
        {
            var graphTemp = new ObjectTypesGraph();

            CreateRootGraphInternal(ObjectTypes[0], graphTemp);
            _currentGraph = graphTemp;

            NotifyPropertyChanged(this, new PropertyChangedEventArgs("CurrentGraph"));
        }

        public void CreateOneLevelGraph(ObjectTypeVertex root)
        {
            var graphTemp = new ObjectTypesGraph();
            CelestialObjectType objectType = root.Tag as CelestialObjectType;

            CreateRootGraphInternal(objectType, graphTemp);
            _currentGraph = graphTemp;

            NotifyPropertyChanged(this, new PropertyChangedEventArgs("CurrentGraph"));
        }

        //public void CreateOneLevelGraph(ObjectTypeVertex root, ObjectTypeVertex parent)
        //{
        //    var graphTemp = new ObjectTypesGraph();
        //    CelestialObjectType objectType = root.Tag as CelestialObjectType;

        //    CreateRootGraphInternal(objectType, graphTemp, parent);
        //    _currentGraph = graphTemp;

        //    NotifyPropertyChanged(this, new PropertyChangedEventArgs("CurrentGraph"));
        //}

        public void CreateGraph(ObjectTypeVertex root)
        {
            var graphTemp = new ObjectTypesGraph();
            CelestialObjectType objectType = root.Tag as CelestialObjectType;

            CreateGraphInternal(objectType, graphTemp);
            _currentGraph = graphTemp;

            NotifyPropertyChanged(this, new PropertyChangedEventArgs("CurrentGraph"));
        }

        private void CreateRootGraphInternal(CelestialObjectType type, ObjectTypesGraph graph)
        {
            //ObjectTypeVertex parent = new ObjectTypeVertex(string.Format("{0} ({1})", type.Description, type.ShortCode));
            ObjectTypeVertex parent = new ObjectTypeVertex(type.Description, type, _previousRoot);
            graph.AddVertex(parent);

            if (type.Subtypes.Count > 0)
            {
                foreach (CelestialObjectType subtype in type.Subtypes)
                {
                    ObjectTypeVertex child = new ObjectTypeVertex(subtype.Description, subtype, parent);
                    graph.AddVertex(child);
                    graph.AddEdge(new ObjectTypeEdge(parent, child));

                    //CreateGraphInternal(subtype, graph);
                }
            }
        }

        //private void CreateRootGraphInternal(CelestialObjectType type, ObjectTypesGraph graph, ObjectTypeVertex parentVertex)
        //{
        //    //ObjectTypeVertex parent = new ObjectTypeVertex(string.Format("{0} ({1})", type.Description, type.ShortCode));
        //    ObjectTypeVertex parent = new ObjectTypeVertex(type.Description, type, parentVertex);
        //    graph.AddVertex(parent);

        //    if (type.Subtypes.Count > 0)
        //    {
        //        foreach (CelestialObjectType subtype in type.Subtypes)
        //        {
        //            ObjectTypeVertex child = new ObjectTypeVertex(subtype.Description, subtype, parent);
        //            graph.AddVertex(child);
        //            graph.AddEdge(new ObjectTypeEdge(parent, child));

        //            //CreateGraphInternal(subtype, graph);
        //        }
        //    }
        //}

        private void CreateGraphInternal(CelestialObjectType type, ObjectTypesGraph graph)
        {
            ObjectTypeVertex parent = new ObjectTypeVertex(type.Description, type);
            graph.AddVertex(parent);

            if (type.Subtypes.Count > 0)
            {
                foreach (CelestialObjectType subtype in type.Subtypes)
                {
                    ObjectTypeVertex child = new ObjectTypeVertex(subtype.Description, subtype, parent);
                    graph.AddVertex(child);
                    graph.AddEdge(new ObjectTypeEdge(parent, child));

                    CreateGraphInternal(subtype, graph);
                }
            }
        }

        public ObservableCollection<CelestialObjectType> ObjectTypes
        {
            get
            {
                if (_container == null)
                    return null;

                return _container.AllTypes;
            }
        }

        protected void NotifyPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }
    }

    public class VertexClickCommandParameters : CommandParameters
    {
        public ObjectTypeVertex Target { get; set; }
    }
}
