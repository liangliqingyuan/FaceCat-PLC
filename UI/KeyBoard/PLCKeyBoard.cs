/*基于捂脸猫FaceCat框架 v1.0
上海卷卷猫信息技术有限公司
 */

using System;
using System.Collections.Generic;
using System.Text;
using FaceCat;
using System.Windows.Forms;

namespace FaceCat
{
    /// <summary>
    /// 虚拟键盘
    /// </summary>
    public class PLCKeyBoard : FCView {
        /// <summary>
        /// 创建虚拟键盘
        /// </summary>
        public PLCKeyBoard() {
            setPadding(new FCPadding(5, 5, 5, 5));
        }

        /// <summary>
        /// 键盘按钮
        /// </summary>
        public ArrayList<PLCKeyButton> m_keyButtons = new ArrayList<PLCKeyButton>();

        private int m_littleHeight = 40;

        /// <summary>
        /// 获取较小的键盘高度
        /// </summary>
        public int getLittleHeight() {
            return m_littleHeight;
        }

        /// <summary>
        /// 设置较小的键盘高度
        /// </summary>
        public void setLittleHeight(int value)
        {
            m_littleHeight = value;
        }

        private int m_littleWidth = 55;

        /// <summary>
        /// 获取较小的键盘宽度
        /// </summary>
        public int getLittleWidth() {
            return m_littleWidth;
        }

        /// <summary>
        /// 设置较小的键盘宽度
        /// </summary>
        public void setLittleWidth(int value)
        {
            m_littleWidth = value;
        }

        private int m_keySpace = 5;

        /// <summary>
        /// 获取键盘的间隙
        /// </summary>
        public int getKeySpace() {
            return m_keySpace; 
        }

        /// <summary>
        /// 设置键盘的间隙
        /// </summary>
        public void setKeySpace(int value)
        {
            m_keySpace = value;
        }

        private int m_normalHeight = 55;

        /// <summary>
        /// 获取或设置常规高度
        /// </summary>
        public int NormalHeight {
            get { return m_normalHeight; }
            set { m_normalHeight = value; }
        }

        private int m_normalWidth = 55;

        /// <summary>
        /// 获取常规宽度
        /// </summary>
        public int getNormalWidth() {
            return m_normalWidth;
        }

        /// <summary>
        /// 设置常规宽度
        /// </summary>
        public void setNormalWidth(int value)
        {
            m_normalWidth = value;
        }

        public bool m_showNumberPad = true;

        /// <summary>
        /// 获取数字键盘
        /// </summary>
        public bool showNumberPad()
        {
            return m_showNumberPad;
        }

        /// <summary>
        /// 设置数字键盘
        /// </summary>
        public void setShowNumberPad(bool value)
        {
            m_showNumberPad = value;
        }

        /// <summary>
        /// 销毁资源
        /// </summary>
        public override void delete() {
            m_keyButtons.Clear();
            base.delete();
        }

        /// <summary>
        /// 控件添加方法
        /// </summary>
        public override void onAdd() {
            base.onAdd();
            int keyButtonsSize = m_keyButtons.Count;
            if (keyButtonsSize == 0) {
                long keyButtonColor1 = FCColor.rgba(44, 59, 66, 255);
                long keyButtonColor2 = FCColor.rgba(84, 156, 142, 255);
                long keyButtonColor3 = FCColor.rgba(72, 72, 122, 255);
                m_keyButtons.Add(new PLCKeyButton("Esc", "", 27, 0, keyButtonColor1));
                m_keyButtons.Add(new PLCKeyButton("F1", "", 112, 0, keyButtonColor2));
                m_keyButtons.Add(new PLCKeyButton("F2", "", 113, 0, keyButtonColor2));
                m_keyButtons.Add(new PLCKeyButton("F3", "", 114, 0, keyButtonColor2));
                m_keyButtons.Add(new PLCKeyButton("F4", "", 115, 0, keyButtonColor2));
                m_keyButtons.Add(new PLCKeyButton("F5", "", 116, 0, keyButtonColor2));
                m_keyButtons.Add(new PLCKeyButton("F6", "", 117, 0, keyButtonColor2));
                m_keyButtons.Add(new PLCKeyButton("F7", "", 118, 0, keyButtonColor2));
                m_keyButtons.Add(new PLCKeyButton("F8", "", 119, 0, keyButtonColor2));
                m_keyButtons.Add(new PLCKeyButton("F9", "", 120, 0, keyButtonColor2));
                m_keyButtons.Add(new PLCKeyButton("F10", "", 121, 0, keyButtonColor2));
                m_keyButtons.Add(new PLCKeyButton("F11", "", 122, 0, keyButtonColor2));
                m_keyButtons.Add(new PLCKeyButton("F12", "", 123, 0, keyButtonColor2));

                m_keyButtons.Add(new PLCKeyButton("`", "~", 96, 126, keyButtonColor3));
                m_keyButtons.Add(new PLCKeyButton("1", "!", 97, 33, keyButtonColor3));
                m_keyButtons.Add(new PLCKeyButton("2", "@", 98, 64, keyButtonColor3));
                m_keyButtons.Add(new PLCKeyButton("3", "#", 99, 35, keyButtonColor3));
                m_keyButtons.Add(new PLCKeyButton("4", "$", 100, 36, keyButtonColor3));
                m_keyButtons.Add(new PLCKeyButton("5", "%", 101, 37, keyButtonColor3));
                m_keyButtons.Add(new PLCKeyButton("6", "^", 102, 94, keyButtonColor3));
                m_keyButtons.Add(new PLCKeyButton("7", "&", 103, 38, keyButtonColor3));
                m_keyButtons.Add(new PLCKeyButton("8", "*", 104, 42, keyButtonColor3));
                m_keyButtons.Add(new PLCKeyButton("9", "(", 105, 40, keyButtonColor3));
                m_keyButtons.Add(new PLCKeyButton("0", ")", 96, 41, keyButtonColor3));
                m_keyButtons.Add(new PLCKeyButton("-", "_", 45, 95, keyButtonColor3));
                m_keyButtons.Add(new PLCKeyButton("=", "+", 61, 43, keyButtonColor3));
                m_keyButtons.Add(new PLCKeyButton("BackSpace", "", 8, 0, FCColor.rgba(65, 146, 77, 255)));

                long rightColor = FCColor.rgba(99, 177, 187, 255);
                long innerColor = FCColor.rgba(102, 108, 122, 255);
                m_keyButtons.Add(new PLCKeyButton("Tab", "", 9, 0, FCColor.rgba(219, 68, 83, 255)));
                m_keyButtons.Add(new PLCKeyButton("Q", "", 113, 81, innerColor));
                m_keyButtons.Add(new PLCKeyButton("W", "", 119, 87, FCColor.rgba(171, 179, 190, 255)));
                m_keyButtons.Add(new PLCKeyButton("E", "", 101, 69, innerColor));
                m_keyButtons.Add(new PLCKeyButton("R", "", 114, 82, innerColor));
                m_keyButtons.Add(new PLCKeyButton("T", "", 116, 84, innerColor));
                m_keyButtons.Add(new PLCKeyButton("Y", "", 121, 89, innerColor));
                m_keyButtons.Add(new PLCKeyButton("U", "", 117, 85, innerColor));
                m_keyButtons.Add(new PLCKeyButton("I", "", 105, 73, innerColor));
                m_keyButtons.Add(new PLCKeyButton("O", "", 111, 79, innerColor));
                m_keyButtons.Add(new PLCKeyButton("P", "", 112, 80, innerColor));
                m_keyButtons.Add(new PLCKeyButton("[", "{", 91, 123, innerColor));
                m_keyButtons.Add(new PLCKeyButton("]", "}", 93, 125, innerColor));
                m_keyButtons.Add(new PLCKeyButton("\\", "|", 229, 124, innerColor));

                m_keyButtons.Add(new PLCKeyButton("Caps Lock", "", 20, 0, FCColor.rgba(62, 140, 163, 255)));
                m_keyButtons.Add(new PLCKeyButton("A", "", 97, 65, FCColor.rgba(171, 179, 190, 255)));
                m_keyButtons.Add(new PLCKeyButton("S", "", 115, 83, FCColor.rgba(171, 179, 190, 255)));
                m_keyButtons.Add(new PLCKeyButton("D", "", 100, 68, FCColor.rgba(171, 179, 190, 255)));
                m_keyButtons.Add(new PLCKeyButton("F", "", 102, 70, innerColor));
                m_keyButtons.Add(new PLCKeyButton("G", "", 103, 71, innerColor));
                m_keyButtons.Add(new PLCKeyButton("H", "", 104, 72, innerColor));
                m_keyButtons.Add(new PLCKeyButton("J", "", 106, 74, innerColor));
                m_keyButtons.Add(new PLCKeyButton("K", "", 107, 75, innerColor));
                m_keyButtons.Add(new PLCKeyButton("L", "", 108, 76, innerColor));
                m_keyButtons.Add(new PLCKeyButton(";", ":", 186, 58, innerColor));
                m_keyButtons.Add(new PLCKeyButton("'", "\\",  222, 92, innerColor));
                m_keyButtons.Add(new PLCKeyButton("Enter", "", 13, 0, FCColor.rgba(140, 192, 81, 255)));

                m_keyButtons.Add(new PLCKeyButton("Shift", "", 16, 0, FCColor.rgba(105, 80, 138, 255)));
                m_keyButtons.Add(new PLCKeyButton("Z", "", 122, 90, innerColor));
                m_keyButtons.Add(new PLCKeyButton("X", "", 120, 88, innerColor));
                m_keyButtons.Add(new PLCKeyButton("C", "", 99, 67, innerColor));
                m_keyButtons.Add(new PLCKeyButton("V", "", 118, 86, innerColor));
                m_keyButtons.Add(new PLCKeyButton("B", "", 98, 66, innerColor));
                m_keyButtons.Add(new PLCKeyButton("N", "", 110, 78, innerColor));
                m_keyButtons.Add(new PLCKeyButton("M", "", 109, 77, innerColor));
                m_keyButtons.Add(new PLCKeyButton(",", "<", 188, 60, innerColor));
                m_keyButtons.Add(new PLCKeyButton(".", ">", 190, 62, innerColor));
                m_keyButtons.Add(new PLCKeyButton("/", "?", 47, 63, innerColor));
                m_keyButtons.Add(new PLCKeyButton("Shift", "", 16, 0, FCColor.rgba(105, 80, 138, 255)));

                m_keyButtons.Add(new PLCKeyButton("Ctrl", "", 17, 0, FCColor.rgba(212, 109, 138, 255)));
                m_keyButtons.Add(new PLCKeyButton("Win", "", 91, 0, FCColor.rgba(55, 56, 102, 255)));
                m_keyButtons.Add(new PLCKeyButton("Alt", "", 164, 0, FCColor.rgba(216, 135, 54, 255)));
                m_keyButtons.Add(new PLCKeyButton("Space", "", 32, 0, FCColor.rgba(70, 156, 143, 255)));
                m_keyButtons.Add(new PLCKeyButton("Alt", "" , 165, 0, FCColor.rgba(216, 135, 54, 255)));
                m_keyButtons.Add(new PLCKeyButton("Win", "", 92, 0, FCColor.rgba(55, 56, 102, 255)));
                m_keyButtons.Add(new PLCKeyButton("Fn", "", 0, 0, FCColor.rgba(70, 156, 143, 255)));
                m_keyButtons.Add(new PLCKeyButton("Ctrl", "", 17, 0, FCColor.rgba(212, 109, 138, 255)));

                long topColor = FCColor.rgba(148, 121, 216, 255);
                long bottomColor = FCColor.rgba(59, 147, 218, 255);
                long midColor = FCColor.rgba(230, 85, 64, 255);
                m_keyButtons.Add(new PLCKeyButton("Print\r\nScreen", "", 44, 0, midColor));
                m_keyButtons.Add(new PLCKeyButton("Scroll\r\nLock", "", 145, 0, midColor));
                m_keyButtons.Add(new PLCKeyButton("Pause\r\nBreak", "", 19, 0, midColor));

                m_keyButtons.Add(new PLCKeyButton("Insert", "", 45, 0, bottomColor));
                m_keyButtons.Add(new PLCKeyButton("Home", "", 46, 0, bottomColor));
                m_keyButtons.Add(new PLCKeyButton("PageUp", "", 33, 0, bottomColor));

                m_keyButtons.Add(new PLCKeyButton("Delete", "", 46, 0, bottomColor));
                m_keyButtons.Add(new PLCKeyButton("End", "", 35, 0, bottomColor));
                m_keyButtons.Add(new PLCKeyButton("Page\r\nDown", "", 34, 0, bottomColor));

                m_keyButtons.Add(new PLCKeyButton("Up", "", 38, 0, topColor));
                m_keyButtons.Add(new PLCKeyButton("Left", "", 37, 0, topColor));
                m_keyButtons.Add(new PLCKeyButton("Down", "", 40, 0, topColor));
                m_keyButtons.Add(new PLCKeyButton("Right", "", 39, 0, topColor));

                if (m_showNumberPad)
                {
                    m_keyButtons.Add(new PLCKeyButton("Num\r\nLock", "", 144, 0, rightColor));
                    m_keyButtons.Add(new PLCKeyButton("/", " ", 47, 0, rightColor));
                    m_keyButtons.Add(new PLCKeyButton("*", " ", 42, 0, rightColor));

                    m_keyButtons.Add(new PLCKeyButton("7", " ", 103, 0, rightColor));
                    m_keyButtons.Add(new PLCKeyButton("8", "Up", 104, 38, rightColor));
                    m_keyButtons.Add(new PLCKeyButton("9", " ", 105, 0, rightColor));

                    m_keyButtons.Add(new PLCKeyButton("4", "Left", 100, 37, rightColor));
                    m_keyButtons.Add(new PLCKeyButton("5", " ", 101, 0, rightColor));
                    m_keyButtons.Add(new PLCKeyButton("6", "Right", 102, 39, rightColor));

                    m_keyButtons.Add(new PLCKeyButton("1", " ", 97, 0, rightColor));
                    m_keyButtons.Add(new PLCKeyButton("2", "Down", 98, 40, rightColor));
                    m_keyButtons.Add(new PLCKeyButton("3", " ", 99, 0, rightColor));

                    m_keyButtons.Add(new PLCKeyButton("0", "", 96, 0, rightColor));
                    m_keyButtons.Add(new PLCKeyButton("del", "", 0, 0, rightColor));

                    m_keyButtons.Add(new PLCKeyButton("-", " ", 45, 0, rightColor));
                    m_keyButtons.Add(new PLCKeyButton("+", "", 43, 0, rightColor));
                    m_keyButtons.Add(new PLCKeyButton("Enter", "", 13, 0, rightColor));
                }

                keyButtonsSize = m_keyButtons.Count;
                for (int i = 0; i < keyButtonsSize; i++) {
                    addView(m_keyButtons[i]);
                }
            }
        }

        /// <summary>
        /// 绘图更新方法
        /// </summary>
        public override void update() {
            base.update();
            int keyButtonsSize = m_keyButtons.Count;
            if (keyButtonsSize > 0) {
                FCPadding padding = getPadding();
                int left = padding.left, top = padding.top;
                int left2 = 0, left3 = 0, left4 = 0;
                int allWidth = m_normalWidth * 15 + m_keySpace * 14;
                for (int i = 0; i < keyButtonsSize; i++) {
                    PLCKeyButton keyButton = m_keyButtons[i];
                    if (i == 0) {
                        keyButton.setLocation(new FCPoint(left, top));
                        keyButton.setSize(new FCSize(m_littleWidth, m_littleHeight));
                        left += allWidth - m_littleWidth * 12 - m_keySpace * 12;
                    }
                    else if (i >= 1 && i <= 12) {
                        keyButton.setLocation(new FCPoint(left, top));
                        keyButton.setSize(new FCSize(m_littleWidth, m_littleHeight));
                        left += keyButton.getWidth() + m_keySpace;
                        if (i == 12) {
                            left = padding.left;
                            top += keyButton.getHeight() + m_keySpace;
                        }
                    }
                    else if (i >= 13 && i <= 26) {
                        keyButton.setLocation(new FCPoint(left, top));
                        keyButton.setSize(new FCSize(m_normalWidth, m_normalHeight));
                        left += keyButton.getWidth() + m_keySpace;
                        if (i == 26) {
                            keyButton.setWidth(allWidth - m_normalWidth * 13 - m_keySpace * 14);
                            left = padding.left;
                            top += keyButton.getHeight() + m_keySpace;
                        }
                    }
                    else if (i >= 27 && i <= 40) {
                        keyButton.setLocation(new FCPoint(left, top));
                        keyButton.setSize(new FCSize(m_normalWidth, m_normalHeight));
                        if (i == 27) {
                            keyButton.setWidth(allWidth - m_normalWidth * 13 - m_keySpace * 14);
                        }
                        left += keyButton.getWidth() + m_keySpace;
                        if (i == 40) {
                            left = padding.left;
                            top += keyButton.getHeight() + m_keySpace;
                        }
                    }
                    else if (i >= 41 && i <= 53) {
                        keyButton.setLocation(new FCPoint(left, top));
                        keyButton.setSize(new FCSize(m_normalWidth, m_normalHeight));
                        if (i == 41 || i == 53) {
                            keyButton.setWidth((allWidth - m_normalWidth * 11 - m_keySpace * 13) / 2);
                        }
                        left += keyButton.getWidth() + m_keySpace;
                        if (i == 53) {
                            left = padding.left;
                            top += keyButton.getHeight() + m_keySpace;
                        }
                    }
                    else if (i >= 54 && i <= 65) {
                        keyButton.setLocation(new FCPoint(left, top));
                        keyButton.setSize(new FCSize(m_normalWidth, m_normalHeight));
                        if (i == 54 || i == 65) {
                            keyButton.setWidth((allWidth - m_normalWidth * 10 - m_keySpace * 12) / 2);
                        }
                        left += keyButton.getWidth() + m_keySpace;
                        if (i == 65) {
                            left = padding.left;
                            top += keyButton.getHeight() + m_keySpace;
                        }
                    }
                    else if (i >= 66 && i <= 73) {
                        keyButton.setLocation(new FCPoint(left, top));
                        keyButton.setSize(new FCSize(m_normalWidth, m_normalHeight));
                        if (i == 66 || i == 73) {
                            keyButton.setWidth(m_normalWidth * 3 / 2);
                        }
                        else if (i == 69) {
                            keyButton.setWidth(allWidth - m_normalWidth * 8 - m_keySpace * 8);
                        }
                        left += keyButton.getWidth() + m_keySpace;
                        if (i == 73) {
                            left = keyButton.getRight() + m_keySpace * 2;
                            left2 = left;
                            top = padding.top;
                        }
                    }
                    else if (i >= 74 && i <= 76) {
                        keyButton.setLocation(new FCPoint(left, top));
                        keyButton.setSize(new FCSize(m_normalWidth, m_littleHeight));
                        left += keyButton.getWidth() + m_keySpace;
                        if (i == 76) {
                            left = left2;
                            top += keyButton.getHeight() + m_keySpace;
                        }
                    }
                    else if (i >= 77 && i <= 79) {
                        keyButton.setLocation(new FCPoint(left, top));
                        keyButton.setSize(new FCSize(m_normalWidth, m_normalHeight));
                        left += keyButton.getWidth() + m_keySpace;
                        if (i == 79) {
                            left = left2;
                            top += keyButton.getHeight() + m_keySpace;
                        }
                    }
                    else if (i >= 80 && i <= 82) {
                        keyButton.setLocation(new FCPoint(left, top));
                        keyButton.setSize(new FCSize(m_normalWidth, m_normalHeight));
                        left += keyButton.getWidth() + m_keySpace;
                        if (i == 82) {
                            left = left2;
                            top += keyButton.getHeight() + m_keySpace;
                            top += keyButton.getHeight() + m_keySpace;
                        }
                    }
                    else if (i == 83) {
                        keyButton.setLocation(new FCPoint(left, top));
                        keyButton.setSize(new FCSize(m_normalWidth, m_normalHeight));
                        keyButton.setLeft(keyButton.getLeft() + keyButton.getWidth() + m_keySpace);
                        top += keyButton.getHeight() + m_keySpace;
                        left = left2;
                    }
                    else if (i >= 84 && i <= 86) {
                        keyButton.setLocation(new FCPoint(left, top));
                        keyButton.setSize(new FCSize(m_normalWidth, m_normalHeight));
                        left += keyButton.getWidth() + m_keySpace;
                        if (i == 86) {
                            top = padding.top + m_littleHeight + m_keySpace;
                            left3 = keyButton.getRight() + m_keySpace * 2;
                            left = left3;
                        }
                    }
                    else if (i >= 87 && i <= 89) {
                        keyButton.setLocation(new FCPoint(left, top));
                        keyButton.setSize(new FCSize(m_normalWidth, m_normalHeight));
                        left += keyButton.getWidth() + m_keySpace;
                        if (i == 89) {
                            top += keyButton.getHeight() + m_keySpace;
                            left = left3;
                        }
                    }
                    else if (i >= 90 && i <= 92) {
                        keyButton.setLocation(new FCPoint(left, top));
                        keyButton.setSize(new FCSize(m_normalWidth, m_normalHeight));
                        left += keyButton.getWidth() + m_keySpace;
                        if (i == 92) {
                            left = left3;
                            top += keyButton.getHeight() + m_keySpace;
                        }
                    }
                    else if (i >= 93 && i <= 95) {
                        keyButton.setLocation(new FCPoint(left, top));
                        keyButton.setSize(new FCSize(m_normalWidth, m_normalHeight));
                        left += keyButton.getWidth() + m_keySpace;
                        if (i == 95) {
                            left = left3;
                            top += keyButton.getHeight() + m_keySpace;
                        }
                    }
                    else if (i >= 96 && i <= 98) {
                        keyButton.setLocation(new FCPoint(left, top));
                        keyButton.setSize(new FCSize(m_normalWidth, m_normalHeight));
                        left += keyButton.getWidth() + m_keySpace;
                        if (i == 98) {
                            left = left3;
                            top += keyButton.getHeight() + m_keySpace;
                        }
                    }
                    else if (i >= 99 && i <= 100) {
                        keyButton.setLocation(new FCPoint(left, top));
                        keyButton.setSize(new FCSize(m_normalWidth, m_normalHeight));
                        if (i == 99) {
                            keyButton.setWidth(m_normalWidth * 2 + m_keySpace);
                        }
                        left += keyButton.getWidth() + m_keySpace;
                        if (i == 100) {
                            left4 = keyButton.getRight() + m_keySpace;
                            left = left4;
                            top = padding.top + m_littleHeight + m_keySpace;
                        }
                    }
                    else if (i >= 101 && i <= 103) {
                        keyButton.setLocation(new FCPoint(left, top));
                        keyButton.setSize(new FCSize(m_normalWidth, m_normalHeight));
                        if (i == 102) {
                            keyButton.setHeight(m_normalHeight * 2 + m_keySpace);
                        }
                        else if (i == 103) {
                            keyButton.setHeight(m_normalHeight * 2 + m_keySpace);
                        }
                        top += keyButton.getHeight() + m_keySpace;
                        if (i == 103) {
                            left = left3 + 30;
                            top = padding.top;
                        }
                    }
                }
            }
        }
    }
}
