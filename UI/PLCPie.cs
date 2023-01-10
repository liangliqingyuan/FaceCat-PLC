using System;
using System.Collections.Generic;
using System.Text;

namespace FaceCat
{
    /// <summary>
    /// 饼图
    /// </summary>
    public class PLCPie : FCView
    {
        /// <summary>
        /// 创建饼图
        /// </summary>
        public PLCPie()
        {
            setSize(new FCSize(200, 200));
        }

        /// <summary>
        /// 饼图半径
        /// </summary>
        public int m_pieRadius = 70;

        /// <summary>
        /// 文字的半径
        /// </summary>
        public int m_textRadius = 80;

        /// <summary>
        /// 开始角度
        /// </summary>
        public int m_startAngle = 0;

        /// <summary>
        /// 数据项
        /// </summary>
        public ArrayList<PLCPieItem> m_items = new ArrayList<PLCPieItem>();

        /// <summary>
        /// 获取最大值
        /// </summary>
        /// <returns></returns>
        public double getMaxValue()
        {
            double maxValue = 0;
            for (int i = 0; i < m_items.size(); i++)
            {
                PLCPieItem item = m_items.get(i);
                maxValue += item.m_value;
            }
            return maxValue;
        }

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
            FCRect eRect = new FCRect(oX - m_pieRadius, oY - m_pieRadius, oX + m_pieRadius, oY + m_pieRadius);
            double maxValue = getMaxValue();
            if (maxValue > 0)
            {
                float startAngle = m_startAngle;
                for (int i = 0; i < m_items.size(); i++)
                {
                    PLCPieItem item = m_items.get(i);
                    float sweepAngle = (float)(item.m_value / maxValue * 360);
                    paint.fillPie(item.m_color, eRect, startAngle, sweepAngle);
                    int x1 = (int)(oX + (m_pieRadius) * Math.Cos((startAngle + sweepAngle / 2) * 3.1415926 / 180));
                    int y1 = (int)(oY + (m_pieRadius) * Math.Sin((startAngle + sweepAngle / 2) * 3.1415926 / 180));
                    int x2 = (int)(oX + (m_textRadius) * Math.Cos((startAngle + sweepAngle / 2) * 3.1415926 / 180));
                    int y2 = (int)(oY + (m_textRadius) * Math.Sin((startAngle + sweepAngle / 2) * 3.1415926 / 180));
                    String itemText = FCTran.getValueByDigit(item.m_value, 2);
                    FCSize itemTextSize = paint.textSize(itemText, getFont());
                    paint.drawLine(FCColor.Text, 1, 0, x1, y1, x2, y2);
                    int x3 = (int)(oX + (m_textRadius + itemTextSize.cx / 2 + 5) * Math.Cos((startAngle + sweepAngle / 2) * 3.1415926 / 180));
                    int y3 = (int)(oY + (m_textRadius + itemTextSize.cy / 2 + 5) * Math.Sin((startAngle + sweepAngle / 2) * 3.1415926 / 180));
                    FCDraw.drawText(paint, itemText, FCColor.Text, getFont(), x3 - itemTextSize.cx / 2, y3 - itemTextSize.cy / 2);
                    startAngle += sweepAngle;
                }
            }
            paint.drawEllipse(getBorderColor(), 1, 0, eRect);
        }
    }

    /// <summary>
    /// 饼图项
    /// </summary>
    public class PLCPieItem
    {
        /// <summary>
        /// 数值
        /// </summary>
        public double m_value;

        /// <summary>
        /// 文字
        /// </summary>
        public String m_text;

        /// <summary>
        /// 颜色
        /// </summary>
        public long m_color = FCColor.Text;
    }
}
