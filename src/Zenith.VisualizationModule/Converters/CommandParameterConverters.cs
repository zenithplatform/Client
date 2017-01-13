using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Zenith.VisualizationModule.ViewModel;

namespace Zenith.VisualizationModule.Converters
{
    public class VertexClickParametersConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            VertexClickCommandParameters parameters = new VertexClickCommandParameters();
            GraphSharp.Controls.VertexControl target = value as GraphSharp.Controls.VertexControl;

            parameters.Target = target.DataContext as ObjectTypeVertex;

            return parameters;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
