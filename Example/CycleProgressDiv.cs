using System;
using System.Collections.Generic;
using System.Text;

namespace FaceCat
{
    /// <summary>
    /// 圆形进度条
    /// </summary>
    public class CycleProgressDiv:FCLayoutDiv
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CycleProgressDiv()
        {
            setAutoWrap(true);
        }
        public ArrayList<PLCCycleProgress> m_cycleProgresses = new ArrayList<PLCCycleProgress>();

        /// <summary>
        /// 颜色集合
        /// </summary>
        private long[] m_colors = new long[] { FCColor.rgb(59, 174, 218), FCColor.rgb(185, 63, 150), FCColor.rgb(219, 68, 83), FCColor.rgb(246, 187, 67),
            FCColor.rgb(216, 112, 173), FCColor.rgb(140, 192, 81), FCColor.rgb(233, 87, 62),
            FCColor.rgb(150, 123 ,220), FCColor.rgb(75, 137, 220), 
            FCColor.rgb(170, 178, 189) };

        /// <summary>
        /// 秒表ID
        /// </summary>
        public int m_timerID = FCView.getNewTimerID();

        public Random m_rd = new Random();

        /// <summary>
        /// 添加视图方法
        /// </summary>
        public override void onAdd()
        {
            base.onAdd();
            for (int i = 0; i < 100; i++)
            {
                PLCCycleProgress plcCycleProgress = new PLCCycleProgress();
                plcCycleProgress.setSize(new FCSize(200, 200));
                addView(plcCycleProgress);
                plcCycleProgress.m_progressColor = m_colors[i % m_colors.Length];
                plcCycleProgress.m_nowValue = m_rd.Next(0, (int)plcCycleProgress.m_maxValue);
                m_cycleProgresses.add(plcCycleProgress);
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
                for (int i = 0; i < m_cycleProgresses.size(); i++)
                {
                    PLCCycleProgress cycleProgress = m_cycleProgresses.get(i);
                    cycleProgress.m_nowValue = cycleProgress.m_nowValue + 1;
                    if (cycleProgress.m_nowValue > cycleProgress.m_maxValue)
                    {
                        cycleProgress.m_nowValue = 0;
                    }
                }
                invalidate();
            }
        }
    }
}
