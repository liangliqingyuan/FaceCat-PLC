using System;
using System.Collections.Generic;
using System.Text;

namespace FaceCat
{
    /// <summary>
    /// 温度计
    /// </summary>
    public class PLCThermometer : FCView
    {
        /// <summary>
        /// 玻璃管颜色
        /// </summary>
        public long m_glassTubeColor = FCColor.rgb(211, 211, 211);

        /// <summary>
        /// 水印颜色
        /// </summary>
        public long m_mercuryColor = FCColor.rgb(255, 77, 59);

        /// <summary>
        /// 左侧刻度最小值
        /// </summary>
        public decimal m_minValue = 0;

        /// <summary>
        /// 左侧刻度最大值
        /// </summary>
        public decimal m_maxValue = 100;

        /// <summary>
        /// 左侧刻度值
        /// </summary>
        public decimal m_value = 10;

        /// <summary>
        /// 刻度分隔份数
        /// </summary>
        private int m_splitcount = 4;

        /// <summary>
        /// 左侧刻度单位，不可为none
        /// </summary>
        public TemperatureUnit m_leftUnit = TemperatureUnit.C;

        /// <summary>
        /// 右侧刻度单位，当为none时，不显示
        /// </summary>
        public TemperatureUnit m_rightUnit = TemperatureUnit.C;

        /// <summary>
        /// 工作区大小
        /// </summary>
        public FCRect m_rectWorking = new FCRect();
        /// <summary>
        /// 左侧矩形
        /// </summary>
        public FCRect m_rectleft = new FCRect();
        /// <summary>
        /// 右侧矩形
        /// </summary>
        public FCRect m_rectRight = new FCRect();

        /// <summary>
        /// 数值的字体
        /// </summary>
        public FCFont m_valueFont = new FCFont("Default", 16);

        /// <summary>
        /// 获取单位字符
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        private string getUnitChar(TemperatureUnit unit)
        {
            string strunit = "℃";
            switch (unit)
            {
                case TemperatureUnit.C:
                    strunit = "℃";
                    break;
                case TemperatureUnit.F:
                    strunit = "℉";
                    break;
                case TemperatureUnit.K:
                    strunit = "k";
                    break;
                case TemperatureUnit.R:
                    strunit = "°r";
                    break;
                case TemperatureUnit.RE:
                    strunit = "°re";
                    break;
            }
            return strunit;
        }

        /// <summary>
        /// 获取右侧的值
        /// </summary>
        /// <param name="decvalue"></param>
        /// <returns></returns>
        private decimal getRightValue(decimal decvalue)
        {
            //先将左侧的换算为摄氏度
            var dec = decvalue;
            switch (m_leftUnit)
            {
                case TemperatureUnit.F:
                    dec = (decvalue - 32) / (9m / 5m);
                    break;
                case TemperatureUnit.K:
                    dec = decvalue - 273;
                    break;
                case TemperatureUnit.R:
                    dec = decvalue / (5m / 9m) - 273.15m;
                    break;
                case TemperatureUnit.RE:
                    dec = decvalue / 1.25m;
                    break;
                default:
                    break;
            }

            switch (m_rightUnit)
            {
                case TemperatureUnit.C:
                    return dec;
                case TemperatureUnit.F:
                    return 9m / 5m * dec + 32;
                case TemperatureUnit.K:
                    return dec + 273;
                case TemperatureUnit.R:
                    return (dec + 273.15m) * (5m / 9m);
                case TemperatureUnit.RE:
                    return dec * 1.25m;
            }
            return decvalue;
        }

        /// <summary>
        /// 尺寸改变方法
        /// </summary>
        public override void onSizeChanged()
        {
            base.onSizeChanged();
            int width = getWidth(), height = getHeight();
            m_rectWorking = new FCRect(width / 2 - width / 8, width / 4, width / 2 - width / 8 + width / 4, width / 4 + height - width / 2);
            m_rectleft = new FCRect(0, m_rectWorking.top + (m_rectWorking.right - m_rectWorking.left) / 2,
                (width - width / 4) / 2 - 2, m_rectWorking.top + (m_rectWorking.right - m_rectWorking.left) / 2 + (m_rectWorking.bottom - m_rectWorking.top) - (m_rectWorking.right - m_rectWorking.left) * 2);
            m_rectRight = new FCRect(width - (width - width / 4) / 2 + 2,
                m_rectWorking.top + (m_rectWorking.right - m_rectWorking.left) / 2,
                width - (width - width / 4) / 2 + 2 + (width - width / 4) / 2 - 2,
                m_rectWorking.top + (m_rectWorking.right - m_rectWorking.left) / 2 + (m_rectWorking.bottom - m_rectWorking.top) - (m_rectWorking.right - m_rectWorking.left) * 2);
        }

        /// <summary>
        /// 重绘方法
        /// </summary>
        /// <param name="paint">绘图对象</param>
        /// <param name="clipRect">裁剪区域</param>
        public override void onPaint(FCPaint paint, FCRect clipRect)
        {
            base.onPaint(paint, clipRect);
            //玻璃管管
            int width = getWidth(), height = getHeight();
            GdiPlusPaintEx gdiPlusPaintEx = paint as GdiPlusPaintEx;
            gdiPlusPaintEx.beginPath();
            paint.addLine(m_rectWorking.left, m_rectWorking.bottom, m_rectWorking.left, m_rectWorking.top + (m_rectWorking.right - m_rectWorking.left) / 2);
            paint.addArc(new FCRect(m_rectWorking.left, m_rectWorking.top, m_rectWorking.right, m_rectWorking.bottom), 180, 360);
            //paint.addLine(m_rectworking.right, m_rectworking.top + (m_rectworking.right - m_rectworking.left) / 2, m_rectworking.right, m_rectworking.bottom);
            gdiPlusPaintEx.m_path.CloseAllFigures();
            paint.fillPath(m_glassTubeColor);
            gdiPlusPaintEx.closePath();

            FCRect rectdi = new FCRect(width / 2 - (m_rectWorking.right - m_rectWorking.left), m_rectWorking.bottom - (m_rectWorking.right - m_rectWorking.left) - 2, width / 2 - (m_rectWorking.right - m_rectWorking.left) + (m_rectWorking.right - m_rectWorking.left) * 2, m_rectWorking.bottom - (m_rectWorking.right - m_rectWorking.left) - 2 + (m_rectWorking.right - m_rectWorking.left) * 2);
            paint.fillEllipse(m_glassTubeColor, rectdi);
            paint.fillEllipse(m_mercuryColor, new FCRect(rectdi.left + 4, rectdi.top + 4, rectdi.left + 4 + (rectdi.right - rectdi.left) - 8, rectdi.top + 4 + (rectdi.bottom - rectdi.top) - 8));

            //刻度
            decimal decsplit = (m_maxValue - m_minValue) / m_splitcount;
            decimal decsplitheight = (m_rectleft.bottom - m_rectleft.top) / m_splitcount;
            FCFont font = getFont();
            long forecolor = getTextColor();
            for (int i = 0; i <= m_splitcount; i++)
            {
                paint.drawLine(forecolor, 1, 0, new FCPoint(m_rectleft.left + 2, (float)(m_rectleft.bottom - decsplitheight * i)), new FCPoint(m_rectleft.right, (float)(m_rectleft.bottom - decsplitheight * i)));

                String valueleft = (m_minValue + decsplit * i).ToString("0.##");
                FCSize sizeleft = paint.textSize(valueleft, font);
                FCDraw.drawText(paint, valueleft, forecolor, font, m_rectleft.left + 2, (int)(m_rectleft.bottom - (float)decsplitheight * i - sizeleft.cy - 1));

                if (m_rightUnit != TemperatureUnit.None)
                {
                    paint.drawLine(FCColor.rgb(0, 0, 0), 1, 0, new FCPoint(m_rectRight.left + 2, (float)(m_rectRight.bottom - decsplitheight * i)), new FCPoint(m_rectRight.right, (float)(m_rectRight.bottom - decsplitheight * i)));
                    String valueright = getRightValue(m_minValue + decsplit * i).ToString("0.##");
                    FCSize sizeright = paint.textSize(valueright, font);
                    FCDraw.drawText(paint, valueright, forecolor, font, m_rectRight.right - sizeright.cx - 3, (int)(m_rectRight.bottom - (float)decsplitheight * i - sizeright.cy - 1));
                }
                if (i != m_splitcount)
                {
                    if (decsplitheight > 40)
                    {
                        decimal decsp1 = decsplitheight / 10;
                        for (int j = 1; j < 10; j++)
                        {
                            if (j == 5)
                            {
                                paint.drawLine(forecolor, 1, 0, new FCPoint(m_rectleft.right - 10, (m_rectleft.bottom - (float)decsplitheight * i - ((float)decsp1 * j))), new FCPoint(m_rectleft.right, (m_rectleft.bottom - (float)decsplitheight * i - ((float)decsp1 * j))));
                                if (m_rightUnit != TemperatureUnit.None)
                                {
                                    paint.drawLine(forecolor, 1, 0, new FCPoint(m_rectRight.left + 10, (m_rectRight.bottom - (float)decsplitheight * i - ((float)decsp1 * j))), new FCPoint(m_rectRight.left, (m_rectRight.bottom - (float)decsplitheight * i - ((float)decsp1 * j))));
                                }
                            }
                            else
                            {
                                paint.drawLine(forecolor, 1, 0, new FCPoint(m_rectleft.right - 5, (m_rectleft.bottom - (float)decsplitheight * i - ((float)decsp1 * j))), new FCPoint(m_rectleft.right, (m_rectleft.bottom - (float)decsplitheight * i - ((float)decsp1 * j))));
                                if (m_rightUnit != TemperatureUnit.None)
                                {
                                    paint.drawLine(forecolor, 1, 0, new FCPoint(m_rectRight.left + 5, (m_rectRight.bottom - (float)decsplitheight * i - ((float)decsp1 * j))), new FCPoint(m_rectRight.left, (m_rectRight.bottom - (float)decsplitheight * i - ((float)decsp1 * j))));
                                }
                            }
                        }
                    }
                    else if (decsplitheight > 10)
                    {
                        paint.drawLine(forecolor, 1, 0, new FCPoint(m_rectleft.right - 5, (m_rectleft.bottom - (float)decsplitheight * i - (float)decsplitheight / 2)), new FCPoint(m_rectleft.right, (m_rectleft.bottom - (float)decsplitheight * i - (float)decsplitheight / 2)));
                        if (m_rightUnit != TemperatureUnit.None)
                        {
                            paint.drawLine(forecolor, 1, 0, new FCPoint(m_rectRight.left + 5, (m_rectRight.bottom - (float)decsplitheight * i - (float)decsplitheight / 2)), new FCPoint(m_rectRight.left, (m_rectRight.bottom - (float)decsplitheight * i - (float)decsplitheight / 2)));
                        }
                    }
                }
            }
            //单位
            string strleftunit = getUnitChar(m_leftUnit);
            FCDraw.drawText(paint, strleftunit, forecolor, font, m_rectleft.left + 2, 2);
            if (m_rightUnit != TemperatureUnit.None)
            {
                string strrightunit = getUnitChar(m_rightUnit);
                FCSize rightsize = paint.textSize(strrightunit, font);
                FCDraw.drawText(paint, strrightunit, forecolor, font, m_rectRight.right - 2 - rightsize.cx, 2);
            }

            //值
            float fltheightvalue = (float)(m_value / (m_maxValue - m_minValue) * (m_rectleft.bottom - m_rectleft.top));
            FCRect rectvalue = new FCRect(m_rectWorking.left + 4, m_rectleft.top + (m_rectleft.bottom - m_rectleft.top - fltheightvalue), m_rectWorking.right - m_rectWorking.left - 8, fltheightvalue + (m_rectWorking.bottom - m_rectWorking.top - (m_rectWorking.right - m_rectWorking.left) / 2 - (m_rectleft.bottom - m_rectleft.top)));
            rectvalue.right += rectvalue.left;
            rectvalue.bottom += rectvalue.top;
            paint.fillRect(m_mercuryColor, rectvalue);

            FCSize sizevalue = paint.textSize(m_value.ToString("0.##"), m_valueFont);
            FCDraw.drawText(paint, m_value.ToString("0.##"), FCColor.rgb(255, 255, 255), m_valueFont, rectdi.left + (rectdi.bottom - rectdi.top - sizevalue.cx) / 2, rectdi.top + (rectdi.bottom - rectdi.top - sizevalue.cy) / 2 + 1);
        }
    }

    /// <summary>
    /// 温度计的单位
    /// </summary>
    public enum TemperatureUnit
    {
        /// <summary>
        /// 不显示
        /// </summary>
        None,
        /// <summary>
        /// 摄氏度
        /// </summary>
        C,
        /// <summary>
        /// 华氏度
        /// </summary>
        F,
        /// <summary>
        /// 开氏度
        /// </summary>
        K,
        /// <summary>
        /// 兰氏度
        /// </summary>
        R,
        /// <summary>
        /// 列氏度
        /// </summary>
        RE
    }
}
