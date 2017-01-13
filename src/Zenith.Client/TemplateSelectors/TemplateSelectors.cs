using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Zenith.Client.ViewModel;

namespace Zenith.Client.TemplateSelectors
{
    public class TabHeaderTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            NavbarTab tab = item as NavbarTab;
            NavbarTabHeader header = tab.Header as NavbarTabHeader;

            if (!string.IsNullOrEmpty(header.ImageResourceKey))
                //if(header.ImageResource != null)
                return VisualAndTextTemplate;
            else
                return ImageAndTextTemplate;
        }

        public DataTemplate ImageAndTextTemplate { get; set; }

        public DataTemplate VisualAndTextTemplate { get; set; }
    }

    //public class SearchBarTextBoxTemplateSelector : DataTemplateSelector
    //{
    //    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    //    {
    //        SearchBarViewModel searchBar = item as SearchBarViewModel;

    //        if (searchBar.IsSegmented)
    //            return SegmentedSearchTemplate;
    //        else
    //            return SimpleSearchTemplate;
    //    }

    //    public DataTemplate SimpleSearchTemplate { get; set; }
    //    public DataTemplate SegmentedSearchTemplate { get; set; }
    //}
}
