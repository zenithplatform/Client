using Zenith.Core.Models;
using Zenith.Core.Service;
using Zenith.Client.ViewModel;
using Zenith.Client.ViewModel.Helpers;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Zenith.Client
{
    /// <summary>
    /// Interaction logic for SearchResults.xaml
    /// </summary>
    public partial class SearchWindow : MetroWindow
    {
        public SearchWindow()
        {
            InitializeComponent();
        }

        private void bSearch_Click(object sender, RoutedEventArgs e)
        {
            //SearchService search = new SearchService();
            //SearchResult result = search.SearchExact(textSearch.Text);
            //ObservableCollection<ObservationDataCategory> all = new ObservableCollection<ObservationDataCategory>();
            //GeneralObservationData general = new GeneralObservationData();
            //List<ObservationDataItem> generalItems = new List<ObservationDataItem>();

            //foreach (SearchResultItem item in result.Items)
            //{
            //    generalItems.Add(ModelHelpers.ObservationItemFromSearchItem(item));
            //}

            //general.CategoryItems = generalItems;
            
            //all.Add(general);
            //this.SearchResultsView.ObsData.DataContext = all;
            //this.SearchResultsView.ResultList.DataContext = result.Items;
        }
    }
}
