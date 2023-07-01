using HMSUserAPI.Interfaces;
using System.Diagnostics;

namespace HMSUserAPI.Models.Logger
{
    public class CustomLogger : ICustomLogger
    {
        private IConfiguration _configuration;
        private string? filePath;
        public CustomLogger(IConfiguration configuration)
        {
            _configuration = configuration;
            filePath = _configuration.GetSection("LogPathFile").Value;
        }

        public void WriteLog(string message)
        {
            if(filePath != null)
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(DateTime.Now.ToString("f")+" : "+message);
                }
            }
            Debug.WriteLine(DateTime.Now + " : " + message);
        }
    }
}
