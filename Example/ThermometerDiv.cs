using System;
using System.Collections.Generic;
using System.Text;

namespace FaceCat
{
    /// <summary>
    /// 温度计示例
    /// </summary>
    public class ThermometerDiv : FCLayoutDiv
    {
        public ThermometerDiv()
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

        public ArrayList<PLCThermometer> m_thermometers = new ArrayList<PLCThermometer>();

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
            for (int i = 0; i < 50; i++)
            {
                PLCThermometer thermometer = new PLCThermometer();
                thermometer.setSize(new FCSize(120, 200));
                addView(thermometer);
                m_thermometers.add(thermometer);
                thermometer.m_mercuryColor = m_colors[i % m_colors.Length];
                int type = m_rd.Next(0, 6);
                switch (type)
                {
                    case 0:
                        break;
                    case 1:
                        thermometer.m_leftUnit = TemperatureUnit.C;
                        break;
                    case 2:
                        thermometer.m_leftUnit = TemperatureUnit.F;
                        break;
                    case 3:
                        thermometer.m_leftUnit = TemperatureUnit.K;
                        break;
                    case 4:
                        thermometer.m_leftUnit = TemperatureUnit.R;
                        break;
                    case 5:
                        thermometer.m_leftUnit = TemperatureUnit.RE;
                        break;
                }
                type = m_rd.Next(0, 6);
                switch (type)
                {
                    case 0:
                        thermometer.m_rightUnit = TemperatureUnit.None;
                        break;
                    case 1:
                        thermometer.m_rightUnit = TemperatureUnit.C;
                        break;
                    case 2:
                        thermometer.m_rightUnit = TemperatureUnit.F;
                        break;
                    case 3:
                        thermometer.m_rightUnit = TemperatureUnit.K;
                        break;
                    case 4:
                        thermometer.m_rightUnit = TemperatureUnit.R;
                        break;
                    case 5:
                        thermometer.m_rightUnit = TemperatureUnit.RE;
                        break;
                }
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
                for (int i = 0; i < m_thermometers.size(); i++)
                {
                    PLCThermometer thermometer = m_thermometers.get(i);
                    thermometer.m_value = m_rd.Next((int)thermometer.m_minValue, (int)thermometer.m_maxValue);
                }
                invalidate();
            }
        }
    }
}
