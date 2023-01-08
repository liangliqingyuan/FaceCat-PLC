using System;
using System.Collections.Generic;
using System.Text;

namespace FaceCat
{
    /// <summary>
    /// 数值输入框
    /// </summary>
    public class PLCSpin : FCSpin
    {
        /// <summary>
        /// 创建Spin
        /// </summary>
        public PLCSpin()
        {
            setTextAlign(FCHorizontalAlign.Center);
            setBackColor(MyColor.USERCOLOR12);
            setTextColor(MyColor.USERCOLOR27);
            setBorderColor(MyColor.USERCOLOR17);
            setMaximum(100);
            setMinimum(0);
            setCornerRadius(0);
            setFont(new FCFont("Default", 18));
        }


        /// <summary>
        /// 单位
        /// </summary>
        public String m_unit = "";

        /// <summary>
        /// 添加视图方法
        /// </summary>
        public override void onLoad()
        {
            FCHost host = getNative().getHost();
            if (m_downButton == null)
            {
                m_downButton = new FCButton();
                m_downButton.addEvent(this, "ontouchdown", null);
                m_downButton.addEvent(this, "ontouchup", null);
                m_downButton.setBackColor(MyColor.USERCOLOR8);
                m_downButton.setFont(new FCFont("Default", 18, false, false, false));
                m_downButton.setText("-");
                m_downButton.setCornerRadius(0);
                addView(m_downButton);
            }
            if (m_upButton == null)
            {
                m_upButton = new FCButton();
                m_upButton.addEvent(this, "ontouchdown", null);
                m_upButton.addEvent(this, "ontouchup", null);
                m_upButton.setBackColor(MyColor.USERCOLOR8);
                m_upButton.setFont(new FCFont("Default", 18, false, false, false));
                m_upButton.setText("+");
                m_upButton.setCornerRadius(0);
                addView(m_upButton);
            }
        }

        /// <summary>
        /// 重绘方法
        /// </summary>
        /// <param name="paint"></param>
        /// <param name="clipRect"></param>
        public override void onPaint(FCPaint paint, FCRect clipRect)
        {
            int width = getWidth(), height = getHeight();
            //base.onPaint(paint, clipRect);
            FCRect drawRect = new FCRect(0, 0, width, height);
            paint.fillRoundRect(getPaintingBackColor(), drawRect, getCornerRadius());
            FCFont tFont = getFont();
            int value = (int)getValue();
            if (m_unit == "X")
            {
                if (value == 0)
                {
                    value = 16;
                }
                else if (value == 1)
                {
                    value = 32;
                }
                else if (value == 2)
                {
                    value = 48;
                }
                else if (value == 3)
                {
                    value = 64;
                }
                else if (value == 4)
                {
                    value = 128;
                }
            }
            String str = value.ToString() + m_unit;
            if (m_unit == "X")
            {
                str = value.ToString() + " X " + value.ToString();
            }
            FCSize tSize = paint.textSize(str, tFont);
            long textColor = getTextColor();
            FCRect tRect = new FCRect((width - tSize.cx) / 2, (height - tSize.cy) / 2, (width + tSize.cx) / 2, (height + tSize.cy) / 2);
            paint.drawText(str, textColor, tFont, tRect);
        }

        /// <summary>
        /// 更新布局方法
        /// </summary>
        public override void update()
        {
            //base.update();
            int width = getWidth(), height = getHeight();
            if (m_upButton != null)
            {
                int uWidth = getHeight();
                FCPoint location = new FCPoint(width - uWidth, 0);
                m_upButton.setLocation(location);
                FCSize size = new FCSize(uWidth, height);
                m_upButton.setSize(size);
            }
            if (m_downButton != null)
            {
                int dWidth = getHeight();
                FCPoint location = new FCPoint(0, 0);
                m_downButton.setLocation(location);
                FCSize size = new FCSize(dWidth, height);
                m_downButton.setSize(size);
            }
        }
    }
}