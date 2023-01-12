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

namespace FaceCat
{
    /// <summary>
    /// 主窗体
    /// </summary>
    public class MainFrame : UIXmlEx, FCTouchEventCallBack
    {
        /// <summary>
        /// 颜色集合
        /// </summary>
        private long[] m_colors = new long[] { FCColor.rgb(59, 174, 218), FCColor.rgb(185, 63, 150), FCColor.rgb(219, 68, 83), FCColor.rgb(246, 187, 67),
            FCColor.rgb(216, 112, 173), FCColor.rgb(140, 192, 81), FCColor.rgb(233, 87, 62),
            FCColor.rgb(150, 123 ,220), FCColor.rgb(75, 137, 220), 
            FCColor.rgb(170, 178, 189) };
        /// <summary>
        /// 加载XML
        /// </summary>
        /// <param name="xmlPath">XML地址</param>
        public override void loadFile(String file, FCView parent)
        {
            //预创建控件
            base.loadFile(file, parent);
            FCTabView tabView = getTabView("divMain");
            FCTabPage divHomePage = getTabPage("divHomePage");
            AppList appList = new AppList();
            appList.setDock(FCDockStyle.Fill);
            divHomePage.addView(appList);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Application.StartupPath + "\\config\\facecat_plc\\Apps.html");
            foreach (XmlNode node in xmlDoc.DocumentElement)
            {
                if (node.Name == "body")
                {
                    String qbTopic = "全部";
                    ArrayList<String> keyWords = new ArrayList<String>();
                    keyWords.add(qbTopic);
                    int num = 0;
                    foreach (XmlNode subNode in node.ChildNodes)
                    {
                        AppIcon appIcon = new AppIcon();
                        appIcon.m_appList = appList;
                        appIcon.m_num = num;

                        appList.addView(appIcon);

                        IconView iconView = new IconView();
                        appIcon.m_iconView = iconView;
                        appIcon.addView(iconView);
                        setAttributesBefore(subNode, iconView);
                        //uiXmlEx.readChildNodes(subNode, iconView);
                        //uiXmlEx.setAttributesAfter(subNode, iconView);
                        appIcon.setText(iconView.m_text2);
                        appIcon.setName(iconView.getName());
                        if (appList.m_tempTID.Length > 0)
                        {
                            iconView.m_templateID = appList.m_tempTID;
                        }
                        for (int c = 0; c < iconView.m_topics.Length; c++)
                        {
                            String topic = iconView.m_topics[c];
                            int sCount = 0;
                            if (appList.m_iconCategory.TryGetValue(topic, out sCount))
                            {
                                appList.m_iconCategory[topic] = sCount + 1;
                            }
                            else
                            {
                                appList.m_iconCategory[topic] = 1;
                                keyWords.add(topic);
                            }
                        }
                        //appIcon.addEvent(this, FCEventID.Click, this);
                        iconView.addEvent(this, FCEventID.Click, this);
                        num++;
                    }
                    appList.onResetLayout();
                    if (appList.m_searchApp != null)
                    {
                        appList.m_searchApp.loadKeyWords(keyWords);
                    }
                }
            }
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

        private Random m_rd = new Random();

        /// <summary>
        /// 点击事件
        /// </summary>
        public void callTouchEvent(string eventName, object sender, FCTouchInfo touchInfo, object invoke)
        {
            FCView view = sender as FCView;
            AppIcon appIcon = view.getParent() as AppIcon;
            String name = view.getName();
            FCTabPage newTabPage = new FCTabPage();
            FCTabView tabView = getTabView("divMain");
            tabView.addView(newTabPage);
            newTabPage.setText(appIcon.getText());
            if (name == "SoftKeyBoard")
            {
                PLCKeyBoard plcKeyBoard = new PLCKeyBoard();
                plcKeyBoard.setDock(FCDockStyle.Fill);
                plcKeyBoard.setShowNumberPad(false);
                newTabPage.addView(plcKeyBoard);
                getNative().update();
                getNative().invalidate();
            }
            else if (name == "Slice")
            {
                FCDiv div = new FCDiv();
                div.setDock(FCDockStyle.Fill);
                newTabPage.addView(div);
                for (int i = 0; i < 10; i++)
                {
                    PLCSlide slide = new PLCSlide();
                    slide.setSize(new FCSize(500, 60));
                    slide.setLocation(new FCPoint(0, i * 60));
                    div.addView(slide);
                    slide.setValue(m_rd.Next(0, 100));
                }
                getNative().update();
                getNative().invalidate();
            }
            else if (name == "Instrument")
            {
                InstrumentDiv instrumentDiv = new InstrumentDiv();
                instrumentDiv.setDock(FCDockStyle.Fill);
                newTabPage.addView(instrumentDiv);
                getNative().update();
                getNative().invalidate();
            }
            else if (name == "Thermometer")
            {
                ThermometerDiv thermometerDiv = new ThermometerDiv();
                thermometerDiv.setDock(FCDockStyle.Fill);
                newTabPage.addView(thermometerDiv);
                getNative().update();
                getNative().invalidate();
            }
            else if (name == "Signal")
            {
                SignalDiv signalDiv = new SignalDiv();
                signalDiv.setDock(FCDockStyle.Fill);
                newTabPage.addView(signalDiv);
                getNative().update();
                getNative().invalidate();
            }
            else if (name == "HProgress")
            {
                HProgressDiv hProgressDiv = new HProgressDiv();
                hProgressDiv.setDock(FCDockStyle.Fill);
                newTabPage.addView(hProgressDiv);
                getNative().update();
                getNative().invalidate();
            }
            else if (name == "VProgress")
            {
                VProgressDiv vProgressDiv = new VProgressDiv();
                vProgressDiv.setDock(FCDockStyle.Fill);
                newTabPage.addView(vProgressDiv);
                getNative().update();
                getNative().invalidate();
            }
            else if (name == "ImageButton")
            {
                FCLayoutDiv layoutDiv6 = new FCLayoutDiv();
                layoutDiv6.setAutoWrap(true);
                layoutDiv6.setDock(FCDockStyle.Fill);
                layoutDiv6.setLayoutStyle(FCLayoutStyle.LeftToRight);
                newTabPage.addView(layoutDiv6);
                for (int i = 0; i < 100; i++)
                {
                    PLCImageButton imageButton = new PLCImageButton();
                    imageButton.setMargin(new FCPadding(20, 20, 20, 20));
                    imageButton.setSize(new FCSize(150, 40));
                    imageButton.setText("按钮" + i.ToString());
                    imageButton.setBackImage(Application.StartupPath + "\\config\\facecat_plc\\image\\cs.png");
                    layoutDiv6.addView(imageButton);
                }
                getNative().update();
                getNative().invalidate();
            }
            else if (name == "Spin")
            {
                FCLayoutDiv layoutDiv7 = new FCLayoutDiv();
                layoutDiv7.setAutoWrap(true);
                layoutDiv7.setDock(FCDockStyle.Fill);
                layoutDiv7.setLayoutStyle(FCLayoutStyle.LeftToRight);
                newTabPage.addView(layoutDiv7);
                for (int i = 0; i < 100; i++)
                {
                    PLCSpin spin = new PLCSpin();
                    layoutDiv7.addView(spin);
                    spin.setMargin(new FCPadding(20, 20, 20, 20));
                    spin.setSize(new FCSize(150, 40));
                    spin.setValue(m_rd.Next((int)spin.getMinimum(), (int)spin.getMaximum()));
                }
                getNative().update();
                getNative().invalidate();
            }
            else if (name == "Grid")
            {
                FCGrid grid = new FCGrid();
                grid.setHeaderHeight(30);
                grid.setDock(FCDockStyle.Fill);
                grid.getRowStyle().setHoveredBackColor(FCColor.None);
                grid.getRowStyle().setFont(new FCFont("Default", 16));
                newTabPage.addView(grid);
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
                getNative().update();
                getNative().invalidate();
            }
            else if (name == "SvgIcon")
            {
                String[] svgFiles = new String[] { "cpu.svg", "drone.svg", "manual-gear.svg", "pig.svg", "robot-two.svg" };
                FCLayoutDiv layoutDiv8 = new FCLayoutDiv();
                layoutDiv8.setAutoWrap(true);
                layoutDiv8.setDock(FCDockStyle.Fill);
                layoutDiv8.setLayoutStyle(FCLayoutStyle.LeftToRight);
                newTabPage.addView(layoutDiv8);
                for (int i = 0; i < 100; i++)
                {
                    FCSvg svg = new FCSvg();
                    layoutDiv8.addView(svg);
                    svg.setSize(new FCSize(60, 60));
                    svg.setMargin(new FCPadding(20, 20, 20, 20));
                    loadSvgFile(svg, Application.StartupPath + "\\config\\facecat_plc\\svg\\" + svgFiles[i % svgFiles.Length]);
                }
                getNative().update();
                getNative().invalidate();
            }
            else if (name == "LineChart")
            {
                LineChartDiv lineChartDiv = new LineChartDiv();
                lineChartDiv.setDock(FCDockStyle.Fill);
                newTabPage.addView(lineChartDiv);
                getNative().update();
                getNative().invalidate();
            }
            else if (name == "CycleProgress")
            {
                CycleProgressDiv cycleProgressDiv = new CycleProgressDiv();
                cycleProgressDiv.setDock(FCDockStyle.Fill);
                newTabPage.addView(cycleProgressDiv);
                getNative().update();
                getNative().invalidate();
            }
            else if (name == "Switch")
            {
                FCLayoutDiv layoutDiv11 = new FCLayoutDiv();
                layoutDiv11.setAutoWrap(true);
                layoutDiv11.setDock(FCDockStyle.Fill);
                layoutDiv11.setLayoutStyle(FCLayoutStyle.LeftToRight);
                newTabPage.addView(layoutDiv11);
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
                getNative().update();
                getNative().invalidate();
            }
            else if (name == "Pie")
            {
                FCLayoutDiv layoutDiv12 = new FCLayoutDiv();
                layoutDiv12.setAutoWrap(true);
                layoutDiv12.setDock(FCDockStyle.Fill);
                layoutDiv12.setLayoutStyle(FCLayoutStyle.LeftToRight);
                newTabPage.addView(layoutDiv12);
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
                    if (m_rd.Next(0, 2) == 0)
                    {
                        pie.m_innerRadius = 45;
                    }
                }
                getNative().update();
                getNative().invalidate();
            }
            else if (name == "HistogramChart")
            {
                HisChartDiv hisChartDiv = new HisChartDiv();
                hisChartDiv.setDock(FCDockStyle.Fill);
                newTabPage.addView(hisChartDiv);
                getNative().update();
                getNative().invalidate();
            }
            else if (name == "LEDNum")
            {
                FCLayoutDiv layoutDiv14 = new FCLayoutDiv();
                layoutDiv14.setAutoWrap(true);
                layoutDiv14.setDock(FCDockStyle.Fill);
                layoutDiv14.setLayoutStyle(FCLayoutStyle.LeftToRight);
                newTabPage.addView(layoutDiv14);
                for (int i = 0; i < 200; i++)
                {
                    PLCLEDNum led = new PLCLEDNum();
                    layoutDiv14.addView(led);
                    led.setMargin(new FCPadding(5, 5, 5, 5));
                    led.setTextColor(m_colors[i % m_colors.Length]);
                    led.m_showNumber = 'A';
                    led.m_borderColor = FCColor.None;
                    foreach (char ch in PLCLEDNum.m_numbers.Keys)
                    {
                        if (m_rd.Next(0, PLCLEDNum.m_numbers.Count) == 0)
                        {
                            led.m_showNumber = ch;
                        }
                    }
                    led.setSize(new FCSize(40, 60));
                }
                getNative().update();
                getNative().invalidate();
            }
        }
    }
}