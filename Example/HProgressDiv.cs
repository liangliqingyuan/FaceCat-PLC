using System;
using System.Collections.Generic;
using System.Text;

namespace FaceCat
{
    /// <summary>
    /// 横向进度条示例
    /// </summary>
    public class HProgressDiv : FCLayoutDiv
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public HProgressDiv()
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

        public ArrayList<PLCHProgress> m_hProgresses = new ArrayList<PLCHProgress>();

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
                PLCHProgress hProgress = new PLCHProgress();
                hProgress.setSize(new FCSize(300, 30));
                hProgress.setMargin(new FCPadding(20, 20, 20, 20));
                addView(hProgress);
                hProgress.m_progressColor = m_colors[i % m_colors.Length];
                hProgress.m_nowValue = m_rd.Next(0, (int)hProgress.m_maxValue);
                m_hProgresses.add(hProgress);
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
                for (int i = 0; i < m_hProgresses.size(); i++)
                {
                    PLCHProgress hProgress = m_hProgresses.get(i);
                    hProgress.m_nowValue = hProgress.m_nowValue + 1;
                    if (hProgress.m_nowValue > hProgress.m_maxValue)
                    {
                        hProgress.m_nowValue = 0;
                    }
                }
                invalidate();
            }
        }
    }
}
