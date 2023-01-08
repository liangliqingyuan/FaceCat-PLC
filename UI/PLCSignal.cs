using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaceCat
{
    /// <summary>
    /// 信号灯
    /// </summary>
    public class PLCSignal : FCView
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PLCSignal()
        {
            setBorderColor(FCColor.rgb(0, 0, 0));
            setFont(new FCFont("Default", 14));
        }

        /// <summary>
        /// 当前状态
        /// </summary>
        public int m_state = 0;

        /// <summary>
        /// 颜色
        /// </summary>
        public long[] m_colors = new long[] { FCColor.rgb(200, 200, 200), FCColor.rgb(255, 80, 80), FCColor.rgb(255, 255, 80), FCColor.rgb(80, 255, 80) };

        /// <summary>
        /// 按钮的大小
        /// </summary>
        public FCSize m_buttonSize = new FCSize(30, 30);

        /// <summary>
        /// 重绘方法
        /// </summary>
        /// <param name="paint">绘图对象</param>
        /// <param name="clipRect">裁剪区域</param>
        public override void onPaint(FCPaint paint, FCRect clipRect)
        {
            base.onPaint(paint, clipRect);
            int width = getWidth(), height = getHeight();
            FCRect eRect = new FCRect(width / 2 - m_buttonSize.cx / 2, 5, width / 2 + m_buttonSize.cx / 2, m_buttonSize.cy + 5);
            long color = m_colors[m_state];
            paint.fillEllipse(color, eRect);
            paint.drawEllipse(getBorderColor(), 1, 0, eRect);
            String text = getText();
            FCFont tFont = getFont();
            FCSize tSize = paint.textSize(text, tFont);
            FCDraw.drawText(paint, text, getTextColor(), tFont, (width - tSize.cx) / 2, eRect.bottom + 10);
        }

        /// <summary>
        /// 重绘边线方法
        /// </summary>
        /// <param name="paint">绘图对象</param>
        /// <param name="clipRect">裁剪区域</param>
        public override void onPaintBorder(FCPaint paint, FCRect clipRect)
        {
        }
    }
}
