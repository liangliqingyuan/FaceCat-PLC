using System;
using System.Collections.Generic;
using System.Windows.Forms;
using FaceCat;
using System.Diagnostics;

namespace FaceCat
{
    static class Program {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            PreViewForm preViewForm = new PreViewForm();
            preViewForm.loadFile("", false, new FCSize(1000, 800));
            preViewForm.Text = "FaceCat-PLC";
            MainForm mainForm = new MainForm();
            mainForm.loadXml("MainFrame");
            preViewForm.addForm2(mainForm);
            preViewForm.m_xml.findView("divWindow").setPadding(new FCPadding(2));
            preViewForm.m_xml.getNative().update();
            preViewForm.m_xml.getNative().invalidate();
            Application.Run(preViewForm);
        }
    }

    public class AppHost
    {
        /// <summary>
        /// 启动程序
        /// </summary>
        public static PreViewForm run(string cmd)
        {
            PreViewForm preViewForm = new PreViewForm();
            preViewForm.setIsMerge(true);
            preViewForm.loadFile("", false, new FCSize(1000, 800));
            preViewForm.Text = "FaceCat-PLC";
            preViewForm.setUrl("https://www.jjmfc.com/facecat_plc.html");
            preViewForm.setIconViewName("app_FaceCatPLC");
            MainForm mainForm = new MainForm();
            mainForm.loadXml("MainFrame");
            preViewForm.addForm(mainForm);
            preViewForm.m_xml.findView("divWindow").setPadding(new FCPadding(2));
            preViewForm.m_xml.getNative().update();
            preViewForm.m_xml.getNative().invalidate();
            preViewForm.Show();
            return preViewForm;
        }
    }
}