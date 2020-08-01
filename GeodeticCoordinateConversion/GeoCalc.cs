using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeodeticCoordinateConversion
{
    class GeoCalc
    {
        #region 角度计算类
        //十进制转弧度
        public static double DEC2ARC(double DEC)
        {
            return (DEC * Math.PI / 180);
        }

        //弧度转十进制
        public static double ARC2DEC(double ARC)
        {
            return (ARC / Math.PI * 180);
        }

        //度分秒转十进制
        public static double DMS2DEC(DMS DDMS)
        {
            double Result = DDMS.D + DDMS.M / 60.0 + DDMS.S / 3600.0;
            return Result;
        }

        //十进制转度分秒
        public static DMS DEC2DMS(double DEC)
        {
            //DMS Result = new DMS
            //{
            //    D = (int)DEC
            //};
            //Result.M = (int)((DEC - Result.D) * 60);
            //Result.S = ((DEC - Result.D) * 60 - Result.M) * 60;
            DMS Result = new DMS
            {
                D = 0,
                M = 0,
                S = DEC * 3600,
            };
            while (Result.S >= 60)
            {
                Result.S -= 60;
                Result.M += 1;
            }
            while (Result.M >= 60)
            {
                Result.M -= 60;
                Result.D += 1;
            }

            return Result;
        }

        //度分秒转弧度
        public static double DMS2ARC(DMS DDMS)
        {
            double TempDEC = 0;
            double Result = 0;
            TempDEC = DMS2DEC(DDMS);
            Result = DEC2ARC(TempDEC);
            return Result;
        }

        //弧度转度分秒
        public static DMS ARC2DMS(double ARC)
        {
            double TempDEC = 0;
            DMS Result = new DMS();
            TempDEC = ARC2DEC(ARC);
            Result = DEC2DMS(TempDEC);
            return Result;
        }
        #endregion

        /// <summary>
        /// 度分秒(DDD.MMSS)转换到字符串。
        /// </summary>
        /// <param name="InputDMS">要转换到字符串的度分秒(DDD.MMSS)。</param>
        /// <returns>转换到的字符串。</returns>
        internal static string DMS2Str(DMS InputDMS)
        {
            string S = InputDMS.S.ToString();

            //去除小数(是否造成问题？？？)
            while (S.Contains("."))
            {
                S = (Convert.ToDouble(S) * 10.0).ToString();
            }
            return InputDMS.D.ToString() + "." + InputDMS.M.ToString("00") + S;
        }

        //提取带号
        internal static int GetZoneNum(string YCoord)
        {
            int ZoneNum = 0;
            double ResultY = 0;
            Extract(YCoord, ref ResultY, ref ZoneNum);
            return ZoneNum;
        }

        //获取Y坐标
        internal static double GetY(string YCoord)
        {
            int ZoneNum = 0;
            double ResultY = 0;
            Extract(YCoord, ref ResultY, ref ZoneNum);
            return ResultY - 500000;    //-500km读取
        }

        //提取类
        internal static void Extract(string YCoord, ref double ResultY, ref int ZoneNum)
        {
            if (YCoord.IndexOf('.') >= 0)   //存在小数点
            {
                string[] TmpSplit = YCoord.Split('.');
                while (TmpSplit[0].Length < 9)
                {
                    YCoord = "0" + YCoord;
                    TmpSplit = YCoord.Split('.');
                }
            }
            else   //不存在小数点
            {
                while(YCoord.Length < 9)
                {
                    YCoord = "0" + YCoord;
                }
            }
            ResultY = Convert.ToDouble(YCoord.Substring(3));
            ZoneNum = Convert.ToInt32(YCoord.Substring(0, 3));
        }

       
    }
}
