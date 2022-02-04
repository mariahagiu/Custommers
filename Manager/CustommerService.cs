using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceProcess;

namespace Manager
{
    public class CustommerService : ServiceBase
    {
        public ServiceHost serviceHost = null; 
        public CustommerService()
        {
            ServiceName = "CustommerService";
        }
        public static void Main()
        {
            ServiceBase.Run(new CustommerService());
        }
        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }
            serviceHost = new ServiceHost(typeof(Manager.Services.CustommerService));
            serviceHost.Open();
        }
        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close(); 
                serviceHost = null;
            }
        }
    }
}
