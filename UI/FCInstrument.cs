using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Drawing2D;

namespace FaceCat
{
    /// <summary>
    /// 仪表盘
    /// </summary>
    public class FCInstrument : FCView
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public FCInstrument()
        {
            bool[] flagArray1 = new bool[5];
            flagArray1[0] = true;
            flagArray1[1] = true;
            this.m_rangeEnabled = flagArray1;
            double[] singleArray1 = new double[5];
            singleArray1[0] = -100f;
            singleArray1[1] = 300f;
            this.m_rangeStartValue = singleArray1;
            double[] singleArray2 = new double[5];
            singleArray2[0] = 300f;
            singleArray2[1] = 400f;
            this.m_rangeEndValue = singleArray2;
        }

        /// <summary>
        /// 底弧的颜色
        /// </summary>
        public long m_baseArcColor = FCColor.rgb(100, 100, 100);

        /// <summary>
        /// 底弧的半径
        /// </summary>
        public int m_baseArcRadius = 80;

        /// <summary>
        /// 底弧的起始角
        /// </summary>
        public int m_baseArcStart = 135;

        /// <summary>
        /// 底角的扫描角
        /// </summary>
        public int m_baseArcSweep = 270;

        /// <summary>
        /// 底弧的宽度
        /// </summary>
        public int m_baseArcWidth = 2;

        /// <summary>
        /// 标题索引。将其设置为0到4，以更改相应标题的属性
        /// </summary>
        public byte m_capIdx = 0;

        /// <summary>
        /// 标题的位置
        /// </summary>
        public FCPoint[] m_capPosition = new FCPoint[] { new FCPoint(10, 10), new FCPoint(10, 10), new FCPoint(10, 10), new FCPoint(10, 10), new FCPoint(10, 10) };

        public FCPoint getCapPosition()
        {
            return m_capPosition[m_capIdx];
        }

        public void setCapPosition(FCPoint value)
        {
            this.m_capPosition[this.m_capIdx] = value;
        }

        /// <summary>
        /// 标题的文字
        /// </summary>
        public String[] m_capText = new String[] { "", "", "", "", "" };

        /// <summary>
        /// 标题文本的颜色
        /// </summary>
        public long[] m_CapColor = new long[] { FCColor.rgb(0, 0, 0), FCColor.rgb(0, 0, 0), FCColor.rgb(0, 0, 0), FCColor.rgb(0, 0, 0), FCColor.rgb(0, 0, 0) };

        /// <summary>
        /// 要在刻度上显示的最大值
        /// </summary>
        public double m_maxValue = 400;

        /// <summary>
        /// 要显示在刻度上的最小值
        /// </summary>
        public double m_minValue = -100;

        /// <summary>
        /// 针的第一种颜色
        /// </summary>
        public String m_needleColor1 = "Gray";

        /// <summary>
        /// 针的第二种颜色
        /// </summary>
        public long m_needleColor2 = FCColor.rgb(50, 50, 50);

        /// <summary>
        /// 针的半径
        /// </summary>
        public int m_needleRadius = 80;

        /// <summary>
        /// 针的类型
        /// </summary>
        public int m_needleType = 0;

        /// <summary>
        /// 针的宽度
        /// </summary>
        public int m_needleWidth = 2;

        /// <summary>
        /// 指数范围。将其设置为0到4，以更改相应范围的属性
        /// </summary>
        public byte m_rangeIdx;

        /// <summary>
        /// 范围的颜色
        /// </summary>
        public long[] m_rangeColor = new long[] { FCColor.rgb(0, 255, 0), FCColor.rgb(0, 255, 0), FCColor.rgb(0, 255, 0), FCColor.rgb(0, 255, 0), FCColor.rgb(0, 255, 0) };

        public long getRangeColor()
        {
            return m_rangeColor[m_rangeIdx];
        }

        public void setRangeColor(long value)
        {
            m_rangeColor[m_rangeIdx] = value;
        }

        /// <summary>
        /// 启用或禁用Range_Idx选择的范围
        /// </summary>
        public bool[] m_rangeEnabled = new bool[] { false, false, false, false, false };

        public bool getRangeEnabled()
        {
            return m_rangeEnabled[m_rangeIdx];
        }

        public void setRangeEnabled(bool value)
        {
            m_rangeEnabled[m_rangeIdx] = value;
        }

        /// <summary>
        /// 范围的结束值。必须大于RangeStartValue
        /// </summary>
        public double[] m_rangeEndValue = new double[] { 300, 300, 300, 300, 300 };

        public double getRangeEndValue()
        {
            return m_rangeEndValue[m_rangeIdx];
        }

        public void setRangeEndValue(double value)
        {
            m_rangeEndValue[m_rangeIdx] = value;
        }

        /// <summary>
        /// 范围的内半径
        /// </summary>
        public int[] m_rangeInnerRadius = new int[] { 70, 70, 70, 70, 70 };

        public int getRangeInnerRadius()
        {
            return m_rangeInnerRadius[m_rangeIdx];
        }

        public void setRangeInnerRadius(int value)
        {
            m_rangeInnerRadius[m_rangeIdx] = value;
        }

        /// <summary>
        /// 范围的外半径
        /// </summary>
        public int[] m_rangeOuterRadius = new int[] { 80, 80, 80, 80, 80 };

        public int getRangeOuterRadius()
        {
            return m_rangeOuterRadius[m_rangeIdx];
        }

        public void setRangeOuterRadius(int value)
        {
            m_rangeOuterRadius[m_rangeIdx] = value;
        }

        /// <summary>
        /// 范围的开始值
        /// </summary>
        public double[] m_rangeStartValue = new double[]{300};

        public double getRangeStartValue()
        {
            return m_rangeStartValue[m_rangeIdx];
        }

        public void setRangeStartValue(double value)
        {
            m_rangeStartValue[m_rangeIdx] = value;
        }

        /// <summary>
        /// 在小比例尺线数量不均匀的情况下，中间比例尺线的颜色
        /// </summary>
        public long m_scaleLinesInterColor = FCColor.rgb(255, 255, 200);

        /// <summary>
        /// 中间比例尺线的内半径，中间比例尺线是数量不均匀的小比例尺线的中间比例尺线
        /// </summary>
        public int m_scaleLinesInnerRadius = 70;

        /// <summary>
        /// 刻度线外半径
        /// </summary>
        public int m_scaleLinesOuterRadius = 80;

        /// <summary>
        /// 小比例尺线数量不均匀时，中间比例尺线即为小比例尺线的外半径
        /// </summary>
        public int m_scaleLinesInterWidth = 1;

        /// <summary>
        /// 主要刻度线的颜色
        /// </summary>
        public long m_scaleLinesMajorColor = FCColor.rgb(0, 0, 0);

        /// <summary>
        /// 主要比例尺线的内半径
        /// </summary>
        public int m_scaleLinesMajorInnerRadius = 70;

        /// <summary>
        /// 主要比例尺线的外半径
        /// </summary>
        public int m_scaleLinesMajorOuterRadius = 80;

        /// <summary>
        /// 主要比例尺线的步长值
        /// </summary>
        public int m_scaleLinesMajorStepValue = 50;

        /// <summary>
        /// 主要比例尺线的宽度
        /// </summary>
        public int m_scaleLinesMajorWidth = 1;

        /// <summary>
        /// 小尺度线条的颜色
        /// </summary>
        public long m_scaleLinesManorColor = FCColor.rgb(100, 100, 100);

        /// <summary>
        /// 小比例尺线的内半径
        /// </summary>
        public int m_scaleLinesManorInnerRadius = 75;

        /// <summary>
        /// 刻度线工作区外半径
        /// </summary>
        public int m_scaleLinesManorOuterRadius = 80;

        /// <summary>
        /// 小比例尺线的数目
        /// </summary>
        private int m_scaleLinesMinorNumOf = 9;

        /// <summary>
        /// 小比例尺线的外半径
        /// </summary>
        public int m_scaleLinesManorWidth = 1;

        /// <summary>
        /// 刻度数字颜色
        /// </summary>
        public long m_scaleNumbersColor = FCColor.rgb(0, 0, 0);

        /// <summary>
        /// 比例尺数字的格式
        /// </summary>
        public String m_scaleNumbersFormat = "";

        /// <summary>
        /// 刻度的半径
        /// </summary>
        public int m_scaleNumbersRadius = 95;

        /// <summary>
        /// 与用于旋转数字的刻度线上的底角相切的角度。设置为0表示没有旋转，例如设置为90
        /// </summary>
        public int m_scaleNumbersRotation = 0;

        /// <summary>
        /// 开始在刻度线旁边写数字的数字
        /// </summary>
        public int m_scaleNumbersStartScaleLine = 0;

        /// <summary>
        /// 用于写数字的刻度线步骤数
        /// </summary>
        public int m_scaleNumbersStepScaleLines = 1;

        /// <summary>
        /// 保留小数的位数
        /// </summary>
        public int m_digit = 0;

        /// <summary>
        /// 当前数值
        /// </summary>
        public float m_value;

        /// <summary>
        /// 数值是否在范围内
        /// </summary>
        public bool[] m_valueIsInRange = new bool[5];

        /// <summary>
        /// 中心点
        /// </summary>
        public FCPoint m_center = new FCPoint(100, 100);

        /// <summary>
        /// 小比例尺线的外半径
        /// </summary>
        public int m_scaleLinesMinorOuterRadius = 80;

        /// <summary>
        /// 小比例尺线的内半径
        /// </summary>
        public int m_scaleLinesMinorInnerRadius = 0x4b;

        /// <summary>
        /// 小比例尺线数量不均匀时，中间比例尺线即为小比例尺线的外半径
        /// </summary>
        public int m_scaleLinesInterOuterRadius = 80;

        /// <summary>
        /// 中间比例尺线的内半径，中间比例尺线是数量不均匀的小比例尺线的中间比例尺线
        /// </summary>
        public int m_scaleLinesInterInnerRadius = 0x49;

        /// <summary>
        /// 小尺度线条的颜色
        /// </summary>
        public long m_scaleLinesMinorColor = FCColor.rgb(100, 100, 100);

        /// <summary>
        /// 小比例尺线的宽度
        /// </summary>
        public int m_scaleLinesMinorWidth = 1;

        /// <summary>
        /// 重绘方法
        /// </summary>
        /// <param name="paint">绘图对象</param>
        /// <param name="clipRect">裁剪区域</param>
        public override void onPaint(FCPaint paint, FCRect clipRect)
        {
            base.onPaint(paint, clipRect);
            GdiPlusPaintEx gdiPlusPaintEx = paint as GdiPlusPaintEx;
            gdiPlusPaintEx.beginPath();
            GraphicsPath path = gdiPlusPaintEx.m_path;
            for (int i = 0; i < 5; i++)
            {
                if ((this.m_rangeEndValue[i] > this.m_rangeStartValue[i]) && this.m_rangeEnabled[i])
                {
                    double startAngle = this.m_baseArcStart + (((this.m_rangeStartValue[i] - this.m_minValue) * this.m_baseArcSweep) / (this.m_maxValue - this.m_minValue));
                    double sweepAngle = ((this.m_rangeEndValue[i] - this.m_rangeStartValue[i]) * this.m_baseArcSweep) / (this.m_maxValue - this.m_minValue);
                    path.Reset();
                    paint.addPie(new FCRect(this.m_center.x - this.m_rangeOuterRadius[i], this.m_center.y - this.m_rangeOuterRadius[i], this.m_center.x + this.m_rangeOuterRadius[i], this.m_center.y + this.m_rangeOuterRadius[i]), (float)startAngle, (float)sweepAngle);
                    path.Reverse();
                    paint.addPie(new FCRect(this.m_center.x - this.m_rangeInnerRadius[i], this.m_center.y - this.m_rangeInnerRadius[i], this.m_center.x + this.m_rangeInnerRadius[i], this.m_center.y + this.m_rangeInnerRadius[i]), (float)startAngle, (float)sweepAngle);
                    path.Reverse();
                    gdiPlusPaintEx.m_g.SetClip(path);
                    paint.fillPie(this.m_rangeColor[i], new FCRect(this.m_center.x - this.m_rangeOuterRadius[i], this.m_center.y - this.m_rangeOuterRadius[i], this.m_center.x + this.m_rangeOuterRadius[i], this.m_center.y + this.m_rangeOuterRadius[i]), (float)startAngle, (float)sweepAngle);
                }
            }
            gdiPlusPaintEx.closePath();
            paint.setClip(clipRect);
            if (this.m_baseArcRadius > 0)
            {
                paint.drawArc(this.m_baseArcColor, this.m_baseArcWidth, 0, new FCRect(this.m_center.x - this.m_baseArcRadius, this.m_center.y - this.m_baseArcRadius, this.m_center.x + this.m_baseArcRadius, this.m_center.y + this.m_baseArcRadius), (float)this.m_baseArcStart, (float)this.m_baseArcSweep);
            }
            string text = "";
            float num5 = 0f;
            for (int j = 0; num5 <= (this.m_maxValue - this.m_minValue); j++)
            {
                text = (this.m_minValue + num5).ToString(this.m_scaleNumbersFormat);
                gdiPlusPaintEx.m_g.ResetTransform();
                FCSizeF ef = paint.textSizeF(text, getFont());
                gdiPlusPaintEx.beginPath();
                path = gdiPlusPaintEx.m_path;
                path.Reset();
                paint.addEllipse(new FCRect(this.m_center.x - this.m_scaleLinesMajorOuterRadius, this.m_center.y - this.m_scaleLinesMajorOuterRadius, this.m_center.x + this.m_scaleLinesMajorOuterRadius, this.m_center.y + this.m_scaleLinesMajorOuterRadius));
                path.Reverse();
                paint.addEllipse(new FCRect(this.m_center.x - this.m_scaleLinesMajorInnerRadius, this.m_center.y - this.m_scaleLinesMajorInnerRadius, this.m_center.x + this.m_scaleLinesMajorInnerRadius, this.m_center.y + this.m_scaleLinesMajorInnerRadius));
                path.Reverse();
                gdiPlusPaintEx.m_g.SetClip(path);
                paint.drawLine(this.m_scaleLinesMajorColor, (float)this.m_scaleLinesMajorWidth, 0, (int)this.m_center.x, (int)this.m_center.y, (int)(this.m_center.x + ((2 * this.m_scaleLinesMajorOuterRadius) * Math.Cos(((this.m_baseArcStart + ((num5 * this.m_baseArcSweep) / (this.m_maxValue - this.m_minValue))) * 3.1415926535897931) / 180.0))), (int)(this.m_center.y + ((2 * this.m_scaleLinesMajorOuterRadius) * Math.Sin(((this.m_baseArcStart + ((num5 * this.m_baseArcSweep) / (this.m_maxValue - this.m_minValue))) * 3.1415926535897931) / 180.0))));
                path.Reset();
                paint.addEllipse(new FCRect(this.m_center.x - this.m_scaleLinesMinorOuterRadius, this.m_center.y - this.m_scaleLinesMinorOuterRadius, this.m_center.x + this.m_scaleLinesMinorOuterRadius, this.m_center.y + this.m_scaleLinesMinorOuterRadius));
                path.Reverse();
                paint.addEllipse(new FCRect(this.m_center.x - this.m_scaleLinesMinorInnerRadius, this.m_center.y - this.m_scaleLinesMinorInnerRadius, this.m_center.x + this.m_scaleLinesMinorInnerRadius, this.m_center.y + this.m_scaleLinesMinorInnerRadius));
                path.Reverse();
                gdiPlusPaintEx.m_g.SetClip(path);
                if (num5 < (this.m_maxValue - this.m_minValue))
                {
                    for (int m = 1; m <= this.m_scaleLinesMinorNumOf; m++)
                    {
                        if (((this.m_scaleLinesMinorNumOf % 2) == 1) && (((this.m_scaleLinesMinorNumOf / 2) + 1) == m))
                        {
                            path.Reset();
                            paint.addEllipse(new FCRect(this.m_center.x - this.m_scaleLinesInterOuterRadius, this.m_center.y - this.m_scaleLinesInterOuterRadius, this.m_center.x + this.m_scaleLinesInterOuterRadius, this.m_center.y + this.m_scaleLinesInterOuterRadius));
                            path.Reverse();
                            paint.addEllipse(new FCRect(this.m_center.x - this.m_scaleLinesInterInnerRadius, this.m_center.y - this.m_scaleLinesInterInnerRadius, this.m_center.x + this.m_scaleLinesInterInnerRadius, this.m_center.y + this.m_scaleLinesInterInnerRadius));
                            path.Reverse();
                            gdiPlusPaintEx.m_g.SetClip(path);
                            paint.drawLine(this.m_scaleLinesInterColor, (float)this.m_scaleLinesInterWidth, 0, (int)this.m_center.x, (int)this.m_center.y, (int)(this.m_center.x + ((2 * this.m_scaleLinesInterOuterRadius) * Math.Cos((((this.m_baseArcStart + ((num5 * this.m_baseArcSweep) / (this.m_maxValue - this.m_minValue))) + (((float)(m * this.m_baseArcSweep)) / (((this.m_maxValue - this.m_minValue) / this.m_scaleLinesMajorStepValue) * (this.m_scaleLinesMinorNumOf + 1)))) * 3.1415926535897931) / 180.0))), (int)(this.m_center.y + ((2 * this.m_scaleLinesInterOuterRadius) * Math.Sin((((this.m_baseArcStart + ((num5 * this.m_baseArcSweep) / (this.m_maxValue - this.m_minValue))) + (((float)(m * this.m_baseArcSweep)) / (((this.m_maxValue - this.m_minValue) / this.m_scaleLinesMajorStepValue) * (this.m_scaleLinesMinorNumOf + 1)))) * 3.1415926535897931) / 180.0))));
                            path.Reset();
                            paint.addEllipse(new FCRect(this.m_center.x - this.m_scaleLinesMinorOuterRadius, this.m_center.y - this.m_scaleLinesMinorOuterRadius, this.m_center.x + this.m_scaleLinesMinorOuterRadius, this.m_center.y + this.m_scaleLinesMinorOuterRadius));
                            path.Reverse();
                            paint.addEllipse(new FCRect(this.m_center.x - this.m_scaleLinesMinorInnerRadius, this.m_center.y - this.m_scaleLinesMinorInnerRadius, this.m_center.x + this.m_scaleLinesMinorInnerRadius, this.m_center.y + this.m_scaleLinesMinorInnerRadius));
                            path.Reverse();
                            gdiPlusPaintEx.m_g.SetClip(path);
                        }
                        else
                        {
                            paint.drawLine(this.m_scaleLinesMinorColor, (float)this.m_scaleLinesMinorWidth, 0, (int)this.m_center.x, (int)this.m_center.y, (int)(this.m_center.x + ((2 * this.m_scaleLinesMinorOuterRadius) * Math.Cos((((this.m_baseArcStart + ((num5 * this.m_baseArcSweep) / (this.m_maxValue - this.m_minValue))) + (((float)(m * this.m_baseArcSweep)) / (((this.m_maxValue - this.m_minValue) / this.m_scaleLinesMajorStepValue) * (this.m_scaleLinesMinorNumOf + 1)))) * 3.1415926535897931) / 180.0))), (int)(this.m_center.y + ((2 * this.m_scaleLinesMinorOuterRadius) * Math.Sin((((this.m_baseArcStart + ((num5 * this.m_baseArcSweep) / (this.m_maxValue - this.m_minValue))) + (((float)(m * this.m_baseArcSweep)) / (((this.m_maxValue - this.m_minValue) / this.m_scaleLinesMajorStepValue) * (this.m_scaleLinesMinorNumOf + 1)))) * 3.1415926535897931) / 180.0))));
                        }
                    }
                }
                paint.setClip(clipRect);
                //if (this.m_scaleNumbersRotation != 0)
                //{
                //    gdiPlusPaintEx.m_g.RotateTransform((float)((90f + this.m_baseArcStart) + ((num5 * this.m_baseArcSweep) / (this.m_maxValue - this.m_minValue))));
                //}
                //graphics.TranslateTransform((float)(this.m_center.x + (this.m_ScaleNumbersRadius * Math.Cos(((this.m_BaseArcStart + ((num5 * this.m_BaseArcSweep) / (this.m_MaxValue - this.m_MinValue))) * 3.1415926535897931) / 180.0))), (float)(this.m_center.y + (this.m_ScaleNumbersRadius * Math.Sin(((this.m_BaseArcStart + ((num5 * this.m_BaseArcSweep) / (this.m_MaxValue - this.m_MinValue))) * 3.1415926535897931) / 180.0))), MatrixOrder.Append);
                if (j >= (this.m_scaleNumbersStartScaleLine - 1))
                {
                    FCDraw.drawText(paint, text, this.m_scaleNumbersColor, getFont(), (int)(this.m_center.x + (this.m_scaleNumbersRadius * Math.Cos(((this.m_baseArcStart + ((num5 * this.m_baseArcSweep) / (this.m_maxValue - this.m_minValue))) * 3.1415926535897931) / 180.0)) - ef.cx / 2), (int)(this.m_center.y + (this.m_scaleNumbersRadius * Math.Sin(((this.m_baseArcStart + ((num5 * this.m_baseArcSweep) / (this.m_maxValue - this.m_minValue))) * 3.1415926535897931) / 180.0)) - ef.cy / 2));
                }
                num5 += this.m_scaleLinesMajorStepValue;
                gdiPlusPaintEx.closePath();
            }
            gdiPlusPaintEx.m_g.ResetTransform();
            paint.setClip(clipRect);
            float num = (this.m_baseArcStart + ((int)(((this.m_value - this.m_minValue) * this.m_baseArcSweep) / (this.m_maxValue - this.m_minValue)))) % 360;
            double d = (num * 3.1415926535897931) / 180.0;
            int needleType = this.m_needleType;
            long white = FCColor.rgb(255, 255, 255);
            long brush2 = FCColor.rgb(255, 255, 255);
            long brush3 = FCColor.rgb(255, 255, 255);
            long brush4 = FCColor.rgb(255, 255, 255);
            long brush1 = FCColor.rgb(255, 255, 255);
            FCPoint[] tfArray = new FCPoint[3];
            if (needleType == 0)
            {
                int green = (int)((((num + 225f) % 180f) * 100f) / 180f);
                int num15 = (int)((((num + 135f) % 180f) * 100f) / 180f);
                paint.fillEllipse(this.m_needleColor2, (int)(this.m_center.x - (this.m_needleWidth * 3)), (int)(this.m_center.y - (this.m_needleWidth * 3)), (int)(this.m_center.x + (this.m_needleWidth * 3)), (int)(this.m_center.y + (this.m_needleWidth * 3)));
                switch (this.m_needleColor1)
                {
                    case "Gray":
                        white = FCColor.rgb(80 + green, 80 + green, 80 + green);
                        brush2 = FCColor.rgb(180 - green, 180 - green, 180 - green);
                        brush3 = FCColor.rgb(80 + num15, 80 + num15, 80 + num15);
                        brush4 = FCColor.rgb(180 - num15, 180 - num15, 180 - num15);
                        paint.drawEllipse(FCColor.rgb(100, 100, 100), 1, 0, (int)(this.m_center.x - (this.m_needleWidth * 3)), (int)(this.m_center.y - (this.m_needleWidth * 3)), (int)(this.m_center.x + (this.m_needleWidth * 3)), (int)(this.m_center.y + (this.m_needleWidth * 3)));
                        break;
                    case "Red":
                        white = FCColor.rgb(0x91 + green, green, green);
                        brush2 = FCColor.rgb(0xf5 - green, 100 - green, 100 - green);
                        brush3 = FCColor.rgb(0x91 + num15, num15, num15);
                        brush4 = FCColor.rgb(0xf5 - num15, 100 - num15, 100 - num15);
                        paint.drawEllipse(FCColor.rgb(255, 0, 0), 1, 0, (int)(this.m_center.x - (this.m_needleWidth * 3)), (int)(this.m_center.y - (this.m_needleWidth * 3)), (int)(this.m_center.x + (this.m_needleWidth * 3)), (int)(this.m_center.y + (this.m_needleWidth * 3)));
                        break;
                    case "Green":
                        white = FCColor.rgb(green, 0x91 + green, green);
                        brush2 = FCColor.rgb(100 - green, 0xf5 - green, 100 - green);
                        brush3 = FCColor.rgb(num15, 0x91 + num15, num15);
                        brush4 = FCColor.rgb(100 - num15, 0xf5 - num15, 100 - num15);
                        paint.drawEllipse(FCColor.rgb(0, 255, 0), 1, 0, (int)(this.m_center.x - (this.m_needleWidth * 3)), (int)(this.m_center.y - (this.m_needleWidth * 3)), (int)(this.m_center.x + (this.m_needleWidth * 3)), (int)(this.m_center.y + (this.m_needleWidth * 3)));
                        break;
                    case "Blue":
                        white = FCColor.rgb(green, green, 0x91 + green);
                        brush2 = FCColor.rgb(100 - green, 100 - green, 0xf5 - green);
                        brush3 = FCColor.rgb(num15, num15, 0x91 + num15);
                        brush4 = FCColor.rgb(100 - num15, 100 - num15, 0xf5 - num15);
                        paint.drawEllipse(FCColor.rgb(0, 0, 255), 1, 0, (int)(this.m_center.x - (this.m_needleWidth * 3)), (int)(this.m_center.y - (this.m_needleWidth * 3)), (int)(this.m_center.x + (this.m_needleWidth * 3)), (int)(this.m_center.y + (this.m_needleWidth * 3)));
                        break;
                    case "Yellow":
                        white = FCColor.rgb(0x91 + green, 0x91 + green, green);
                        brush2 = FCColor.rgb(0xf5 - green, 0xf5 - green, 100 - green);
                        brush3 = FCColor.rgb(0x91 + num15, 0x91 + num15, num15);
                        brush4 = FCColor.rgb(0xf5 - num15, 0xf5 - num15, 100 - num15);
                        paint.drawEllipse(FCColor.rgb(255, 255, 0), 1, 0, (int)(this.m_center.x - (this.m_needleWidth * 3)), (int)(this.m_center.y - (this.m_needleWidth * 3)), (int)(this.m_center.x + (this.m_needleWidth * 3)), (int)(this.m_center.y + (this.m_needleWidth * 3)));
                        break;
                    case "Violet":
                        white = FCColor.rgb(0x91 + green, green, 0x91 + green);
                        brush2 = FCColor.rgb(0xf5 - green, 100 - green, 0xf5 - green);
                        brush3 = FCColor.rgb(0x91 + num15, num15, 0x91 + num15);
                        brush4 = FCColor.rgb(0xf5 - num15, 100 - num15, 0xf5 - num15);
                        paint.drawEllipse(FCColor.rgb(238, 130, 238), 1, 0, (int)(this.m_center.x - (this.m_needleWidth * 3)), (int)(this.m_center.y - (this.m_needleWidth * 3)), (int)(this.m_center.x + (this.m_needleWidth * 3)), (int)(this.m_center.y + (this.m_needleWidth * 3)));
                        break;
                    case "Magenta":
                        white = FCColor.rgb(green, 0x91 + green, 0x91 + green);
                        brush2 = FCColor.rgb(100 - green, 0xf5 - green, 0xf5 - green);
                        brush3 = FCColor.rgb(num15, 0x91 + num15, 0x91 + num15);
                        brush4 = FCColor.rgb(100 - num15, 0xf5 - num15, 0xf5 - num15);
                        paint.drawEllipse(FCColor.rgb(255, 0, 255), 1, 0, (int)(this.m_center.x - (this.m_needleWidth * 3)), (int)(this.m_center.y - (this.m_needleWidth * 3)), (int)(this.m_center.x + (this.m_needleWidth * 3)), (int)(this.m_center.y + (this.m_needleWidth * 3)));
                        break;
                }
               
            }
            else if (needleType == 1)
            {
                FCPoint point2 = new FCPoint(this.m_center.x - ((int)((this.m_needleRadius / 8) * Math.Cos(d))), this.m_center.y - ((int)((this.m_needleRadius / 8) * Math.Sin(d))));
                FCPoint point3 = new FCPoint(this.m_center.x + ((int)(this.m_needleRadius * Math.Cos(d))), this.m_center.y + ((int)(this.m_needleRadius * Math.Sin(d))));
                paint.fillEllipse(this.m_needleColor2, (int)(this.m_center.x - (this.m_needleWidth * 3)), (int)(this.m_center.y - (this.m_needleWidth * 3)), (int)(this.m_center.x + (this.m_needleWidth * 3)), (int)(this.m_center.y + (this.m_needleWidth * 3)));
                switch (this.m_needleColor1)
                {
                    case "Gray":
                        paint.drawLine(FCColor.rgb(50, 50, 50), (int)this.m_needleWidth, 0, this.m_center.x, this.m_center.y, point3.x, point3.y);
                        paint.drawLine(FCColor.rgb(50, 50, 50), (float)this.m_needleWidth, 0, this.m_center.x, this.m_center.y, point2.x, point2.y);
                        return;
                    case "Red":
                        paint.drawLine(FCColor.rgb(255, 0, 0), (int)this.m_needleWidth, 0, this.m_center.x, this.m_center.y, point3.x, point3.y);
                        paint.drawLine(FCColor.rgb(255, 0, 0), (int)this.m_needleWidth, 0, this.m_center.x, this.m_center.y, point2.x, point2.y);
                        return;
                    case "Green":
                        paint.drawLine(FCColor.rgb(0, 255, 0), (int)this.m_needleWidth, 0, this.m_center.x, this.m_center.y, point3.x, point3.y);
                        paint.drawLine(FCColor.rgb(0, 255, 0), (int)this.m_needleWidth, 0, this.m_center.x, this.m_center.y, point2.x, point2.y);
                        return;

                    case "Blue":
                        paint.drawLine(FCColor.rgb(0, 0, 255), (int)this.m_needleWidth, 0, this.m_center.x, this.m_center.y, point3.x, point3.y);
                        paint.drawLine(FCColor.rgb(0, 0, 255), (int)this.m_needleWidth, 0, this.m_center.x, this.m_center.y, point2.x, point2.y);
                        return;

                    case "Yellow":
                        paint.drawLine(FCColor.rgb(255, 255, 255), (int)this.m_needleWidth, 0, this.m_center.x, this.m_center.y, point3.x, point3.y);
                        paint.drawLine(FCColor.rgb(255, 255, 255), (int)this.m_needleWidth, 0, this.m_center.x, this.m_center.y, point2.x, point2.y);
                        return;

                    case "Violet":
                        paint.drawLine(FCColor.rgb(238, 130, 238), (int)this.m_needleWidth, 0, this.m_center.x, this.m_center.y, point3.x, point3.y);
                        paint.drawLine(FCColor.rgb(238, 130, 238), (int)this.m_needleWidth, 0, this.m_center.x, this.m_center.y, point2.x, point2.y);
                        return;

                    case "Magenta":
                        paint.drawLine(FCColor.rgb(255, 0, 255), (int)this.m_needleWidth, 0, this.m_center.x, this.m_center.y, point3.x, point3.y);
                        paint.drawLine(FCColor.rgb(255, 0, 255), (int)this.m_needleWidth, 0, this.m_center.x, this.m_center.y, point2.x, point2.y);
                        return;
                }
            }
            if (Math.Floor((double)((float)(((double)((num + 225f) % 360f)) / 180.0))) == 0.0)
            {
                white = brush2;
                brush2 = white;
            }
            if (Math.Floor((double)((float)(((double)((num + 135f) % 360f)) / 180.0))) == 0.0)
            {
                brush4 = brush3;
            }
            tfArray[0].x = (int)(this.m_center.x + (this.m_needleRadius * Math.Cos(d)));
            tfArray[0].y = (int)(this.m_center.y + (this.m_needleRadius * Math.Sin(d)));
            tfArray[1].x = (int)(this.m_center.x - ((this.m_needleRadius / 20) * Math.Cos(d)));
            tfArray[1].y = (int)(this.m_center.y - ((this.m_needleRadius / 20) * Math.Sin(d)));
            tfArray[2].x = (int)((this.m_center.x - ((this.m_needleRadius / 5) * Math.Cos(d))) + ((this.m_needleWidth * 2) * Math.Cos(d + 1.5707963267948966)));
            tfArray[2].y = (int)((this.m_center.y - ((this.m_needleRadius / 5) * Math.Sin(d))) + ((this.m_needleWidth * 2) * Math.Sin(d + 1.5707963267948966)));
            paint.fillPolygon(white, tfArray);
            tfArray[2].x = (int)((this.m_center.x - ((this.m_needleRadius / 5) * Math.Cos(d))) + ((this.m_needleWidth * 2) * Math.Cos(d - 1.5707963267948966)));
            tfArray[2].y = (int)((this.m_center.y - ((this.m_needleRadius / 5) * Math.Sin(d))) + ((this.m_needleWidth * 2) * Math.Sin(d - 1.5707963267948966)));
            paint.fillPolygon(brush2, tfArray);
            tfArray[0].x = (int)(this.m_center.x - (((this.m_needleRadius / 20) - 1) * Math.Cos(d)));
            tfArray[0].y = (int)(this.m_center.y - (((this.m_needleRadius / 20) - 1) * Math.Sin(d)));
            tfArray[1].x = (int)((this.m_center.x - ((this.m_needleRadius / 5) * Math.Cos(d))) + ((this.m_needleWidth * 2) * Math.Cos(d + 1.5707963267948966)));
            tfArray[1].y = (int)((this.m_center.y - ((this.m_needleRadius / 5) * Math.Sin(d))) + ((this.m_needleWidth * 2) * Math.Sin(d + 1.5707963267948966)));
            tfArray[2].x = (int)((this.m_center.x - ((this.m_needleRadius / 5) * Math.Cos(d))) + ((this.m_needleWidth * 2) * Math.Cos(d - 1.5707963267948966)));
            tfArray[2].y = (int)((this.m_center.y - ((this.m_needleRadius / 5) * Math.Sin(d))) + ((this.m_needleWidth * 2) * Math.Sin(d - 1.5707963267948966)));
            paint.fillPolygon(brush4, tfArray);
            tfArray[0].x = (int)(this.m_center.x - ((this.m_needleRadius / 20) * Math.Cos(d)));
            tfArray[0].y = (int)(this.m_center.y - ((this.m_needleRadius / 20) * Math.Sin(d)));
            tfArray[1].x = (int)(this.m_center.x + (this.m_needleRadius * Math.Cos(d)));
            tfArray[1].y = (int)(this.m_center.y + (this.m_needleRadius * Math.Sin(d)));
            paint.drawLine(this.m_needleColor2, 1, 0, (int)this.m_center.x, (int)this.m_center.y, tfArray[0].x, tfArray[0].y);
            paint.drawLine(this.m_needleColor2, 1, 0, (int)this.m_center.x, (int)this.m_center.y, tfArray[1].x, tfArray[1].y);
        }
    }
}
