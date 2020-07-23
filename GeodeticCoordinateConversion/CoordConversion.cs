using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeodeticCoordinateConversion
{
    class CoordConversion
    {
        //预备转换
        internal static void GaussPrepare(Ellipse E, ref List<GaussCoord> GC, ref List<BL> BLDMS, int Mode, int ZoneType)
        {
            switch (Mode)
            {
                case 0:  //Mode 0正算
                    {
                        GC = GaussDirect(DMSList2DEC(BLDMS), E.a, E.e, E.e2, ZoneType);
                        break;
                    }
                case 1:  //Mode 1反算
                    {
                        BLDMS = GaussReverse(GC, E.a, E.e, E.e2);
                        break;
                    }
                default:
                    {
                        throw new Exception("正反算参数错误。");
                    }
            }
        }

        //度分秒列表整体转换十进制
        internal static List<DEC> DMSList2DEC(List<BL> InputBLDMS)
        {
            List<DEC> ResultDEC = new List<DEC>();
            foreach (BL BLDMS in InputBLDMS)
            {
                DEC DC = new DEC
                {
                    B = GeoCalc.DMS2DEC(BLDMS.B),
                    L = GeoCalc.DMS2DEC(BLDMS.L),
                };
                //MessageBoxes.Error(DC.B.ToString() + " "+DC.L.ToString());
                ResultDEC.Add(DC);
            }
            return ResultDEC;
        }

        //高斯投影正算
        internal static List<GaussCoord> GaussDirect(List<DEC> InputDEC, double a, double e, double e2, int ZoneType)
        {
            List<GaussCoord> GaussResult = new List<GaussCoord>();

            //克拉索夫斯基椭球元素
            double m0 = a * (1 - Math.Pow(e, 2));
            double m2 = 3 / 2 * Math.Pow(e, 2) * m0;
            double m4 = 5 / 4 * Math.Pow(e, 2) * m2;
            double m6 = 7 / 6 * Math.Pow(e, 2) * m4;
            double m8 = 9 / 8 * Math.Pow(e, 2) * m6;

            double a0 = m0 + m2 / 2 + 3 / 8 * m4 + 5 / 16 * m6 + 35 / 128 * m8;
            double a2 = m2 / 2 + m4 / 2 + 15 / 32 * m6 + 7 / 16 * m8;
            double a4 = m4 / 8 + 3 / 16 * m6 + 7 / 32 * m8;
            double a6 = m6 / 32 + m8 / 16;
            double a8 = m8 / 128;

            foreach (DEC CDEC in InputDEC)
            {
                double l=0;
                if (ZoneType == 6)// 按6度分带计算l
                {
                    CDEC.ZoneType = GEOZoneType.Zone6;
                    //CDEC.Zone = Convert.ToInt32(Math.Round((CDEC.L + 3) / 6));
                    //CDEC.Center = 6 * CDEC.Zone - 3;   //求6度带中央经线                  
                    l = CDEC.L - CDEC.Center;
                }
                else if (ZoneType == 3)
                {
                    CDEC.ZoneType = GEOZoneType.Zone3;
                    //CDEC.Zone = Convert.ToInt32(Math.Round(CDEC.L / 3));
                    //CDEC.Center = 3 * CDEC.Zone;
                    l = CDEC.L - CDEC.Center;
                }
                l *= 3600;

                //十进制转弧度
                CDEC.B = GeoCalc.DEC2ARC(CDEC.B);
                CDEC.L = GeoCalc.DEC2ARC(CDEC.L);

                //计算中间参数
                double W = Math.Sqrt(1 - Math.Pow(e, 2) * Math.Pow((Math.Sin(CDEC.B)), 2));
                double M = a * Math.Pow(1 - e, 2) / Math.Pow(W, 3);
                double N = a / W;
                double n = Math.Pow(e2, 2) * Math.Pow((Math.Cos(CDEC.B)), 2);
                double p = 206265;

                // 求子午线弧长
                double X = a0 * CDEC.B - Math.Sin(CDEC.B) * Math.Cos(CDEC.B) * ((a2 - a4 + a6) + (2 * a4 - 16 / 3 * a6) * Math.Pow(Math.Sin(CDEC.B), 2) + 16 / 3 * a6 * Math.Pow(Math.Sin(CDEC.B), 4));
                double t = Math.Tan(CDEC.B);

                //正算转换
                GaussCoord GC = new GaussCoord
                {
                    x = X + N / 2 * Math.Sin(CDEC.B) * Math.Cos(CDEC.B) * Math.Pow(l, 2) / Math.Pow(p, 2) + N / (24 * Math.Pow(p, 4)) * Math.Sin(CDEC.B) * (Math.Pow((Math.Cos(CDEC.B)), 3)) * (5 - Math.Pow(t, 2) + 9 * n + 4 * Math.Pow(n, 2)) * Math.Pow(l, 4) + N / (720 * Math.Pow(p, 6)) * Math.Sin(CDEC.B) * (Math.Pow((Math.Cos(CDEC.B)), 5)) * (61 - 58 * Math.Pow(t, 2) + Math.Pow(t, 4)) * Math.Pow(l, 6),
                    y = N * Math.Cos(CDEC.B) * l / p + N / (6 * Math.Pow(p, 3)) * (Math.Pow(Math.Cos(CDEC.B), 3)) * (1 - Math.Pow(t, 2) + n) * Math.Pow(l, 3) + N / (120 * Math.Pow(p, 5)) * (Math.Pow(Math.Cos(CDEC.B), 5)) * (5 - 18 * Math.Pow(t, 2) + Math.Pow(t, 4) + 14 * n - 58 * Math.Pow(t, 2) * n) * Math.Pow(l, 5),
                    Zone = CDEC.Zone,
                    ZoneType = CDEC.ZoneType   
                };
                GaussResult.Add(GC);
            }
            return GaussResult;
        }

        //高斯投影反算
        internal static List<BL> GaussReverse(List<GaussCoord> InputGC, double a, double e, double e2)
        {
            List<BL> ResultBL = new List<BL>();
            foreach (GaussCoord GC in InputGC)
            {
                double beta = GC.x / 6367588.4969;
                double Bf = beta + (50221746 + (293622 + (2350 + 22 * Math.Pow(Math.Cos(beta), 2)) * Math.Pow(Math.Cos(beta), 2)) * Math.Pow(Math.Cos(beta), 2)) * Math.Pow(10, -10) * Math.Sin(beta) * Math.Cos(beta);
                double nf = Math.Pow(e2, 2) * Math.Pow(Math.Cos(Bf), 2);
                double Wf = Math.Sqrt(1 - Math.Pow(e, 2) * Math.Pow(Math.Sin(Bf), 2));
                double Mf = a * (1 - Math.Pow(e, 2)) / Math.Pow(Wf, 3);
                double Nf = a / Wf;
                double tf = Math.Tan(Bf);

                //反算B、l
                double B = Bf - tf * Math.Pow(GC.y, 2) / (2 * Mf * Nf) + tf * (5 + 3 * Math.Pow(tf, 2) + nf - 9 * nf * Math.Pow(tf, 2)) * Math.Pow(GC.y, 4) / (24 * Mf * Math.Pow(Nf, 3)) - tf * (61 + 90 * Math.Pow(tf, 2) + 45 * Math.Pow(tf, 4)) * Math.Pow(GC.y, 6) / (720 * Mf * Math.Pow(Nf, 5));
                B = B / Math.PI * 180;
                double L = GC.y / (Nf * Math.Cos(Bf)) - (1 + 2 * Math.Pow(tf, 2) + nf) * Math.Pow(GC.y, 3) / (6 * Math.Pow(Nf, 3) * Math.Cos(Bf)) + (5 + 28 * Math.Pow(tf, 2) + 24 * Math.Pow(tf, 4) + 6 * nf + 8 * nf * Math.Pow(tf, 2)) * Math.Pow(GC.y, 5) / (120 * Math.Pow(Nf, 5) * Math.Cos(Bf));
                L = L / Math.PI * 180;

                //计算中央经线
                GC.GetCenter();

                // 本带内经度换算
                L += GC.Center;
                BL TmpBL = new BL()
                {
                    B = GeoCalc.DEC2DMS(B),
                    L = GeoCalc.DEC2DMS(L),
                };
                ResultBL.Add(TmpBL);
            }
            return ResultBL;
        }
    }
}