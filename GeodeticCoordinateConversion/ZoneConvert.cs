using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodeticCoordinateConversion
{
    /// <summary>
    /// 6度带、3度带互转类。
    /// </summary>
    public class ZoneConvert
    {
        public bool Gauss6Dirty = true;
        public GaussCoord Gauss6;
        public bool Gauss3Dirty = true;
        public GaussCoord Gauss3;

        

        public void Convert6To3()
        {
            Gauss3 = Gauss6.GaussReverse() //六度带反算
                  .GaussDirect(GEOZoneType.Zone3);   //三度带正算
        }

        public void Convert3To6()
        {
            Gauss6 = Gauss3.GaussReverse()   //三度带反算
                  .GaussDirect(GEOZoneType.Zone6);   //六度带正算
        }

        public void AutoConvert()
        {

        }
    }
}
