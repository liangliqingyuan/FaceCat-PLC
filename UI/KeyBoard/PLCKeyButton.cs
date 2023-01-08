/*基于捂脸猫FaceCat框架 v1.0
上海卷卷猫信息技术有限公司
 */

using System;
using System.Collections.Generic;
using System.Text;
using FaceCat;

namespace FaceCat
{
    /// <summary>
    /// 虚拟键盘按钮
    /// </summary>
    public class PLCKeyButton : FCButton {
        /// <summary>
        /// 创建按钮
        /// </summary>
        public PLCKeyButton(String keyText1, String keyText2, int keyValue1, int keyValue2, long backColor)
        {
            m_keyText1 = keyText1;
            m_keyText2 = keyText2;
            m_keyValue1 = keyValue1;
            m_keyValue2 = keyValue2;
            setBorderColor(FCColor.rgba(100, 100, 100, 255));
            setFont(new FCFont("Default", 14, false, false, false));
            setTextColor(FCColor.rgba(255, 255, 255, 255));
            setBackColor(backColor);
        }

        private String m_keyText1;

        /// <summary>
        /// 获取按键文字1
        /// </summary>
        public String getKeyText1() {
            return m_keyText1;
        }

        /// <summary>
        /// 设置按键文字
        /// </summary>
        public void setKeyText1(String value)
        {
            m_keyText1 = value; 
        }

        private String m_keyText2;

        /// <summary>
        /// 获取按键文字2
        /// </summary>
        public String getKeyText2() {
            return m_keyText2;
        }

        /// <summary>
        /// 设置按键文字2
        /// </summary>
        public void setKeyText2(String value)
        {
            m_keyText2 = value;
        }

        private int m_keyValue1;

        /// <summary>
        /// 获取按键1
        /// </summary>
        public int getKeyValue1() {
            return m_keyValue1;
        }

        /// <summary>
        /// 设置按键1
        /// </summary>
        public void setKeyValue1(int value)
        {
            m_keyValue1 = value; 
        }

        private int m_keyValue2;

        /// <summary>
        /// 获取或设置按键2
        /// </summary>
        public int getKeyValue2() {
            return m_keyValue2;
        }

        /// <summary>
        /// 获取或设置按键2
        /// </summary>
        public void setKeyValue2(int value)
        {
            m_keyValue2 = value;
        }

        /// <summary>
        /// 绘制背景方法
        /// </summary>
        /// <param name="paint">绘图对象</param>
        /// <param name="clipRect">裁剪区域</param>
        public override void onPaintBackground(FCPaint paint, FCRect clipRect)
        {
            String text = getText();
            int cornerRadius = 6;
            int width = getWidth(), height = getHeight();
            FCRect drawRect = new FCRect(0, 0, width, height);
            if (width / 4 < cornerRadius || height / 4 < cornerRadius)
            {
                cornerRadius = Math.Min(width / 4, height / 4);
            }
            long backColor = getBackColor();
            FCRect innerRect = drawRect;
            innerRect.left += 3;
            innerRect.top += 3;
            innerRect.right -= 4;
            innerRect.bottom -= 4;
            //paint.drawRoundRect(backColor, 1, 0, drawRect, cornerRadius);
            paint.fillRect(backColor, drawRect);
            if (this == m_native.getPushedView())
            {
                paint.fillRect(FCColor.Pushed, drawRect);
            }
        }

        /// <summary>
        /// 绘制边线方法
        /// </summary>
        /// <param name="paint">绘图对象</param>
        /// <param name="clipRect">裁剪区域</param>
        public override void onPaintBorder(FCPaint paint, FCRect clipRect)
        {
        }

        /// <summary>
        /// 重绘前景方法
        /// </summary>
        /// <param name="paint">绘图对象</param>
        /// <param name="clipRect">裁剪区域</param>
        public override void onPaintForeground(FCPaint paint, FCRect clipRect) {
            int width = getWidth();
            int height = getHeight();
            int mw = width / 2;
            int mh = height / 2;
            int fontSize = Math.Min(mw, mh) * 6 / 10;
            if (fontSize == 0) {
                fontSize = 1;
            }
            FCFont font = new FCFont("Default", fontSize, false, false, false);
            long foreColor = getPaintingTextColor();
            if (m_keyText1 != null && m_keyText1.Length > 0 && m_keyText2 != null && m_keyText2.Length > 0) {
                FCSize tSize1 = paint.textSize(m_keyText1, font, -1);
                FCSize tSize2 = paint.textSize(m_keyText2, font, -1);
                FCRect tRect1 = new FCRect();
                tRect1.left = (width - tSize1.cx) / 2;
                tRect1.top = mh - tSize1.cy;
                tRect1.right = tRect1.left + tSize1.cx;
                tRect1.bottom = tRect1.top + tSize1.cy;
                paint.drawText(m_keyText1, foreColor, font, tRect1, -1);
                if (m_keyText2 != null && m_keyText2.Length > 0) {
                    if (m_keyText2 == "Left" || m_keyText2 == "Up"
                        || m_keyText2 == "Down" || m_keyText2 == "Right") {
                        if (m_keyText2 == "Left") {
                            int arrowHalfSize = height / 10;
                            FCPoint[] points = new FCPoint[3];
                            points[0] = new FCPoint(mw - arrowHalfSize, mh * 3 / 2);
                            points[1] = new FCPoint(mw + arrowHalfSize, mh * 3 / 2 - arrowHalfSize);
                            points[2] = new FCPoint(mw + arrowHalfSize, mh * 3 / 2 + arrowHalfSize);
                            paint.fillPolygon(foreColor, points);
                        }
                        else if (m_keyText2 == "Up") {
                            int arrowHalfSize = height / 10;
                            FCPoint[] points = new FCPoint[3];
                            points[0] = new FCPoint(mw, mh * 3 / 2 - arrowHalfSize);
                            points[1] = new FCPoint(mw - arrowHalfSize, mh * 3 / 2 + arrowHalfSize);
                            points[2] = new FCPoint(mw + arrowHalfSize, mh * 3 / 2 + arrowHalfSize);
                            paint.fillPolygon(foreColor, points);
                        }
                        else if (m_keyText2 == "Right") {
                            int arrowHalfSize = height / 10;
                            FCPoint[] points = new FCPoint[3];
                            points[0] = new FCPoint(mw + arrowHalfSize, mh * 3 / 2);
                            points[1] = new FCPoint(mw - arrowHalfSize, mh * 3 / 2 - arrowHalfSize);
                            points[2] = new FCPoint(mw - arrowHalfSize, mh * 3 / 2 + arrowHalfSize);
                            paint.fillPolygon(foreColor, points);
                        }
                        else if (m_keyText2 == "Down") {
                            int arrowHalfSize = width / 10;
                            FCPoint[] points = new FCPoint[3];
                            points[0] = new FCPoint(mw, mh * 3 / 2 + arrowHalfSize);
                            points[1] = new FCPoint(mw - arrowHalfSize, mh * 3 / 2 - arrowHalfSize);
                            points[2] = new FCPoint(mw + arrowHalfSize, mh * 3 / 2 - arrowHalfSize);
                            paint.fillPolygon(foreColor, points);
                        }
                    }
                    else {
                        FCRect tRect2 = new FCRect();
                        tRect2.left = (width - tSize2.cx) / 2;
                        tRect2.top = mh + height / 20;
                        tRect2.right = tRect2.left + tSize2.cx;
                        tRect2.bottom = tRect2.top + tSize2.cy;
                        paint.drawText(m_keyText2, foreColor, font, tRect2, -1);
                    }
                }

            }
            else if (m_keyText1 != null && m_keyText1.Length > 0) {
                if (m_keyText1 == "Left") {
                    int arrowHalfSize = height / 10;
                    FCPoint[] points = new FCPoint[3];
                    points[0] = new FCPoint(mw - arrowHalfSize, mh);
                    points[1] = new FCPoint(mw + arrowHalfSize, mh - arrowHalfSize);
                    points[2] = new FCPoint(mw + arrowHalfSize, mh + arrowHalfSize);
                    paint.fillPolygon(foreColor, points);
                }
                else if (m_keyText1 == "Up") {
                    int arrowHalfSize = height / 10;
                    FCPoint[] points = new FCPoint[3];
                    points[0] = new FCPoint(mw, mh - arrowHalfSize);
                    points[1] = new FCPoint(mw - arrowHalfSize, mh + arrowHalfSize);
                    points[2] = new FCPoint(mw + arrowHalfSize, mh + arrowHalfSize);
                    paint.fillPolygon(foreColor, points);
                }
                else if (m_keyText1 == "Right") {
                    int arrowHalfSize = height / 10;
                    FCPoint[] points = new FCPoint[3];
                    points[0] = new FCPoint(mw + arrowHalfSize, mh);
                    points[1] = new FCPoint(mw - arrowHalfSize, mh - arrowHalfSize);
                    points[2] = new FCPoint(mw - arrowHalfSize, mh + arrowHalfSize);
                    paint.fillPolygon(foreColor, points);
                }
                else if (m_keyText1 == "Down") {
                    int arrowHalfSize = width / 10;
                    FCPoint[] points = new FCPoint[3];
                    points[0] = new FCPoint(mw, mh + arrowHalfSize);
                    points[1] = new FCPoint(mw - arrowHalfSize, mh - arrowHalfSize);
                    points[2] = new FCPoint(mw + arrowHalfSize, mh - arrowHalfSize);
                    paint.fillPolygon(foreColor, points);
                }
                else if (m_keyText1 == "Win") {
                    mw -= 3;
                    int winHalfSize = height / 5;
                    FCPoint[] points = new FCPoint[4];
                    points[0] = new FCPoint(mw - winHalfSize + 2, mh - winHalfSize + 2);
                    points[1] = new FCPoint(mw - 1, mh - winHalfSize);
                    points[2] = new FCPoint(mw - 1, mh - 1);
                    points[3] = new FCPoint(mw - winHalfSize + 2, mh - 1);
                    paint.fillPolygon(foreColor, points);
                    points[0] = new FCPoint(mw - winHalfSize + 2, mh + 1);
                    points[1] = new FCPoint(mw - 1, mh + 1);
                    points[2] = new FCPoint(mw - 1, mh + winHalfSize);
                    points[3] = new FCPoint(mw - winHalfSize + 2, mh + winHalfSize - 2);
                    paint.fillPolygon(foreColor, points);
                    points[0] = new FCPoint(mw + 1, mh - 1);
                    points[1] = new FCPoint(mw + winHalfSize + 2, mh - 1);
                    points[2] = new FCPoint(mw + winHalfSize + 2, mh - winHalfSize - 3);
                    points[3] = new FCPoint(mw + 1, mh - winHalfSize);
                    paint.fillPolygon(foreColor, points);
                    points[0] = new FCPoint(mw + 1, mh + 1);
                    points[1] = new FCPoint(mw + winHalfSize + 2, mh + 1);
                    points[2] = new FCPoint(mw + winHalfSize + 2, mh + winHalfSize + 3);
                    points[3] = new FCPoint(mw + 1, mh + winHalfSize);
                    paint.fillPolygon(foreColor, points);
                }
                else if (m_keyText1 == "Fn") {
                    int fnHalfSize = height / 3;
                    paint.drawRect(foreColor, 1, 0, new FCRect(mw - fnHalfSize, mh - fnHalfSize, mw + fnHalfSize, mh + fnHalfSize));
                    paint.drawLine(foreColor, 1, 0, mw - fnHalfSize / 2, mh - fnHalfSize / 2, mw + fnHalfSize / 2, mh - fnHalfSize / 2);
                    paint.drawLine(foreColor, 1, 0, mw - fnHalfSize / 2, mh, mw + fnHalfSize / 2, mh);
                    paint.drawLine(foreColor, 1, 0, mw - fnHalfSize / 2, mh + fnHalfSize / 2, mw + fnHalfSize / 2, mh + fnHalfSize / 2);
                }
                else {
                    FCSize tSize = paint.textSize(m_keyText1, font, -1);
                    FCRect tRect = new FCRect();
                    tRect.left = (width - tSize.cx) / 2;
                    tRect.top = (height - tSize.cy) / 2;
                    tRect.right = tRect.left + tSize.cx;
                    tRect.bottom = tRect.top + tSize.cy;
                    paint.drawText(m_keyText1, foreColor, font, tRect, -1);
                }
            }
        }
    }
}
