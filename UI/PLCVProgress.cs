using System;
using System.Collections.Generic;
using System.Text;

namespace FaceCat
{
    /// <summary>
    /// 纵向进度条
    /// </summary>
    public class PLCVProgress:FCView
    {
        /// <summary>
        /// 最大值
        /// </summary>
        public double m_maxValue = 100;

        /// <summary>
        /// 当前值
        /// </summary>
        public double m_nowValue;

        /// <summary>
        /// 进度条的颜色
        /// </summary>
        public long m_progressColor = FCColor.Text;

        /// <summary>
        /// 重绘方法
        /// </summary>
        /// <param name="paint">绘图对象</param>
        /// <param name="clipRect">裁剪区域</param>
        public override void onPaint(FCPaint paint, FCRect clipRect)
        {
            base.onPaint(paint, clipRect);
            int width = getWidth(), height = getHeight();
            int pHeight = (int)(m_nowValue / m_maxValue * height);
            if (pHeight > 0)
            {
                FCRect bRect = new FCRect(0, height - pHeight, width, height);
                paint.fillRect(m_progressColor, bRect);
            }
        }
    }
}
