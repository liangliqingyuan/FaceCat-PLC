using System;
using System.Collections.Generic;
using System.Text;

namespace FaceCat
{
    /// <summary>
    /// 开关
    /// </summary>
    public class PLCSwitch:FCCheckBox
    {
        /// <summary>
        /// 创建复选框
        /// </summary>
        public PLCSwitch()
        {
            m_borderColor = FCColor.None;
        }

        /// <summary>
        /// 选中的颜色
        /// </summary>
        public long m_checkedColor = FCColor.Pushed;

        /// <summary>
        /// 未选的颜色
        /// </summary>
        public long m_unCheckedColor = FCColor.Hovered;

        /// <summary>
        /// 重绘复选框按钮
        /// </summary>
        /// <param name="paint"></param>
        /// <param name="clipRect"></param>
        public override void onPaintCheckButton(FCPaint paint, FCRect clipRect)
        {
            FCRect drawRect = clipRect;
            int width = getWidth(), height = getHeight();
            bool iChecked = isChecked();
            int d = getButtonSize().cy;
            int pHeight = height;
            int round = 4;
            FCRect pRect = new FCRect(1, height / 2 - pHeight / 2, width - 1, height / 2 + pHeight / 2);
            long backColor = getBackColor();
            long backColor1 = m_unCheckedColor;
            FCRect ellipseRect = new FCRect(1, 0, width / 2, height);
            if (iChecked)
            {
                backColor = getButtonBackColor();
                backColor1 = m_checkedColor;
                ellipseRect.left = width / 2;
                ellipseRect.right = width;
            }
            paint.fillRoundRect(backColor, pRect, round);
            paint.fillRoundRect(backColor1, ellipseRect, round);
        }

        /// <summary>
        /// 重绘边线方法
        /// </summary>
        /// <param name="paint"></param>
        /// <param name="clipRect"></param>
        public override void onPaintBorder(FCPaint paint, FCRect clipRect)
        {
        }

        /// <summary>
        /// 重绘背景方法
        /// </summary>
        /// <param name="paint"></param>
        /// <param name="clipRect"></param>
        public override void onPaintBackground(FCPaint paint, FCRect clipRect)
        {
        }

        /// <summary>
        /// 重绘前景方法
        /// </summary>
        /// <param name="paint">绘图对象</param>
        /// <param name="clipRect">裁剪区域</param>
        public override void onPaintForeground(FCPaint paint, FCRect clipRect)
        {
            String text = getText();
            int width = getWidth(), height = getHeight();
            if (width > 0 && height > 0)
            {
                FCRect buttonRect = new FCRect(5, (height - m_buttonSize.cy) / 2, 5 + m_buttonSize.cx, (height + m_buttonSize.cy) / 2);
                //绘制背景图
                onPaintCheckButton(paint, buttonRect);
                //绘制文字
                if (text != null && text.Length > 0)
                {
                    FCFont font = getFont();
                    FCSize tSize = paint.textSize(text, font, -1);
                    FCPoint tLocation = new FCPoint(buttonRect.right + 5, (height - tSize.cy) / 2);
                    FCRect tRect = new FCRect(tLocation.x, tLocation.y, tLocation.x + tSize.cx, tLocation.y + tSize.cy);
                    long textColor = getPaintingTextColor();
                    paint.drawText(text, textColor, font, tRect, -1);
                }
            }
        }
    }
}
