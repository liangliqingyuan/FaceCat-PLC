using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaceCat
{
    /// <summary>
    /// 环形进度条
    /// </summary>
    public class PLCCycleProgress:FCView
    {
        /// <summary>
        /// 创建进度条
        /// </summary>
        public PLCCycleProgress()
        {
            setFont(new FCFont("Default", 20, false, false, false));
        }

        /// <summary>
        /// 最大值
        /// </summary>
        public double m_maxValue = 100;

        /// <summary>
        /// 当前值
        /// </summary>
        public double m_nowValue;

        /// <summary>
        /// 进度条的背景颜色
        /// </summary>
        public long m_progressBackColor = FCColor.Border;

        /// <summary>
        /// 进度条的颜色
        /// </summary>
        public long m_progressColor = FCColor.Text;

        /// <summary>
        /// 内半径
        /// </summary>
        public int m_innerRadius = 70;

        /// <summary>
        /// 外半径
        /// </summary>
        public int m_outerRadius = 90;

        /// <summary>
        /// 保留小数的位数
        /// </summary>
        public int m_digit = 0;

        /// <summary>
        /// 绘图方法
        /// </summary>
        /// <param name="paint">绘图对象</param>
        /// <param name="clipRect">裁剪区域</param>
        public override void onPaint(FCPaint paint, FCRect clipRect)
        {
            base.onPaint(paint, clipRect);
            int width = getWidth(), height = getHeight();
            int oX = width / 2, oY = height / 2;
            FCRect outerRect = new FCRect(oX - m_outerRadius, oY - m_outerRadius, oX + m_outerRadius, oY + m_outerRadius);
            paint.fillEllipse(m_progressBackColor, outerRect);
            int sweep = (int)(m_nowValue / m_maxValue * 360);
            paint.fillPie(m_progressColor, outerRect, 90, sweep);
            FCRect innerRect = new FCRect(oX - m_innerRadius, oY - m_innerRadius, oX + m_innerRadius, oY + m_innerRadius);
            paint.fillEllipse(getBackColor(), innerRect);

            String pText = FCTran.getValueByDigit(m_nowValue, m_digit) + "%";
            FCFont tFont = getFont();
            FCSize tSize = paint.textSize(pText, tFont);
            FCDraw.drawText(paint, pText, getTextColor(), tFont, oX - tSize.cx / 2, oY - tSize.cy / 2);
        }
    }
}
