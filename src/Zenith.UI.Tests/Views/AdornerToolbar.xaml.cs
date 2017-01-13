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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zenith.Client.Shared.Controls;

namespace Zenith.UI.Tests.Views
{
    /// <summary>
    /// Interaction logic for AdornerToolbar.xaml
    /// </summary>
    public partial class AdornerToolbar : UserControl
    {
        public AdornerToolbar()
        {
            InitializeComponent();
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            //AdornedControl textbox = FindVisualParent<AdornedControl>((DependencyObject)sender);

            //string s = "";
        }

        //public static T FindParent<T>(DependencyObject child) where T : DependencyObject
        //{
        //    //get parent item
        //    DependencyObject parentObject = VisualTreeHelper.GetParent(child);

        //    //we've reached the end of the tree
        //    if (parentObject == null) return null;

        //    //check if the parent matches the type we're looking for
        //    T parent = parentObject as T;
        //    if (parent != null)
        //        return parent;
        //    else
        //        return FindParent<T>(parentObject);
        //}

        //public static T FindVisualParent<T>(DependencyObject child) where T : DependencyObject
        //{
        //    if (child == null) return null;

        //    //handle content elements separately
        //    ContentElement contentElement = child as ContentElement;
        //    if (contentElement != null)
        //    {
        //        DependencyObject parent = ContentOperations.GetParent(contentElement);
        //        if (parent != null) return (T)parent;

        //        FrameworkContentElement fce = contentElement as FrameworkContentElement;
        //        return fce != null ? (T)fce.Parent : null;
        //    }

        //    //also try searching for parent in framework elements (such as DockPanel, etc)
        //    FrameworkElement frameworkElement = child as FrameworkElement;
        //    if (frameworkElement != null)
        //    {
        //        DependencyObject parent = frameworkElement.Parent;
        //        if (parent != null) return (T)parent;
        //    }

        //    //if it's not a ContentElement/FrameworkElement, rely on VisualTreeHelper
        //    return (T)VisualTreeHelper.GetParent(child);
        //}
    }
}
