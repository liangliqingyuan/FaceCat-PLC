using System;
using System.Collections.Generic;
using System.Text;

namespace FaceCat
{
    /// <summary>
    /// 折线示例
    /// </summary>
    public class LineChartDiv : FCLayoutDiv
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public LineChartDiv()
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

        public ArrayList<FCChart> m_lineCharts = new ArrayList<FCChart>();

        public Random m_rd = new Random();

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
                PolylineShape ps = new PolylineShape();
                ps.setFieldName(0);
                ps.setColor(m_colors[i % m_colors.Length]);
                ps.setWidth(2);
                chartDiv.addShape(ps);
                m_lineCharts.add(chart);
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
                for (int i = 0; i < m_lineCharts.size(); i++)
                {
                    FCChart chart = m_lineCharts.get(i);
                    FCDataTable dataSource = chart.getDataSource();
                    int dataSize = dataSource.getRowsCount();
                    double lastValue = 0;
                    if (dataSize > 0)
                    {
                        lastValue = dataSource.get2(dataSize - 1, 0);
                    }
                    dataSource.set(dataSize + 1, 0, lastValue + (-5 + m_rd.Next(0, 10)));
                    chart.update();
                }
                invalidate();
            }
        }
    }
}
