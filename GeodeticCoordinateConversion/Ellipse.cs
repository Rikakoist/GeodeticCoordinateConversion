using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodeticCoordinateConversion
{
    /// <summary>
    /// 椭球对象
    /// </summary>
    class Ellipse
    {
        public double a { get; private set; }  //长半轴
        public double b { get; private set; }    //短半轴
        public double e { get; private set; }    //第一偏心率
        public double e2 { get; private set; }  //第二偏心率
        public double c { get; private set; }    //极点处子午线曲率半径
        private GEOEllipseType ellipseType; //椭球类型
        public GEOEllipseType EllipseType
        {
            get
            {
                return ellipseType;
            }
            set
            {
                if (value == ellipseType)
                    return;
                else
                {
                    ellipseType = value;
                    switch (value)
                    {
                        case GEOEllipseType.noEllipse:
                            {
                                return;
                            }
                        case GEOEllipseType.Krassovsky_ellipsoid:
                            {
                                //克拉索夫斯基椭球体
                                this.a = 6378245;
                                this.b = 6356863.0187730473;
                                break;
                            }
                        case GEOEllipseType.Int_1975:
                            {
                                //1975年国际椭球体
                                this.a = 6378140;
                                this.b = 6356755.2881575287;
                                break;
                            }
                        case GEOEllipseType.WGS_84:
                            {
                                //WGS-84椭球体
                                this.a = 6378137;
                                this.b = 6356752.3142;
                                break;
                            }
                        case GEOEllipseType.CGCS_2000:
                            {
                                //CGCS-2000
                                this.a = 6378137;
                                this.b = 6356752.3141;
                                break;
                            }
                        default:
                            {
                                throw new Exception(ErrMessages.ArgumentUnknown);
                            }
                    }
                    this.c = Math.Pow(this.a, 2) / this.b;
                    this.e = Math.Sqrt(Math.Pow(this.a, 2) - Math.Pow(this.b, 2)) / this.a;
                    this.e2 = Math.Sqrt(Math.Pow(this.a, 2) - Math.Pow(this.b, 2)) / this.b;
                }
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="newEllipse">要设置的椭球类型</param>
        public Ellipse(GEOEllipseType newEllipse)
        {
            if ((int)newEllipse < 0)
                throw new ArgumentOutOfRangeException(ErrMessages.ArgumentUnknown);
            this.EllipseType = newEllipse;
        }
    }

    /// <summary>
    /// 椭球枚举常量
    /// </summary>
    public enum GEOEllipseType
    {
        /// <summary>
        /// 未设置椭球
        /// </summary>
        noEllipse = 0,
        /// <summary>
        /// 克拉索夫斯基椭球体
        /// </summary>
        Krassovsky_ellipsoid = 1,
        /// <summary>
        /// 1975年国际椭球体
        /// </summary>
        Int_1975 = 2,
        /// <summary>
        /// WGS-84椭球体
        /// </summary>
        WGS_84 = 3,
        /// <summary>
        /// CGCS-2000
        /// </summary>
        CGCS_2000 = 4
    }
}
