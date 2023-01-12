using System;
using System.Collections.Generic;
using System.Text;

namespace FaceCat
{
    /// <summary>
    /// LED字符
    /// </summary>
    public class PLCLEDNum:FCView
    {
        /// <summary>
        /// 所有的字符
        /// </summary>
        public static HashMap<char, String> m_numbers = new HashMap<char, String>();

        /// <summary>
        /// 构造函数
        /// </summary>
        public PLCLEDNum()
        {
            if (m_numbers.size() == 0)
            {
                m_numbers.put('0', "1,2,3,4,5,6");
                m_numbers.put('1', "2,3");
                m_numbers.put('2', "1,2,5,4,7");
                m_numbers.put('3', "1,2,7,3,4");
                m_numbers.put('4', "2,3,6,7");
                m_numbers.put('5', "1,6,7,3,4");
                m_numbers.put('6', "1,6,5,4,3,7");
                m_numbers.put('7', "1,2,3");
                m_numbers.put('8', "1,2,3,4,5,6,7");
                m_numbers.put('9', "1,2,3,4,7,6");
                m_numbers.put('A', "1,2,3,5,6,7");
                m_numbers.put('b', "3,4,5,6,7");
                m_numbers.put('C', "1,6,5,4");
                m_numbers.put('c', "7,5,4");
                m_numbers.put('d', "2,3,4,5,7");
                m_numbers.put('E', "1,4,5,6,7");
                m_numbers.put('F', "1,5,6,7");
                m_numbers.put('H', "2,3,5,6,7");
                m_numbers.put('h', "3,5,6,7");
                m_numbers.put('J', "2,3,4");
                m_numbers.put('L', "4,5,6");
                m_numbers.put('o', "3,4,5,7");
                m_numbers.put('P', "1,2,5,6,7");
                m_numbers.put('r', "5,7");
                m_numbers.put('U', "2,3,4,5,6");
                m_numbers.put('-', "7");
                m_numbers.put(':', "");
                m_numbers.put('.', "");
            }
        }

        /// <summary>
        /// 要显示的数字
        /// </summary>
        public char m_showNumber = '0';

        /// <summary>
        /// 边线的宽度
        /// </summary>
        public int m_borderWidth = 8;

        /// <summary>
        /// 重绘方法
        /// </summary>
        /// <param name="paint">绘图对象</param>
        /// <param name="clipRect">裁剪区域</param>
        public override void onPaint(FCPaint paint, FCRect clipRect)
        {
            base.onPaint(paint, clipRect);
            int width = getWidth(), height = getHeight();
            long textColor = getTextColor();
            if (m_showNumber == '.')
            {
                FCRect dotRect = new FCRect((width - m_borderWidth) / 2, height - m_borderWidth * 2, (width - m_borderWidth) / 2 + m_borderWidth, height - m_borderWidth * 2 + m_borderWidth);
                paint.fillRect(textColor, dotRect);
            }
            else if (m_showNumber == ':')
            {
                FCRect rect1 = new FCRect((width - m_borderWidth) / 2, (height / 2 - m_borderWidth) / 2, (width - m_borderWidth) / 2 + m_borderWidth, (height / 2 - m_borderWidth) / 2 + m_borderWidth);
                paint.fillRect(textColor, rect1);
                FCRect rect2 = new FCRect((width - m_borderWidth) / 2, (height / 2 - m_borderWidth) / 2 + height / 2, (width - m_borderWidth) / 2 + m_borderWidth, (height / 2 - m_borderWidth) / 2 + height / 2 + m_borderWidth);
                paint.fillRect(textColor, rect2);
            }
            else
            {
                String numberStr = m_numbers.get(m_showNumber);
                if (numberStr.IndexOf("1") != -1)
                {
                    FCPoint[] points = new FCPoint[5];
                    points[0] = new FCPoint(2, 0);
                    points[1] = new FCPoint(width - 2, 0);
                    points[2] = new FCPoint(width - m_borderWidth - 2, 0 + m_borderWidth);
                    points[3] = new FCPoint(m_borderWidth + 2, 0 + m_borderWidth);
                    points[4] = new FCPoint(2, 0);
                    paint.fillPolygon(textColor, points);
                }
                if (numberStr.IndexOf("2") != -1)
                {
                    FCPoint[] points = new FCPoint[6];
                    points[0] = new FCPoint(width, 0);
                    points[1] = new FCPoint(width, 0 + (height - m_borderWidth - 4) / 2);
                    points[2] = new FCPoint(width - m_borderWidth / 2, 0 + (height - m_borderWidth - 4) / 2 + m_borderWidth / 2);
                    points[3] = new FCPoint(width - m_borderWidth, 0 + (height - m_borderWidth - 4) / 2);
                    points[4] = new FCPoint(width - m_borderWidth, 0 + m_borderWidth);
                    points[5] = new FCPoint(width, 0);
                    paint.fillPolygon(textColor, points);
                }
                if (numberStr.IndexOf("3") != -1)
                {
                    FCPoint[] points = new FCPoint[6];
                    points[0] = new FCPoint(width, height-(height-m_borderWidth-4)/2);
                    points[1] = new FCPoint(width, height);
                    points[2] = new FCPoint(width-m_borderWidth, height-m_borderWidth);
                    points[3] = new FCPoint(width-m_borderWidth, height-(height-m_borderWidth-4)/2);
                    points[4] = new FCPoint(width-m_borderWidth/2, height-(height-m_borderWidth-4)/2-m_borderWidth/2);
                    points[5] = new FCPoint(width, height-(height-m_borderWidth-4)/2);
                    paint.fillPolygon(textColor, points);
                }
                if (numberStr.IndexOf("4") != -1)
                {
                    FCPoint[] points = new FCPoint[5];
                    points[0] = new FCPoint(2, height);
                    points[1] = new FCPoint(width - 2, height);
                    points[2] = new FCPoint(width - m_borderWidth - 2, height - m_borderWidth);
                    points[3] = new FCPoint(m_borderWidth + 2, height - m_borderWidth);
                    points[4] = new FCPoint(2, height);
                    paint.fillPolygon(textColor, points);
                }
                if (numberStr.IndexOf("5") != -1)
                {
                    FCPoint[] points = new FCPoint[6];
                    points[0] = new FCPoint(0, height - (height - m_borderWidth - 4) / 2);
                    points[1] = new FCPoint(0, height);
                    points[2] = new FCPoint(m_borderWidth, height - m_borderWidth);
                    points[3] = new FCPoint(m_borderWidth, height - (height - m_borderWidth - 4) / 2);
                    points[4] = new FCPoint(m_borderWidth / 2, height - (height - m_borderWidth - 4) / 2 - m_borderWidth / 2);
                    points[5] = new FCPoint(0, height - (height - m_borderWidth - 4) / 2);
                    paint.fillPolygon(textColor, points);
                }
                if (numberStr.IndexOf("6") != -1)
                {
                    FCPoint[] points = new FCPoint[6];
                    points[0] = new FCPoint(0, 0);
                    points[1] = new FCPoint(0, 0 + (height - m_borderWidth - 4) / 2);
                    points[2] = new FCPoint(m_borderWidth / 2, 0 + (height - m_borderWidth - 4) / 2 + m_borderWidth / 2);
                    points[3] = new FCPoint(m_borderWidth, 0 + (height - m_borderWidth - 4) / 2);
                    points[4] = new FCPoint(m_borderWidth, 0 + m_borderWidth);
                    points[5] = new FCPoint(0, 0);
                    paint.fillPolygon(textColor, points);
                }
                if (numberStr.IndexOf("7") != -1)
                {
                    FCPoint[] points = new FCPoint[7];
                    points[0] = new FCPoint(m_borderWidth / 2, height / 2 + 1);
                    points[1] = new FCPoint(m_borderWidth, height / 2 - m_borderWidth / 2 + 1);
                    points[2] = new FCPoint(width - m_borderWidth, height / 2 - m_borderWidth / 2 + 1);
                    points[3] = new FCPoint(width - m_borderWidth / 2, height / 2 + 1);
                    points[4] = new FCPoint(width - m_borderWidth, height / 2 + m_borderWidth / 2 + 1);
                    points[5] = new FCPoint(m_borderWidth, height / 2 + m_borderWidth / 2 + 1);
                    points[6] = new FCPoint(m_borderWidth / 2, height / 2 + 1);
                    paint.fillPolygon(textColor, points);
                }
            }
        }
    }
}
