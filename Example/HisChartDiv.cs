using System;
using System.Collections.Generic;
using System.Text;

namespace FaceCat
{
    /// <summary>
    /// 柱状图示例
    /// </summary>
    public class HisChartDiv : FCLayoutDiv
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public HisChartDiv()
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

        public Random m_rd = new Random();

        public ArrayList<FCChart> m_histogramCharts = new ArrayList<FCChart>();

        /// <summary>
        /// 添加视图方法
        /// </summary>
        public override void onAdd()
        {
            base.onAdd();
            for (int i = 0; i < 20; i++)
            {
                FCChart chart = new FCChart();
                addView(chart);
                chart.setHScalePixel(21);
                chart.setSize(new FCSize(400, 200));
                ChartDiv chartDiv = chart.addDiv();
                chartDiv.setBackColor(FCColor.rgb(255, 255, 255));
                chartDiv.getLeftVScale().setScaleColor(FCColor.rgb(0, 0, 0));
                chartDiv.getLeftVScale().setTextColor(FCColor.rgb(0, 0, 0));
                chartDiv.getHScale().setScaleColor(FCColor.rgb(0, 0, 0));
                chartDiv.getHScale().setTextColor(FCColor.rgb(0, 0, 0));

                chartDiv.getHScale().setDateColor(DateType.Day, FCColor.rgb(0, 0, 0));
                chartDiv.getHScale().setDateColor(DateType.Hour, FCColor.rgb(0, 0, 0));
                chartDiv.getHScale().setDateColor(DateType.Millisecond, FCColor.rgb(0, 0, 0));
                chartDiv.getHScale().setDateColor(DateType.Minute, FCColor.rgb(0, 0, 0));
                chartDiv.getHScale().setDateColor(DateType.Month, FCColor.rgb(0, 0, 0));
                chartDiv.getHScale().setDateColor(DateType.Second, FCColor.rgb(0, 0, 0));
                chartDiv.getHScale().setDateColor(DateType.Year, FCColor.rgb(0, 0, 0));
                chartDiv.getHScale().setHScaleType(HScaleType.Number);

                FCDataTable dataSource = chart.getDataSource();
                dataSource.addColumn(0);
                BarShape bs = new BarShape();
                bs.setFieldName(0);
                bs.setUpColor(m_colors[i % m_colors.Length]);
                bs.setDownColor(m_colors[i % m_colors.Length]);
                chartDiv.addShape(bs);
                m_histogramCharts.add(chart);
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
                for (int i = 0; i < m_histogramCharts.size(); i++)
                {
                    FCChart chart = m_histogramCharts.get(i);
                    FCDataTable dataSource = chart.getDataSource();
                    int dataSize = dataSource.getRowsCount();
                    dataSource.set(dataSize + 1, 0, m_rd.Next(100, 200));
                    chart.update();
                }
                invalidate();
            }
        }
    }
}
