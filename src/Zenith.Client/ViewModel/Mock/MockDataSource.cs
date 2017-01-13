using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenith.Client.ViewModel.Mock
{
    public class MockDataSource
    {
        //public ObservableCollection<ObservationDataCategory> all = new ObservableCollection<ObservationDataCategory>();

        //public ObservableCollection<ObservationDataCategory> GetData()
        //{
        //    List<ObservationDataItem> generalItems = new List<ObservationDataItem>();
        //    GeneralObservationData general = new GeneralObservationData();

        //    ObservationValue constellation = new ObservationValue();
        //    constellation.AddPrimitive("Orion");

        //    ObservationValue raValue = new ObservationValue();
        //    raValue.AddPrimitive("+07", "°");
        //    raValue.AddPrimitive("24", "′");
        //    raValue.AddPrimitive("25.426", "″");

        //    ObservationValue decValue = new ObservationValue();
        //    decValue.AddPrimitive("05", "h");
        //    decValue.AddPrimitive("55", "m");
        //    decValue.AddPrimitive("10.3053", "s");

        //    generalItems.Add(new ObservationDataItem() { Designation = "", HasHelp = false, Name = "Constellation", Values = new List<ObservationValue>() { constellation } });
        //    generalItems.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "Right Ascension", Values = new List<ObservationValue> { raValue } });
        //    generalItems.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "Declination", Values = new List<ObservationValue> { decValue } });

        //    general.CategoryItems = generalItems;

            
        //    generalItems.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "Spectral type", Values = null });
        //    generalItems.Add(new ObservationDataItem() { Designation = "V", HasHelp = true, Name = "Apparent magnitude", Values = null });
        //    generalItems.Add(new ObservationDataItem() { Designation = "J", HasHelp = true, Name = "Apparent magnitude", Values = null });
        //    generalItems.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "U−B color index", Values = null });
        //    generalItems.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "B−V color index", Values = null });
        //    generalItems.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "Variable type", Values = null });

            
        //    generalItems.Add(new ObservationDataItem() { Designation = "R_v", HasHelp = true, Name = "Radial velocity", Values = null });
        //    generalItems.Add(new ObservationDataItem() { Designation = @"\mu", HasHelp = true, Name = "Proper motion", Values = null });
        //    generalItems.Add(new ObservationDataItem() { Designation = @"\pi", HasHelp = true, Name = "Parallax", Values = null });
        //    generalItems.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "Distance", Values = null });
        //    generalItems.Add(new ObservationDataItem() { Designation = "M_v", HasHelp = true, Name = "Absolute magnitude", Values = null });

            

        //    //List<ObservationDataItem> characteristicsItems = new List<ObservationDataItem>();
        //    //Characteristics characteristics = new Characteristics();
        //    //characteristicsItems.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "Spectral type", Values = null });
        //    //characteristicsItems.Add(new ObservationDataItem() { Designation = "V", HasHelp = true, Name = "Apparent magnitude", Values = null });
        //    //characteristicsItems.Add(new ObservationDataItem() { Designation = "J", HasHelp = true, Name = "Apparent magnitude", Values = null });
        //    //characteristicsItems.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "U−B color index", Values = null });
        //    //characteristicsItems.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "B−V color index", Values = null });
        //    //characteristicsItems.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "Variable type", Values = null });

        //    //characteristics.CategoryItems = characteristicsItems;

        //    //List<ObservationDataItem> astrometryItems = new List<ObservationDataItem>();
        //    //Astrometry astrometry = new Astrometry();
        //    //astrometryItems.Add(new ObservationDataItem() { Designation = "R_v", HasHelp = true, Name = "Radial velocity", Values = null });
        //    //astrometryItems.Add(new ObservationDataItem() { Designation = @"\mu", HasHelp = true, Name = "Proper motion", Values = null });
        //    //astrometryItems.Add(new ObservationDataItem() { Designation = @"\pi", HasHelp = true, Name = "Parallax", Values = null });
        //    //astrometryItems.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "Distance", Values = null });
        //    //astrometryItems.Add(new ObservationDataItem() { Designation = "M_v", HasHelp = true, Name = "Absolute magnitude", Values = null });

        //    //astrometry.CategoryItems = astrometryItems;

        //    all.Add(general);
        //    //all.Add(characteristics);
        //    //all.Add(astrometry);
            

        //    return all;
        //}

        //public static ObservableCollection<ObservationDataItem> GetObservationData()
        //{
        //    ObservableCollection<ObservationDataItem> all = new ObservableCollection<ObservationDataItem>();
        //    //GeneralObservationData general = new GeneralObservationData();

        //    ObservationValue constellation = new ObservationValue();
        //    constellation.AddPrimitive("Orion");

        //    ObservationValue raValue = new ObservationValue();
        //    raValue.AddPrimitive("+07", "°");
        //    raValue.AddPrimitive("24", "′");
        //    raValue.AddPrimitive("25.426", "″");

        //    ObservationValue raValue2 = new ObservationValue();
        //    raValue2.AddPrimitive("+07", "°");
        //    raValue2.AddPrimitive("24", "′");
        //    raValue2.AddPrimitive("25.426", "″");

        //    ObservationValue raValue3 = new ObservationValue();
        //    raValue3.AddPrimitive("+07", "°");
        //    raValue3.AddPrimitive("24", "′");
        //    raValue3.AddPrimitive("25.426", "″");

        //    ObservationValue decValue = new ObservationValue();
        //    decValue.AddPrimitive("05", "h");
        //    decValue.AddPrimitive("55", "m");
        //    decValue.AddPrimitive("10.3053", "s");

        //    all.Add(new ObservationDataItem() { Designation = "", HasHelp = false, Name = "Constellation", Values = new List<ObservationValue>() { constellation, constellation } });
        //    all.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "Right Ascension", Values = new List<ObservationValue> { raValue, raValue2, raValue3 } });
        //    all.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "Declination", Values = new List<ObservationValue> { decValue, decValue } });


        //    all.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "Spectral type", Values = null });
        //    all.Add(new ObservationDataItem() { Designation = "V", HasHelp = true, Name = "Apparent magnitude", Values = null });
        //    all.Add(new ObservationDataItem() { Designation = "J", HasHelp = true, Name = "Apparent magnitude", Values = null });
        //    all.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "U−B color index", Values = null });
        //    all.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "B−V color index", Values = null });
        //    all.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "Variable type", Values = null });
        //    all.Add(new ObservationDataItem() { Designation = "R_v", HasHelp = true, Name = "Radial velocity", Values = null });
        //    all.Add(new ObservationDataItem() { Designation = @"\mu", HasHelp = true, Name = "Proper motion", Values = null });
        //    all.Add(new ObservationDataItem() { Designation = @"\pi", HasHelp = true, Name = "Parallax", Values = null });
        //    all.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "Distance", Values = null });
        //    all.Add(new ObservationDataItem() { Designation = "M_v", HasHelp = true, Name = "Absolute magnitude", Values = null });



        //    //List<ObservationDataItem> characteristicsItems = new List<ObservationDataItem>();
        //    //Characteristics characteristics = new Characteristics();
        //    //characteristicsItems.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "Spectral type", Values = null });
        //    //characteristicsItems.Add(new ObservationDataItem() { Designation = "V", HasHelp = true, Name = "Apparent magnitude", Values = null });
        //    //characteristicsItems.Add(new ObservationDataItem() { Designation = "J", HasHelp = true, Name = "Apparent magnitude", Values = null });
        //    //characteristicsItems.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "U−B color index", Values = null });
        //    //characteristicsItems.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "B−V color index", Values = null });
        //    //characteristicsItems.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "Variable type", Values = null });

        //    //characteristics.CategoryItems = characteristicsItems;

        //    //List<ObservationDataItem> astrometryItems = new List<ObservationDataItem>();
        //    //Astrometry astrometry = new Astrometry();
        //    //astrometryItems.Add(new ObservationDataItem() { Designation = "R_v", HasHelp = true, Name = "Radial velocity", Values = null });
        //    //astrometryItems.Add(new ObservationDataItem() { Designation = @"\mu", HasHelp = true, Name = "Proper motion", Values = null });
        //    //astrometryItems.Add(new ObservationDataItem() { Designation = @"\pi", HasHelp = true, Name = "Parallax", Values = null });
        //    //astrometryItems.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "Distance", Values = null });
        //    //astrometryItems.Add(new ObservationDataItem() { Designation = "M_v", HasHelp = true, Name = "Absolute magnitude", Values = null });

        //    //astrometry.CategoryItems = astrometryItems;

        //    //all.Add(general);
        //    //all.Add(characteristics);
        //    //all.Add(astrometry);


        //    return all;
        //}
    }
}
