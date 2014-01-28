using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VeryOldSystemHistory
{
    class Permissions
    {
        public static string 查詢個人日誌 { get { return "System0010"; } }
        public static bool 查詢個人日誌權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[查詢個人日誌].Executable;
            }
        }

        public static string 查詢所有日誌 { get { return "System0020"; } }
        public static bool 查詢所有日誌權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[查詢所有日誌].Executable;
            }
        }



        public static string 學生歷程 { get { return "Button0320"; } }
        public static bool 學生歷程權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[學生歷程].Executable;
            }
        }

        public static string 班級歷程 { get { return "Button0440"; } }
        public static bool 班級歷程權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[班級歷程].Executable;
            }
        }

        public static string 教師歷程 { get { return "Button0510"; } }
        public static bool 教師歷程權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[教師歷程].Executable;
            }
        }

        public static string 課程歷程 { get { return "Button0620"; } }
        public static bool 課程歷程權限
        {
            get
            {
                return FISCA.Permission.UserAcl.Current[課程歷程].Executable;
            }
        }
    }
}
