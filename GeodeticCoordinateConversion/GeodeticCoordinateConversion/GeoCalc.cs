﻿using System;
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

        //字符串截取(DDD.MMSS)
        internal static DMS Str2DMS(string InputStr)
        {
            DMS ResultDMS = new DMS();
            if (InputStr.IndexOf('.') > 0)
            {
                string[] SplitStr = InputStr.Split('.');
                while (SplitStr[1].Length < 4)
                {
                    SplitStr[1] += "0";
                }

                //从字符串拆分度分秒
                ResultDMS.D = Convert.ToInt32(SplitStr[0]);
                ResultDMS.M = Convert.ToInt32(SplitStr[1].Substring(0, 2));
                ResultDMS.S = Convert.ToDouble(SplitStr[1].Substring(2));
            }
            else
            {
                ResultDMS.D = Convert.ToInt32(InputStr);
                ResultDMS.M = 0;
                ResultDMS.S = 0;
            }

            //确认小数点位置
            while (ResultDMS.S > 60.0)
            {
                ResultDMS.S /= 10;
            }
            return ResultDMS;
        }

        //转换到字符串(To DDD.MMSS)
        internal static string DMS2Str(DMS InputDMS)
        {
            string D = InputDMS.D.ToString();
            string M = InputDMS.M.ToString("00");
            string S = InputDMS.S.ToString();

            //去除小数
            while (S.Contains("."))
            {
                S = (Convert.ToDouble(S) * 10).ToString();
            }
            return D + "." + M + S;
        }

        //求中央经线
        internal static double GetCenter(int Type, int Zone)
        {
            if (Type == 6)
            {
                return (6 * Zone - 3);
            }
            else if (Type == 3)
            {
                return (3 * Zone);
            }
            else
            {
                throw new Exception("分带不正确！");
            }
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

        //设置椭球
        internal static Ellipse SetEllipse(int EllipseNum)
        {
            Ellipse E = new Ellipse();
            switch (EllipseNum)
            {
                case 0:
                    {
                        //克拉索夫斯基椭球体
                        E.a = 6378245;
                        E.b = 6356863.0187730473;
                        break;
                    }
                case 1:
                    {
                        //1975年国际椭球体
                        E.a = 6378140;
                        E.b = 6356755.2881575287;
                        break;
                    }
                case 2:
                    {
                        //WGS-84椭球体
                        E.a = 6378137;
                        E.b = 6356752.3142;
                        break;
                    }
                case 3:
                    {
                        //CGCS-2000
                        E.a = 6378137;
                        E.b = 6356752.3141;
                        break;
                    }
                default:
                    {
                        throw new Exception("椭球参数错误！");
                    }
            }
            E.c = Math.Pow(E.a, 2) / E.b;
            E.e = Math.Sqrt(Math.Pow(E.a, 2) - Math.Pow(E.b, 2)) / E.a;
            E.e2 = Math.Sqrt(Math.Pow(E.a, 2) - Math.Pow(E.b, 2)) / E.b;
            return E;
        }
    }
}