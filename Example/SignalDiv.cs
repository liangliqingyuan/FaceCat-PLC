using System;
using System.Collections.Generic;
using System.Text;

namespace FaceCat
{
    /// <summary>
    /// 信号灯示例
    /// </summary>
    public class SignalDiv : FCLayoutDiv
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public SignalDiv()
        {
            setAutoWrap(true);
        }

        /// <summary>
        /// 颜色集合
        /// </summary>
        private long[] m_colors = new long[] { FCColor.rgb(59, 174, 218), FCColor.rgb(185, 63, 150), FCColor.rgb(219, 68, 83), FCColor.rgb(246, 187, 67),
            FCColor.rgb(216, 112, 173), FCColor.rgb(140, 192, 81), FCColor.rgb(233, 87, 62),
            FCColor.rgb(150, 123 ,220), FCColor.rgb(75, 137, 220), 
            FCColor.rgb(170, 178, 189) };

        public ArrayList<PLCSignal> m_signals = new ArrayList<PLCSignal>();

        /// <summary>
        /// 秒表ID
        /// </summary>
        public int m_timerID = FCView.getNewTimerID();

        public Random m_rd = new Random();

        public int m_tick = 0;

        /// <summary>
        /// 添加视图方法
        /// </summary>
        public override void onAdd()
        {
            base.onAdd();
            for (int i = 0; i < 100; i++)
            {
                PLCSignal signal = new PLCSignal();
                signal.setSize(new FCSize(100, 100));
                signal.setText("信号灯" + i.ToString());
                //signal.m_colors = m_colors;
                addView(signal);
                m_signals.add(signal);
            }
            startTimer(m_timerID, 100);
        }

        /// <summary>
        /// 移除视图方法
        /// </summary>
        public override void onRemove()
        {
            base.onRemove();
            stopTimer(m_timerID);
        }

        /// <summary>
        /// 秒表方法
        /// </summary>
        /// <param name="timerID"></param>
        public override void onTimer(int timerID)
        {
            base.onTimer(timerID);
            if (timerID == m_timerID)
            {
                if (m_tick % 10 == 0)
                {
                    for (int i = 0; i < m_signals.size(); i++)
                    {
                        PLCSignal signal = m_signals.get(i);
                        signal.m_state = m_rd.Next(0, signal.m_colors.Length);
                    }
                }
                invalidate();
                m_tick++;
                if (m_tick > 100000)
                {
                    m_tick = 0;
                }
            }
        }
    }
}
