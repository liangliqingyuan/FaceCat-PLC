using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FaceCat
{
    /// <summary>
    /// 切片项
    /// </summary>
    public class PLCSlide : FCView
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public PLCSlide()
        {
            setBackColor(getTextColor());
            setBorderColor(FCColor.None);
            setFont(new FCFont("Default", 16, false, false, false));
        }

        /// <summary>
        /// TICK值
        /// </summary>
        private int m_tick = 0;

        /// <summary>
        /// 秒表ID
        /// </summary>
        private int m_timerID = getNewTimerID();

        public int m_digit = 0;

        /// <summary>
        /// 获取保留小数的位数
        /// </summary>
        public virtual int getDigit()
        {
            return m_digit;
        }

        /// <summary>
        /// 设置保留小数的位数
        /// </summary>
        public virtual void setDigit(int value)
        {
            m_digit = value;
        }

        public bool m_isAdding;

        /// <summary>
        /// 获取是否正在增量
        /// </summary>
        public virtual bool isAdding()
        {
            return m_isAdding;
        }

        /// <summary>
        /// 设置是否正在增量
        /// </summary>
        public virtual void setIsAdding(bool value)
        {
            if (m_isAdding != value)
            {
                m_isAdding = value;
                m_tick = 0;
                if (m_isAdding)
                {
                    startTimer(m_timerID, 10);
                }
                else
                {
                    stopTimer(m_timerID);
                }
            }
        }

        public bool m_isReducing;

        /// <summary>
        /// 获取是否正在减量
        /// </summary>
        public virtual bool isReducing()
        {
            return m_isReducing;
        }

        /// <summary>
        /// 设置是否正在减量
        /// </summary>
        public virtual void setIsReducing(bool value)
        {
            if (m_isReducing != value)
            {
                m_isReducing = value;
                m_tick = 0;
                if (m_isReducing)
                {
                    startTimer(m_timerID, 10);
                }
                else
                {
                    stopTimer(m_timerID);
                }
            }
        }

        public double m_maximum = 100;

        /// <summary>
        /// 获取最大值
        /// </summary>
        public virtual double getMaximum()
        {
            return m_maximum;
        }

        /// <summary>
        /// 设置最大值
        /// </summary>
        public virtual void setMaximum(double value)
        {
            m_maximum = value;
            if (getValue() > value)
            {
                setValue(value);
            }
        }

        public double m_minimum = 0;

        /// <summary>
        /// 获取最小值
        /// </summary>
        public virtual double getMinimum()
        {
            return m_minimum;
        }

        /// <summary>
        /// 设置最小值
        /// </summary>
        public virtual void setMinimum(double value)
        {
            m_minimum = value;
            if (getValue() < value)
            {
                setValue(value);
            }
        }


        public double m_step = 1;

        /// <summary>
        /// 获取数值增减幅度
        /// </summary>
        public virtual double getStep()
        {
            return m_step;
        }

        /// <summary>
        /// 设置数值增减幅度
        /// </summary>
        public virtual void setStep(double value)
        {
            m_step = value;
        }

        /// <summary>
        /// 获取数值
        /// </summary>
        public virtual double getValue()
        {
            return FCTran.strToDouble(getText().Replace(",", ""));
        }

        /// <summary>
        /// 设置数值
        /// </summary>
        public virtual void setValue(double value)
        {
            if (value > m_maximum)
            {
                value = m_maximum;
            }
            if (value < m_minimum)
            {
                value = m_minimum;
            }
            double oldValue = getValue();
            setText(getValueByDigit(value, m_digit));
            onValueChanged();
        }

        /// <summary>
        /// 增加指定幅度的数值
        /// </summary>
        public virtual void add()
        {
            setValue(getValue() + m_step);
        }

        /// <summary>
        /// 获取视图类型
        /// </summary>
        /// <returns>视图类型</returns>
        public override String getViewType()
        {
            return "Slice";
        }

        /// <summary>
        /// 获取事件名称列表
        /// </summary>
        /// <returns>名称列表</returns>
        public override ArrayList<String> getEventNames()
        {
            ArrayList<String> eventNames = base.getEventNames();
            eventNames.AddRange(new String[] { "ValueChanged" });
            return eventNames;
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="name">属性名称</param>
        /// <param name="value">返回属性值</param>
        /// <param name="type">返回属性类型</param>
        public override void getAttribute(String name, ref String value, ref String type)
        {
            if (name == "digit")
            {
                type = "int";
                value = FCTran.doubleToStr(getDigit());
            }
            else if (name == "maximum")
            {
                type = "double";
                value = FCTran.doubleToStr(getMaximum());
            }
            else if (name == "minimum")
            {
                type = "double";
                value = FCTran.doubleToStr(getMinimum());
            }
            else if (name == "step")
            {
                type = "double";
                value = FCTran.doubleToStr(getStep());
            }
            else if (name == "value")
            {
                type = "double";
                value = FCTran.doubleToStr(getValue());
            }
            else
            {
                base.getAttribute(name, ref value, ref type);
            }
        }

        /// <summary>
        /// 获取属性名称列表
        /// </summary>
        /// <returns>属性名称列表</returns>
        public override ArrayList<String> getAttributeNames()
        {
            ArrayList<String> attributeNames = base.getAttributeNames();
            attributeNames.AddRange(new String[] { "Digit", "Maximum", "Minimum", "Step" });
            return attributeNames;
        }

        /// <summary>
        /// 根据保留小数的位置将double型转化为String型
        /// </summary>
        /// <param name="value">值</param>
        /// <param name="digit">保留小数点</param>
        /// <returns>数值字符</returns>
        public String getValueByDigit(double value, int digit)
        {
            if (digit > 0)
            {
                StringBuilder format = new StringBuilder();
                format.Append("0");
                format.Append(".");
                for (int i = 0; i < digit; i++)
                {
                    format.Append("0");
                }
                return value.ToString(format.ToString());
            }
            else
            {
                return value.ToString("0");
            }
        }

        /// <summary>
        /// 线的矩形
        /// </summary>
        private FCRect m_lineRect = new FCRect();

        /// <summary>
        /// 鼠标按下方法
        /// </summary>
        /// <param name="touchInfo"></param>
        public override void onTouchDown(FCTouchInfo touchInfo)
        {
            base.onTouchDown(touchInfo);
            FCPoint mp = touchInfo.m_firstPoint;
            if (m_lineRect.right - m_lineRect.left > 0)
            {
                int pos = mp.x - m_lineRect.left;
                double newValue = (m_maximum - m_minimum) * pos / (m_lineRect.right - m_lineRect.left);
                if (mp.x <= m_lineRect.left)
                {
                    newValue = m_minimum;
                }
                else if (mp.x >= m_lineRect.right)
                {
                    newValue = m_maximum;
                }
                setValue(newValue);
                invalidate();
            }
        }

        /// <summary>
        /// 鼠标移动方法
        /// </summary>
        /// <param name="touchInfo"></param>
        public override void onTouchMove(FCTouchInfo touchInfo)
        {
            base.onTouchMove(touchInfo);
            if (touchInfo.m_firstTouch)
            {
                FCPoint mp = touchInfo.m_firstPoint;
                if (m_lineRect.right - m_lineRect.left > 0)
                {
                    int pos = mp.x - m_lineRect.left;
                    double newValue = (m_maximum - m_minimum) * pos / (m_lineRect.right - m_lineRect.left);
                    if (mp.x <= m_lineRect.left)
                    {
                        newValue = m_minimum;
                    }
                    else if (mp.x >= m_lineRect.right)
                    {
                        newValue = m_maximum;
                    }
                    setValue(newValue);
                    invalidate();
                }
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
            long textColor = getPaintingTextColor();
            FCFont tFont = getFont();
            String minText = getValueByDigit(m_minimum, m_digit);
            String maxText = getValueByDigit(m_maximum, m_digit);
            FCSize minTextSize = paint.textSize(minText, tFont);
            FCSize maxTextSize = paint.textSize(maxText, tFont);
            FCRect drawRect = new FCRect(minTextSize.cx + 10, 1, width - maxTextSize.cx - 10, height);
            FCDraw.drawText(paint, minText, textColor, tFont, 2, drawRect.bottom - 15 - minTextSize.cy / 2);
            FCDraw.drawText(paint, maxText, textColor, tFont, width - maxTextSize.cx - 8, drawRect.bottom - 15 - maxTextSize.cy / 2);
            m_lineRect = new FCRect(drawRect.left, drawRect.bottom - 15, drawRect.right, drawRect.bottom - 13);
            if (m_lineRect.right - m_lineRect.left > 0)
            {
                double value = getValue();
                String nowText = getValueByDigit(value, m_digit);
                FCSize nowTextSize = paint.textSize(nowText, tFont);
                int pos = m_lineRect.left + (int)((m_lineRect.right - m_lineRect.left) * value / (m_maximum - m_minimum));
                FCPoint[] points = new FCPoint[5];
                points[0] = new FCPoint(pos - 5, m_lineRect.top - 7);
                points[1] = new FCPoint(pos + 5, m_lineRect.top - 7);
                points[2] = new FCPoint(pos + 5, m_lineRect.top + 5);
                points[3] = new FCPoint(pos, m_lineRect.top + 10);
                points[4] = new FCPoint(pos - 5, m_lineRect.top + 5);
                paint.fillRect(textColor, m_lineRect);
                paint.fillPolygon(textColor, points);
                FCDraw.drawText(paint, nowText, textColor, tFont, pos - nowTextSize.cx / 2, m_lineRect.top - 10 - nowTextSize.cy);
            }
        }

        /// <summary>
        /// 键盘按下方法
        /// </summary>
        /// <param name="key">按键</param>
        public override void onKeyDown(char key)
        {
            base.onKeyDown(key);
            FCHost host = getNative().getHost();
            if (!host.isKeyPress(0x10) && !host.isKeyPress(0x11) && !host.isKeyPress(0x12))
            {
                if (key == 39)
                {
                    add();
                    invalidate();
                }
                else if (key == 37)
                {
                    reduce();
                    invalidate();
                }
            }
        }

        /// <summary>
        /// 触摸滚动方法
        /// </summary>
        /// <param name="touchInfo">触摸信息</param>
        public override void onTouchWheel(FCTouchInfo touchInfo)
        {
            base.onTouchWheel(touchInfo);
            if (touchInfo.m_delta > 0)
            {
                add();
            }
            else if (touchInfo.m_delta < 0)
            {
                reduce();
            }
            invalidate();
        }

        /// <summary>
        /// 秒表事件
        /// </summary>
        /// <param name="timerID">秒表ID</param>
        public override void onTimer(int timerID)
        {
            base.onTimer(timerID);
            if (timerID == m_timerID)
            {
                if (m_tick > 20)
                {
                    if (m_tick > 50 || m_tick % 3 == 1)
                    {
                        if (m_isAdding)
                        {
                            add();
                            invalidate();
                        }
                        else if (m_isReducing)
                        {
                            reduce();
                            invalidate();
                        }
                    }
                }
                m_tick++;
            }
        }

        /// <summary>
        /// 数值改变时触发
        /// </summary>
        public virtual void onValueChanged()
        {
            callEvents(FCEventID.ValueChanged);
        }

        /// <summary>
        /// 减少指定幅度的数值
        /// </summary>
        public void reduce()
        {
            setValue(getValue() - m_step);
        }

        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="name">属性名称</param>
        /// <param name="value">属性值</param>
        public override void setAttribute(String name, String value)
        {
            if (name == "digit")
            {
                setDigit(FCTran.strToInt(value));
            }
            else if (name == "maximum")
            {
                setMaximum(FCTran.strToDouble(value));
            }
            else if (name == "minimum")
            {
                setMinimum(FCTran.strToDouble(value));
            }
            else if (name == "step")
            {
                setStep(FCTran.strToDouble(value));
            }
            else if (name == "value")
            {
                setValue(FCTran.strToDouble(value));
            }
            else
            {
                base.setAttribute(name, value);
            }
        }
    }
}
