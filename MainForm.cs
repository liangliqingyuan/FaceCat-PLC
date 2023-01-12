using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using FaceCat;

namespace FaceCat
{
    public partial class MainForm : FCForm {
        public MainForm() {
            InitializeComponent();
            //146,92,222,223
        }

        /// <summary>
        /// XML
        /// </summary>
        private UIXmlEx m_xmlEx;

        /// <summary>
        /// 获取客户端尺寸
        /// </summary>
        /// <returns>客户端尺寸</returns>
        public new FCSize getClientSize() {
            return new FCSize(ClientSize.Width, ClientSize.Height);
        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="name">名称</param>
        public void loadXml(String name) {
            m_xmlEx = new MainFrame();
            m_xml = m_xmlEx;
            m_xml.createNative();
            m_native = m_xml.getNative();
            m_native.setPaint(new GdiPlusPaintEx());
            m_host = new WinHostEx();
            m_host.setNative(m_native);
            m_native.setHost(m_host);
            m_host.setHWnd(Handle);
            //m_native.AllowScaleSize = true;
            m_native.setAllowScaleSize(true);
            m_native.setSize(new FCSize(ClientSize.Width, ClientSize.Height));
            m_xmlEx.resetScaleSize(getClientSize());
            m_xml.loadFile(Application.StartupPath + "\\config\\facecat_plc\\" + name + ".html", null);
            m_host.setToolTip(new FCToolTip());
            m_host.getToolTip().setFont(new FCFont("Default", 20, true, false, false));
            (m_host.getToolTip() as FCToolTip).setInitialDelay(250);
            m_native.update();
            Invalidate();
        }

        /// <summary>
        /// 尺寸改变方法
        /// </summary>
        /// <param name="e">参数</param>
        protected override void OnSizeChanged(EventArgs e) {
            base.OnSizeChanged(e);
            if (m_host != null) {
                m_xmlEx.resetScaleSize(getClientSize());
                Invalidate();
            }
        }

        /// <summary>
        /// 鼠标滚动方法
        /// </summary>
        /// <param name="e">参数</param>
        protected override void OnMouseWheel(MouseEventArgs e) {
            base.OnMouseWheel(e);
            if (m_host != null) {
                if (m_host.isKeyPress(0x11)) {
                    double scaleFactor = m_xmlEx.getScaleFactor();
                    if (e.Delta > 0) {
                        if (scaleFactor > 0.2) {
                            scaleFactor -= 0.1;
                        }
                    } else if (e.Delta < 0) {
                        if (scaleFactor < 10) {
                            scaleFactor += 0.1;
                        }
                    }
                    m_xmlEx.setScaleFactor(scaleFactor);
                    m_xmlEx.resetScaleSize(getClientSize());
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// 消息监听
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m) {
            try {
                if (m_host != null) {
                    if (m_host.onMessage(ref m) > 0) {
                        return;
                    }
                }
            } catch (Exception ex) {
            }
            base.WndProc(ref m);
        }
    }
}