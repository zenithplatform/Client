using Zenith.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Zenith.Client.ViewModel.Helpers
{
    public static class ModelHelpers
    {
        public static List<ObjectDetailsItemViewModel> DetailsFromResult(CelestialObject celestialObject)
        {
            if (celestialObject == null || celestialObject.ObjectData == null || celestialObject.ObjectData.Count == 0)
                return null;

            List<ObjectDetailsItemViewModel> details = new List<ObjectDetailsItemViewModel>();
            List<string> itemsToSkip = new List<string>() { "Constellation", "ObjectType", "ObjectName", "OtherIdentifiers" };

            foreach (DataItemBase item in celestialObject.ObjectData)
            {
                if (itemsToSkip.Contains(item.Name))
                    continue;

                ObjectDetailsItemViewModel detailsItem = new ObjectDetailsItemViewModel();

                List<ObservationValue> values = new List<ObservationValue>();
                ObservationValue value = new ObservationValue();

                detailsItem.Name = item.Name;

                foreach (var val in item.Values)
                {
                    if (val is ValueBase)
                    {
                        value.AddPrimitive(val.Value.ToString());
                        detailsItem.AddValue(val.Value.ToString(), null);
                    }
                    else if (val is ComplexValue)
                    {
                        ComplexValue complexValue = val as ComplexValue;
                        detailsItem.AddValue(complexValue.ToString(), null);
                    }

                    values.Add(value);
                }

                details.Add(detailsItem);
            }

            return details;
        }

        public static ObjectCommonDataViewModel CommonDataFromResult(CelestialObject celestialObject)
        {
            if (celestialObject == null || celestialObject.ObjectData == null || celestialObject.ObjectData.Count == 0)
                return null;

            ObjectCommonDataViewModel commonData = new ObjectCommonDataViewModel();

            commonData.Constellation = celestialObject.ObjectData.Where(it => it.Name.Equals("Constellation")).First().Values.First().Value.ToString();
            commonData.ObjectType = celestialObject.ObjectData.Where(it => it.Name.Equals("ObjectType")).First().Values.First().Value.ToString();
            commonData.ObjectIdentifier = celestialObject.ObjectData.Where(it => it.Name.Equals("ObjectName")).First().Values.First().Value.ToString();
            commonData.OtherIdentifiers = celestialObject.ObjectData.Where(it => it.Name.Equals("OtherIdentifiers")).First().Values.Select(it => it.Value.ToString());

            return commonData;
        }

        public static List<ObjectListViewItem> ObjectListFromResult(ObjectSearchResult result)
        {
            if (result == null || result.Objects == null || result.Objects.Count == 0)
                return null;

            List<ObjectListViewItem> objects = new List<ObjectListViewItem>();

            foreach(CelestialObject celestialObject in result.Objects)
            {
                ObjectListViewItem objectItem = new ObjectListViewItem();
                objectItem.Name = celestialObject.ObjectData.Where(it => it.Name.Equals("ObjectName")).First().Values.First().Value.ToString();
                objectItem.Constellation = celestialObject.ObjectData.Where(it => it.Name.Equals("Constellation")).First().Values.First().Value.ToString();
                objectItem.Coordinates = string.Format("Declination : {0}, Right Ascension : {1}", celestialObject.ObjectData.Where(it => it.Name.Equals("Declination")).First().Values.First().Value.ToString(),
                                                                                                   celestialObject.ObjectData.Where(it => it.Name.Equals("RightAscension")).First().Values.First().Value.ToString());

                objects.Add(objectItem);
            }

            return objects;
        }
    }
}
