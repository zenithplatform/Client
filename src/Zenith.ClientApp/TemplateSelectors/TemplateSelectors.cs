using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Zenith.ClientApp.ViewModel;

namespace Zenith.ClientApp.TemplateSelectors
{
    //public class TabHeaderTemplateSelector : DataTemplateSelector
    //{
    //    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    //    {
    //        NavbarTab tab = item as NavbarTab;
    //        NavbarTabHeader header = tab.Header as NavbarTabHeader;

    //        if (!string.IsNullOrEmpty(header.ImageResourceKey))
    //            return VisualAndTextTemplate;
    //        else
    //            return ImageAndTextTemplate;
    //    }

    //    public DataTemplate ImageAndTextTemplate { get; set; }

    //    public DataTemplate VisualAndTextTemplate { get; set; }
    //}
}
