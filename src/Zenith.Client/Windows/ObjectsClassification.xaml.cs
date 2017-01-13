using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Zenith.Client.ViewModel;

namespace Zenith.Client.Windows
{
    public partial class ObjectsClassification : MetroWindow
    {
        public ObjectsClassification()
        {
            InitializeComponent();

            GraphViewModel graphModel = new GraphViewModel();
            graphModel.LoadObjectTypes();
            graphModel.CreateMainGraph();

            this.DataContext = graphModel;
        }

        public ObjectsClassification(GraphViewModel graphModel)
            :this()
        {
            this.DataContext = graphModel;
        }
    }
}
