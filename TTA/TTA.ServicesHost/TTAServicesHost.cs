using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.ServiceModel;
using TTA.Service;

namespace TTA.ServicesHost
{
    public partial class TTAServicesHost : ServiceBase
    {
        ServiceHost host = null;

        public TTAServicesHost()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            host = new ServiceHost(typeof(TTA.Service.TTAService));
            host.Open();
        }

        protected override void OnStop()
        {
            if (host != null)
            {
                host.Close();
            }
        }
    }
}
