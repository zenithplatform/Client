using System.Windows;
using System.Windows.Controls;
using Zenith.SearchModule.ViewModel;

namespace Zenith.SearchModule.Views
{
    public partial class SearchOptionsPane : UserControl
    {
        public SearchOptionsPane()
        {
            InitializeComponent();
        }

        //public static readonly DependencyProperty SearchPaneState = DependencyProperty.Register("SearchPaneState", typeof(SearchOptionsPaneState),
        //    typeof(Manage), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnDialogAnimationChanged));
        //public bool DialogAnimation
        //{

        //    get { return (bool)this.GetValue(DialogAnimationProperty); }
        //    set
        //    {
        //        var oldValue = (bool)this.GetValue(DialogAnimationProperty);
        //        if (oldValue != value) this.SetValue(DialogAnimationProperty, value);
        //    }
        //}
    }
}
