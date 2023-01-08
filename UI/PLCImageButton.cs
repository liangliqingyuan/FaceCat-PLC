using System;
using System.Collections.Generic;
using System.Text;

namespace FaceCat
{
    /// <summary>
    /// 带图片的按钮
    /// </summary>
    public class PLCImageButton:FCButton
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PLCImageButton()
        {
            setFont(new FCFont("Default", 14));
        }

        /// <summary>
        /// 图片的大小
        /// </summary>
        public FCSize m_imageSize = new FCSize(30, 30);

        public override void onPaint(FCPaint paint, FCRect clipRect)
        {
            int width = getWidth(), height = getHeight();
            FCRect drawRect = new FCRect(0, 0, width, height);
            paint.fillRoundRect(getPaintingBackColor(), drawRect, getCornerRadius());
            FCFont tFont = getFont();
            String text = getText();
            FCSize tSize = paint.textSize(text, tFont);
            int totalWidth = tSize.cx + 10 + m_imageSize.cx;
            FCRect imageRect = new FCRect((width - totalWidth) / 2, (height - m_imageSize.cy) / 2,
                (width - totalWidth) / 2 + m_imageSize.cx, (height + m_imageSize.cy) / 2);
            paint.drawImage(getBackImage(), imageRect);
            FCDraw.drawText(paint, text, getTextColor(), tFont, imageRect.right + 10, (height - tSize.cy) / 2);
        }
    }
}
