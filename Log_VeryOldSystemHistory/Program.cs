using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA;
using FISCA.Presentation;
using SmartSchool;
using SmartSchool.ApplicationLog;
using FISCA.Permission;

namespace VeryOldSystemHistory
{
    public class Program
    {
        [MainMethod()]
        static public void Main()
        {
            MotherForm.StartMenu["系統歷程"]["查詢個人日誌(舊)"].Enable = Permissions.查詢個人日誌權限;
            MotherForm.StartMenu["系統歷程"]["查詢個人日誌(舊)"].Click += delegate
            {
                LogBrowserForm browser = new LogBrowserForm(CurrentUser.Instance.UserName.ToUpper());
                browser.ShowDialog();
            };

            MotherForm.StartMenu["系統歷程"]["查詢所有日誌(舊)"].Enable = Permissions.查詢所有日誌權限;
            MotherForm.StartMenu["系統歷程"]["查詢所有日誌(舊)"].Click += delegate
            {
                LogBrowserForm browser = new LogBrowserForm();
                browser.ShowDialog();
            };

            //學生
            var btnHistory = K12.Presentation.NLDPanels.Student.RibbonBarItems["其它"]["學生歷程(舊)"];
            btnHistory.Image = Properties.Resources.folder_zoom_64;
            btnHistory.Enable = Permissions.學生歷程權限;
            btnHistory.Size = FISCA.Presentation.RibbonBarButton.MenuButtonSize.Medium;
            btnHistory.Click += new EventHandler(Student_Click);

            //班級
            btnHistory = K12.Presentation.NLDPanels.Class.RibbonBarItems["其它"]["班級歷程(舊)"];
            btnHistory.Image = Properties.Resources.folder_zoom_64;
            btnHistory.Enable = Permissions.班級歷程權限;
            btnHistory.Click += new EventHandler(Class_Click);
            btnHistory.Size = FISCA.Presentation.RibbonBarButton.MenuButtonSize.Medium;

            //教師
            btnHistory = K12.Presentation.NLDPanels.Teacher.RibbonBarItems["其它"]["教師歷程(舊)"];
            btnHistory.Image = Properties.Resources.folder_zoom_64;
            btnHistory.Enable = Permissions.教師歷程權限;
            btnHistory.Click += new EventHandler(Teacher_Click);
            btnHistory.Size = FISCA.Presentation.RibbonBarButton.MenuButtonSize.Medium;

            //課程
            btnHistory = K12.Presentation.NLDPanels.Course.RibbonBarItems["其它"]["課程歷程(舊)"];
            btnHistory.Image = Properties.Resources.folder_zoom_64;
            btnHistory.Enable = Permissions.課程歷程權限;
            btnHistory.Click += new EventHandler(Course_Click);
            btnHistory.Size = FISCA.Presentation.RibbonBarButton.MenuButtonSize.Medium;


            Catalog detail1;
            detail1 = RoleAclSource.Instance["系統"]["功能按鈕"];
            detail1.Add(new RibbonFeature(Permissions.查詢所有日誌, "所有日誌(舊)"));

            detail1 = RoleAclSource.Instance["系統"]["功能按鈕"];
            detail1.Add(new RibbonFeature(Permissions.查詢個人日誌, "個人日誌(舊)"));

            detail1 = RoleAclSource.Instance["學生"]["功能按鈕"];
            detail1.Add(new RibbonFeature(Permissions.學生歷程, "學生歷程(舊)"));

            detail1 = RoleAclSource.Instance["班級"]["功能按鈕"];
            detail1.Add(new RibbonFeature(Permissions.班級歷程, "班級歷程(舊)"));

            detail1 = RoleAclSource.Instance["教師"]["功能按鈕"];
            detail1.Add(new RibbonFeature(Permissions.教師歷程, "教師歷程(舊)"));

            detail1 = RoleAclSource.Instance["課程"]["功能按鈕"];
            detail1.Add(new RibbonFeature(Permissions.課程歷程, "課程歷程(舊)"));

        }
        static void Course_Click(object sender, EventArgs e)
        {
            if (K12.Presentation.NLDPanels.Course.SelectedSource.Count > 0)
            {
                List<string> idlist = new List<string>();
                foreach (string each in K12.Presentation.NLDPanels.Course.SelectedSource)
                    idlist.Add(each);

                LogBrowserForm logbro = new LogBrowserForm(EntityType.Course, idlist.ToArray());
                logbro.Show();
            }
        }

        static void Teacher_Click(object sender, EventArgs e)
        {
            if (K12.Presentation.NLDPanels.Teacher.SelectedSource.Count > 0)
            {
                List<string> idlist = new List<string>();
                foreach (string each in K12.Presentation.NLDPanels.Teacher.SelectedSource)
                    idlist.Add(each);

                LogBrowserForm logbro = new LogBrowserForm(EntityType.Teacher, idlist.ToArray());
                logbro.Show();
            }
        }

        static void Class_Click(object sender, EventArgs e)
        {
            if (K12.Presentation.NLDPanels.Class.SelectedSource.Count > 0)
            {
                List<string> idlist = new List<string>();
                foreach (string each in K12.Presentation.NLDPanels.Class.SelectedSource)
                    idlist.Add(each);

                LogBrowserForm logbro = new LogBrowserForm(EntityType.Class, idlist.ToArray());
                logbro.Show();
            }
        }

        static void Student_Click(object sender, EventArgs e)
        {
            if (K12.Presentation.NLDPanels.Student.SelectedSource.Count > 0)
            {
                List<string> idlist = new List<string>();
                foreach (string each in K12.Presentation.NLDPanels.Student.SelectedSource)
                    idlist.Add(each);

                LogBrowserForm logbro = new LogBrowserForm(EntityType.Student, idlist.ToArray());
                logbro.Show();
            }
        }
    }
}
