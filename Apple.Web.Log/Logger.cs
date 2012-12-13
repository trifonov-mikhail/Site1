using System;
using Erc.Apple.Data;

namespace Apple.Web
{
    public static class Logger
    {
        private static readonly Log log = new Log();

        public static void LogInfo(string mess, string source)
        {
            Log(mess, source, LogMessageType.Info);
        }
        public static void LogWarning(string mess, string source)
        {
            Log(mess, source, LogMessageType.Warning);
        }
        public static void LogError(string mess, string source)
        {
            Log(mess, source, LogMessageType.Error);
        }

        public static void LogException(Exception exc, string source)
        {
            string mess = exc.Message;
            if (exc.InnerException != null)
            {
                mess += string.Format("\n{0}", exc.InnerException.Message);
            }
            mess += string.Format("\n{0}", exc.StackTrace);
            Log(mess, source, LogMessageType.Error);
        }

        public static void Log(string mess, string source, LogMessageType type)
        {
            LogMessage message = new LogMessage();

            message.MessageType = (int)type;
            message.Source = source;
            message.Message = mess;

            try
            {
                log.Add(message);
            }
            catch
            {
            }

        }
    }
}