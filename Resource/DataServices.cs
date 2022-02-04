using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Resource.Services;
using System.ServiceModel;
using System.ServiceProcess;

namespace Resource
{
    public class DataServices: ServiceBase
    {
        public ServiceHost serviceHost = null;
        public DataServices()
        {
            ServiceName = "DataServices";
        }
        public static void Main()
        {
            ServiceBase.Run(new DataServices());
        }
        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }
            serviceHost = new ServiceHost(typeof(CustommerResource));
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
