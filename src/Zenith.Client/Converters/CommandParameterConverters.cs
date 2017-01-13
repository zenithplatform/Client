using Zenith.Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Globalization;
using Zenith.Client.Shared;

namespace Zenith.Client.Converters
{
    public class HelpCommandParametersConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            HelpCommandParameters parameters = new HelpCommandParameters();

            //foreach (var obj in values)
            //{
            //    if (obj is ObservationDataItem) parameters.Item = (ObservationDataItem)obj;
            //    else if (obj is TextBox) parameters.Source = (TextBox)obj;
            //}
            return parameters;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

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

    public class ObjectTypesCommandParametersConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ObjectTypesCommandParameters parameters = new ObjectTypesCommandParameters();

            Hyperlink hyperlink = values[0] as Hyperlink;
            TextBlock sourceElemenet = hyperlink.Parent as TextBlock;
            string objectType = values[1].ToString();

            parameters.SourceElement = sourceElemenet;
            parameters.InputData = objectType;
            //foreach (var obj in values)
            //{
            //    if (obj is ObservationDataItem) parameters.Item = (ObservationDataItem)obj;
            //    else if (obj is TextBox) parameters.Source = (TextBox)obj;
            //}
            return parameters;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class TileCommandParametersConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            TileClickCommandParameters parameters = new TileClickCommandParameters();

            string searchType = value.ToString();
            parameters.SearchType = (SearchType)Enum.Parse(typeof(SearchType), searchType);
            //parameters.SourceElement = sourceElemenet;
            //parameters.InputData = objectType;
            //foreach (var obj in values)
            //{
            //    if (obj is ObservationDataItem) parameters.Item = (ObservationDataItem)obj;
            //    else if (obj is TextBox) parameters.Source = (TextBox)obj;
            //}
            return parameters;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class MultiTileCommandParametersConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            TileClickCommandParameters parameters = new TileClickCommandParameters();

            SearchType searchType = (SearchType)values[0];
            string searchContext = values[1].ToString();

            parameters.SearchType = searchType;
            parameters.SearchContext = searchContext;
            //parameters.SourceElement = sourceElemenet;
            //parameters.InputData = objectType;
            //foreach (var obj in values)
            //{
            //    if (obj is ObservationDataItem) parameters.Item = (ObservationDataItem)obj;
            //    else if (obj is TextBox) parameters.Source = (TextBox)obj;
            //}
            return parameters;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
