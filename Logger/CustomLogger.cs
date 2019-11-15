namespace Logger
{
    using log4net;
    using log4net.Config;
    using System;
    using System.IO;

    public class CustomLogger
    {
        public ILog GetLogger(Type declaringType)
        {
            LoadConfigurationFileAndWatch();
            return LogManager.GetLogger(declaringType);
        }

        private void LoadConfigurationFileAndWatch()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var configFileDirectory = Path.Combine(baseDirectory, "log4net.config");

            FileInfo configFileInfo = new FileInfo(configFileDirectory);
            XmlConfigurator.ConfigureAndWatch(configFileInfo);
        }
    }
}
