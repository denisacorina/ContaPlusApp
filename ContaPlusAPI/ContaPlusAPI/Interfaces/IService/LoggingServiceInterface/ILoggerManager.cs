namespace ContaPlusAPI.Interfaces.IService.Logging
{
    public interface ILoggerManager
    {
        void LogDebug(string message);
        void LogError(string message);
        void LogWarning(string message);
        void LogInfo(string message);
    }
}
