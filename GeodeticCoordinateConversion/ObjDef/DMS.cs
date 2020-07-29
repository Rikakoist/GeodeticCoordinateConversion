﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GeodeticCoordinateConversion
{
    /// <summary>
    /// 度分秒类。
    /// </summary>
    public sealed class DMS
    {
        #region Fields
        /// <summary>
        /// 全局唯一ID。
        /// </summary>
        public readonly Guid guid;
        /// <summary>
        /// 度（私有）。
        /// </summary>
        private double d;
        /// <summary>
        /// 分（私有）。
        /// </summary>
        private double m;
        /// <summary>
        /// 秒（私有）。
        /// </summary>
        private double s;
        #endregion

        #region Properties
        /// <summary>
        /// 度。
        /// </summary>
        public double D
        {
            get => d;
            set
            {
                if ((value < Restraints.DegreeMin) || (value > Restraints.DegreeMax))
                {
                    throw new ArgumentOutOfRangeException(ErrMessage.Data.DegreeOutOfRange);
                }
                else
                {
                    if (d == value)
                        return;
                    d = value;
                    DChanged?.Invoke(this, new EventArgs());
                }
            }
        }
        /// <summary>
        /// 分。
        /// </summary>
        public double M
        {
            get => m;
            set
            {
                if ((value < Restraints.MinuteMin) || (value > Restraints.MinuteMax))
                {
                    throw new ArgumentOutOfRangeException(ErrMessage.Data.MinuteOutOfRange);
                }
                else
                {
                    if (m == value)
                        return;
                    m = value;
                    MChanged?.Invoke(this, new EventArgs());
                }
            }
        }
        /// <summary>
        /// 秒。
        /// </summary>
        public double S
        {
            get => s;
            set
            {
                if ((value < Restraints.SecondMin) || (value > Restraints.SecondMax))
                {
                    throw new ArgumentOutOfRangeException(ErrMessage.Data.SecondOutOfRange);
                }
                else
                {
                    if (s == value)
                        return;
                    s = value;
                    SChanged?.Invoke(this, new EventArgs());
                }
            }
        }
        /// <summary>
        /// 度分秒字符串表示形式。
        /// </summary>
        public string Value
        {
            get => this.ToString();
            set => this.FromString(value);
        }
        #endregion

        #region Constructor
        /// <summary>
        /// 空的度分秒对象构造函数。度、分、秒将设为默认值0。
        /// </summary>
        public DMS()
        {
            try
            {
                this.guid = System.Guid.NewGuid();
                this.D = 0; this.M = 0; this.S = 0;
            }
            catch (Exception err)
            {
                throw new InitializeException(ErrMessage.DMS.InitializeError, err);
            }
        }

        /// <summary>
        /// 使用字符串初始化度分秒对象。
        /// </summary>
        /// <param name="Str"></param>
        public DMS(string Str)
        {
            try
            {
                this.guid = System.Guid.NewGuid();
                FromString(Str);
            }
            catch (Exception err)
            {
                throw new InitializeException(ErrMessage.DMS.InitializeError, err);
            }
        }

        /// <summary>
        /// 使用度分秒初始化度分秒对象。
        /// </summary>
        /// <param name="D">度。</param>
        /// <param name="M">分。</param>
        /// <param name="S">秒。</param>
        public DMS(double D, double M, double S)
        {
            try
            {
                this.guid = System.Guid.NewGuid();
                this.D = D; this.M = M; this.S = S;
            }
            catch (Exception err)
            {
                throw new InitializeException(ErrMessage.DMS.InitializeError, err);
            }
        }

        /// <summary>
        /// 通过XML节点初始化度分秒对象。
        /// </summary>
        /// <param name="xmlNode">包含对象结构的XML节点。</param>
        public DMS(XmlNode xmlNode)
        {
            try
            {
                XmlElement ele = (XmlElement)xmlNode;
                this.guid = Guid.Parse(ele.GetAttribute(nameof(guid)));
                this.D = double.Parse(ele.GetAttribute(nameof(D)));
                this.M = double.Parse(ele.GetAttribute(nameof(M)));
                this.S = double.Parse(ele.GetAttribute(nameof(S)));
            }
            catch (Exception err)
            {
                throw new InitializeFromXmlException(ErrMessage.DMS.InitializeError, err);
            }
        }
        #endregion

        #region Events
        public delegate void DChangedEventHander(object sender, EventArgs e);
        public event DChangedEventHander DChanged;
        public delegate void MChangedEventHander(object sender, EventArgs e);
        public event MChangedEventHander MChanged;
        public delegate void SChangedEventHander(object sender, EventArgs e);
        public event SChangedEventHander SChanged;
        #endregion

        #region Methods
        /// <summary>
        /// 度分秒对象转换到XML元素。
        /// </summary>
        /// <param name="xmlDocument">指定的XML文档。</param>
        /// <param name="NodeName">新建的元素命名。</param>
        /// <returns>转换到的XML元素。</returns>
        public XmlElement ToXmlElement(XmlDocument xmlDocument, string NodeName)
        {
            try
            {
                XmlElement ele = xmlDocument.CreateElement(NodeName);

                ele.SetAttribute(nameof(guid), this.guid.ToString());
                ele.SetAttribute(nameof(D), this.D.ToString());
                ele.SetAttribute(nameof(M), this.M.ToString());
                ele.SetAttribute(nameof(S), this.S.ToString());

                return ele;
            }
            catch (Exception err)
            {
                throw new XmlException(ErrMessage.DMS.SaveToXmlFailed, err);
            }
        }

        /// <summary>
        /// 使用字符串设置度分秒的值。
        /// </summary>
        /// <param name="Str">输入字符串。</param>
        public void FromString(string Str)
        {
            try
            {
                if ((Str.IndexOf('.') == 0) || (Str.IndexOf('.') == Str.Length - 1) || ((Str.Split('.')).Length > 2))
                {
                    throw new FormatException(ErrMessage.Data.WrongDigitPosition);
                }
                if (Str.IndexOf('.') > 0)
                {
                    string[] SplitStr = Str.Split('.');
                    //小数点后补0至四位
                    while (SplitStr[1].Length < 4)
                    {
                        SplitStr[1] += "0";
                    }

                    //从字符串拆分度分秒
                    D = Convert.ToInt32(SplitStr[0]);
                    M = Convert.ToInt32(SplitStr[1].Substring(0, 2));
                    double tmpS = Convert.ToDouble(SplitStr[1].Substring(2));
                    //确认小数点位置
                    while (tmpS > 60.0)
                    {
                        tmpS /= 10;
                    }
                    S = tmpS;
                }
                else
                {
                    D = Convert.ToInt32(Str);
                    M = 0;
                    S = 0;
                }
            }
            catch (Exception err)
            {
                throw new FormatException(ErrMessage.DMS.ConvertFromStringFailed, err);
            }
        }

        /// <summary>
        /// 度分秒对象转换到字符串。
        /// </summary>
        /// <returns>转换到的字符串。</returns>
        public override string ToString()
        {
            try
            {
                double tmpD = D; double tmpM = M; double tmpS = S;
                //将度的小数点部分*60加到分上。
                if (Math.Abs(tmpD - (int)tmpD) > 1e-7)
                {
                    tmpM += (tmpD - (int)tmpD) * 60;
                }
                tmpD = (int)tmpD;

                //将分的小数点部分*60加到秒上。
                if (Math.Abs(tmpM - (int)tmpM) > 1e-7)
                {
                    tmpS += (tmpM - (int)tmpM) * 60;
                }
                tmpM = (int)tmpM;

                //去除秒的小数点，以便转换为字符串。
                while (Math.Abs(tmpS - (int)tmpS) > 1e-7 && tmpS <= 1e7)
                {
                    tmpS *= 10;
                }
                tmpS = (int)tmpS;

                //秒为0。
                if (Math.Abs(tmpS) < 1e-7)
                {
                    //分为0。
                    if (Math.Abs(tmpM) < 1e-7)
                    {
                        //度为0。
                        if (Math.Abs(tmpD) < 1e-7)
                        {
                            return "0";
                        }
                        //度不为0。
                        else
                        {
                            return (tmpD.ToString() + ".0000");
                        }
                    }
                    //分不为0。
                    else
                    {
                        return (tmpD.ToString() + "." + tmpM.ToString("00") + "00");
                    }
                }
                //秒不为0。
                else
                {
                    if (tmpS < 0)
                    {
                        return ("-" + tmpD.ToString() + "." + tmpM.ToString("00") + (-tmpS).ToString());
                    }
                    else
                    {
                        return (tmpD.ToString() + "." + tmpM.ToString("00") + tmpS.ToString());
                    }
                }
            }
            catch (Exception err)
            {
                throw new FormatException(ErrMessage.DMS.ConvertToStringFailed, err);
            }
        }
        #endregion
    }
}