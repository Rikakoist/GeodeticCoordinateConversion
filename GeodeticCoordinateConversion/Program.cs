using GeodeticCoordinateConversion.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeodeticCoordinateConversion
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //检查工作文件夹和文件名
            Settings AppSettings = new Settings();
            if ((String.IsNullOrWhiteSpace(AppSettings.WorkFolder))
                || (!System.IO.Directory.Exists(AppSettings.WorkFolder)))
            {
                AppSettings.WorkFolder = Application.StartupPath;
            }

            if (String.IsNullOrWhiteSpace(AppSettings.DataFileName)
                || (AppSettings.DataFileName.IndexOfAny(System.IO.Path.GetInvalidFileNameChars())) >= 0)
            {
                AppSettings.DataFileName = "GeoConversion.xml";
            }

            if (String.IsNullOrWhiteSpace(AppSettings.DBName)
               || (AppSettings.DBName.IndexOfAny(System.IO.Path.GetInvalidFileNameChars())) >= 0)
            {
                AppSettings.DBName = "GeoConvertDB.mdb";
            }

            AppSettings.Save();

            CultureInfo info = new CultureInfo(AppSettings.Language.Replace("_","-"));
            Thread.CurrentThread.CurrentCulture = info;
            Thread.CurrentThread.CurrentUICulture = info;

            DBIO.CheckDBExists();
            DBIO.OpenConnection();
            Application.Run(new MainForm());
            DBIO.CloseConnection();
        }
    }
}
