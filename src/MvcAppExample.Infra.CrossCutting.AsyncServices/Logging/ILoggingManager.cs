namespace MvcAppExample.Infra.CrossCutting.AsyncServices.Logging
{
    public interface ILoggingManager
    {
        void DebugLog(string message);
        void InfoLog(string message);
        void WarnLog(string message);
        void ErrorLog(string message);
        void FatalLog(string message);


        //public class ManagerLog : IManagerLog
        //{
        //    private ILog _logger;
        //    public ManagerLog()
        //    {
        //        _logger = LogManager.GetLogger("ExampleLog");
        //        log4net.Config.XmlConfigurator.Configure();
        //    }

        //    public void DebugLog(string message) => Task.Run(() => _logger.Debug(message));
        //    public void InfoLog(string message) => Task.Run(() => _logger.Info(message));
        //    public void WarnLog(string message) => Task.Run(() => _logger.Warn(message));
        //    public void ErrorLog(string message) => Task.Run(() => _logger.Error(message));
        //    public void FatalLog(string message) => Task.Run(() => _logger.Fatal(message));
        //}
    }
}
