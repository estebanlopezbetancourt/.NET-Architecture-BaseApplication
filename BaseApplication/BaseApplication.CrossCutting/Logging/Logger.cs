using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseApplication.Crosscutting.Logging
{
    public sealed class Log
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        //for more Singleton implementations go to: http://msdn.microsoft.com/en-us/library/ff650316.aspx
        private static readonly Log instance = new Log();
        private Log() { }
        public static Log Instance
        {
            get
            {
                return instance;
            }
        }

        public void Write(string msg, LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Trace:
                    logger.Trace(msg);
                    break;
                case LogLevel.Debug:
                    logger.Debug(msg);
                    break;
                case LogLevel.Info:
                    logger.Info(msg);
                    break;
                case LogLevel.Warning:
                    logger.Warn(msg);
                    break;
                case LogLevel.Error:
                    logger.Error(msg);
                    break;
                case LogLevel.Fatal:
                    logger.Fatal(msg);
                    break;
                default:
                    break;
            }

        }

        public void Exception(string msg, Exception ex)
        {
            logger.Error(msg, ex);
        }
    }
}
