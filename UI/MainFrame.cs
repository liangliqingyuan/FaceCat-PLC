using System;
using System.Collections.Generic;
using System.Text;
using FaceCat;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Xml;

namespace encodeex
{
    /// <summary>
    /// 主窗体
    /// </summary>
    public class MainFrame : UIXmlEx, FCTimerEventCallBack
    {
        /// <summary>
        /// 颜色集合
        /// </summary>
        private long[] m_colors = new long[] { FCColor.rgb(59, 174, 218), FCColor.rgb(185, 63, 150), FCColor.rgb(219, 68, 83), FCColor.rgb(246, 187, 67),
            FCColor.rgb(216, 112, 173), FCColor.rgb(140, 192, 81), FCColor.rgb(233, 87, 62),
            FCColor.rgb(150, 123 ,220), FCColor.rgb(75, 137, 220), 
            FCColor.rgb(170, 178, 189) };

        public ArrayList<FCInstrument> m_instruments = new ArrayList<FCInstrument>();

        public ArrayList<PLCThermometer> m_thermometers = new ArrayList<PLCThermometer>();

        public ArrayList<PLCSignal> m_signals = new ArrayList<PLCSignal>();

        public ArrayList<PLCHProgress> m_hProgresses = new ArrayList<PLCHProgress>();

        public ArrayList<PLCVProgress> m_vProgresses = new ArrayList<PLCVProgress>();

        public ArrayList<FCChart> m_lineCharts = new ArrayList<FCChart>();

        public ArrayList<FCChart> m_histogramCharts = new ArrayList<FCChart>();

        public ArrayList<PLCCycleProgress> m_cycleProgresses = new ArrayList<PLCCycleProgress>();

        public Random m_rd = new Random();

        public int m_tick = 0;

        /// <summary>
        /// 加载XML
        /// </summary>
        /// <param name="xmlPath">XML地址</param>
        public override void loadFile(String file, FCView parent)
        {
            //预创建控件
            base.loadFile(file, parent);
            PLCKeyBoard plcKeyBoard = new PLCKeyBoard();
            plcKeyBoard.setDock(FCDockStyle.Fill);
            plcKeyBoard.setShowNumberPad(false);
            getTabPage("TabPage").addView(plcKeyBoard);
            for (int i = 0; i < 10; i++)
            {
                PLCSlide slide = new PLCSlide();
                slide.setSize(new FCSize(500, 60));
                slide.setLocation(new FCPoint(0, i * 60));
                getTabPage("TabPage2").addView(slide);
                slide.setValue(m_rd.Next(0, 100));
            }
            FCLayoutDiv layoutDiv = new FCLayoutDiv();
            layoutDiv.setAutoWrap(true);
            layoutDiv.setDock(FCDockStyle.Fill);
            layoutDiv.setLayoutStyle(FCLayoutStyle.LeftToRight);
            getTabPage("TabPage3").addView(layoutDiv);
            String[] styles = new String[] { "Gray", "Red", "Green", "Blue", "Yellow", "Violet", "Magenta" };
            for (int i = 0; i < 50; i++)
            {
                FCInstrument instrument = new FCInstrument();
                instrument.setSize(new FCSize(200, 200));
                instrument.m_needleColor1 = styles[i % styles.Length];
                layoutDiv.addView(instrument);
                instrument.m_value = m_rd.Next((int)instrument.m_minValue, (int)instrument.m_maxValue);
                instrument.m_needleType = m_rd.Next(0, 2);
                instrument.m_needleRadius = m_rd.Next(0, 40) + 40;
                instrument.m_needleWidth = 3 + m_rd.Next(0, 5);
                instrument.setRangeColor(m_colors[i % m_colors.Length]);
                instrument.m_baseArcStart = m_rd.Next(0, 200);
                instrument.m_baseArcSweep = m_rd.Next(240, 360);
                m_instruments.add(instrument);
            }
            layoutDiv.update();
            layoutDiv.startTimer(m_timeriD, 100);
            layoutDiv.addEvent(this, FCEventID.Timer, this);

            FCLayoutDiv layoutDiv2 = new FCLayoutDiv();
            layoutDiv2.setAutoWrap(true);
            layoutDiv2.setDock(FCDockStyle.Fill);
            layoutDiv2.setLayoutStyle(FCLayoutStyle.LeftToRight);
            for (int i = 0; i < 50; i++)
            {
                PLCThermometer thermometer = new PLCThermometer();
                thermometer.setSize(new FCSize(120, 200));
                layoutDiv2.addView(thermometer);
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
            getTabPage("TabPage4").addView(layoutDiv2);
            layoutDiv2.update();

            FCLayoutDiv layoutDiv3 = new FCLayoutDiv();
            layoutDiv3.setAutoWrap(true);
            layoutDiv3.setDock(FCDockStyle.Fill);
            layoutDiv3.setLayoutStyle(FCLayoutStyle.LeftToRight);
            for (int i = 0; i < 100; i++)
            {
                PLCSignal signal = new PLCSignal();
                signal.setSize(new FCSize(100, 100));
                signal.setText("信号灯" + i.ToString());
                //signal.m_colors = m_colors;
                layoutDiv3.addView(signal);
                m_signals.add(signal);
            }
            getTabPage("TabPage5").addView(layoutDiv3);
            layoutDiv3.update();

            FCLayoutDiv layoutDiv4 = new FCLayoutDiv();
            layoutDiv4.setAutoWrap(true);
            layoutDiv4.setDock(FCDockStyle.Fill);
            layoutDiv4.setLayoutStyle(FCLayoutStyle.LeftToRight);
            for (int i = 0; i < 100; i++)
            {
                PLCHProgress hProgress = new PLCHProgress();
                hProgress.setSize(new FCSize(300, 30));
                hProgress.setMargin(new FCPadding(20, 20, 20, 20));
                layoutDiv4.addView(hProgress);
                hProgress.m_progressColor = m_colors[i % m_colors.Length];
                hProgress.m_nowValue = m_rd.Next(0, (int)hProgress.m_maxValue);
                m_hProgresses.add(hProgress);
            }
            getTabPage("TabPage6").addView(layoutDiv4);
            layoutDiv4.update();

            FCLayoutDiv layoutDiv5 = new FCLayoutDiv();
            layoutDiv5.setAutoWrap(true);
            layoutDiv5.setDock(FCDockStyle.Fill);
            layoutDiv5.setLayoutStyle(FCLayoutStyle.LeftToRight);
            for (int i = 0; i < 100; i++)
            {
                PLCVProgress vProgress = new PLCVProgress();
                vProgress.setSize(new FCSize(30, 300));
                vProgress.setMargin(new FCPadding(20, 20, 20, 20));
                layoutDiv5.addView(vProgress);
                vProgress.m_progressColor = m_colors[i % m_colors.Length];
                vProgress.m_nowValue = m_rd.Next(0, (int)vProgress.m_maxValue);
                m_vProgresses.add(vProgress);
            }
            getTabPage("TabPage7").addView(layoutDiv5);
            layoutDiv5.update();

            FCLayoutDiv layoutDiv6 = new FCLayoutDiv();
            layoutDiv6.setAutoWrap(true);
            layoutDiv6.setDock(FCDockStyle.Fill);
            layoutDiv6.setLayoutStyle(FCLayoutStyle.LeftToRight);
            for (int i = 0; i < 100; i++)
            {
                PLCImageButton imageButton = new PLCImageButton();
                imageButton.setMargin(new FCPadding(20, 20, 20, 20));
                imageButton.setSize(new FCSize(150, 40));
                imageButton.setText("按钮" + i.ToString());
                imageButton.setBackImage(Application.StartupPath + "\\config\\facecat_plc\\image\\cs.png");
                layoutDiv6.addView(imageButton);
            }
            getTabPage("TabPage8").addView(layoutDiv6);
            layoutDiv6.update();

            FCLayoutDiv layoutDiv7 = new FCLayoutDiv();
            layoutDiv7.setAutoWrap(true);
            layoutDiv7.setDock(FCDockStyle.Fill);
            layoutDiv7.setLayoutStyle(FCLayoutStyle.LeftToRight);
            getTabPage("TabPage9").addView(layoutDiv7);
            for (int i = 0; i < 100; i++)
            {
                PLCSpin spin = new PLCSpin();
                layoutDiv7.addView(spin);
                spin.setMargin(new FCPadding(20, 20, 20, 20));
                spin.setSize(new FCSize(150, 40));
                spin.setValue(m_rd.Next((int)spin.getMinimum(), (int)spin.getMaximum()));
            }
            layoutDiv7.update();

            FCGrid grid = new FCGrid();
            grid.setHeaderHeight(30);
            grid.setDock(FCDockStyle.Fill);
            grid.getRowStyle().setHoveredBackColor(FCColor.None);
            grid.getRowStyle().setFont(new FCFont("Default", 16));
            getTabPage("TabPage10").addView(grid);
            String[] columns = new String[] { "文字", "整型", "浮点型", "百分比浮点型", "复选框", "按钮", "下拉列表", "输入框" };
            for (int i = 0; i < columns.Length; i++)
            {
                FCGridColumn column = new FCGridColumn(columns[i]);
                column.setWidth(120);
                column.setFont(new FCFont("Default", 16));
                grid.addColumn(column);
                if (columns[i] == "浮点型")
                {
                    column.setCellAlign(FCHorizontalAlign.Right);
                }
                else if (columns[i] == "百分比浮点型")
                {
                    column.setCellAlign(FCHorizontalAlign.Center);
                }
            }
            grid.update();
            for (int i = 0; i < 100; i++)
            {
                FCGridRow row = new FCGridRow();
                grid.addRow(row);
                row.setHeight(40);
                for (int j = 0; j < columns.Length; j++)
                {
                    if (j == 0)
                    {
                        FCGridStringCell cell = new FCGridStringCell("文字");
                        row.addCell(j, cell);
                    }
                    else if (j == 1)
                    {
                        FCGridIntCell cell = new FCGridIntCell(100);
                        row.addCell(j, cell);
                    }
                    else if (j == 2)
                    {
                        FCGridDoubleCell cell = new FCGridDoubleCell(3.1415926);
                        row.addCell(j, cell);
                        FCGridCellStyle cellStyle = new FCGridCellStyle();
                        if (i % 2 == 0)
                        {
                            cellStyle.setBackColor(FCColor.rgb(255, 0, 0));
                        }
                        else
                        {
                            cellStyle.setBackColor(FCColor.rgb(0, 255, 0));
                        }
                        cell.setStyle(cellStyle);
                    }
                    else if (j == 3)
                    {
                        FCGridPercentCell cell = new FCGridPercentCell(0.31415926);
                        cell.setDigit(2);
                        row.addCell(j, cell);
                    }
                    else if (j == 4)
                    {
                        FCGridCheckBoxCell cell1 = new FCGridCheckBoxCell();
                        row.addCell(j, cell1);
                        cell1.setBool(m_rd.Next(0, 2) == 0);
                        cell1.getCheckBox().setButtonBorderColor(FCColor.Text);
                        cell1.getCheckBox().setButtonSize(new FCSize(30, 30));
                    }
                    else if (j == 5)
                    {
                        FCGridButtonCell cell1 = new FCGridButtonCell();
                        row.addCell(j, cell1);
                        cell1.setText("按钮");
                        cell1.getButton().setFont(new FCFont("Default", 16));
                        cell1.getButton().setBackColor(m_colors[i % m_colors.Length]);
                    }
                    else if (j == 6)
                    {
                        FCGridComboBoxCell cell = new FCGridComboBoxCell();
                        row.addCell(j, cell);
                        cell.getComboBox().addItem(new FCMenuItem("选项1"));
                        cell.getComboBox().addItem(new FCMenuItem("选项2"));
                        cell.getComboBox().addItem(new FCMenuItem("选项3"));
                        cell.getComboBox().setSelectedIndex(0);
                        cell.getComboBox().setReadOnly(true);
                        cell.getComboBox().setFont(new FCFont("Default", 16));
                        for (int c = 0; c < cell.getComboBox().getItems().size(); c++)
                        {
                            FCMenuItem menuItem = cell.getComboBox().getItems().get(c);
                            menuItem.setFont(new FCFont("Default", 16));
                            menuItem.setHeight(30);
                        }
                    }
                    else if (j == 7)
                    {
                        FCGridTextBoxCell cell = new FCGridTextBoxCell();
                        row.addCell(j, cell);
                        cell.getTextBox().setTempText("请输入文字");
                        cell.getTextBox().setFont(new FCFont("Default", 16));
                    }
                }
            }

            String[] svgFiles = new String[] { "cpu.svg", "drone.svg", "manual-gear.svg", "pig.svg", "robot-two.svg" };
            FCLayoutDiv layoutDiv8 = new FCLayoutDiv();
            layoutDiv8.setAutoWrap(true);
            layoutDiv8.setDock(FCDockStyle.Fill);
            layoutDiv8.setLayoutStyle(FCLayoutStyle.LeftToRight);
            getTabPage("TabPage11").addView(layoutDiv8);
            for (int i = 0; i < 100; i++)
            {
                FCSvg svg = new FCSvg();
                layoutDiv8.addView(svg);
                svg.setSize(new FCSize(60, 60));
                svg.setMargin(new FCPadding(20, 20, 20, 20));
                loadSvgFile(svg, Application.StartupPath + "\\config\\facecat_plc\\svg\\" + svgFiles[i % svgFiles.Length]);
            }
            layoutDiv8.update();

            FCLayoutDiv layoutDiv9 = new FCLayoutDiv();
            layoutDiv9.setAutoWrap(true);
            layoutDiv9.setDock(FCDockStyle.Fill);
            layoutDiv9.setLayoutStyle(FCLayoutStyle.LeftToRight);
            getTabPage("TabPage12").addView(layoutDiv9);
            for (int i = 0; i < 20; i++)
            {
                FCChart chart = new FCChart();
                layoutDiv9.addView(chart);
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
            layoutDiv9.update();

            FCLayoutDiv layoutDiv10 = new FCLayoutDiv();
            layoutDiv10.setAutoWrap(true);
            layoutDiv10.setDock(FCDockStyle.Fill);
            layoutDiv10.setLayoutStyle(FCLayoutStyle.LeftToRight);
            getTabPage("TabPage13").addView(layoutDiv10);
            for (int i = 0; i < 100; i++)
            {
                PLCCycleProgress plcCycleProgress = new PLCCycleProgress();
                plcCycleProgress.setSize(new FCSize(200, 200));
                layoutDiv10.addView(plcCycleProgress);
                plcCycleProgress.m_progressColor = m_colors[i % m_colors.Length];
                plcCycleProgress.m_nowValue = m_rd.Next(0, (int)plcCycleProgress.m_maxValue);
                m_cycleProgresses.add(plcCycleProgress);
            }
            layoutDiv10.update();

            FCLayoutDiv layoutDiv11 = new FCLayoutDiv();
            layoutDiv11.setAutoWrap(true);
            layoutDiv11.setDock(FCDockStyle.Fill);
            layoutDiv11.setLayoutStyle(FCLayoutStyle.LeftToRight);
            getTabPage("TabPage14").addView(layoutDiv11);
            for (int i = 0; i < 200; i++)
            {
                PLCSwitch pSwitch = new PLCSwitch();
                layoutDiv11.addView(pSwitch);
                pSwitch.setSize(new FCSize(60, 30));
                pSwitch.setMargin(new FCPadding(20, 20, 20, 20));
                pSwitch.m_backColor = FCColor.rgb(200, 200, 200);
                pSwitch.m_unCheckedColor = FCColor.rgb(150, 150, 150);
                pSwitch.m_checkedColor = m_colors[i % m_colors.Length];
                pSwitch.setChecked(m_rd.Next(0, 3) != 0);
            }
            layoutDiv11.update();

            FCLayoutDiv layoutDiv12 = new FCLayoutDiv();
            layoutDiv12.setAutoWrap(true);
            layoutDiv12.setDock(FCDockStyle.Fill);
            layoutDiv12.setLayoutStyle(FCLayoutStyle.LeftToRight);
            getTabPage("TabPage15").addView(layoutDiv12);
            for (int i = 0; i < 200; i++)
            {
                PLCPie pie = new PLCPie();
                layoutDiv12.addView(pie);
                pie.setSize(new FCSize(250, 250));
                int pItemSize = m_rd.Next(3, 10);
                for (int j = 0; j < pItemSize; j++)
                {
                    PLCPieItem item = new PLCPieItem();
                    item.m_text = "项目" + j.ToString();
                    item.m_value = m_rd.Next(10, 100);
                    pie.m_items.add(item);
                    item.m_color = m_colors[j % m_colors.Length];
                }
            }
            layoutDiv12.update();

            FCLayoutDiv layoutDiv13 = new FCLayoutDiv();
            layoutDiv13.setAutoWrap(true);
            layoutDiv13.setDock(FCDockStyle.Fill);
            layoutDiv13.setLayoutStyle(FCLayoutStyle.LeftToRight);
            getTabPage("TabPage16").addView(layoutDiv13);
            for (int i = 0; i < 20; i++)
            {
                FCChart chart = new FCChart();
                layoutDiv13.addView(chart);
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
            layoutDiv13.update();
        }

        public void loadSvgFile(FCSvg svg, String fileName)
        {
            svg.m_shapes.clear();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(fileName);
            XmlNode rootNode = xmlDoc.DocumentElement;
            FCSvgOutWrite outWrite = new FCSvgOutWrite();
            outWrite.moreAnalysis(svg, this, rootNode);
        }

        public int m_timeriD = FCView.getNewTimerID();

        public void callTimerEvent(string eventName, object sender, int timerID, object invoke)
        {
            if (timerID == m_timeriD)
            {
                for (int i = 0; i < m_instruments.size(); i++)
                {
                    FCInstrument instrument = m_instruments.get(i);
                    instrument.m_value = m_rd.Next((int)instrument.m_minValue, (int)instrument.m_maxValue);
                }
                for (int i = 0; i < m_thermometers.size(); i++)
                {
                    PLCThermometer thermometer = m_thermometers.get(i);
                    thermometer.m_value = m_rd.Next((int)thermometer.m_minValue, (int)thermometer.m_maxValue);
                }
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
                }
                for (int i = 0; i < m_histogramCharts.size(); i++)
                {
                    FCChart chart = m_histogramCharts.get(i);
                    FCDataTable dataSource = chart.getDataSource();
                    int dataSize = dataSource.getRowsCount();
                    dataSource.set(dataSize + 1, 0, m_rd.Next(100, 200));
                }
                for (int i = 0; i < m_cycleProgresses.size(); i++)
                {
                    PLCCycleProgress cycleProgress = m_cycleProgresses.get(i);
                    cycleProgress.m_nowValue = cycleProgress.m_nowValue + 1;
                    if (cycleProgress.m_nowValue > cycleProgress.m_maxValue)
                    {
                        cycleProgress.m_nowValue = 0;
                    }
                }
                for (int i = 0; i < m_hProgresses.size(); i++)
                {
                    PLCHProgress hProgress = m_hProgresses.get(i);
                    hProgress.m_nowValue = hProgress.m_nowValue + 1;
                    if (hProgress.m_nowValue > hProgress.m_maxValue)
                    {
                        hProgress.m_nowValue = 0;
                    }
                }
                for (int i = 0; i < m_vProgresses.size(); i++)
                {
                    PLCVProgress vProgress = m_vProgresses.get(i);
                    vProgress.m_nowValue = vProgress.m_nowValue + 1;
                    if (vProgress.m_nowValue > vProgress.m_maxValue)
                    {
                        vProgress.m_nowValue = 0;
                    }
                }
                if (m_tick % 10 == 0)
                {
                    for (int i = 0; i < m_signals.size(); i++)
                    {
                        PLCSignal signal = m_signals.get(i);
                        signal.m_state = m_rd.Next(0, signal.m_colors.Length);
                    }
                }
                getNative().update();
                getNative().invalidate();
                m_tick++;
                if (m_tick > 100000)
                {
                    m_tick = 0;
                }
            }
        }
    }
}