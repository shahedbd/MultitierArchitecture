using log4net;
using System.Reflection;

namespace MySchool.Shared.Log
{
    public class Logger : ILogger
    {
        private ILog log;
        public Logger()
        {
            log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public void Debug(string message)
        {
            log.Debug(message);
        }
        public void Error(string msg)
        {
            log.Error(msg);
        }
        public void Info(string msg)
        {
            log.Info(msg);
        }
        public void Fatal(string msg)
        {
            log.Fatal(msg);
        }
        public void Warn(string msg)
        {
            log.Warn(msg);
        }
    }
}
