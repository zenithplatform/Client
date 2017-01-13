using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Zenith.SearchModule.Converters
{
    public class SearchBarStyleConverter : IValueConverter
    {
        public Style SimpleSearchStyle { get; set; }
        public Style SegmentedSearchStyle { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isSegmented = (bool)value;

            if (isSegmented)
                return SegmentedSearchStyle;
            else
                return SimpleSearchStyle;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
