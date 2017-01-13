using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenith.Client.ViewModel.Mock
{
    public static class MockExactResult
    {
        public static ObjectsDetailsViewModel GetResult()
        {
            ObjectsDetailsViewModel view = new ObjectsDetailsViewModel();

            //view.Heading = "* alf Ori";
            //view.ObjectType = "Main sequence star";
            //view.OtherIdentifiers = new System.Collections.ObjectModel.ObservableCollection<string>() {"2MASS J05551028+0724255",
            //                                                                                            "PLX 1362",
            //                                                                                            "*  58 Ori",
            //                                                                                            "* alf Ori",
            //                                                                                            "AAVSO 0549+07",
            //                                                                                            "ADS  4506 AP",
            //                                                                                            "AG+07  681",
            //                                                                                            "BD+07  1055",
            //                                                                                            "CCDM J05552+0724AP",
            //                                                                                            "CSI+07  1055  1",
            //                                                                                            "EIC   108",
            //                                                                                            "FK5  224",
            //                                                                                            "GC  7451",
            //                                                                                            "GCRV  3679",
            //                                                                                            "GEN# +1.00039801J",
            //                                                                                            "GSC 00129-01873",
            //                                                                                            "HD  39801",
            //                                                                                            "HIC  27989",
            //                                                                                            "HIP  27989",
            //                                                                                            "HR  2061",
            //                                                                                            "IRAS 05524+0723",
            //                                                                                            "IRC +10100",
            //                                                                                            "JP11  1282",
            //                                                                                            "N30 1266",
            //                                                                                            "NAME BETELGEUSE",
            //                                                                                            "PMC 90-93   162",
            //                                                                                            "PPM 149643",
            //                                                                                            "RAFGL  836",
            //                                                                                            "SAO 113271",
            //                                                                                            "SKY#  9804",
            //                                                                                            "TD1  5587",
            //                                                                                            "TYC  129-1873-1",
            //                                                                                            "UBV   21314",
            //                                                                                            "V* alf Ori",
            //                                                                                            "YZ   7  2503",
            //                                                                                            "[LFO93] 0552+07",
            //                                                                                            "JCMTSE J055510.1+072426",
            //                                                                                            "PLX 1362.00",
            //                                                                                            "JCMTSF J055510.1+072426",
            //                                                                                            "WDS J05552+0724Aa,Ab",
            //                                                                                            "** H  639A",
            //                                                                                            "WDS J05552+0724Aa,Ac",
            //                                                                                            "WDS J05552+0724A",
            //                                                                                            "** KAR    1" };

            //ObservableCollection<ObservationDataItem> obsDataItems = new ObservableCollection<ObservationDataItem>();

            //ObservationValue constellation = new ObservationValue();
            //constellation.AddPrimitive("Orion");

            //ObservationValue raValue = new ObservationValue();
            //raValue.AddPrimitive("+07", "°");
            //raValue.AddPrimitive("24", "′");
            //raValue.AddPrimitive("25.426", "″");

            ////ObservationValue raValue2 = new ObservationValue();
            ////raValue2.AddPrimitive("+07", "°");
            ////raValue2.AddPrimitive("24", "′");
            ////raValue2.AddPrimitive("25.426", "″");

            ////ObservationValue raValue3 = new ObservationValue();
            ////raValue3.AddPrimitive("+07", "°");
            ////raValue3.AddPrimitive("24", "′");
            ////raValue3.AddPrimitive("25.426", "″");

            //ObservationValue decValue = new ObservationValue();
            //decValue.AddPrimitive("05", "h");
            //decValue.AddPrimitive("55", "m");
            //decValue.AddPrimitive("10.3053", "s");

            //obsDataItems.Add(new ObservationDataItem() { Designation = "", HasHelp = false, Name = "Constellation", Values = new List<ObservationValue>() { constellation/*, constellation */} });
            //obsDataItems.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "Right Ascension", Values = new List<ObservationValue> { raValue/*, raValue2, raValue3 */} });
            //obsDataItems.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "Declination", Values = new List<ObservationValue> { decValue/*, decValue */} });            
            //obsDataItems.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "Spectral type", Values = null });
            //obsDataItems.Add(new ObservationDataItem() { Designation = "V", HasHelp = true, Name = "Apparent magnitude", Values = null });
            //obsDataItems.Add(new ObservationDataItem() { Designation = "J", HasHelp = true, Name = "Apparent magnitude", Values = null });
            //obsDataItems.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "U−B color index", Values = null });
            //obsDataItems.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "B−V color index", Values = null });
            //obsDataItems.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "Variable type", Values = null });
            //obsDataItems.Add(new ObservationDataItem() { Designation = "R_v", HasHelp = true, Name = "Radial velocity", Values = null });
            //obsDataItems.Add(new ObservationDataItem() { Designation = @"\mu", HasHelp = true, Name = "Proper motion", Values = null });
            //obsDataItems.Add(new ObservationDataItem() { Designation = @"\pi", HasHelp = true, Name = "Parallax", Values = null });
            //obsDataItems.Add(new ObservationDataItem() { Designation = "", HasHelp = true, Name = "Distance", Values = null });
            //obsDataItems.Add(new ObservationDataItem() { Designation = "M_v", HasHelp = true, Name = "Absolute magnitude", Values = null });

            //view.ObservationData = obsDataItems;

            return view;
        }
    }
}
