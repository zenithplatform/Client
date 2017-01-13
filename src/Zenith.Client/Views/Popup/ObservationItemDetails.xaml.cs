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

namespace Zenith.Client.Views
{
    /// <summary>
    /// Interaction logic for ObservationDataItemDetails.xaml
    /// </summary>
    public partial class ObservationItemDetails : UserControl
    {
        public ObservationItemDetails()
        {
            InitializeComponent();
            //https://en.wikipedia.org/w/api.php?format=json&action=query&prop=extracts&exintro=&explaintext=&titles=Stellar%20parallax
            //http://stackoverflow.com/questions/8555320/is-there-a-clean-wikipedia-api-just-for-retrieve-content-summary
        }
    }
}
