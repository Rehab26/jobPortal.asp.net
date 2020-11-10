using JobPortal.Logger;
using System;
using System.Web.Hosting;

namespace JobPortal.App.Models
{
    public class FileLogger
    {
        static string errorFilepath = HostingEnvironment.MapPath(@"~\Logs\ErrorLog.txt");
        static string infoFilepath = HostingEnvironment.MapPath(@"~\Logs\InfoLog.txt");
        public static void LogInfo(string msg)
        {
            Logger.Logger.LogInfo(infoFilepath, msg);
        }
        public static void LogError(Exception ex)
        {
            string msg = $"Error: msg={ex.Message},  InnerExcepton={ex.InnerException?.ToString()},  Stacktrace={ex.StackTrace}";
            Logger.Logger.LogError(errorFilepath, msg);
        }


        public static void NLog(string msg)
        {
            //NLog.Logger logger = LogManager.GetCurrentClassLogger();
            //logger.Info(msg);
        }


    }
}