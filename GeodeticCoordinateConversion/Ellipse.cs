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
        public double a;    //长半轴
        public double b;    //短半轴
        public double e;    //第一偏心率
        public double e2;   //第二偏心率
        public double c;    //极点处子午线曲率半径
        public EllipseType ellipseType; //椭球类型

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="newEllipse">要设置的椭球类型</param>
        public Ellipse(EllipseType newEllipse)
        {
            if ((int)newEllipse < 0)
                throw new ArgumentOutOfRangeException("新建椭球类型参数非法。");
            SetEllipseType(newEllipse);
        }

        /// <summary>
        /// 设置椭球
        /// </summary>
        /// <param name="newEllipse">新的椭球类型。</param>
        /// <returns>设置是否成功。</returns>
        public bool SetEllipseType(EllipseType newEllipse)
        {
            if (newEllipse == ellipseType)
                return false;
            switch (newEllipse)
            {
                case EllipseType.Krassovsky_ellipsoid:
                    {
                        //克拉索夫斯基椭球体
                        this.a = 6378245;
                        this.b = 6356863.0187730473;
                        break;
                    }
                case EllipseType.Int_1975:
                    {
                        //1975年国际椭球体
                        this.a = 6378140;
                        this.b = 6356755.2881575287;
                        break;
                    }
                case EllipseType.WGS_84:
                    {
                        //WGS-84椭球体
                        this.a = 6378137;
                        this.b = 6356752.3142;
                        break;
                    }
                case EllipseType.CGCS_2000:
                    {
                        //CGCS-2000
                        this.a = 6378137;
                        this.b = 6356752.3141;
                        break;
                    }
                default:
                    {
                        throw new Exception("新建椭球参数错误！");
                    }
            }
            this.c = Math.Pow(this.a, 2) / this.b;
            this.e = Math.Sqrt(Math.Pow(this.a, 2) - Math.Pow(this.b, 2)) / this.a;
            this.e2 = Math.Sqrt(Math.Pow(this.a, 2) - Math.Pow(this.b, 2)) / this.b;
            return true;
        }
    }

    /// <summary>
    /// 椭球枚举常量
    /// </summary>
    public enum EllipseType
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
