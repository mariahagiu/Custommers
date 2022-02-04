using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceProcess;

namespace Engine
{
    class CustommerEngineService : ServiceBase
    {
        public ServiceHost serviceHost = null; 
        public CustommerEngineService()
        {
            ServiceName = "CustommerEngineService";
        }
        public static void Main()
        {
            ServiceBase.Run(new CustommerEngineService());
        }
            protected override void OnStart(string[] args)
        {
            if (serviceHost != null) 
            { 
                serviceHost.Close(); 
            }
            serviceHost = new ServiceHost(typeof(Engine.Services.CustommerValidationService));
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
