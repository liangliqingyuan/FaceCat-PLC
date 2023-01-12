using System;
using System.Collections.Generic;
using System.Text;

namespace FaceCat
{
    /// <summary>
    /// 仪表示例
    /// </summary>
    public class InstrumentDiv:FCLayoutDiv
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public InstrumentDiv()
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

        public ArrayList<FCInstrument> m_instruments = new ArrayList<FCInstrument>();

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
            String[] styles = new String[] { "Gray", "Red", "Green", "Blue", "Yellow", "Violet", "Magenta" };
            for (int i = 0; i < 50; i++)
            {
                FCInstrument instrument = new FCInstrument();
                instrument.setSize(new FCSize(200, 200));
                instrument.m_needleColor1 = styles[i % styles.Length];
                addView(instrument);
                instrument.m_value = m_rd.Next((int)instrument.m_minValue, (int)instrument.m_maxValue);
                instrument.m_needleType = m_rd.Next(0, 2);
                instrument.m_needleRadius = m_rd.Next(0, 40) + 40;
                instrument.m_needleWidth = 3 + m_rd.Next(0, 5);
                instrument.setRangeColor(m_colors[i % m_colors.Length]);
                instrument.m_baseArcStart = m_rd.Next(0, 200);
                instrument.m_baseArcSweep = m_rd.Next(240, 360);
                m_instruments.add(instrument);
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
                for (int i = 0; i < m_instruments.size(); i++)
                {
                    FCInstrument instrument = m_instruments.get(i);
                    instrument.m_value = m_rd.Next((int)instrument.m_minValue, (int)instrument.m_maxValue);
                }
                invalidate();
            }
        }
    }
}
