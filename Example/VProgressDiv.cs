using System;
using System.Collections.Generic;
using System.Text;

namespace FaceCat
{
    /// <summary>
    /// 横向进度条示例
    /// </summary>
    public class VProgressDiv : FCLayoutDiv
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public VProgressDiv()
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

        /// <summary>
        /// 秒表ID
        /// </summary>
        public int m_timerID = FCView.getNewTimerID();

        public ArrayList<PLCVProgress> m_vProgresses = new ArrayList<PLCVProgress>();

        public Random m_rd = new Random();

        /// <summary>
        /// 添加视图方法
        /// </summary>
        public override void onAdd()
        {
            base.onAdd();
            for (int i = 0; i < 100; i++)
            {
                PLCVProgress vProgress = new PLCVProgress();
                vProgress.setSize(new FCSize(30, 300));
                vProgress.setMargin(new FCPadding(20, 20, 20, 20));
                addView(vProgress);
                vProgress.m_progressColor = m_colors[i % m_colors.Length];
                vProgress.m_nowValue = m_rd.Next(0, (int)vProgress.m_maxValue);
                m_vProgresses.add(vProgress);
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
                for (int i = 0; i < m_vProgresses.size(); i++)
                {
                    PLCVProgress vProgress = m_vProgresses.get(i);
                    vProgress.m_nowValue = vProgress.m_nowValue + 1;
                    if (vProgress.m_nowValue > vProgress.m_maxValue)
                    {
                        vProgress.m_nowValue = 0;
                    }
                }
                invalidate();
            }
        }
    }
}
